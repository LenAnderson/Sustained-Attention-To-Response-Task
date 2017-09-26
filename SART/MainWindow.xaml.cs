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

namespace SART
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SustainedAttentionToResponseTask sart;
        public MainWindow()
        {
            InitializeComponent();
            sart = new SustainedAttentionToResponseTask();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            SARTWindow sartWindow = new SARTWindow(sart);
            sartWindow.Show();
            sartWindow.Closed += sartWindow_Closed;
        }

        private void sartWindow_Closed(object sender, EventArgs e)
        {
            LogWindow logWindow = new LogWindow(sart);
            logWindow.ShowDialog();
        }
    }
}
