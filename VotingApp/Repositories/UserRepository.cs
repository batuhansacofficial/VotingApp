using VotingApp.Models;

namespace VotingApp.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User? GetUser(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public bool UserExists(string username)
        {
            return _users.Any(u => u.Username == username);
        }
    }
}
