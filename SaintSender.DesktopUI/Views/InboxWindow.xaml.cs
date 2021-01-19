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
        public InboxWindow()
        {
            InitializeComponent();
            this.MinHeight = 450;
            this.MinWidth = 800;
            this.MaxHeight = 900;
            FillUpTheGridTest();
        }

        private void FillUpTheGridTest() 
        {
            int[] asd = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] df = { "a", "s", "d", "f", "u", "h", "d", "d", "r" };
            string[] dff = { "a", "s", "d", "f", "u", "h", "d", "d", "r" };
            string[] dgf = { "a", "s", "d", "f", "u", "h", "d", "d", "r" };

            for (int i = 0; i < asd.Length; i++)
            {
                TextBlock block1 = new TextBlock();
                TextBlock block2 = new TextBlock();
                TextBlock block3 = new TextBlock();
                TextBlock block4 = new TextBlock();
                
                block1.Text = asd[i].ToString();
                block2.Text = dff[i];
                block3.Text = df[i];
                block4.Text = dgf[i];

                block1.HorizontalAlignment = HorizontalAlignment.Center;
                block2.HorizontalAlignment = HorizontalAlignment.Center;
                block3.HorizontalAlignment = HorizontalAlignment.Center;
                block4.HorizontalAlignment = HorizontalAlignment.Center;

                block1.VerticalAlignment = VerticalAlignment.Center;
                block2.VerticalAlignment = VerticalAlignment.Center;
                block3.VerticalAlignment = VerticalAlignment.Center;
                block4.VerticalAlignment = VerticalAlignment.Center;

                block1.FontSize = 16;
                block2.FontSize = 16;
                block3.FontSize = 16;
                block4.FontSize = 16;

                myGrid.Children.Add(block1);
                myGrid.Children.Add(block2);
                myGrid.Children.Add(block3);
                myGrid.Children.Add(block4);
                
                Grid.SetColumn(block1, 0);
                Grid.SetColumn(block2, 1);
                Grid.SetColumn(block3, 2);
                Grid.SetColumn(block4, 3);

                Grid.SetRow(block1, i);
                Grid.SetRow(block2, i);
                Grid.SetRow(block3, i);
                Grid.SetRow(block4, i);
            }
        }
    }
}
