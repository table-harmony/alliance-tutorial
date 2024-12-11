<%@ Page Title="Documentation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="FileUploaderTutorial.Documentation" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Documentation</h1>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h2>File Upload System Overview</h2>
                    <p>The File Upload system provides a robust and secure way to handle file uploads in ASP.NET applications. It supports multiple storage providers and implements best practices for file handling.</p>
                    
                    <h3 class="mt-4">Key Features</h3>
                    <ul>
                        <li><i class="bi bi-hdd"></i> Local storage support</li>
                        <li><i class="bi bi-cloud"></i> Cloud storage integration</li>
                    </ul>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2>Implementation Details</h2>
                    <h4>Storage Providers</h4>
                    <ul>
                        <li><strong>Local File System:</strong> Direct storage on server filesystem</li>
                        <li><strong>Cloud Storage:</strong> Integration with cloud providers</li>
                    </ul>

                    <h4>File Processing</h4>
                    <ol>
                        <li>File validation and sanitization</li>
                        <li>Unique filename generation</li>
                        <li>Upload processing</li>
                    </ol>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2>Security Considerations</h2>
                    <div class="alert alert-warning">
                        <h5><i class="bi bi-exclamation-triangle"></i> Important Security Measures:</h5>
                        <ul>
                            <li>File type validation</li>
                            <li>Size restrictions</li>
                            <li>Malware scanning</li>
                            <li>Secure storage paths</li>
                            <li>Access control</li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-body">
                    <h2>Usage Examples</h2>
                    <p>Implementation examples for different scenarios:</p>
                    <ul>
                        <li>Single file uploads</li>
                        <li>Multiple file uploads</li>
                        <li>Progress tracking</li>
                        <li>Error handling</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>