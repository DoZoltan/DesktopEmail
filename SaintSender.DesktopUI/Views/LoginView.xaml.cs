using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView(INotifyPropertyChanged ViewModel)
        {
            InitializeComponent();
            this.DataContext = ViewModel;
            this.Show();
            CheckIfComputerIsOnline();
        }

        public LoginView()
        {
            InitializeComponent();
            CheckIfComputerIsOnline();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            InboxWindow inboxWindow = new InboxWindow();
            inboxWindow.Show();
            this.Close();

            if (!IsValidEmail(EmailTxt.Text) || PasswordTxt.Password.Length < 4)
            {
                WrongEmailOrPW.Visibility = Visibility.Visible;
            }
            //else
            //{
            //    InboxWindow inboxWindow = new InboxWindow();
            //    inboxWindow.Show();
            //    this.Close();                
            //}
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

        private void CheckIfComputerIsOnline()
        {
            if (OnlineChecker.CheckIfComputerIsOnline())
            {
                Online.Text = "Online";
                Online.Background = new SolidColorBrush(Colors.LimeGreen);
            }
            else
            {
                Online.Text = "Offline";
                Online.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
