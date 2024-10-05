using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System.Data;

namespace DataAccessLayer.Models {

    public class UserModel {

        public static List<User> GetAllUsers() {
            string query = "SELECT * FROM Users";
            DataSet data = DatabaseContext.ExecuteQuery(query);

            List<User> users = [];

            foreach (DataRow row in data.Tables[0].Rows) {
                users.Add(new User() {
                    Id = Convert.ToInt32(row["Id"]),
                    Email = row["Email"].ToString(),
                    Password = row["Password"].ToString(),
                });
            }

            return users;
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

        public static User GetUserById(int id) {
            string query = "SELECT * FROM Users WHERE Id = @Id";
            var parameters = new[] { new SqlParameter("@Id", id) };

            DataSet data = DatabaseContext.ExecuteQuery(query, parameters);

            if (data.Tables.Count == 0)
                return null;

            if (data.Tables[0].Rows.Count == 0)
                return null;

            DataRow row = data.Tables[0].Rows[0];

            User user = new User() {
                Id = Convert.ToInt32(row["Id"]),
                Email = row["Email"].ToString(),
                Password = row["Password"].ToString(),
                Role = (UserRoleEnum)Convert.ToUInt32(row["Role"])
            };

            return user;
        }

        public static User GetUserByEmail(string email) {
            string query = "SELECT * FROM Users WHERE Email = @Email";
            var parameters = new[] { new SqlParameter("@Email", email) };

            DataSet data = DatabaseContext.ExecuteQuery(query, parameters);

            if (data.Tables.Count == 0)
                return null;

            if (data.Tables[0].Rows.Count == 0)
                return null;

            DataRow row = data.Tables[0].Rows[0];

            User user = new User() {
                Id = Convert.ToInt32(row["Id"]),
                Email = row["Email"].ToString(),
                Password = row["Password"].ToString(),
                Role = (UserRoleEnum)Convert.ToInt32(row["Role"])
            };

            return user;
        }

        public static void UpdateUser(User user) {
            User existingUser = GetUserById(user.Id);

            if (existingUser == null)
                throw new NotFoundException();

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