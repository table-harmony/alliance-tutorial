<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SendersTutorial.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Senders Tutorial</h1>
            <p class="lead">Learn how to send messages with email, sms and whatsapp.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title"><i class="bi bi-shield-lock"></i> Tutorial Features</h5>
                    <ul>
                        <li>SMTP servers</li>
                        <li>Twillio usage</li>
                        <li>Whatsapp and SMS messages</li>
                    </ul>
                </div>
            </div>

            <div class="row mb-4">
                <div class="col-md-4">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-envelope"></i> Email
                            </h5>
                            <p class="card-text">Send email messages using an SMTP server.</p>
                            <a href="Email.aspx" class="btn btn-primary">Try email</a>
                        </div>
                    </div>
                </div>
            
                <div class="col-md-4">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-chat"></i> SMS
                            </h5>
                            <p class="card-text">Send SMS messages</p>
                            <a href="Sms.aspx" class="btn btn-primary">Try SMS</a>
                        </div>
                    </div>
                </div>
            
                <div class="col-md-4">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-chat-dots"></i> Whatsapp
                            </h5>
                            <p class="card-text">Send Whatsapp messages</p>
                            <a href="Whatsapp.aspx" class="btn btn-primary">Try Whatsapp</a>
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
                        <p class="card-text">Documentation explaining encryption</p>
                        <a href="Documentation.aspx" class="btn btn-primary">
                            <i class="bi bi-archive"></i> Documentation
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>