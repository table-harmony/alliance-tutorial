<%@ Page Title="Public Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicError.aspx.cs" Inherits="ErrorHandlingTutorial.PublicError" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title mb-0"><i class="bi bi-info-circle"></i> Public Exception Demo</h3>
                    </div>
                    <div class="card-body">
                        <form runat="server">
                            <p class="card-text">Click the button below to throw a public exception with a user-friendly message.</p>
                            <asp:Button runat="server" ID="ThrowErrorButton" Text="Throw Public Exception" CssClass="btn btn-danger" OnClick="ThrowErrorButton_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>