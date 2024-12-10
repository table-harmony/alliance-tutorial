<%@ Page Async="true" Title="All Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllEvents.aspx.cs" Inherits="EventTrackerTutorial.AllEvents" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function initChart(chartData) {
            const ctx = document.getElementById('eventChart').getContext('2d');

            new Chart(ctx, {
                type: 'line',
                data: {
                    labels: chartData.labels,
                    datasets: [{
                        label: 'Events per Day',
                        data: chartData.data,
                        borderColor: 'rgb(13, 110, 253)',
                        backgroundColor: 'rgba(13, 110, 253, 0.1)',
                        tension: 0.1,
                        fill: true
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        title: {
                            display: true,
                            text: 'Event Frequency Over Time'
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true,
                            ticks: {
                                stepSize: 1
                            }
                        }
                    }
                }
            });
        }
    </script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="row">
            <div class="col-md-12">
                <div class="card shadow-sm mb-4">
                    <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
                        <h3 class="card-title mb-0">Event List</h3>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="EventsGridView" runat="server" CssClass="table table-striped" 
                            AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Key" HeaderText="Event Key" />
                                <asp:BoundField DataField="CreationTime" HeaderText="Creation Time" DataFormatString="{0:g}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            
            <div class="col-md-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-primary text-white">
                        <h3 class="card-title mb-0">Event Analytics</h3>
                    </div>
                    <div class="card-body">
                        <canvas id="eventChart" style="width: 100%; height: 400px;"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
