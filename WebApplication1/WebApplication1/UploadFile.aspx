<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="WebApplication1.UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>File Upload</h2>
            <asp:FileUpload ID="FileUploadControl" runat="server" />
            <br /><br />
            <asp:Button ID="UploadButton" runat="server" Text="Upload File" OnClick="UploadButton_Click" />
            <br /><br />
            <asp:Label ID="StatusLabel" runat="server" Text="" />
        </div>
    </form>
</body>
</html>
