using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SendersTutorial.Utils {
    /// <summary>
    /// WhatsApp sender implementation using Twilio.
    /// Important:
    /// - Requires WhatsApp Business API approval
    /// - Must use a verified WhatsApp Business number
    /// - Test accounts limited to message templates
    /// - Recipients must opt-in to receive messages
    /// </summary>
    public class WhatsAppSender : ISender<WhatsAppMessage> {
        private readonly string _accountSid;
        private readonly string _authToken;

        public WhatsAppSender() {
            _accountSid = ConfigurationManager.AppSettings["Twilio_AccountSid"];
            _authToken = ConfigurationManager.AppSettings["Twilio_AuthToken"];

            TwilioClient.Init(_accountSid, _authToken);
        }

        public async Task<bool> SendAsync(WhatsAppMessage message) {
            try {
                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber($"whatsapp:{message.To}")) {
                    From = new PhoneNumber($"whatsapp:{message.From}"),
                    Body = message.Content
                };

                var whatsappMessage = await MessageResource.CreateAsync(messageOptions);

                message.Status = whatsappMessage.Status.ToString();
                return true;
            } catch (Exception) {
                message.Status = "Failed";
                return false;
            }
        }
    }
}