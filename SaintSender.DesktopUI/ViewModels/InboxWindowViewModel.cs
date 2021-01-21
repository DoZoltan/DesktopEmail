using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System.Windows.Threading;

namespace SaintSender.DesktopUI.ViewModels
{
    class InboxWindowViewModel : ViewModelBase
    {
        private SerializeEmailModelService serializeEmailModel;
        private int From = 0;
        private int To = 25;
        private bool Refresh;
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
            serializeEmailModel = new SerializeEmailModelService();
            FullEmailList = new List<EmailModel>();
            getMailService = new GetMailService();
            LoadSavedEmails();
            getMailService.ConnectingToIMAPService("kumkvatmailcool@gmail.com", "kumkvatmail");
            Refresh = true;
            Task.Run(() => GetEmailsAsync());


            //FullEmailList = getMailService.GetEmailMessages();
            //SetSpecificRangeOfEmails(0, 25);
        }

        public void DeleteEmails()
        {
            serializeEmailModel.DeleteSearchFile();
        }

        public string SaveEmails()
        {
            return serializeEmailModel.SerializeEmailList(FullEmailList);
        }

        public void LoadSavedEmails()
        {
            FullEmailList = serializeEmailModel.DeserializeEmails();
            if (FullEmailList.Count > 0)
            {
                SetSpecificRangeOfEmails(From, To);
            }
        }

        public void SetSpecificRangeOfEmails(int from, int to)
        {
            From = from;
            To = to;
            ActualMailCollection = new ObservableCollection<EmailModel>();
            for (int i = From; i < to; i++)
            {
                if (from > -1 && FullEmailList.Count > i)
                {
                    FullEmailList = FullEmailList.OrderByDescending(x => x.Date).ToList();
                    ActualMailCollection.Add(FullEmailList[i]);
                }
            }
        }

        private async Task GetEmailsAsync()
        {
            if (Refresh)
            {

                while (Refresh && OnlineChecker.CheckIfComputerIsOnline())
                {

                    FullEmailList = await Task.Run(() => getMailService.GetEmailMessagesAsync());

                    //foreach (var item in from email in result
                    //                     where FullEmailList.Contains(email, new EmailComparer()) == false
                    //                     select email)
                    //{
                    //    FullEmailList.Add(item);
                    //}
                    SetSpecificRangeOfEmails(From, To);
                    await Task.Delay(5000);
                }
            }
            else
            {
                getMailService.Disconnect();
                
            }

        }

        public void DisconnectFromGmail()
        {
            Refresh = false;
        }
    }
}
