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
using SaintSender.Core.Models;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for NewEmailWindow.xaml
    /// </summary>
    public partial class NewEmailWindow : Window
    {
        NewEmailWindowViewModel newEmailWindowViewModel = new NewEmailWindowViewModel();
        TextFillingModel textFilling = new TextFillingModel();

        public NewEmailWindow()
        {
            InitializeComponent();
            DataContext = textFilling;
        }

        public NewEmailWindow(EmailModel emailModel)
        {
            InitializeComponent();
            DataContext = emailModel;
        }

        public void BodyText_Hide(object sender, RoutedEventArgs e)
        {
            if (Text.Text == "Text body")
                Text.Text = "";
        }

        public void BodyText_Show(object sender, RoutedEventArgs e)
        {
            if (Text.Text == "")
                Text.Text = "Text body";
        }

        public void SubjectText_Hide(object sender, RoutedEventArgs e)
        {
            if (Subject.Text == "Subject")
                Subject.Text = "";
        }

        public void SubjectText_show(object sender, RoutedEventArgs e)
        {
            if (Subject.Text == "")
                Subject.Text = "Subject";
        }

        public void MailingAddressText_Hide(object sender, RoutedEventArgs e)
        {
            if (MailingAddress.Text == "Mailing address")
                MailingAddress.Text = "";
            WrongEmail.Visibility = Visibility.Hidden;
        }

        public void MailingAddresText_Show(object sender, RoutedEventArgs e)
        {
            if (MailingAddress.Text == "")
                MailingAddress.Text = "Mailing address";
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidEmail(MailingAddress.Text))
            {
                WrongEmail.Visibility = Visibility.Visible;
            }
            else
            {
                newEmailWindowViewModel.SendEmail(MailingAddress.Text, Subject.Text, Text.Text);
                this.Close();
            }
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
    }
}