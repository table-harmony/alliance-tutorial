<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="PasswordEncryption.aspx.cs" Inherits="WebApplication1.PasswordEncryption" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Password Encryption</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <div>
        <h2>Encrypt Password in Image</h2>
        <div>
          <label for="PasswordInput">Password:</label>
          <asp:TextBox ID="PasswordInput" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <br />
        <asp:Button
          ID="EncryptButton"
          runat="server"
          Text="Encrypt Password"
          OnClick="EncryptButton_Click"
        />
        <br /><br />
        <asp:Label ID="StatusLabel" runat="server" Text="" />
      </div>
      <div>
        <h3>Verify Password:</h3>
        <a href="VerifyPassword.aspx">Verify with text only</a>
        <br /><br />
        <a href="VerifyPassword2.aspx">Verify with image only</a>
      </div>
    </form>
  </body>
</html>
