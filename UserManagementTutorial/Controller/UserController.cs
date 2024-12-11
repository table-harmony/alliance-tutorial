using System;
using System.Collections.Generic;
using UserManagementTutorial.Model;
using UserManagementTutorial.Model.Entities;
using UserManagementTutorial.Utils;

namespace UserManagementTutorial.Controller {
    public class UserController {
        private readonly UserModel _userModel = new UserModel();

        public List<User> GetUsers() {
            return _userModel.GetUsers();
        }

        public User GetUserById(int id) {
            return _userModel.GetUserById(id);
        }

        public User GetUserByUserName(string username) {
            return _userModel.GetUserByUserName(username);
        }

        public User GetUserByCredentials(string username, string plainPassword) {
            User user = GetUserByUserName(username);

            if (user == null) {
                throw new Exception("User not found");
            }

            bool isPasswordsMatch = SHA256Encryption.Compare(plainPassword, user.PasswordHash);

            if (!isPasswordsMatch) {
                throw new Exception("Incorrect credentials");
            }

            return user;
        }

        public void CreateUser(User user) {
            User existingUser = GetUserByUserName(user.UserName);

            if (existingUser != null) {
                throw new Exception("User already exists with UserName");
            }

            user.PasswordHash = SHA256Encryption.Encrypt(user.PasswordHash);

            _userModel.CreateUser(user);
        }

        public void UpdateUser(User user) {
            User existingUser = GetUserByUserName(user.UserName);

            if (existingUser != null && existingUser.Id != user.Id) {
                throw new Exception("User already exists with UserName");
            }

            if (!string.IsNullOrEmpty(user.PasswordHash))
                user.PasswordHash = SHA256Encryption.Encrypt(user.PasswordHash);

            _userModel.UpdateUser(user);
        }

        public void DeleteUser(int id) {
            User existingUser = GetUserById(id);

            if (existingUser == null)
                throw new Exception("User not found");

            _userModel.DeleteUser(id);
        }
    }
}