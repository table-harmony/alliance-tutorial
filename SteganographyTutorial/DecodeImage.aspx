<%@ Page Title="Decode File" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DecodeImage.aspx.cs" Inherits="SteganographyTutorial.DecodeImage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="h-100 d-flex align-items-center justify-content-center">
        <div class="col-md-8">
            <div class="card shadow-sm">
                <div class="card-header bg-primary text-white">
                    <h3 class="card-title mb-0">Decode File</h3>
                </div>
                <div class="card-body">
                    <form id="form1" runat="server">
                        <div class="mb-4">
                            <label for="FileUpload" class="form-label">Select Encoded Image</label>
                            <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control" accept="image/*" required="true" />
                        </div>
                        <div class="mb-4">
                            <asp:Button ID="DecodeButton" runat="server" Text="Decode File" CssClass="btn btn-primary" OnClick="DecodeButton_Click" />
                        </div>
                        <asp:Panel ID="ResultPanel" runat="server" Visible="false">
                            <div class="card bg-light">
                                <div class="card-body">
                                    <h5 class="card-title">Hidden Message</h5>
                                    <asp:Label ID="MessageLabel" runat="server" CssClass="card-text" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Label ID="StatusLabel" runat="server" CssClass="text-danger" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>