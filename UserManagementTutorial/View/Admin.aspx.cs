using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementTutorial.Controller;
using UserManagementTutorial.Model.Entities;
using UserManagementTutorial.Utils;

namespace UserManagementTutorial.View {
    public partial class Admin : System.Web.UI.Page {
        private readonly UserController _userController = new UserController();

        protected void Page_Load(object sender, EventArgs e) {
            if (!SessionManager.IsLoggedIn || SessionManager.CurrentUser.Role != UserRole.Admin) {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            if (!IsPostBack) {
                BindGrid();
            }
        }

        private void BindGrid() {
            UsersGridView.DataSource = _userController.GetUsers();
            UsersGridView.DataBind();
        }

        protected void CreateUserButton_Click(object sender, EventArgs e) {
            try {
                var newUser = new User {
                    UserName = NewUserNameInput.Text,
                    PasswordHash = NewPasswordInput.Text,
                    Role = (UserRole)int.Parse(NewRoleDropDown.SelectedValue)
                };

                _userController.CreateUser(newUser);
                BindGrid();
                ClearNewUserForm();
                
                StatusLabel.CssClass = "alert alert-success";
                StatusLabel.Text = "User created successfully!";
                ScriptManager.RegisterStartupScript(this, GetType(), "hideModal", 
                    "$('#createUserModal').modal('hide');", true);
            }
            catch (Exception ex) {
                CreateErrorLabel.Text = ex.Message;
            }
        }

        private void ClearNewUserForm() {
            NewUserNameInput.Text = string.Empty;
            NewPasswordInput.Text = string.Empty;
            NewRoleDropDown.SelectedIndex = 0;
            CreateErrorLabel.Text = string.Empty;
        }

        protected void ConfirmDeleteButton_Click(object sender, EventArgs e) {
            try {
                int userId = Convert.ToInt32(DeleteUserIdHidden.Value);
                _userController.DeleteUser(userId);
                BindGrid();
            }
            catch (Exception ex) {
                StatusLabel.CssClass = "alert alert-danger";
                StatusLabel.Text = "Error deleting user: " + ex.Message;
            }
        }

        protected void UsersGridView_RowEditing(object sender, GridViewEditEventArgs e) {
            UsersGridView.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void UsersGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            UsersGridView.EditIndex = -1;
            BindGrid();
        }

        protected void UsersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            try {
                GridViewRow row = UsersGridView.Rows[e.RowIndex];
                int userId = Convert.ToInt32(UsersGridView.DataKeys[e.RowIndex].Value);

                string username = (row.FindControl("EditUserNameInput") as TextBox).Text;
                string password = (row.FindControl("EditPasswordInput") as TextBox).Text;
                string roleValue = (row.FindControl("EditRoleDropDown") as DropDownList).SelectedValue;

                var user = new User {
                    Id = userId,
                    UserName = username,
                    Role = (UserRole)int.Parse(roleValue)
                };

                if (!string.IsNullOrEmpty(password)) {
                    user.PasswordHash = password;
                }
                else {
                    user.PasswordHash = _userController.GetUserById(userId).PasswordHash;
                }

                _userController.UpdateUser(user);
                UsersGridView.EditIndex = -1;
                BindGrid();
                
                StatusLabel.CssClass = "alert alert-success";
                StatusLabel.Text = "User updated successfully!";
            }
            catch (Exception ex) {
                StatusLabel.CssClass = "alert alert-danger";
                StatusLabel.Text = "Error updating user: " + ex.Message;
            }
        }

        protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            try {
                int userId = Convert.ToInt32(UsersGridView.DataKeys[e.RowIndex].Value);
                _userController.DeleteUser(userId);
                BindGrid();

                StatusLabel.CssClass = "alert alert-success";
                StatusLabel.Text = "User deleted successfully!";
            }
            catch (Exception ex) {
                StatusLabel.CssClass = "alert alert-danger";
                StatusLabel.Text = "Error deleting user: " + ex.Message;
            }
        }
    }
}