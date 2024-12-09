<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="UploadFile2.aspx.cs" Inherits="WebApplication1.UploadFile2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="uploadForm" method="post" enctype="multipart/form-data" runat="server">
        <div>
            <h2>File Upload Using Form Submit</h2>
            <input type="file" name="fileUpload" id="fileUpload" runat="server" />
            <br /><br />
            <input type="submit" name="submit" id="submit" value="Upload File" runat="server" />
            <br /><br />
            <asp:Label ID="StatusLabel" runat="server" Text="" />
        </div>
    </form>
</body>
</html>
