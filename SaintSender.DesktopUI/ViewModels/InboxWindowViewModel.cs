using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaintSender.Core.Models;

namespace SaintSender.DesktopUI.ViewModels
{
    class InboxWindowViewModel : ViewModelBase
    {
        private ObservableCollection<FakeModel> _fakeModelCollection;
        public ObservableCollection<FakeModel> FakeModelCollection 
        {
            get { return _fakeModelCollection; }
            set { SetProperty(ref _fakeModelCollection, value); }
        }

        public InboxWindowViewModel() 
        {
            FakeModelCollection = new ObservableCollection<FakeModel>();
            FakeModelCollection.Add(new FakeModel("sender", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender1", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender2", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender3", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender5", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender4", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender6", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender8", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender7", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender9", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender9", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender7", "subject", "date", "read"));
            FakeModelCollection.Add(new FakeModel("sender8", "subject", "date", "read"));
        }
    }
}
