<%@ Page Title="Documentation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="SteganographyTutorial.Documentation" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Documentation</h1>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h2>What is Steganography?</h2>
                    <p>Steganography is the practice of concealing information within other non-secret data or carriers, typically multimedia files like images, audio, or video. Unlike encryption, which makes data unreadable, steganography hides the very existence of the secret message.</p>
                    
                    <h3 class="mt-4">LSB (Least Significant Bit) Technique</h3>
                    <p>This tutorial implements the LSB steganography technique, which works by manipulating the least significant bits of pixel data in an image. Here's how it works:</p>
                    <ul>
                        <li>Each pixel in an image consists of three color channels (Red, Green, Blue)</li>
                        <li>Each channel is represented by 8 bits (values from 0-255)</li>
                        <li>Changing the last bit (LSB) of a color value causes minimal visual change</li>
                        <li>We use these LSBs to store our hidden message</li>
                    </ul>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2>Encoding Process</h2>
                    <p>When encoding a message into an image, the following steps occur:</p>
                    <ol>
                        <li>Convert the secret message into binary (each character becomes 8 bits)</li>
                        <li>Process each pixel's color channels (R,G,B)</li>
                        <li>Replace the LSB of each color channel with a bit from our message</li>
                        <li>Add termination sequence (zeros) to mark message end</li>
                        <li>Save the modified image</li>
                    </ol>
                    
                    <div class="alert alert-info">
                        <h5><i class="bi bi-info-circle"></i> Example:</h5>
                        <p>Original pixel RGB: (100, 150, 200)<br>
                        Binary: (01100100, 10010110, 11001000)<br>
                        Message bit: 1<br>
                        Modified RGB: (01100101, 10010110, 11001000)</p>
                    </div>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2>Decoding Process</h2>
                    <p>To extract a hidden message from an encoded image:</p>
                    <ol>
                        <li>Read each pixel's color channels sequentially</li>
                        <li>Extract the LSB from each channel</li>
                        <li>Combine 8 bits to form a character</li>
                        <li>Continue until termination sequence is found</li>
                        <li>Convert binary data back to text</li>
                    </ol>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2>Practical Applications</h2>
                    <ul>
                        <li><strong>Digital Watermarking:</strong> Embedding copyright information in digital media</li>
                        <li><strong>Secure Communication:</strong> Transmitting sensitive information covertly</li>
                        <li><strong>Data Authentication:</strong> Verifying the integrity of digital content</li>
                        <li><strong>Privacy Protection:</strong> Hiding sensitive metadata in images</li>
                        <li><strong>Covert Storage:</strong> Storing confidential information within seemingly normal files</li>
                    </ul>

                    <div class="alert alert-warning mt-3">
                        <h5><i class="bi bi-shield-exclamation"></i> Important Considerations:</h5>
                        <ul>
                            <li>Message size is limited by image dimensions</li>
                            <li>Image compression may destroy hidden data</li>
                            <li>Use PNG format to preserve data integrity</li>
                            <li>Consider adding encryption for additional security</li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-body">
                    <h2>Implementation Details</h2>
                    <p>Our implementation uses C# and the System.Drawing namespace to manipulate image data. The core encoding logic can be found in the Steganography class:</p>
                    
                    <h5>Key Components:</h5>
                    <ul>
                        <li>Bitmap manipulation for pixel access</li>
                        <li>Binary conversion utilities</li>
                        <li>Stream handling for file operations</li>
                        <li>Error handling and validation</li>
                    </ul>
                    
                    <p>For the complete implementation, see the Steganography class in:</p>
                    <code>SteganographyTutorial/Utils/Steganography.cs</code>
                </div>
            </div>
        </div>
    </div>
</asp:Content>