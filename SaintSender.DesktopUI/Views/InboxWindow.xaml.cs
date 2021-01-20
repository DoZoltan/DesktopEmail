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

        public InboxWindow()
        {
            InboxWindowViewModel = new ViewModels.InboxWindowViewModel();
            
            InitializeComponent();
            
            this.MinHeight = 450;
            this.MinWidth = 800;
            this.MaxHeight = 900;

            DataContext = InboxWindowViewModel;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
