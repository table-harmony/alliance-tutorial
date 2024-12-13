<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ErrorHandlingTutorial.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Error Handling Tutorial</h1>
            <p class="lead">Learn how to implement custom error handling in ASP.NET Web Forms applications.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title">Tutorial Features</h5>
                    <ul>
                        <li>Custom Error Pages</li>
                        <li>Public vs Private Exceptions</li>
                        <li>Global Error Handling</li>
                        <li>User-Friendly Error Messages</li>
                    </ul>
                </div>
            </div>

            <div class="row mb-4">
                <div class="col-md-6">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-exclamation-triangle"></i> System Error
                            </h5>
                            <p class="card-text">Throws a standard system exception to demonstrate default error handling.</p>
                            <a href="SystemError.aspx" class="btn btn-primary">
                                <i class="bi bi-exclamation-circle"></i> System Error
                            </a>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-6">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-info-circle"></i> Public Error
                            </h5>
                            <p class="card-text">Throws a public exception with a user-friendly message.</p>
                            <a href="PublicError.aspx" class="btn btn-primary">
                                <i class="bi bi-info"></i> Public Error
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            <i class="bi bi-archive"></i> Documentation
                        </h5>
                        <p class="card-text">Learn more about error handling best practices and implementation details.</p>
                        <a href="Documentation.aspx" class="btn btn-primary">
                            <i class="bi bi-archive"></i> Documentation
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>