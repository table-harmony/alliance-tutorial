<%@ Page Title="Profile" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="UserManagementTutorial.View.Profile" %>
<%@ Import Namespace="UserManagementTutorial.Utils" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card mt-5">
                    <div class="card-body">
                        <h2 class="card-title text-center">Profile</h2>

                        <div class="text-center mb-4">
                            <i class="bi bi-person-circle display-3"></i>
                            <p class="lead mt-2"><%: SessionManager.CurrentUser.UserName %></p>
                            <span class="badge bg-primary"><%: SessionManager.CurrentUser.Role %></span>
                        </div>

                        <form runat="server">
                            <div class="mb-3">
                                <label class="form-label">Username</label>
                                <asp:TextBox runat="server" ID="UserNameInput" CssClass="form-control" />

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserNameInput" 
                                    CssClass="text-danger d-block" ErrorMessage="Username is required" />

                                <asp:RegularExpressionValidator runat="server" ControlToValidate="UserNameInput"
                                    CssClass="text-danger d-block" ValidationExpression="^[a-zA-Z0-9]{3,20}$"
                                    ErrorMessage="Username must be 3-20 characters long and contain only letters and numbers" />
                            </div>

                            <div class="mb-3">
                                <label class="form-label">New Password (leave blank to keep current)</label>

                                <asp:TextBox runat="server" ID="PasswordInput" TextMode="Password" CssClass="form-control" />

                                <asp:RegularExpressionValidator runat="server" ControlToValidate="PasswordInput"
                                    CssClass="text-danger d-block" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
                                    ErrorMessage="Password must be at least 8 characters long and contain at least one letter and one number" />
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Confirm New Password</label>

                                <asp:TextBox runat="server" ID="ConfirmPasswordInput" TextMode="Password" CssClass="form-control" />
                                
                                <asp:CompareValidator runat="server" ControlToValidate="ConfirmPasswordInput"
                                    ControlToCompare="PasswordInput" CssClass="text-danger d-block"
                                    ErrorMessage="Passwords do not match" />
                            </div>

                            <asp:Button runat="server" ID="UpdateButton" Text="Update Profile" OnClick="UpdateButton_Click" 
                                CssClass="btn btn-primary w-100" />

                            <asp:Label runat="server" ID="ErrorLabel" CssClass="text-danger mt-2" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>