using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Models
{
    public class FakeModel
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string Read { get; set; }

        public FakeModel(string sender, string subject, string date, string read)
        {
            Sender = sender;
            Subject = subject;
            Date = date;
            Read = read;
        }
    }
}
