<%@ Page Title="Logout" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="UserManagementTutorial.View.Logout" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card mt-5">
                    <div class="card-body text-center">
                        <i class="bi bi-box-arrow-right display-3 text-danger mb-3"></i>

                        <h2 class="card-title">Confirm Logout</h2>
                        <p class="lead">Are you sure you want to logout?</p>

                        <form runat="server">
                            <asp:Button runat="server" ID="LogoutButton" Text="Yes, Logout" 
                                OnClick="LogoutButton_Click" CssClass="btn btn-danger me-2" />
                            <a href="Home.aspx" class="btn btn-secondary">Cancel</a>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>