# Message Senders Tutorial

Implementation of various messaging services in ASP.NET Web Forms.

## Features

- Email Integration (SMTP)
- SMS Messaging (Twilio)
- WhatsApp Integration
- Message Templates

## Components

### Email Features

- SMTP server integration
- HTML email support
- File attachments
- Email templates

### SMS Features

- Twilio API integration
- Message scheduling
- Delivery status tracking
- Bulk messaging support

### WhatsApp Features

- WhatsApp Business API
- Message templates
- Media message support
- Contact management

## Configuration

API keys and credentials needed:

- SMTP Server credentials
- Twilio API keys
- WhatsApp Business API access

## Implementation

Core functionality is implemented in dedicated utility classes:

- `Utils/EmailSender.cs`
- `Utils/SmsSender.cs`
- `Utils/WhatsAppSender.cs`
