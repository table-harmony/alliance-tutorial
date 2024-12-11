using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementTutorial.Controller;
using UserManagementTutorial.Model.Entities;
using UserManagementTutorial.Utils;

namespace UserManagementTutorial.View {
    public partial class Profile : System.Web.UI.Page {
        private readonly UserController _userController = new UserController();

        protected void Page_Load(object sender, EventArgs e) {
            if (!SessionManager.IsLoggedIn) {
                Response.Redirect("~/View/Login.aspx");
                return;
            }

            if (!IsPostBack) {
                UserNameInput.Text = SessionManager.CurrentUser.UserName;
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e) {
            try {
                var user = new User {
                    Id = SessionManager.CurrentUser.Id,
                    UserName = UserNameInput.Text,
                    PasswordHash = SessionManager.CurrentUser.PasswordHash,
                    Role = SessionManager.CurrentUser.Role
                };

                if (!string.IsNullOrEmpty(PasswordInput.Text)) {
                    user.PasswordHash = PasswordInput.Text;
                }

                _userController.UpdateUser(user);
                SessionManager.SetCurrentUser(_userController.GetUserById(user.Id));

                Response.Redirect("~/View/Home.aspx");
            } catch (Exception ex) {
                ErrorLabel.Text = ex.Message;
            }
        }
    }
}