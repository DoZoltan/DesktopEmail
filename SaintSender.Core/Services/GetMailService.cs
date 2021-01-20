using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using SaintSender.Core.Interfaces;

namespace SaintSender.Core.Services
{
    class GetMailService : IGetMailService
    {
		private string From = "kumkvatmailcool@gmail.com";
		private string Password = "kumkvatmail";
		public void GetMessage()
		{
			using (var client = new ImapClient())
			{
				client.Connect("imap.gmail.com", 993, true);

				client.Authenticate(From, Password);

				// The Inbox folder is always available on all IMAP servers...
				var inbox = client.Inbox;
				inbox.Open(FolderAccess.ReadOnly);

				Console.WriteLine("Total messages: {0}", inbox.Count);
				Console.WriteLine("Recent messages: {0}", inbox.Recent);

				for (int i = 0; i < inbox.Count; i++)
				{
					var message = inbox.GetMessage(i);
					Console.WriteLine("Subject: {0}", message.Subject);
					Console.WriteLine("Body: {0}", message.HtmlBody);
					Console.WriteLine("Date: {0}", message.Date);
				}

				client.Disconnect(true);
			}
		}
	}
}
