using MahApps.Metro.Controls;
using Prism.Interactivity.InteractionRequest;
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

namespace PaskiPlacowe.InteractionRequest
{
    /// <summary>
    /// Interaction logic for MetroNotificationWindow.xaml
    /// </summary>
    public partial class MetroNotificationWindow : MetroWindow
    {
        /// <summary>
        /// Creates a new instance of <see cref="DefaultNotificationWindow"/>
        /// </summary>
        public MetroNotificationWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets or gets the <see cref="INotification"/> shown by this window./>
        /// </summary>
        public INotification Notification
        {
            get
            {
                return this.DataContext as INotification;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
