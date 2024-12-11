<%@ Page Title="Delete Account" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="UserManagementTutorial.View.Delete" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card mt-5">
                    <div class="card-body text-center">
                        <i class="bi bi-person-x display-1 text-danger mb-3"></i>
                        <h2 class="card-title">Delete Account</h2>
                        <p class="lead text-danger">Warning: This action cannot be undone!</p>
                        <p>Are you sure you want to permanently delete your account?</p>
                        <form runat="server">
                            <div class="mb-3">
                                <label class="form-label">Confirm your password</label>
                                <asp:TextBox runat="server" ID="PasswordInput" TextMode="Password" 
                                    CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PasswordInput"
                                    CssClass="text-danger d-block" ErrorMessage="Password is required" />
                            </div>
                            <asp:Button runat="server" ID="DeleteButton" Text="Yes, Delete My Account" 
                                OnClick="DeleteButton_Click" CssClass="btn btn-danger me-2" />
                            <a href="Profile.aspx" class="btn btn-secondary">Cancel</a>
                            <asp:Label runat="server" ID="ErrorLabel" CssClass="text-danger d-block mt-3" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>