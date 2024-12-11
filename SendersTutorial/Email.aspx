<%@ Page Async="true" Title="Email" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="SendersTutorial.Email" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4">Send Email</h1>
        <p class="lead">Send emails using SMTP server</p>

        <div class="card mb-4">
            <div class="card-body">
                <form runat="server">
                    <div class="mb-3">
                        <label for="FromInput" class="form-label">From:</label>
                        <asp:TextBox ID="FromInput" runat="server" CssClass="form-control" TextMode="Email" />
                    </div>
                    <div class="mb-3">
                        <label for="ToInput" class="form-label">To:</label>
                        <asp:TextBox ID="ToInput" runat="server" CssClass="form-control" TextMode="Email" />
                    </div>
                    <div class="mb-3">
                        <label for="SubjectInput" class="form-label">Subject:</label>
                        <asp:TextBox ID="SubjectInput" runat="server" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="MessageInput" class="form-label">Message:</label>
                        <asp:TextBox ID="MessageInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                    </div>
                    <asp:Button ID="SendButton" runat="server" Text="Send Email" CssClass="btn btn-primary" OnClick="SendButton_Click" />
                    <asp:Label ID="StatusLabel" runat="server" CssClass="ms-3" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>