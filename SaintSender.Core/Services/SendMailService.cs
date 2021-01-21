using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    public class SendMailService
    {
        CredentialService CredentialServiceObject = new CredentialService();
        private string From;
        private string Password;
        public SendMailService()
        {
            string[] credentials = CredentialServiceObject.GetSavedCredentials();
            From = credentials[0];
            Password = credentials[1];

        }

        public void SendMessage(string to, string subject, string bodyText)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(From));
            message.To.Add(new MailboxAddress(to));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = bodyText
            };
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(From, Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
