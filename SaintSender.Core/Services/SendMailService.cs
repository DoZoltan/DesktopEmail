using MailKit.Net.Smtp;
using MimeKit;
using SaintSender.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    public class SendMailService : ISendMailService
    {
        private string From = "kumkvatmailcool@gmail.com";
        private string Password = "kumkvatmail";
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
                client.Connect("smtp.gmail.com", 587, true);
                client.Authenticate(From, Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
