<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FileUploaderTutorial.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">File Upload Tutorial</h1>
            <p class="lead">This project demonstrates different approaches to handling file uploads in ASP.NET Web Forms.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title">Tutorial Features</h5>
                    <ul>
                        <li>ASP.NET FileUpload Control Implementation</li>
                        <li>HTML Form-based File Upload</li>
                        <li>Async File Processing</li>
                        <li>API usage</li>
                    </ul>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">ASP.NET Upload</h5>
                            <p class="card-text">Uses the built-in ASP.NET FileUpload control with server-side handling.</p>
                            <a href="AspNetUpload.aspx" class="btn btn-primary">Try ASP.NET Upload</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">HTML Form Upload</h5>
                            <p class="card-text">Uses a standard HTML form with custom handling and processing.</p>
                            <a href="HtmlFormUpload.aspx" class="btn btn-primary">Try HTML Form Upload</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>