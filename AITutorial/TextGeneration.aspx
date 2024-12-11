<%@ Page Async="true" Title="Text Generation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TextGeneration.aspx.cs" Inherits="AITutorial.TextGeneration" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4">Text Generation</h1>
        <p class="lead">Generate text using Google's Gemini AI</p>

        <div class="card mb-4">
            <div class="card-body">
                <form id="form1" runat="server">
                    <div class="mb-3">
                        <label for="PromptInput" class="form-label">Enter your prompt:</label>
                        <asp:TextBox ID="PromptInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                    </div>
                    <asp:Button ID="GenerateButton" runat="server" Text="Generate" CssClass="btn btn-primary" OnClick="GenerateButton_Click" />
                
                    <div class="mt-4">
                        <asp:Label ID="ResultLabel" runat="server" CssClass="d-block" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>