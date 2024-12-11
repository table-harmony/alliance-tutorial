<%@ Page Title="Home" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UserManagementTutorial.Home" %>
<%@ Import Namespace="UserManagementTutorial.Utils" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">User Management Tutorial</h1>
            <p class="lead">Learn how to implement secure user authentication and management in ASP.NET applications.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title"><i class="bi bi-shield-lock"></i> Tutorial Features</h5>
                    <ul>
                        <li>Secure User Authentication</li>
                        <li>Role-based Authorization</li>
                        <li>Session Management</li>
                        <li>Password Encryption</li>
                        <li>User Profile Management</li>
                    </ul>
                </div>
            </div>

            <% if (SessionManager.IsLoggedIn) { %>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Welcome, <%= SessionManager.CurrentUser.UserName %>!</h5>
                        <p class="card-text">
                            You are logged in as: <%= SessionManager.CurrentUser.Role %>
                        </p>
                        <div class="mt-3">
                            <a href="Profile.aspx" class="btn btn-primary me-2">Profile</a>
                            <a href="Delete.aspx" class="btn btn-danger me-2">Delete</a>
                            <a href="Logout.aspx" class="btn btn-outline-danger">Logout</a>
                        </div>
                    </div>
                </div>
            <% } else { %>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Get Started</h5>
                        <p class="card-text">
                            Please login or register to access all features.
                        </p>
                        <div class="mt-3">
                            <a href="Login.aspx" class="btn btn-primary me-2">Login</a>
                            <a href="Register.aspx" class="btn btn-outline-primary">Register</a>
                        </div>
                    </div>
                </div>
            <% } %>
        </div>
    </div>
</asp:Content>