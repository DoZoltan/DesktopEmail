using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Models
{
    class Email
    {
        public string Sender { get; set; }
        public DateTime IncomingDate { get; set; }
        public string Subject { get; set; }
        public bool Read = false;
    public Email(string sender, DateTime date, string subject) 
        {
            this.Sender = sender;
            this.IncomingDate = date;
            this.Subject = subject;
        }

    public bool ReadOrUnread()
        {
            if (this.Read == false)
            {
                return this.Read = true;
            }
            else
            {
               return this.Read = false;
            }
        }
    }
}
