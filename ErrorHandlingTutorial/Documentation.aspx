<%@ Page Title="Documentation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="ErrorHandlingTutorial.Documentation" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1 class="display-4 mb-4">Documentation</h1>

                <div class="card mb-4">
                    <div class="card-body">
                        <h2 class="card-title">
                            <i class="bi bi-book"></i> Overview
                        </h2>
                        <p class="card-text">
                            This tutorial demonstrates comprehensive error handling in ASP.NET Web Forms applications,
                            including custom error pages, public vs. system exceptions, and global error handling.
                        </p>
                    </div>
                </div>

                <!-- Error Types -->
                <div class="card mb-4">
                    <div class="card-header bg-primary text-white">
                        <h3 class="mb-0"><i class="bi bi-exclamation-triangle"></i> Error Types</h3>
                    </div>
                    <div class="card-body">
                        <!-- 403 Error -->
                        <h4 class="text-danger">
                            <i class="bi bi-shield-lock"></i> 403 Forbidden
                        </h4>
                        <p>
                            The 403 error occurs when access to a resource is forbidden. You can test this by directly accessing
                            protected server resources, for example: <code>http://localhost:port</code>
                        </p>
                        <div class="alert alert-info">
                            <i class="bi bi-info-circle"></i> This error is handled through IIS configuration and custom error pages.
                        </div>

                        <!-- 404 Error -->
                        <h4 class="text-warning mt-4">
                            <i class="bi bi-exclamation-circle"></i> 404 Not Found
                        </h4>
                        <p>
                            The 404 error occurs when a requested resource doesn't exist. There are two ways this can be triggered:
                        </p>
                        <ul>
                            <li>Through the application's routing (handled by Global.asax)</li>
                            <li>Through IIS when accessing non-existent URLs (e.g., <code>https://localhost:port/nonexistent</code>)</li>
                        </ul>

                        <!-- 500 Error -->
                        <h4 class="text-danger mt-4">
                            <i class="bi bi-x-circle"></i> 500 Internal Server Error
                        </h4>
                        <p>
                            The 500 error occurs when an unhandled exception is thrown. This tutorial demonstrates two types:
                        </p>
                        <ul>
                            <li>Public Exceptions: Display user-friendly messages</li>
                            <li>System Exceptions: Display generic error messages for security</li>
                        </ul>
                    </div>
                </div>

                <!-- Configuration -->
                <div class="card mb-4">
                    <div class="card-header bg-success text-white">
                        <h3 class="mb-0"><i class="bi bi-gear"></i> Configuration</h3>
                    </div>
                    <div class="card-body">
                        <h4>Debug Mode</h4>
                        <p>
                            In Web.config, the <code>debug</code> attribute controls error handling behavior:
                        </p>
                        <ul>
                            <li><code>debug="true"</code>: Shows detailed error pages (development)</li>
                            <li><code>debug="false"</code>: Uses custom error pages (production)</li>
                        </ul>

                        <h4 class="mt-4">IIS Configuration</h4>
                        <div class="alert alert-warning">
                            <i class="bi bi-exclamation-triangle"></i> 
                            The httpErrors section in Web.config should be disabled during development to see actual error details.
                            Enable it in production for consistent error handling.
                        </div>
                        <pre class="bg-light p-3"><code>&lt;system.webServer&gt;
    &lt;httpErrors errorMode="Custom" existingResponse="Replace"&gt;
        &lt;error statusCode="403" path="/403.aspx" responseMode="ExecuteURL" /&gt;
        &lt;error statusCode="404" path="/404.aspx" responseMode="ExecuteURL" /&gt;
    &lt;/httpErrors&gt;
&lt;/system.webServer&gt;</code></pre>
                    </div>
                </div>

                <!-- Best Practices -->
                <div class="card">
                    <div class="card-header bg-info text-white">
                        <h3 class="mb-0"><i class="bi bi-check-circle"></i> Best Practices</h3>
                    </div>
                    <div class="card-body">
                        <ul>
                            <li>Use Public Exceptions for user-facing error messages</li>
                            <li>Keep system exception details hidden from users</li>
                            <li>Implement both Global.asax and IIS error handling</li>
                            <li>Use different configurations for development and production</li>
                            <li>Log all system exceptions for debugging</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>