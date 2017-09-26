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

namespace SART
{
    /// <summary>
    /// Interaction logic for SARTWindow.xaml
    /// </summary>
    public partial class SARTWindow : Window
    {
        protected SustainedAttentionToResponseTask sart;
        public SARTWindow(SustainedAttentionToResponseTask sart)
        {
            this.sart = sart;
            sart.Finished += Sart_Finished;
            InitializeComponent();
            DataContext = sart;
            sart.Start();
        }

        private void Sart_Finished(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                this.Close();
            }));
        }

        private void SART_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    sart.SpacePressed();
                    break;
                case Key.Escape:
                    sart.Abort();
                    this.Close();
                    break;
            }
        }
    }
}
