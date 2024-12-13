<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ExampleUsage.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Example Usage</h1>
            <p class="lead">This is an example usage of the tutorials.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title">Tutorial Features</h5>
                    <ul>
                        <li>Steganography</li>
                        <li>Encryption</li>
                        <li>File upload</li>
                    </ul>
                </div>
            </div>

                    <div class="card">
            <div class="card-body">
                <h5 class="card-title">Get Started</h5>
                <p class="card-text">
                    Please login or register.
                </p>
                <div class="mt-3">
                    <a href="Login.aspx" class="btn btn-primary me-2">Login</a>
                    <a href="Register.aspx" class="btn btn-outline-primary">Register</a>
                </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>