using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SendersTutorial.Utils {
    /// <summary>
    /// SMS sender implementation using Twilio.
    /// Important: 
    /// - Must use a verified Twilio phone number as sender
    /// - Test accounts can only send to verified numbers
    /// - Message pricing varies by country
    /// </summary>
    public class SMSSender : ISender<SMSMessage> {
        public SMSSender() {
            var accountSid = ConfigurationManager.AppSettings["Twilio_AccountSid"];
            var authToken = ConfigurationManager.AppSettings["Twilio_AuthToken"];

            TwilioClient.Init(accountSid, authToken);
        }

        public async Task<bool> SendAsync(SMSMessage message) {
            try {
                var smsMessage = await MessageResource.CreateAsync(
                    body: message.Content,
                    from: new PhoneNumber(message.From),
                    to: new PhoneNumber(message.To)
                );

                message.Status = smsMessage.Status.ToString();
                return true;
            } catch (Exception) {
                message.Status = "Failed";
                return false;
            }
        }
    }
}