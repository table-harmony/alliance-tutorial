<%@ Page Title="Custom Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomChat.aspx.cs" Inherits="WebSocketsTutorial.CustomChat" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style>
        .chat-container {
            height: 400px;
            overflow-y: auto;
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-header bg-primary text-white">
                        <h3 class="card-title mb-0">Custom Chat</h3>
                    </div>
                    <div class="card-body">
                        <div id="chatMessages" class="chat-container mb-3">
                        </div>
                        <div class="input-group">
                            <input type="text" id="messageInput" class="form-control" placeholder="Type your message...">
                            <button class="btn btn-primary" type="button" id="sendButton">
                                <i class="bi bi-send"></i> Send
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function() {
            const socket = new WebSocket(`https://localhost:44363/ws`);

            const chatMessages = document.getElementById('chatMessages');
            const messageInput = document.getElementById('messageInput');
            const sendButton = document.getElementById('sendButton');

            socket.onopen = function(event) {
                console.log("Connected to chat server");
                appendMessage("Client connected to chat server", false);
            };

            socket.onmessage = function(event) {
                appendMessage(event.data, false);
            };

            socket.onclose = function (event) {
                console.log("Disconnected from chat server");
                appendMessage("Client disconnected from chat server", false);
            };

            function sendMessage() {
                const message = messageInput.value.trim();

                if (!message || socket.readyState !== WebSocket.OPEN)
                    return;

                socket.send(message);
                appendMessage(message, true);
                messageInput.value = '';
            }

            function appendMessage(message, isSent) {
                const messageDiv = document.createElement('div');
                messageDiv.textContent = message;

                if (isSent) {
                    messageDiv.className = 'ms-auto w-50 bg-primary text-white rounded p-3 mb-2';
                } else {
                    messageDiv.className = 'me-auto w-50 bg-light rounded p-3 mb-2';
                }

                chatMessages.appendChild(messageDiv);
                chatMessages.scrollTop = chatMessages.scrollHeight;
            }

            sendButton.addEventListener('click', sendMessage);
            messageInput.addEventListener('keypress', function(e) {
                if (e.key === 'Enter') {
                    sendMessage();
                }
            });
        });
    </script>
</asp:Content>