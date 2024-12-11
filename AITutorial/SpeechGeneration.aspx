<%@ Page Async="true" Title="Speech Generation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpeechGeneration.aspx.cs" Inherits="AITutorial.SpeechGeneration" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4">Speech Generation</h1>
        <p class="lead">Convert text to speech using ElevenLabs</p>

        <div class="card mb-4">
            <div class="card-body">
                <form id="form1" runat="server">
                    <div class="mb-3">
                        <label for="PromptInput" class="form-label">Enter text to convert:</label>
                        <asp:TextBox ID="PromptInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                    </div>
                    <asp:Button ID="GenerateButton" runat="server" Text="Generate" CssClass="btn btn-primary" OnClick="GenerateButton_Click" />
                    <div class="mt-4">
                        <audio id="audioPlayer" controls="controls" runat="server" visible="false"></audio>
                        <asp:Label ID="ErrorLabel" runat="server" CssClass="text-danger" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>