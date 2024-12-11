<%@ Page Title="Documentation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="SendersTutorial.Documentation" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4">Message Sending Documentation</h1>
        <p class="lead">Learn how to integrate email, SMS, and WhatsApp messaging in your applications</p>

        <div class="card mb-4">
            <div class="card-body">
                <h2><i class="bi bi-envelope"></i> Email Integration</h2>
                <p>Send emails using SMTP servers in your ASP.NET applications.</p>

                <h5>Features:</h5>
                <ul>
                    <li>SMTP server integration</li>
                    <li>Support for attachments</li>
                    <li>HTML and plain text emails</li>
                </ul>

                <div class="alert alert-warning">
                    <h5><i class="bi bi-exclamation-triangle"></i> Important Limitations:</h5>
                    <ul>
                        <li>You cannot send emails from arbitrary addresses - must use your verified SMTP server email</li>
                        <li>Gmail SMTP requires App Password for authentication</li>
                        <li>Daily sending limits apply based on your SMTP provider</li>
                    </ul>
                </div>

                <div class="alert alert-info">
                    <h5><i class="bi bi-info-circle"></i> Getting Started:</h5>
                    <p>To set up SMTP email sending:</p>
                    <ol>
                        <li>Create account with an email service provider (Gmail, SendGrid, etc.)</li>
                        <li>For Gmail: Enable 2FA and generate an App Password</li>
                        <li>Add SMTP credentials to Web.config</li>
                    </ol>
                    <p>Recommended Providers:</p>
                    <ul>
                        <li><a href="https://www.mailersend.com/" target="_blank">Mailer Send</a> - Email service provider</li>
                        <li><a href="https://sendgrid.com/pricing" target="_blank">SendGrid</a> - Email service provider</li>
                        <li><a href="https://support.google.com/mail/answer/7126229" target="_blank">Gmail SMTP</a> - For testing</li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="card mb-4">
            <div class="card-body">
                <h2><i class="bi bi-chat"></i> SMS & WhatsApp Integration</h2>
                <p>Send SMS and WhatsApp messages using Twilio's API.</p>

                <h5>Features:</h5>
                <ul>
                    <li>SMS messaging worldwide</li>
                    <li>WhatsApp Business API integration</li>
                    <li>Delivery status tracking</li>
                </ul>

                <div class="alert alert-warning">
                    <h5><i class="bi bi-exclamation-triangle"></i> Important Limitations:</h5>
                    <ul>
                        <li>Must use a verified Twilio phone number as sender</li>
                        <li>WhatsApp requires business account verification</li>
                        <li>Test accounts can only send to verified numbers</li>
                        <li>Message pricing varies by country</li>
                    </ul>
                </div>

                <div class="alert alert-info">
                    <h5><i class="bi bi-info-circle"></i> Getting Started:</h5>
                    <p>To set up Twilio messaging:</p>
                    <ol>
                        <li>Create a <a href="https://www.twilio.com/try-twilio" target="_blank">Twilio account</a></li>
                        <li>Purchase or verify a phone number</li>
                        <li>For WhatsApp: Join the WhatsApp Business API</li>
                        <li>Add Twilio credentials to Web.config</li>
                    </ol>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="card-body">
                <h2><i class="bi bi-code-square"></i> Implementation</h2>
                <p>The messaging functionality is implemented in:</p>
                <ul>
                    <li><code>Utils/Email.cs</code> - Email sending implementation</li>
                    <li><code>Utils/SMS.cs</code> - SMS sending implementation</li>
                    <li><code>Utils/Whatsapp.cs</code> - WhatsApp sending implementation</li>
                </ul>

                <h5>Configuration Example:</h5>
                <pre class="bg-light p-3 rounded"><code>&lt;appSettings&gt;
    &lt;!-- SMTP Settings --&gt;
    &lt;add key="Smtp_Host" value="smtp.gmail.com"/&gt;
    &lt;add key="Smtp_Port" value="587"/&gt;
    &lt;add key="Smtp_Username" value="your-email@domain.com"/&gt;
    &lt;add key="Smtp_Password" value="your-app-password"/&gt;

    &lt;!-- Twilio Settings --&gt;
    &lt;add key="Twilio_AccountSid" value="your-account-sid"/&gt;
    &lt;add key="Twilio_AuthToken" value="your-auth-token"/&gt;
&lt;/appSettings&gt;</code></pre>
            </div>
        </div>
    </div>
</asp:Content>