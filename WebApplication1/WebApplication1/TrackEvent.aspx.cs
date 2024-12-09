using System;
using WebApplication1.Utils;

namespace WebApplication1 {
    public partial class TrackEvent : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["submit"] != null)
                HandleTrackEvent();   
        }

        public async void HandleTrackEvent() {
            try {
                if (string.IsNullOrEmpty(eventKey.Value)) {
                    StatusLabel.Text = "Please write a key.";
                    return;
                }

                var eventTracker = new EventTracker();  
                await eventTracker.TrackEventAsync(eventKey.Value);

                StatusLabel.Text = "Tracked successfully!";
            } catch (Exception ex) {
                StatusLabel.Text = "Tracking failed: " + ex.Message;
            }
        }
    }
}