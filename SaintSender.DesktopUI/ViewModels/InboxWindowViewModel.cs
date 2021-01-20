using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaintSender.Core.Models;
using SaintSender.Core.Services;

namespace SaintSender.DesktopUI.ViewModels
{
    class InboxWindowViewModel : ViewModelBase
    {
        private List<EmailModel> _fullEmailList;
        public List<EmailModel> FullEmailList
        {
            get { return _fullEmailList; }
            private set { _fullEmailList = value; }
        }

        private ObservableCollection<EmailModel> _actualMailCollection;
        public ObservableCollection<EmailModel> ActualMailCollection
        {
            get { return _actualMailCollection; }
            set { SetProperty(ref _actualMailCollection, value); }
        }

        private GetMailService getMailService;

        public InboxWindowViewModel()
        {
            getMailService = new GetMailService();
            getMailService.ConnectingToIMAPService("kumkvatmailcool@gmail.com", "kumkvatmail");
            FullEmailList = getMailService.GetEmailMessages();

            SetSpecificRangeOfEmails(0, 25);
        }

        public void SetSpecificRangeOfEmails(int from, int to)
        {
            ActualMailCollection = new ObservableCollection<EmailModel>();
            for (int i = from; i < to; i++)
            {
                if (from > -1 && FullEmailList.Count > i)
                {
                    ActualMailCollection.Add(FullEmailList[i]);
                }
            }
        }
    }
}
