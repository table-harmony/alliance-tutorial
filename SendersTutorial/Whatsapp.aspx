<%@ Page Title="WhatsApp" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WhatsApp.aspx.cs" Inherits="SendersTutorial.WhatsApp" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4">Send WhatsApp Message</h1>
        <p class="lead">Send WhatsApp messages using Twilio</p>

        <div class="card mb-4">
            <div class="card-body">
                <form runat="server">
                    <div class="mb-3">
                        <label for="FromInput" class="form-label">From (WhatsApp Number):</label>
                        <asp:TextBox ID="FromInput" runat="server" CssClass="form-control" TextMode="Phone" />
                    </div>
                    <div class="mb-3">
                        <label for="ToInput" class="form-label">To:</label>
                        <asp:TextBox ID="ToInput" runat="server" CssClass="form-control" TextMode="Phone" />
                    </div>
                    <div class="mb-3">
                        <label for="MessageInput" class="form-label">Message:</label>
                        <asp:TextBox ID="MessageInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                    </div>
                    <asp:Button ID="SendButton" runat="server" Text="Send WhatsApp" CssClass="btn btn-primary" OnClick="SendButton_Click" />
                    <asp:Label ID="StatusLabel" runat="server" CssClass="ms-3" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>