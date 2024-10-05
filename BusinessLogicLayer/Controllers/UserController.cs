using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using Utils;

namespace BusinessLogicLayer.Controllers {
    public interface IUserController {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User? GetUserByEmail(string email);
        User GetUserByCredentials(string email, string password);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }

    public class UserController : IUserController {
        public List<User> GetAllUsers() { return UserModel.GetAllUsers(); }

        public User? GetUserById(int id) { return UserModel.GetUserById(id); }
        public User? GetUserByEmail(string email) { return UserModel.GetUserByEmail(email); }

        public User GetUserByCredentials(string email, string password) {
            User? user = GetUserByEmail(email);

            if (user == null)
                throw new NotFoundException("User does not exist");

            bool passwordsMatch = Sha256Encryption.Compare(password, user.Password);

            if (!passwordsMatch)
                throw new PublicException("Passwords do not match");

            return user;
        }

        public void CreateUser(User user) {
            User? existingUser = GetUserByEmail(user.Email);

            if (existingUser != null)
                throw new PublicException("User already exists");

            user.Password = Sha256Encryption.Encrypt(user.Password);

            UserModel.CreateUser(user);
        }

        public void UpdateUser(User user) {

            if (!string.IsNullOrEmpty(user.Password))
                user.Password = Sha256Encryption.Encrypt(user.Password);

            if (!string.IsNullOrEmpty(user.Email)) {
                User? existingUser = GetUserByEmail(user.Email);

                if (existingUser != null && existingUser.Id != user.Id)
                    throw new PublicException("Email taken");
            }

            UserModel.UpdateUser(user);
        }

        public void DeleteUser(int id) { UserModel.DeleteUser(id); }
    }
}