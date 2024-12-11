<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebSocketsTutorial.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">WebSockets Tutorial</h1>
            <p class="lead">This project demonstrates different approaches to real-time communication in ASP.NET Web Forms.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title">Features</h5>
                    <ul>
                        <li>Native WebSocket Implementation</li>
                        <li>SignalR Integration</li>
                        <li>Real-time Message Broadcasting</li>
                        <li>Connection Management</li>
                    </ul>
                </div>
            </div>

            <div class="row mb-4">
                <div class="col-md-6">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-chat-dots"></i> Custom Chat
                            </h5>
                            <p class="card-text">Basic chat implementation using native WebSocket protocol.</p>
                            <a href="CustomChat.aspx" class="btn btn-primary">
                                <i class="bi bi-chat"></i> Try Custom Chat
                            </a>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-6">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-chat-square-dots"></i> SignalR Chat
                            </h5>
                            <p class="card-text">Advanced chat implementation using SignalR for real-time communication.</p>
                            <a href="SignalRChat.aspx" class="btn btn-primary">
                                <i class="bi bi-chat-square"></i> Try SignalR Chat
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
                        <p class="card-text">Documentation explaining Steganography</p>
                        <a href="Documentation.aspx" class="btn btn-primary">
                            <i class="bi bi-archive"></i> Documentation
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>