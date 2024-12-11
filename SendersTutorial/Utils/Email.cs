using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SendersTutorial.Utils {
    /// <summary>
    /// Email sender implementation using SMTP.
    /// Important: You can only send emails from addresses owned by your SMTP server account.
    /// For Gmail: Requires 2FA and App Password.
    /// </summary>
    public class EmailSender : ISender<EmailMessage> {
        private readonly SmtpClient _smtpClient;

        public EmailSender() {
            var host = ConfigurationManager.AppSettings["Smtp_Host"];
            var port = int.Parse(ConfigurationManager.AppSettings["Smtp_Port"]);
            var username = ConfigurationManager.AppSettings["Smtp_Username"];
            var password = ConfigurationManager.AppSettings["Smtp_Password"];

            _smtpClient = new SmtpClient(host, port) {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
        }

        public async Task<bool> SendAsync(EmailMessage message) {
            try {
                var mailMessage = new MailMessage {
                    From = new MailAddress(message.From),
                    Subject = message.Subject,
                    Body = message.Content,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(message.To);

                foreach (var attachment in message.Attachments) {
                    mailMessage.Attachments.Add(attachment);
                }

                await _smtpClient.SendMailAsync(mailMessage);

                message.Status = "Sent";
                return true;
            } catch (Exception) {
                message.Status = "Failed";
                return false;
            }
        }
    }
}