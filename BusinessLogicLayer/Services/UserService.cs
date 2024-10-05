using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Utils;

namespace BusinessLogicLayer.Services {
    public interface IUserService {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User? GetUserByEmail(string email);
        User GetUserByCredentials(string email, string password);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }

    public class UserService(IUserRepository repository, IEncryption encryption) : IUserService {
        private readonly IUserRepository _repository = repository;
        private readonly IEncryption _encryption = encryption;

        public List<User> GetAllUsers() { return _repository.GetAllUsers(); }

        public User? GetUserById(int id) { return _repository.GetUserById(id); }
        public User? GetUserByEmail(string email) { return _repository.GetUserByEmail(email); }

        public User GetUserByCredentials(string email, string password) {
            User? user = GetUserByEmail(email);

            if (user == null)
                throw new NotFoundException("User does not exist");

            bool passwordsMatch = _encryption.Compare(password, user.Password);

            if (!passwordsMatch)
                throw new PublicException("Passwords do not match");

            return user;
        }

        public void CreateUser(User user) {
            User? existingUser = GetUserByEmail(user.Email);

            if (existingUser != null)
                throw new PublicException("User already exists");

            user.Password = _encryption.Encrypt(user.Password);

            _repository.CreateUser(user);
        }

        public void UpdateUser(User user) {

            if (!string.IsNullOrEmpty(user.Password))
                user.Password = _encryption.Encrypt(user.Password);

            if (!string.IsNullOrEmpty(user.Email)) {
                User? existingUser = GetUserByEmail(user.Email);

                if (existingUser != null && existingUser.Id != user.Id)
                    throw new PublicException("Email taken");
            }

            _repository.UpdateUser(user);
        }

        public void DeleteUser(int id) { _repository.DeleteUser(id); }
    }
}