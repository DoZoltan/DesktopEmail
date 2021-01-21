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

        private string _email;
        private string _password;
        private CredentialService CredentialServiceObject = new CredentialService();

        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        public void SignIn(TextBox emailTxt, PasswordBox passwordTxt)
        {
            if (IsValidEmail(emailTxt.Text) && passwordTxt.Password.Length >= 4)
            {

                InboxWindow inboxWindow = new InboxWindow();
                inboxWindow.Show();
            } 
            else { throw new ArgumentException(); }
        }

        bool IsValidEmail(string email)
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
    }
}
