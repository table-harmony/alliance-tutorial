using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Utils;

namespace WebApplication1 {
    public partial class AllEvents : System.Web.UI.Page {
        protected async void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) 
                GetEvents();
        }

        protected async void GetEvents() {
            try {
                var eventTracker = new EventTracker();
                var events = await eventTracker.GetEventsAsync();

                StringBuilder html = new StringBuilder();
                html.Append("<h2>All Events</h2>");

                if (events.Count == 0) {
                    html.Append("<p>No events found.</p>");
                } else {
                    html.Append("<table border='1'>");
                    html.Append("<tr><th>Event Key</th><th>Creation Time</th></tr>");

                    foreach (var evt in events) {
                        html.Append("<tr>");
                        html.AppendFormat("<td>{0}</td>", evt.Key);
                        html.AppendFormat("<td>{0}</td>", evt.CreationTime.ToString("g"));
                        html.Append("</tr>");
                    }

                    html.Append("</table>");
                }

                html.Append("<br/><a href='TrackEvent.aspx'>Track New Event</a>");
                eventsContainer.InnerHtml = html.ToString();
            } catch (Exception ex) {
                eventsContainer.InnerHtml = $"<p style='color: red;'>Error loading events: {ex.Message}</p>";
            }
        }
    }
}