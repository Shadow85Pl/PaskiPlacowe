using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaskiPlacowe.ViewModel
{
    internal class Main: BindableBase
    {
        #region Private Variables
        private BindableBase _currentPageViewModel = null;
        #endregion
        public Main()
        {
            _currentPageViewModel = new Login();
        }
        
        public BindableBase CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                SetProperty(ref _currentPageViewModel, value);
            }
        }
    }
}
