using System;
using UserManagementTutorial.Controller;
using UserManagementTutorial.Utils;

namespace UserManagementTutorial.View {
    public partial class Delete : System.Web.UI.Page {
        private readonly UserController _userController = new UserController();

        protected void Page_Load(object sender, EventArgs e) {
            if (!SessionManager.IsLoggedIn) {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e) {
            try {
                var user = _userController.GetUserByCredentials(
                    SessionManager.CurrentUser.UserName,
                    PasswordInput.Text
                );

                _userController.DeleteUser(SessionManager.CurrentUser.Id);
                SessionManager.ClearCurrentUser();

                Response.Redirect("~/View/Home.aspx");
            } catch (Exception ex) {
                ErrorLabel.Text = ex.Message;
            }
        }
    }
}