using SaintSender.Core.Services;
using SaintSender.DesktopUI.ViewModels;
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
        LoginViewModel LoginViewModel = new LoginViewModel();
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
            try
            {
                LoginViewModel.SignIn(EmailTxt, PasswordTxt);
                this.Close();
            }
            catch (ArgumentException)
            {
                WrongEmailOrPW.Visibility = Visibility.Visible;
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
