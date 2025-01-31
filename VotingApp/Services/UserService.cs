using VotingApp.Models;
using VotingApp.Repositories;

namespace VotingApp.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AuthenticateUser(string username)
        {
            return _userRepository.UserExists(username);
        }

        public void RegisterUser(string username, string password, string email)
        {
            if (_userRepository.UserExists(username))
            {
                throw new System.Exception("User already exists.");
            }

            _userRepository.AddUser(new User(username, password, email));
        }

        public User? GetUser(string username)
        {
            return _userRepository.GetUser(username);
        }
    }
}
