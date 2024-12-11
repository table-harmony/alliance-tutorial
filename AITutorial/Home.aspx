<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AITutorial.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4">AI Tutorial</h1>
        <p class="lead">This project demonstrates different usages of LLM's.</p>
            
        <div class="card mb-4">
            <div class="card-body">
                <h5 class="card-title">Features</h5>
                <ul>
                    <li>Text Generation with Google's Gemini AI</li>
                    <li>Image Generation with Stability AI</li>
                    <li>Speech Synthesis with ElevenLabs</li>
                </ul>
            </div>
        </div>
            
        <div class="row mb-4">
            <div class="col-md-4">
                <div class="card h-100">
                    <div class="card-body">
                        <h5 class="card-title">
                            <i class="bi bi-chat-dots"></i> Text Generation
                        </h5>
                        <p class="card-text">Generate text responses using Google's Gemini AI.</p>
                        <a href="TextGeneration.aspx" class="btn btn-primary">Try Text Generation</a>
                    </div>
                </div>
            </div>
            
            <div class="col-md-4">
                <div class="card h-100">
                    <div class="card-body">
                        <h5 class="card-title">
                            <i class="bi bi-image"></i> Image Generation
                        </h5>
                        <p class="card-text">Generate images using Stability AI.</p>
                        <a href="ImageGeneration.aspx" class="btn btn-primary">Try Image Generation</a>
                    </div>
                </div>
            </div>
            
            <div class="col-md-4">
                <div class="card h-100">
                    <div class="card-body">
                        <h5 class="card-title">
                            <i class="bi bi-mic"></i> Speech Synthesis
                        </h5>
                        <p class="card-text">Convert text to speech using ElevenLabs.</p>
                        <a href="SpeechGeneration.aspx" class="btn btn-primary">Try Speech Synthesis</a>
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
                    <p class="card-text">Documentation explaining AI usage and more</p>
                    <a href="Documentation.aspx" class="btn btn-primary">
                        <i class="bi bi-archive"></i> Documentation
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>