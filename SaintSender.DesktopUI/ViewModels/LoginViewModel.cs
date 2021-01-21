using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private CredentialService CredentialServiceObject = new CredentialService();
        private string _email;
        private string _password;


        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public bool CanLogIn(string email, string password)
        {
            bool output = false;
            if (email.Length > 0 && password.Length > 0)
            {
                output = true;
            }
            return output;
        }
    }
}
