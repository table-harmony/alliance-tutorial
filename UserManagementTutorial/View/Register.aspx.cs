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
    public partial class Register : System.Web.UI.Page {
        protected readonly UserController _userController = new UserController();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void RegisterButton_Click(object sender, EventArgs e) {
            try {
                string username = UserNameInput.Text;
                string password = PasswordInput.Text;

                User user = new User() {
                    UserName = username,
                    PasswordHash = password,
                    Role = UserRole.Member
                };

                _userController.CreateUser(user);

                Response.Redirect("~/View/Login.aspx");
            } catch (Exception ex) {
                ErrorLabel.Text = ex.Message;
            }
        }
    }
}