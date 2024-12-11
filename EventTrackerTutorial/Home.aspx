<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EventTrackerTutorial.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Event Tracking Tutorial</h1>
            <p class="lead">Learn how to implement event tracking and analytics in your ASP.NET applications.</p>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title">Tutorial Features</h5>
                    <ul>
                        <li>Real-time Event Tracking</li>
                        <li>Event Analytics Dashboard</li>
                        <li>Custom Event Properties</li>
                        <li>Event History</li>
                    </ul>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Track Events</h5>
                            <p class="card-text">Create and track custom events in your application.</p>
                            <a href="TrackEvent.aspx" class="btn btn-primary">Track New Event</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">View Events</h5>
                            <p class="card-text">View and analyze all tracked events in your system.</p>
                            <a href="AllEvents.aspx" class="btn btn-primary">View All Events</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>