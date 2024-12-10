<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="VerifyPassword.aspx.cs" Inherits="WebApplication1.VerifyPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verify Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Verify Password</h2>
            <div>
                <label for="PasswordInput">Enter Password:</label>
                <asp:TextBox ID="PasswordInput" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="VerifyButton" runat="server" Text="Verify Password" OnClick="VerifyButton_Click" />
            <br /><br />
            <asp:Label ID="StatusLabel" runat="server" Text="" />
        </div>
    </form>
</body>
</html>
