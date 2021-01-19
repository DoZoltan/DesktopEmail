using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Models
{
    class IncomingEmails
    {
        public List<Email> IncomingEmailsList = new List<Email>();
        
        public IncomingEmails() { }

        public void AddEmailToIncomingEmailsList(Email email)
        {
            IncomingEmailsList.Add(email);
        }

        public List<Email> GetIncomingEmails()
        {
            return this.IncomingEmailsList;
        }
    }
}
