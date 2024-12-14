<%@ Page Async="true" Title="File Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileLogin.aspx.cs" Inherits="ExampleUsage.FileLogin" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="h-100 d-flex align-items-center justify-content-center">
        <div class="col-md-8">
            <div class="card shadow-sm">
                <div class="card-header bg-primary text-white">
                    <h3 class="card-title mb-0">Login</h3>
                </div>

                <div class="card-body">
                    <form id="form1" runat="server">
                        <div class="mb-4">
                            <label for="UserNameInput" class="form-label">UserName</label>
                            <asp:TextBox ID="UserNameInput" runat="server" CssClass="form-control" required="true" />
                        </div>

                        <div class="mb-4">
                            <label for="PasswordInput" class="form-label">Password</label>
							<asp:FileUpload ID="PasswordInput" runat="server" class="form-control" required="true" />
                        </div>

                        <div class="mb-4">
                            <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="LoginButton_Click" />
                        </div>

						<asp:Label ID="StatusLabel" runat="server" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
