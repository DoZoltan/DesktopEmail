using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaintSender.Core.Services;

namespace SaintSender.DesktopUI.ViewModels
{
    class NewEmailWindowViewModel : ViewModelBase
    {
        private SendMailService mailService = new SendMailService();

        public void SendEmail(string emailTo, string subject, string text)
        {
            mailService.SendMessage(emailTo, subject, text);
        }
    }
}