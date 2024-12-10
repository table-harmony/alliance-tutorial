<%@ Page Async="true" Title="Track Event" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackEvent.aspx.cs" Inherits="EventTrackerTutorial.TrackEvent" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="h-100 d-flex align-items-center justify-content-center">
        <div class="col-md-8">
            <div class="card shadow-sm">
                <div class="card-header bg-primary text-white">
                    <h3 class="card-title mb-0">Track New Event</h3>
                </div>
                <div class="card-body">
                    <form id="form1" runat="server">
                        <div class="mb-4">
                            <label for="eventKey" class="form-label">Event Key</label>
                            <input type="text" name="eventKey" id="eventKey" class="form-control" runat="server" required />
                            <div class="form-text">Enter a key for your event</div>
                        </div>
                        <div class="mb-4">
                            <input type="submit" name="submit" value="Track Event" class="btn btn-primary" />
                        </div>
                        <asp:Label ID="StatusLabel" runat="server" Text="" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
