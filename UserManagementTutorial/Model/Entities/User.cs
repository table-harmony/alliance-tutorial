using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagementTutorial.Model.Entities {
    public enum UserRole {
        Member,
        Admin,
    }

    public class User {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}