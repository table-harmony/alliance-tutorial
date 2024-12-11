<%@ Page Title="Login" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UserManagementTutorial.View.Login" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card mt-5">
                    <div class="card-body">
                        <h2 class="card-title text-center">Login</h2>

                        <form runat="server">
                            <div class="mb-3">
                                <label class="form-label">Username</label>
                                <asp:TextBox 
                                    runat="server" 
                                    ID="UserNameInput"
                                    CssClass="form-control" />

                                <asp:RequiredFieldValidator 
                                    runat="server" 
                                    ControlToValidate="UserNameInput" 
                                    CssClass="text-danger d-block" 
                                    ErrorMessage="Username is required" />

                                <asp:RegularExpressionValidator 
                                    runat="server" 
                                    ControlToValidate="UserNameInput"
                                    CssClass="text-danger d-block" 
                                    ValidationExpression="^[a-zA-Z0-9]{3,20}$"
                                    ErrorMessage="Username must be 3-20 characters long" />
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Password</label>
                                <asp:TextBox 
                                    runat="server" 
                                    ID="PasswordInput" 
                                    TextMode="Password" 
                                    CssClass="form-control" />

                                <asp:RequiredFieldValidator 
                                    runat="server" 
                                    ControlToValidate="PasswordInput" 
                                    CssClass="text-danger d-block" 
                                    ErrorMessage="Password is required" />

                                <asp:RegularExpressionValidator 
                                    runat="server" 
                                    ControlToValidate="PasswordInput"
                                    CssClass="text-danger d-block" 
                                    ValidationExpression="^.{8,}$"
                                    ErrorMessage="Password must be at least 8 characters long" />
                            </div>

                            <asp:Button runat="server" ID="LoginButton" Text="Login" OnClick="LoginButton_Click" 
                                CssClass="btn btn-primary w-100" />

                            <asp:Label runat="server" ID="ErrorLabel" CssClass="text-danger mt-2" />

                            <div class="text-center mt-3">
                                <a href="Register.aspx">Don't have an account? Register here</a>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>