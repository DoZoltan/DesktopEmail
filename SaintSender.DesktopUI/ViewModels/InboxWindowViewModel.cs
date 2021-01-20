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
        
        private ObservableCollection<FakeModel> _fakeModelCollection;
        public ObservableCollection<FakeModel> FakeModelCollection 
        private List<FakeModel> _fullEmailList;
        public List<FakeModel> FullEmailList 

        {
            get { return _fullEmailList; }
            private set { _fullEmailList = value; }
        }

        private ObservableCollection<FakeModel> _actualMailCollection;
        public ObservableCollection<FakeModel> ActualMailCollection 
        {
            get { return _actualMailCollection; }
            set { SetProperty(ref _actualMailCollection, value); }
        }

        public InboxWindowViewModel() 
        {
            FullEmailList = new List<FakeModel>();
            FullEmailList.Add(new FakeModel("sender0", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender1", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender2", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender3", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender4", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender5", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender6", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender7", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender8", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender9", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender10", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender11", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender12", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender13", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender14", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender15", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender16", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender17", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender18", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender19", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender20", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender21", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender22", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender23", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender24", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender25", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender26", "subject", "date", "read"));
            FullEmailList.Add(new FakeModel("sender27", "subject", "date", "read"));

            SetSpecificRangeOfEmails(0, 25);
        }
        
        public void SetSpecificRangeOfEmails(int from, int to)
        {
            ActualMailCollection = new ObservableCollection<FakeModel>();
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
