using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for InboxWindow.xaml
    /// </summary>
    public partial class InboxWindow : Window
    {
        private ViewModels.InboxWindowViewModel InboxWindowViewModel;
        private int ActualEmailRangeFrom = 25;
        private int EmailStepNumber = 25;

        public InboxWindow()
        {
            InitializeComponent();
            
            this.MinHeight = 450;
            this.MinWidth = 1200;
            this.MaxHeight = 900;
            this.MaxWidth = 1900;

            InboxWindowViewModel = new ViewModels.InboxWindowViewModel();
            DataContext = InboxWindowViewModel;
        }


        private void BackUp_Button(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(InboxWindowViewModel.SaveEmails());
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            LoadScreenWhileAsyncIsNotDone();
        }

        private void LoadScreenWhileAsyncIsNotDone() 
        {
            while (InboxWindowViewModel.ActualMailCollection == null || InboxWindowViewModel.ActualMailCollection.Count == 0)
            {
                emailScroll.Visibility = Visibility.Hidden;
                LoadScreen.Visibility = Visibility.Visible;
            }
            emailScroll.Visibility = Visibility.Visible;
            LoadScreen.Visibility = Visibility.Hidden;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            InboxWindowViewModel.SetSpecificRangeOfEmails(ActualEmailRangeFrom - EmailStepNumber, ActualEmailRangeFrom);
            if (ActualEmailRangeFrom - EmailStepNumber >= EmailStepNumber)
            {
                ActualEmailRangeFrom -= EmailStepNumber;
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            InboxWindowViewModel.SetSpecificRangeOfEmails(ActualEmailRangeFrom, ActualEmailRangeFrom + EmailStepNumber);
            if (ActualEmailRangeFrom + EmailStepNumber <= InboxWindowViewModel.FullEmailList.Count)
            {
                ActualEmailRangeFrom += EmailStepNumber;
            }
        }

        private void NewEmail_Button(object sender, RoutedEventArgs e)
        {
            NewEmailWindow newEmailWindow = new NewEmailWindow();
            newEmailWindow.Show();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EmailModel emailModel = (EmailModel)emailList.SelectedValue;
            EmailWindow emailWindow = new EmailWindow(emailModel);
            emailWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            login.Show();
            InboxWindowViewModel.DisconnectFromGmail();
            this.Close();
        }
    }
}
