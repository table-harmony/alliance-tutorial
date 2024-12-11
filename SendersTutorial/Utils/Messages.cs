using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace SendersTutorial.Utils {
    public abstract class Message {
        public string Content { get; set; }
        public string Status { get; set; }
    }

    public class EmailMessage : Message {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
    }

    public class SMSMessage : Message {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class WhatsAppMessage : Message {
        public string From { get; set; }
        public string To { get; set; }
    }
}