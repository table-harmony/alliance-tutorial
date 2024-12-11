using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagementTutorial.Model.Entities;

namespace UserManagementTutorial.Utils {
    public static class SessionManager {
        private const string USER_KEY = "CurrentUser";

        public static bool IsLoggedIn => GetCurrentUser() != null;

        public static User CurrentUser {
            get => HttpContext.Current.Session[USER_KEY] as User;
        }

        public static void SetCurrentUser(User user) {
            if (HttpContext.Current.Session != null) {
                HttpContext.Current.Session[USER_KEY] = user;
            }
        }

        public static User GetCurrentUser() {
            if (HttpContext.Current.Session != null) {
                return HttpContext.Current.Session[USER_KEY] as User;
            }
            return null;
        }

        public static void ClearCurrentUser() {
            HttpContext.Current.Session?.Remove(USER_KEY);
        }
    }
}