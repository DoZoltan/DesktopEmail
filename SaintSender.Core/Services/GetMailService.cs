using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using SaintSender.Core.Models;

namespace SaintSender.Core.Services
{
    public class GetMailService
    {
        ImapClient _client;
        //private string From = "kumkvatmailcool@gmail.com";
        //private string Password = "kumkvatmail";

        public void ConnectingToIMAPService(string username, string password)
        {
            this._client = new ImapClient();

            try
            {
                _client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                _client.Connect("imap.gmail.com", 993, true);
                _client.Authenticate(username, password);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Failed to connect: {e}");
            }
        }

        public void Disconnect()
        {
            _client.Disconnect(true);
        }

        public bool AuthenticateIsCorrect()
        {
            if (_client != null)
            {
                return _client.IsAuthenticated;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<EmailModel>> GetEmailMessagesAsync()
        {
            var resultEmails = new List<EmailModel>();

            if (AuthenticateIsCorrect())
            {
                var inbox = _client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);

                var summaries = inbox.Fetch(0, -1, MessageSummaryItems.UniqueId 
                    | MessageSummaryItems.Size | MessageSummaryItems.Flags);

                foreach (var summary in summaries)
                {
                    IList<IMessageSummary> info = 
                        inbox.Fetch(new[] { summary.UniqueId }, MessageSummaryItems.Flags 
                        | MessageSummaryItems.GMailLabels);

                    var email = await inbox.GetMessageAsync(summary.UniqueId);

                    resultEmails.Add(
                        new EmailModel(
                            email.From.ToString(), email.Subject, email.Date.DateTime,
                            GetEmailIsChecked(info), email.GetTextBody(MimeKit.Text.TextFormat.Html)));
                }
            }
            return resultEmails;
        }

        public List<EmailModel> GetEmailMessages()
        {
            var resultEmails = new List<EmailModel>();

            if (AuthenticateIsCorrect())
            {
                var inbox = _client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);

                var summaries = inbox.Fetch(0, -1, MessageSummaryItems.UniqueId
                    | MessageSummaryItems.Size | MessageSummaryItems.Flags);

                foreach (var summary in summaries)
                {
                    IList<IMessageSummary> info =
                        inbox.Fetch(new[] { summary.UniqueId }, MessageSummaryItems.Flags
                        | MessageSummaryItems.GMailLabels);

                    var email = inbox.GetMessage(summary.UniqueId);

                    resultEmails.Add(
                        new EmailModel(
                            email.From.ToString(), email.Subject, email.Date.DateTime,
                            GetEmailIsChecked(info), email.GetTextBody(MimeKit.Text.TextFormat.Plain)));
                }
            }
            return resultEmails;
        }

        private bool GetEmailIsChecked(IList<IMessageSummary> info)
        {
            return (info[0].Flags.Value.HasFlag(MessageFlags.Seen));
        }
    }
}
