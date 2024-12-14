using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleUsage.Utils {
    public class User {
        public string Name { get; set; }

        public string Password { get; set; }
        public string Salt { get; set; }
    }

    public static class Database {
        public static List<User> Users { get; set; } = new List<User>();  
    }
}