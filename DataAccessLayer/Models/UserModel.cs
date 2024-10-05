using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Models {

    public class UserModel {

        /// <summary>
        /// Converts a DataRow into a User object
        /// </summary>
        /// <param name="row">Row to be converted</param>
        /// <returns>New User object with Row data</returns>
        private static User? MapToUser(DataRow row) {
            if (row == null)
                return null;

            if (!int.TryParse(row["Id"]?.ToString(), out int id))
                return null;

            return new User {
                Id = id,
                Email = row["Email"] as string ?? string.Empty,
                Password = row["Password"] as string ?? string.Empty,
                Role = Enum.TryParse<UserRoleEnum>(row["Role"]?.ToString(), out var role) ? role : UserRoleEnum.Member
            };
        }

        public static List<User> GetAllUsers() {
            string query = "SELECT * FROM Users";
            DataSet data = DatabaseContext.ExecuteQuery(query);

            return data.Tables[0].Rows.Cast<DataRow>()
                .Select(row => MapToUser(row)!)
                .ToList();
        }

        public static void CreateUser(User user) {
            string query = @"INSERT INTO Users 
                                (Email, Password, Role) 
                                OUTPUT INSERTED.*                                
                                VALUES (@Email, @Password, @Role)";

            var parameters = new[] {
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", user.Role),
            };

            DataSet data = DatabaseContext.ExecuteQuery(query, parameters);
            
            user.Id = Convert.ToInt32(data.Tables[0].Rows[0]["Id"]);
        }

        public static User? GetUserById(int id) {
            string query = "SELECT * FROM Users WHERE Id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };

            DataSet data = DatabaseContext.ExecuteQuery(query, parameters);

            return data.Tables[0].Rows.Cast<DataRow>()
                .Select(MapToUser)
                .FirstOrDefault();
        }

        public static User? GetUserByEmail(string email) {
            string query = "SELECT * FROM Users WHERE Email = @Email";
            var parameters = new[] { new SqlParameter("@Email", email) };

            DataSet data = DatabaseContext.ExecuteQuery(query, parameters);

            return data.Tables[0].Rows.Cast<DataRow>()
                .Select(MapToUser)
                .FirstOrDefault();
        }

        public static void UpdateUser(User user) {
            User? existingUser = GetUserById(user.Id);

            if (existingUser == null)
                return;

            string query = @"UPDATE Users 
                SET Email = @Email, Password = @Password, Role = @Role
                WHERE Id = @Id";

            var parameters = new[] {
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", (int)user.Role),
            };

            DatabaseContext.ExecuteQuery(query, parameters);
        }

        public static void DeleteUser(int id) {
            string query = "DELETE FROM Users WHERE Id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };

            DatabaseContext.ExecuteQuery(query, parameters);
        }
    }
}