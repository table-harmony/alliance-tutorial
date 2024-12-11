<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SteganographyTutorial.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Steganography Tutorial</h1>
            <p class="lead">Learn how to hide and extract secret messages within image files using steganography techniques.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title mt-2"><i class="bi bi-shield-lock"></i> Tutorial Features</h5>
                    <ul>
                        <li>Hide text messages within image files</li>
                        <li>Extract hidden messages from encoded images</li>
                        <li>Non-destructive LSB encoding</li>
                        <li>Support for various image formats</li>
                        <li>Secure message embedding</li>
                    </ul>
                </div>
            </div>

            <div class="row mb-4">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-file-earmark-lock2"></i> Encode Image
                            </h5>
                            <p class="card-text">Hide your secret message within an image file using LSB steganography.</p>
                            <a href="EncodeFile.aspx" class="btn btn-primary">
                                <i class="bi bi-pencil-square"></i> Encode Message
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">
                                <i class="bi bi-file-earmark-text"></i> Decode Image
                            </h5>
                            <p class="card-text">Extract hidden messages from previously encoded image files.</p>
                            <a href="DecodeFile.aspx" class="btn btn-primary">
                                <i class="bi bi-eye"></i> Decode Message
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