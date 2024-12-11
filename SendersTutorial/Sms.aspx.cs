using SendersTutorial.Utils;
using System;

namespace SendersTutorial {
    public partial class SMS : System.Web.UI.Page {
        private readonly SMSSender _smsSender = new SMSSender();

        protected async void SendButton_Click(object sender, EventArgs e) {
            try {
                var message = new SMSMessage {
                    From = FromInput.Text,
                    To = ToInput.Text,
                    Content = MessageInput.Text
                };

                bool success = await _smsSender.SendAsync(message);
                StatusLabel.Text = success ? "SMS sent successfully!" : "Failed to send SMS";
            } catch (Exception ex) {
                StatusLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}