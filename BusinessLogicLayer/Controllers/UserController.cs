using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using Utils;

namespace BusinsessLogicLayer.Controllers {
    public class UserController {

        public static List<User> GetAllUsers() { return UserModel.GetAllUsers(); }

        public static User? GetUserById(int id) {  return UserModel.GetUserById(id); }
        public static User? GetUserByEmail(string email) { return UserModel.GetUserByEmail(email); }

        public static User GetUserByCredentials(string email, string password) {
            User? user = GetUserByEmail(email);

            if (user == null)
                throw new NotFoundException("User does not exist");

            bool passwordsMatch = Sha256Encryption.Compare(password, user.Password);

            if (!passwordsMatch)
                throw new PublicException("Passwords do not match");

            return user;
        }

        public static void CreateUser(User user) {
            User? existingUser = GetUserByEmail(user.Email);

            if (existingUser != null)
                throw new PublicException("User already exists");

            user.Password = Sha256Encryption.Encrypt(user.Password);

            UserModel.CreateUser(user); 
        }
    
        public static void UpdateUser(User user) {

            if (!string.IsNullOrEmpty(user.Password))
                user.Password = Sha256Encryption.Encrypt(user.Password);

            if (!string.IsNullOrEmpty(user.Email)) {
                User? existingUser = GetUserByEmail(user.Email);

                if (existingUser != null && existingUser.Id != user.Id)
                    throw new PublicException("Email taken");
            }

            UserModel.UpdateUser(user);
        }

        public static void DeleteUser(int id) { UserModel.DeleteUser(id); }

    }
}