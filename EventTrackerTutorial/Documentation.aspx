<%@ Page Title="Documentation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentation.aspx.cs" Inherits="EventTrackerTutorial.Documentation" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1 class="display-4">Documentation</h1>
            
            <div class="card mb-4">
                <div class="card-body">
                    <h2>Developer Overview</h2>
                    <p>The Event Tracker system enables developers to monitor and analyze user interactions within their applications. Integration with devharmony.io provides powerful analytics and visualization capabilities.</p>
                    
                    <h3 class="mt-4">Key Features for Developers</h3>
                    <ul>
                        <li>Real-time event tracking</li>
                        <li>Interactive analytics dashboard</li>
                    </ul>

                    <div class="alert alert-warning mb-4">
                        <h4 class="alert-heading"><i class="bi bi-exclamation-triangle"></i> Important Setup Requirement</h4>
                        <p>Before using the Event Tracker, you need to obtain a School ID from devharmony.io:</p>
                        <ol>
                            <li>Register at <a href="https://devharmony.io" target="_blank">devharmony.io</a></li>
                            <li>Navigate to your school settings</li>
                            <li>Copy your unique School ID</li>
                            <li>Replace <code>your_school_id</code> in the EventTracker configuration</li>
                        </ol>
                        <hr>
                        <p class="mb-0">Your events won't be tracked without a valid School ID. Contact tableharmony123@gmail.com if you need assistance.</p>
                    </div>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2><i class="bi bi-code-square"></i> Implementation Guide</h2>
                    <div class="alert alert-info">
                        <h5><i class="bi bi-lightbulb"></i> Quick Start:</h5>
                        <ol>
                            <li>Initialize the event tracker in your application</li>
                            <li>Define custom event properties</li>
                            <li>Track events using the provided API</li>
                            <li>View analytics in devharmony.io dashboard</li>
                        </ol>
                    </div>

                    <h4 class="mt-4">Analytics Features</h4>
                    <ul>
                        <li><strong>Real-time Monitoring:</strong> Track user actions as they happen</li>
                        <li><strong>Custom Dashboards:</strong> Create personalized analytics views</li>
                        <li><strong>Event Filtering:</strong> Filter events by type, date, or custom properties</li>
                        <li><strong>Data Visualization:</strong> Generate charts and graphs from event data</li>
                        <li><strong>Export Options:</strong> Download event data in various formats</li>
                    </ul>
                </div>
            </div>

            <div class="card mb-4">
                <div class="card-body">
                    <h2>Integration with devharmony.io</h2>
                    <p>The Event Tracker seamlessly integrates with devharmony.io to provide:</p>
                    <ul>
                        <li><strong>Interactive Dashboards:</strong> Visual representation of event data</li>
                        <li><strong>Custom Reports:</strong> Generate detailed analytics reports</li>
                        <li><strong>API Access:</strong> Programmatic access to event data</li>
                        <li><strong>Real-time Updates:</strong> Live event tracking and notifications</li>
                    </ul>

                    <div class="alert alert-success mt-3">
                        <h5><i class="bi bi-graph-up"></i> Analytics Dashboard</h5>
                        <p>View your application's analytics at: <a href="https://devharmony.io" target="_blank">devharmony.io/dashboard</a></p>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-body">
                    <h2>Example Usage</h2>
                    <p>Track various types of events in your application:</p>
                    <ul>
                        <li>User interactions (clicks, form submissions)</li>
                        <li>System events (errors, warnings)</li>
                        <li>Business events (purchases, registrations)</li>
                        <li>Custom events (specific to your application)</li>
                    </ul>

                    <div class="alert alert-info mt-3">
                        <h5><i class="bi bi-code-slash"></i> Sample Implementation:</h5>
                        <pre><code>// Track a custom event 
await eventTracker.TrackEventAsync("User logged in");</code></pre>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>