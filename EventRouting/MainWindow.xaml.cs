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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventRouting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            Tbl_Output.Text += $"{(sender as FrameworkElement)?.Name}: Click\n";
        }

        private void Wnd_Main_Click(object sender, RoutedEventArgs e)
        {
            Tbl_Output.Text += $"{(sender as FrameworkElement)?.Name}: ButtonBase-Click\n";
        }

        private void Spl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Tbl_Output.Text += $"{(sender as FrameworkElement)?.Name}: Preview/Tunnel\n";
        }

        private void Spl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Tbl_Output.Text += $"{(sender as FrameworkElement)?.Name}: Bubble\n";
        }
    }
}
