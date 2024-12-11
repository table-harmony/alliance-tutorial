using SendersTutorial.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SendersTutorial {
    public partial class Email : System.Web.UI.Page {
        protected readonly EmailSender _emailSender = new EmailSender();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected async void SendButton_Click(object sender, EventArgs e) {
            try {
                var message = new EmailMessage {
                    From = FromInput.Text,
                    To = ToInput.Text,
                    Subject = SubjectInput.Text,
                    Content = MessageInput.Text
                };

                bool success = await _emailSender.SendAsync(message);

                StatusLabel.Text = success ? "Email sent successfully!" : "Failed to send email";
            } catch (Exception ex) {
                StatusLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}