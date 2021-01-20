using System;
using System.Collections.Generic;
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
    /// Interaction logic for InboxWindow.xaml
    /// </summary>
    public partial class InboxWindow : Window
    {
        private ViewModels.InboxWindowViewModel InboxWindowViewModel;
        private int ActualEmailRangeFrom = 25;
        private int EmailStepNumber = 25;

        public InboxWindow()
        {
            InboxWindowViewModel = new ViewModels.InboxWindowViewModel();
            
            InitializeComponent();
            
            this.MinHeight = 450;
            this.MinWidth = 1200;
            this.MaxHeight = 900;
            this.MaxWidth = 1900;

            DataContext = InboxWindowViewModel;
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
    }
}
