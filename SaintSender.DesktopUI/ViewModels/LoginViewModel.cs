using SaintSender.Core.Services;
using SaintSender.DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SaintSender.DesktopUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private CredentialService CredentialServiceObject = new CredentialService();
        private string _email;
        private string _password;
        GetMailService mailService = new GetMailService();


        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        public void SignIn(string emailTxt, string passwordTxt, CheckBox stayLoggedIn)
        {
            mailService.ConnectingToIMAPService(emailTxt, passwordTxt);
            if (mailService.AuthenticateIsCorrect())
            {
                if ((bool)stayLoggedIn.IsChecked)
                {

                    CredentialServiceObject.SaveCredentials(emailTxt, passwordTxt);
                }

                InboxWindow inboxWindow = new InboxWindow(mailService);
                inboxWindow.Show();
            }
            else { throw new ArgumentException(); }
        }

        public void SignIn(string emailTxt, string passwordTxt)
        {
            mailService.ConnectingToIMAPService(emailTxt, passwordTxt);

            if (mailService.AuthenticateIsCorrect())
            {
                InboxWindow inboxWindow = new InboxWindow(mailService);
                inboxWindow.Show();
            }
            else { throw new ArgumentException(); }
        }

        bool CanAuthenticate(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
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

        internal bool SignInWithCredentials()
        {
            string[] credentials = CredentialServiceObject.GetSavedCredentials();
            if (credentials != null)
            {
                _email = credentials[0];
                _password = credentials[1];
                SignIn(Email, Password);
                return true;
            }
            return false;
        }
    }
}
