using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserManagementTutorial.Dal;
using UserManagementTutorial.Model.Entities;

namespace UserManagementTutorial.Model {
    public class UserModel {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        private static User MapToUser(DataRow row) {
            return new User() {
                Id = int.Parse(row["Id"].ToString()),
                UserName = row["UserName"].ToString(),
                PasswordHash = row["PasswordHash"].ToString(),
                Role = (UserRole)Enum.Parse(typeof(UserRole), row["Role"].ToString())
            };
        }

        public List<User> GetUsers() {
            DatabaseCommand command = new DatabaseCommand() {
                CommandText = "SELECT * FROM Users",
            };

            DataSet result = _dbContext.ExecuteQuery(command);

            return result.Tables[0].Rows
                .Cast<DataRow>()
                .Select(MapToUser).ToList();
        }

        public User GetUserById(int id) {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Id", id)
            };
 
            DatabaseCommand command = new DatabaseCommand() {
                CommandText = "SELECT * FROM Users WHERE Id = @Id",
                Parameters = parameters
            };

            DataSet result = _dbContext.ExecuteQuery(command);

            return result.Tables[0].Rows
                .Cast<DataRow>()
                .Select(MapToUser)
                .FirstOrDefault();
        }

        public User GetUserByUserName(string username) {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@UserName", username)
            };

            DatabaseCommand command = new DatabaseCommand() {
                CommandText = "GetUserByUserName",
                Parameters = parameters,
                CommandType = CommandType.StoredProcedure
            };

            DataSet result = _dbContext.ExecuteQuery(command);

            return result.Tables[0].Rows
                .Cast<DataRow>()
                .Select(MapToUser)
                .FirstOrDefault();
        }

        public void CreateUser(User user) {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@PasswordHash", user.PasswordHash),
                new SqlParameter("@Role", user.Role)
            };

            DatabaseCommand command = new DatabaseCommand() {
                CommandText = @"INSERT INTO Users 
                                (UserName, PasswordHash, Role)
                                VALUES (@UserName, @PasswordHash, @Role)",
                Parameters = parameters
            };

            _dbContext.ExecuteNonQuery(command);
        }

        public void UpdateUser(User user) {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@PasswordHash", user.PasswordHash),
                new SqlParameter("@Role", user.Role)
            };

            DatabaseCommand command = new DatabaseCommand() {
                CommandText = @"UPDATE Users SET 
                                UserName = @UserName, 
                                PasswordHash = @PasswordHash,
                                Role = @Role
                                WHERE Id = @Id",
                Parameters = parameters
            };

            _dbContext.ExecuteNonQuery(command);
        }

        public void DeleteUser(int id) {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Id", id)
            };
            
            DatabaseCommand command = new DatabaseCommand() {
                CommandText = "DELETE FROM Users WHERE Id = @Id",
                Parameters = parameters
            };

            _dbContext.ExecuteNonQuery(command);
        }
    }
}