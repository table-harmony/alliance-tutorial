<%@ Page Async="true" Title="Encode Image" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EncodeImage.aspx.cs" Inherits="SteganographyTutorial.EncodeImage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="h-100 d-flex align-items-center justify-content-center">
        <div class="col-md-8">
            <div class="card shadow-sm">
                <div class="card-header bg-primary text-white">
                    <h3 class="card-title mb-0">Encode Image</h3>
                </div>
                <div class="card-body">
                    <form id="form1" runat="server">
                        <div class="mb-4">
                            <label for="FileUpload" class="form-label">Select Image File</label>
                            <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control" accept="image/*" required="true" />
                        </div>
                        <div class="mb-4">
                            <label for="SecretMessage" class="form-label">Secret Message</label>
                            <asp:TextBox ID="SecretMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" required="true" />
                        </div>
                        <div class="mb-4">
                            <asp:Button ID="EncodeButton" runat="server" Text="Encode File" CssClass="btn btn-primary" OnClick="EncodeButton_Click" />
                        </div>
                        <asp:Label ID="StatusLabel" runat="server" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
