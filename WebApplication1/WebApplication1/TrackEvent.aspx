<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="TrackEvent.aspx.cs" Inherits="WebApplication1.TrackEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Track Event</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Track Event</h2>
            <input type="text" name="eventKey" id="eventKey" runat="server" />
            <br /><br />
            <input type="submit" name="submit" id="submit" runat="server" />
            <br /><br />
            <asp:Label ID="StatusLabel" runat="server" Text="" />
        </div>
    </form>
    <br /><br />
    <a href="AllEvents.aspx">All events</a>
</body>
</html>
