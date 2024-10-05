using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Models {

    public interface IUserModel {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User? GetUserByEmail(string email);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }

    public class UserModel : IUserModel {

        /// <summary>
        /// Converts a DataRow into a User object
        /// </summary>
        /// <param name="row">Row to be converted</param>
        /// <returns>New User object with Row data</returns>
        private User? MapToUser(DataRow row) {
            if (row == null)
                return null;

            if (!int.TryParse(row["Id"]?.ToString(), out int id))
                return null;

            return new User {
                Id = id,
                Email = row["Email"].ToString() ?? "",
                Password = row["Password"].ToString() ?? "",
                Role = Enum.TryParse<UserRoleEnum>(row["Role"]?.ToString(), out var role) ? role : UserRoleEnum.Member
            };
        }

        public List<User> GetAllUsers() {
            string query = "SELECT * FROM Users";
            DataSet data = DatabaseContext.ExecuteQuery(query);

            return data.Tables[0].Rows.Cast<DataRow>()
                .Select(row => MapToUser(row)!)
                .ToList();
        }

        public User? GetUserById(int id) {
            string query = "SELECT * FROM Users WHERE Id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };

            DataSet data = DatabaseContext.ExecuteQuery(query, parameters);

            return data.Tables[0].Rows.Cast<DataRow>()
                .Select(MapToUser)
                .FirstOrDefault();
        }

        public User? GetUserByEmail(string email) {
            string query = "SELECT * FROM Users WHERE Email = @Email";
            var parameters = new[] { new SqlParameter("@Email", email) };

            DataSet data = DatabaseContext.ExecuteQuery(query, parameters);

            return data.Tables[0].Rows.Cast<DataRow>()
                .Select(MapToUser)
                .FirstOrDefault();
        }

        public void CreateUser(User user) {
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

        public void UpdateUser(User user) {
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

        public void DeleteUser(int id) {
            string query = "DELETE FROM Users WHERE Id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };

            DatabaseContext.ExecuteQuery(query, parameters);
        }
    }
}