<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="VerifyPassword2.aspx.cs" Inherits="WebApplication1.VerifyPassword2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verify Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Verify Password (only image)</h2>
            <asp:FileUpload ID="FileUploadControl" runat="server" />
            <br /><br />
            <asp:Button ID="VerifyButton" runat="server" Text="Upload File" OnClick="VerifyButton_Click" />
            <br /><br />
            <asp:Label ID="StatusLabel" runat="server" Text="" />
        </div>
    </form>
</body>
</html>
