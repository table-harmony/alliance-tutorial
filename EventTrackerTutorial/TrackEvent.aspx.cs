using System;
using EventTrackerTutorial.Utils;

namespace EventTrackerTutorial {
    public partial class TrackEvent : System.Web.UI.Page {
        protected readonly EventTracker eventTracker = new EventTracker();

        protected void Page_Load(object sender, EventArgs e) {
            if (Request["submit"] != null) {
                HandleTrackEvent();
            }
        }

        private async void HandleTrackEvent() {
            try {
                if (string.IsNullOrEmpty(eventKey.Value)) {
                    StatusLabel.Text = "Please enter an event key.";
                    return;
                }

                await eventTracker.TrackEventAsync(eventKey.Value);
                StatusLabel.Text = "Event tracked successfully!";
            } catch (Exception ex) {
                StatusLabel.Text = "Tracking failed: " + ex.Message;
            }
        }
    }
}