using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementTutorial.Utils;

namespace UserManagementTutorial.View {
    public partial class Logout : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!SessionManager.IsLoggedIn) {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e) {
            SessionManager.ClearCurrentUser();
            Response.Redirect("~/View/Home.aspx");
        }
    }
}