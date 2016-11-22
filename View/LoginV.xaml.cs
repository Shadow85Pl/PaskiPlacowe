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

namespace PaskiPlacowe.View
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginV : UserControl
    {
        public LoginV()
        {
            InitializeComponent();
        }

        private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is ViewModel.LoginVM)
                (this.DataContext as ViewModel.LoginVM).Password = (sender as PasswordBox).SecurePassword;
        }
    }
}
