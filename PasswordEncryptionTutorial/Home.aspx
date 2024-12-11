<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PasswordEncryptionTutorial.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Password Encryption Tutorial</h1>
            <p class="lead">Learn how to implement secure password hashing in your ASP.NET applications.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title"><i class="bi bi-shield-lock"></i> Tutorial Features</h5>
                    <ul>
                        <li>SHA256 Password Hashing</li>
                        <li>Secure Password Storage</li>
                        <li>Password Verification</li>
                        <li>Best Practices Implementation</li>
                    </ul>
                </div>
            </div>

            <div class="row mb-4">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-key"></i> Encrypt Password
                            </h5>
                            <p class="card-text">Generate a secure hash from a password.</p>
                            <a href="EncryptPassword.aspx" class="btn btn-primary">
                                <i class="bi bi-lock"></i> Encrypt Password
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-check-square"></i> Verify Password
                            </h5>
                            <p class="card-text">Verify a password against its encryption.</p>
                            <a href="VerifyPassword.aspx" class="btn btn-primary">
                                <i class="bi bi-shield-check"></i> Verify Password
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            <i class="bi bi-archive"></i> Documentation
                        </h5>
                        <p class="card-text">Documentation explaining encryption</p>
                        <a href="Documentation.aspx" class="btn btn-primary">
                            <i class="bi bi-archive"></i> Documentation
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>