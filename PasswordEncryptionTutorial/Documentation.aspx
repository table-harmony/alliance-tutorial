<%@ Page Title="Documentation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="PasswordEncryptionTutorial.Documentation" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Documentation</h1>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h2>Password Hashing Overview</h2>
                    <p>Password hashing is a fundamental security practice that converts plain-text passwords into fixed-length strings of characters. Unlike encryption, hashing is a one-way function - the original password cannot be recovered from the hash.</p>
                    
                    <h3 class="mt-4">SHA256 Algorithm</h3>
                    <p>This tutorial implements SHA256 (Secure Hash Algorithm 256-bit), which:</p>
                    <ul>
                        <li>Produces a 256-bit (32-byte) hash value</li>
                        <li>Is part of the SHA-2 family of cryptographic hash functions</li>
                        <li>Generates unique hashes for different inputs</li>
                        <li>Is computationally infeasible to reverse</li>
                    </ul>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2>Implementation Process</h2>
                    <p>The password hashing process involves several steps:</p>
                    <ol>
                        <li>Generate a random salt for each password</li>
                        <li>Combine the password with the salt</li>
                        <li>Apply the SHA256 hashing algorithm</li>
                        <li>Store both the hash and salt securely</li>
                    </ol>
                    
                    <div class="alert alert-info">
                        <h5><i class="bi bi-info-circle"></i> Example:</h5>
                        <p>Password: "MySecurePass123"<br>
                        Salt: "a1b2c3d4"<br>
                        Combined: "MySecurePass123a1b2c3d4"<br>
                        Hash: "8f9d2c..." (64 characters)</p>
                    </div>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2>Security Best Practices</h2>
                    <ul>
                        <li><strong>Use Unique Salts:</strong> Generate a new salt for each password</li>
                        <li><strong>Secure Storage:</strong> Store hashes and salts in a secure database</li>
                        <li><strong>Never Store Plain Text:</strong> Always hash passwords before storage</li>
                        <li><strong>Implement Rate Limiting:</strong> Prevent brute-force attacks</li>
                        <li><strong>Use HTTPS:</strong> Protect passwords during transmission</li>
                    </ul>

                    <div class="alert alert-warning mt-3">
                        <h5><i class="bi bi-exclamation-triangle"></i> Important Considerations:</h5>
                        <ul>
                            <li>Hashed passwords cannot be recovered if lost</li>
                            <li>Always implement proper password reset functionality</li>
                            <li>Consider using additional security measures (2FA, etc.)</li>
                            <li>Regularly update security practices</li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-body">
                    <h2>Implementation Details</h2>
                    <p>Our implementation uses C# and the System.Security.Cryptography namespace. Key components include:</p>
                    
                    <h5>Core Components:</h5>
                    <ul>
                        <li>SHA256Managed for hash generation</li>
                        <li>RNGCryptoServiceProvider for salt generation</li>
                        <li>Base64 encoding for hash storage</li>
                        <li>Secure string comparison for verification</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>