<%@ Page Title="Documentation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="WebSocketsTutorial.Documentation" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style>
        .code-block {
            background-color: #f8f9fa;
            padding: 1rem;
            border-radius: 0.25rem;
            margin-bottom: 1rem;
            font-family: monospace;
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4 mb-4">Documentation</h1>

        <div class="card mb-4">
            <div class="card-body">
                <h2 class="card-title">Overview</h2>
                <p>This tutorial demonstrates two approaches to implementing real-time communication in ASP.NET Web Forms:</p>
                <ul>
                    <li>Native WebSocket Implementation</li>
                    <li>SignalR Implementation</li>
                </ul>
            </div>
        </div>

        <div class="card mb-4">
            <div class="card-body">
                <h2 class="card-title">WebSocket Implementation</h2>
                <h3>What are WebSockets?</h3>
                <p>WebSocket is a communication protocol that provides full-duplex communication channels over a single TCP connection. Unlike HTTP, WebSocket:</p>
                <ul>
                    <li>Maintains a persistent connection</li>
                    <li>Enables real-time data transfer</li>
                    <li>Reduces overhead compared to HTTP polling</li>
                    <li>Supports bi-directional communication</li>
                </ul>

                <h3 class="mt-4">Configuration Requirements</h3>
                <p>To enable WebSocket support in your ASP.NET application, you need to configure the following in Web.config:</p>
                
                <div class="code-block">
                    <pre>&lt;system.webServer&gt;
    &lt;handlers&gt;
        &lt;add name="WebSocketHandler" 
             path="/ws" 
             verb="*" 
             type="WebSocketsTutorial.Utils.WebSocketHandler"/&gt;
    &lt;/handlers&gt;
    &lt;validation validateIntegratedModeConfiguration="false"/&gt;
&lt;/system.webServer&gt;</pre>
                </div>

                <p>This configuration:</p>
                <ul>
                    <li>Registers a custom WebSocket handler at the "/ws" endpoint</li>
                    <li>Enables handling of WebSocket upgrade requests</li>
                    <li>Maps all HTTP verbs to the handler</li>
                </ul>
            </div>
        </div>

        <div class="card mb-4">
            <div class="card-body">
                <h2 class="card-title">SignalR Implementation</h2>
                <p>SignalR provides a simplified way to add real-time functionality to web applications. It:</p>
                <ul>
                    <li>Automatically handles connection management</li>
                    <li>Broadcasts messages to all connected clients</li>
                    <li>Scales across multiple servers</li>
                    <li>Falls back to other transport methods if WebSocket isn't available</li>
                </ul>

                <h3 class="mt-4">Required Packages</h3>
                <ul>
                    <li>Microsoft.AspNet.SignalR</li>
                    <li>Microsoft.AspNet.SignalR.SystemWeb</li>
                    <li>Microsoft.AspNet.SignalR.Core</li>
                </ul>
            </div>
        </div>

        <div class="card">
            <div class="card-body">
                <h2 class="card-title">Implementation Comparison</h2>
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Feature</th>
                                <th>Native WebSocket</th>
                                <th>SignalR</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Connection Management</td>
                                <td>Manual</td>
                                <td>Automatic</td>
                            </tr>
                            <tr>
                                <td>Fallback Transport</td>
                                <td>No</td>
                                <td>Yes</td>
                            </tr>
                            <tr>
                                <td>Broadcasting</td>
                                <td>Custom Implementation</td>
                                <td>Built-in</td>
                            </tr>
                            <tr>
                                <td>Scalability</td>
                                <td>Limited</td>
                                <td>Built-in Support</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>