using VotingApp.Repositories;
using VotingApp.Services;
using VotingApp.Utils;

UserRepository userRepository = new();
CategoryRepository categoryRepository = new();
VoteRepository voteRepository = new();

UserService userService = new(userRepository);
CategoryService categoryService = new(categoryRepository);
VotingService votingService = new(voteRepository, categoryRepository);

Console.WriteLine("Voting Uygulaması'na hoşgeldiniz!\n");

while (true)
{
    Console.Write("Kullanıcı adınızı giriniz: ");
    string username = Console.ReadLine()?.Trim();

    if (!ValidationUtils.IsValidUsername(username))
    {
        Console.WriteLine("Kullanıcı adınız en az 3 karakter uzunluğunda olmalıdır.\n");
        continue;
    }

    if (!userService.AuthenticateUser(username))
    {
        Console.Write("Kullanıcı kaydı bulunamadı. Oluşturmak ister misiniz? (evet/hayır): ");
        string response = Console.ReadLine()?.Trim().ToLower();
        if (response != "evet") continue;

        Console.Write("E-posta adresinizi giriniz: ");
        string email = Console.ReadLine()?.Trim();
        if (!ValidationUtils.IsValidEmail(email))
        {
            Console.WriteLine("Geçerli bir e-posta adresi girmediniz.\n");
            continue;
        }

        Console.Write("Şifrenizi giriniz: ");
        string password = Console.ReadLine();
        if (!ValidationUtils.IsValidPassword(password))
        {
            Console.WriteLine("Şifreniz en az 6 karakter uzunluğunda olmalıdır.\n");
            continue;
        }

        userService.RegisterUser(username, password, email);
        Console.WriteLine("Kaydınız başarıyla oluşturuldu!\n");
    }

    Console.Write("\nOy kullanmak istediğiniz kategorinin numarasını giriniz ya da 'yeni' yazarak bir kategori önerin : ");
    string input = Console.ReadLine()?.Trim().ToLower();

    if (input == "yeni")
    {
        Console.Write("Eklemeyi önerdiğiniz kategorinin ismini yazınız: ");
        string newCategoryName = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(newCategoryName))
        {
            Console.WriteLine("Hata! Geçersiz kategori ismi.");
            continue;
        }

        categoryService.RequestNewCategory(newCategoryName);
        Console.WriteLine($"'{newCategoryName}' adlı kategori eklendi!\n");
        continue;
    }

    if (!int.TryParse(input, out int categoryId))
    {
        Console.WriteLine("Mevcut bir kategori seçmediniz.\n");
        continue;
    }

    if (!votingService.Vote(username, categoryId))
    {
        Console.WriteLine("Mevcut olmayan ya da daha önce oy kullandığınız bir kategori seçtiniz.\n");
        continue;
    }

    Console.WriteLine("Oyunuz kaydedilmiştir!\n");

    Console.Write("Başka bir kategori için oy kullanmak ister misiniz? (evet/hayır): ");
    string voteAgain = Console.ReadLine()?.Trim().ToLower();
    if (voteAgain != "evet") break;
}

Console.WriteLine("\nSonuçlar:");
DisplayUtils.ShowVotingResults(votingService.GetResults());

Console.WriteLine("Uygulamamızı kullandığınız için teşekkür ederiz!");