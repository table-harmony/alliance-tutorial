<%@ Page Title="Verify Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerifyPassword.aspx.cs" Inherits="PasswordEncryptionTutorial.VerifyPassword" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="h-100 d-flex align-items-center justify-content-center">
        <div class="col-md-8">
            <div class="card shadow-sm">
                <div class="card-header bg-primary text-white">
                    <h3 class="card-title mb-0">Verify Password</h3>
                </div>
                <div class="card-body">
                    <form id="form1" runat="server">
                        <div class="mb-4">
                            <label for="PasswordInput" class="form-label">Password</label>
                            <asp:TextBox ID="PasswordInput" runat="server" CssClass="form-control" TextMode="Password" required="true" />
                        </div>
                        <div class="mb-4">
                            <label for="EncryptionInput" class="form-label">Encryption to Verify Against</label>
                            <asp:TextBox ID="EncryptionInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" required="true" />
                        </div>
                        <div class="mb-4">
                            <asp:Button ID="VerifyButton" runat="server" Text="Verify Password" CssClass="btn btn-primary" OnClick="VerifyButton_Click" />
                        </div>
                        <asp:Label ID="StatusLabel" runat="server" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>