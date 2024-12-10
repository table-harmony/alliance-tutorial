using System;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventTrackerTutorial.Utils;

namespace EventTrackerTutorial {
    public partial class AllEvents : System.Web.UI.Page {
        protected readonly EventTracker eventTracker = new EventTracker();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                LoadEvents();
            }
        }

        protected async void LoadEvents() {
            try {
                var events = await eventTracker.GetEventsAsync();

                // Bind GridView
                EventsGridView.DataSource = events;
                EventsGridView.DataBind();

                // Prepare chart data
                var eventsByDate = events
                    .GroupBy(e => e.CreationTime.Date)
                    .OrderBy(g => g.Key)
                    .ToDictionary(
                        g => g.Key.ToString("MM/dd/yyyy"),
                        g => g.Count()
                    );

                var chartData = new {
                    labels = eventsByDate.Keys.ToArray(),
                    data = eventsByDate.Values.ToArray()
                };

                var serializer = new JavaScriptSerializer();
                var chartDataJson = serializer.Serialize(chartData);

                // Initialize chart
                ScriptManager.RegisterStartupScript(this, GetType(), "InitChart", 
                    $"initChart({chartDataJson});", true);
            }
            catch {
                
            }
        }

        protected void EventsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            EventsGridView.PageIndex = e.NewPageIndex;
            LoadEvents();
        }
    }
}