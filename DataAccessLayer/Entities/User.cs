namespace DataAccessLayer.Entities {
    public enum UserRoleEnum {
        Admin,
        Member
    }

    public class User {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRoleEnum Role { get; set; }
    }
}
