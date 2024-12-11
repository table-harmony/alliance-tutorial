using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementTutorial.Controller;
using UserManagementTutorial.Utils;

namespace UserManagementTutorial.View {
    public partial class Login : System.Web.UI.Page {
        protected readonly UserController _userController = new UserController();

        protected void Page_Load(object sender, EventArgs e) {
            if (SessionManager.IsLoggedIn)
                Response.Redirect("~/View/Home.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            try {
                string username = UserNameInput.Text;
                string password = PasswordInput.Text;

                var user = _userController.GetUserByCredentials(username, password);

                SessionManager.SetCurrentUser(user);
                Response.Redirect("~/View/Home.aspx");
            } catch (Exception ex) {
                ErrorLabel.Text = ex.Message;
            }
        }
    }
}