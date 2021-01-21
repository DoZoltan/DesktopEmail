using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Models
{
    public class TextFillingModel
    {
        public string Sender 
        {
            get { return "Mailing address"; }
            set { Sender = value; }
        }
        public string Message 
        {
            get { return "Message"; }
            set { Message = value; }
        }
        public DateTime Date 
        {
            get { return DateTime.Now; }
            set { Date = value; }
        }
        public bool Read 
        {
            get { return false; }
            set { Read = value; }
        }
        public string Subject 
        {
            get { return "Subject"; }
            set { Subject = value; }
        }
    }
}
