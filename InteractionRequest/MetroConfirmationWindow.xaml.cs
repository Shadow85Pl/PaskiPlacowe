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
    /// Interaction logic for MetroConfirmationWindow.xaml
    /// </summary>
    public partial class MetroConfirmationWindow : MetroWindow
    {
        /// <summary>
        /// Creates a new instance of ConfirmationChildWindow.
        /// </summary>
        public MetroConfirmationWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets or gets the <see cref="IConfirmation"/> shown by this window./>
        /// </summary>
        public IConfirmation Confirmation
        {
            get
            {
                return this.DataContext as IConfirmation;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Confirmation.Confirmed = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Confirmation.Confirmed = false;
            this.Close();
        }
    }
}

