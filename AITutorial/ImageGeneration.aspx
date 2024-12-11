<%@ Page Async="true" Title="Image Generation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImageGeneration.aspx.cs" Inherits="AITutorial.ImageGeneration" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4">Image Generation</h1>
        <p class="lead">Generate images using Stability AI</p>

        <div class="card mb-4">
            <div class="card-body">
                <form runat="server">
                    <div class="mb-3">
                        <label for="PromptInput" class="form-label">Describe the image:</label>
                        <asp:TextBox ID="PromptInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                    </div>
                    <asp:Button ID="GenerateButton" runat="server" Text="Generate" CssClass="btn btn-primary" OnClick="GenerateButton_Click" />
                    <div class="mt-4">
                        <asp:Image ID="ResultImage" runat="server" CssClass="img-fluid" Visible="false" />
                        <asp:Label ID="ErrorLabel" runat="server" CssClass="text-danger" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>