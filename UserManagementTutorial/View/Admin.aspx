<%@ Page Title="Admin Panel" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="UserManagementTutorial.View.Admin" %>
<%@ Import Namespace="UserManagementTutorial.Utils" %>
<%@ Import Namespace="UserManagementTutorial.Model.Entities" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2>User Management</h2>
            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#createUserModal">
                <i class="bi bi-person-plus"></i> Create User
            </button>
        </div>
        
        <form runat="server">
            <!-- Users GridView -->
            <div class="card">
                <div class="card-body">
                    <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" 
                        CssClass="table table-striped" DataKeyNames="Id"
                        OnRowEditing="UsersGridView_RowEditing" 
                        OnRowCancelingEdit="UsersGridView_RowCancelingEdit"
                        OnRowUpdating="UsersGridView_RowUpdating" 
                        OnRowDeleting="UsersGridView_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Username">
                                <ItemTemplate>
                                    <%# Eval("UserName") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="EditUserNameInput" Text='<%# Bind("UserName") %>' 
                                        CssClass="form-control" />
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="EditUserNameInput"
                                        ValidationGroup="EditUser" CssClass="text-danger d-block" 
                                        ValidationExpression="^[a-zA-Z0-9]{3,20}$"
                                        ErrorMessage="Username must be 3-20 characters long" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password">
                                <ItemTemplate>
                                    <span class="text-muted">Hidden</span>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="EditPasswordInput" TextMode="Password" 
                                        CssClass="form-control" placeholder="Leave blank to keep current" />
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="EditPasswordInput"
                                        ValidationGroup="EditUser" CssClass="text-danger d-block"
                                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
                                        ErrorMessage="Invalid password format" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Role">
                                <ItemTemplate>
                                    <%# Eval("Role") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList runat="server" ID="EditRoleDropDown" CssClass="form-select">
                                        <asp:ListItem Text="Member" Value="0" />
                                        <asp:ListItem Text="Admin" Value="1" />
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CommandName="Edit" CssClass="btn btn-primary btn-sm"
                                        Text="Edit" />
                                    <button type="button" class="btn btn-danger btn-sm" 
                                        onclick='showDeleteModal(<%# Eval("Id") %>, "<%# Eval("UserName") %>"); return false;'>
                                        Delete
                                    </button>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton runat="server" CommandName="Update" ValidationGroup="EditUser" 
                                        CssClass="btn btn-success btn-sm" Text="Save" />
                                    <asp:LinkButton runat="server" CommandName="Cancel" CssClass="btn btn-secondary btn-sm"
                                        Text="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            
            <asp:Label runat="server" ID="StatusLabel" CssClass="text-danger mt-2" />

            <!-- Create User Modal -->
            <div class="modal fade" id="createUserModal" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Create New User</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                        </div>
                        <div class="modal-body">
                            <div class="mb-3">
                                <label class="form-label">Username</label>
                                <asp:TextBox runat="server" ID="NewUserNameInput" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewUserNameInput" 
                                    ValidationGroup="CreateUser" CssClass="text-danger d-block" 
                                    ErrorMessage="Username is required" />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="NewUserNameInput"
                                    ValidationGroup="CreateUser" CssClass="text-danger d-block" 
                                    ValidationExpression="^[a-zA-Z0-9]{3,20}$"
                                    ErrorMessage="Username must be 3-20 characters long" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Password</label>
                                <asp:TextBox runat="server" ID="NewPasswordInput" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPasswordInput"
                                    ValidationGroup="CreateUser" CssClass="text-danger d-block"
                                    ErrorMessage="Password is required" />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="NewPasswordInput"
                                    ValidationGroup="CreateUser" CssClass="text-danger d-block"
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
                                    ErrorMessage="Password must be at least 8 characters with letters and numbers" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Role</label>
                                <asp:DropDownList runat="server" ID="NewRoleDropDown" CssClass="form-select">
                                    <asp:ListItem Text="Member" Value="0" />
                                    <asp:ListItem Text="Admin" Value="1" />
                                </asp:DropDownList>
                            </div>
                            <asp:Label runat="server" ID="CreateErrorLabel" CssClass="text-danger" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                            <asp:Button runat="server" ID="CreateUserButton" Text="Create User" 
                                ValidationGroup="CreateUser" CssClass="btn btn-primary" 
                                OnClick="CreateUserButton_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Delete Confirmation Modal -->
            <div class="modal fade" id="deleteModal" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Confirm Delete</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                        </div>
                        <div class="modal-body">
                            <p>Are you sure you want to delete user "<span id="deleteUserName"></span>"?</p>
                            <asp:HiddenField runat="server" ID="DeleteUserIdHidden" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                            <asp:Button runat="server" ID="ConfirmDeleteButton" Text="Delete" 
                                CssClass="btn btn-danger" OnClick="ConfirmDeleteButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>

    <script type="text/javascript">
        function showDeleteModal(userId, userName) {
            document.getElementById('<%= DeleteUserIdHidden.ClientID %>').value = userId;
            document.getElementById('deleteUserName').textContent = userName;
            new bootstrap.Modal(document.getElementById('deleteModal')).show();
        }
    </script>
</asp:Content>
