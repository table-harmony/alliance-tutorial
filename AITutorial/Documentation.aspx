<%@ Page Title="Documentation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="AITutorial.Documentation" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <h1 class="display-4">AI Integration Documentation</h1>
        <p class="lead">Learn how to use different AI models in your ASP.NET applications.</p>
        
        <div class="card mb-4">
            <div class="card-body">
                <h2><i class="bi bi-chat-dots"></i> Text Generation with Gemini</h2>
                <p>Generate human-like text responses using Google's Gemini AI model.</p>
                
                <h5>Features:</h5>
                <ul>
                    <li>Natural language understanding</li>
                    <li>Context-aware responses</li>
                    <li>Multi-language support</li>
                </ul>

                <h5>Implementation:</h5>
                <p>The text generation functionality is implemented in:</p>
                <code>AITutorial/Utils/TextModel.cs</code>

                <div class="alert alert-info">
                    <i class="bi bi-key"></i> Get your API key from: 
                    <a href="https://makersuite.google.com/app/apikey" target="_blank" class="alert-link">Google AI Studio</a>
                </div>
            </div>
        </div>

        <div class="card mb-4">
            <div class="card-body">
                <h2><i class="bi bi-image"></i> Image Generation with Stability AI</h2>
                <p>Create custom images from text descriptions using Stability AI's powerful image generation model.</p>

                <h5>Features:</h5>
                <ul>
                    <li>Text-to-image generation</li>
                    <li>Customizable image dimensions</li>
                    <li>Multiple output formats</li>
                </ul>

                <h5>Implementation:</h5>
                <p>The image generation functionality is implemented in:</p>
                <code>AITutorial/Utils/ImageModel.cs</code>

                <div class="alert alert-info">
                    <i class="bi bi-key"></i> Get your API key from: 
                    <a href="https://platform.stability.ai/docs/getting-started" target="_blank" class="alert-link">Stability AI Platform</a>
                </div>
            </div>
        </div>

        <div class="card mb-4">
            <div class="card-body">
                <h2><i class="bi bi-mic"></i> Speech Synthesis with ElevenLabs</h2>
                <p>Convert text to natural-sounding speech using ElevenLabs' advanced text-to-speech technology.</p>

                <h5>Features:</h5>
                <ul>
                    <li>High-quality voice synthesis</li>
                    <li>Multiple voice options</li>
                    <li>Natural-sounding output</li>
                </ul>

                <h5>Implementation:</h5>
                <p>The speech synthesis functionality is implemented in:</p>
                <code>AITutorial/Utils/SpeechModel.cs</code>

                <div class="alert alert-info">
                    <i class="bi bi-key"></i> Get your API key from: 
                    <a href="https://elevenlabs.io/app/settings/api-keys" target="_blank" class="alert-link">ElevenLabs Dashboard</a>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="card-body">
                <h2><i class="bi bi-gear"></i> Configuration</h2>
                <p>Add your API keys to Web.config:</p>
                <pre class="bg-light p-3 rounded"><code>&lt;appSettings&gt;
    &lt;add key="Gemini_ApiKey" value="your_gemini_key" /&gt;
    &lt;add key="Stability_ApiKey" value="your_stability_key" /&gt;
    &lt;add key="ElevenLabs_ApiKey" value="your_elevenlabs_key" /&gt;
&lt;/appSettings&gt;</code></pre>
            </div>
        </div>
    </div>
</asp:Content>