using SendersTutorial.Utils;
using System;

namespace SendersTutorial {
    public partial class WhatsApp : System.Web.UI.Page {
        private readonly WhatsAppSender _whatsappSender = new WhatsAppSender();

        protected async void SendButton_Click(object sender, EventArgs e) {
            try {
                var message = new WhatsAppMessage {
                    From = FromInput.Text,
                    To = ToInput.Text,
                    Content = MessageInput.Text
                };

                bool success = await _whatsappSender.SendAsync(message);
                StatusLabel.Text = success ? "WhatsApp message sent successfully!" : "Failed to send message";
            } catch (Exception ex) {
                StatusLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}