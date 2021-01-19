using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Interfaces
{
    interface ISendMailService
    {
        void SendMessage(string to, string subject, string bodyText);
    }
}
