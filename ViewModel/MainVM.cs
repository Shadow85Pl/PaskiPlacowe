using PaskiPlacowe.BaseClasses;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaskiPlacowe.ViewModel
{
    internal class MainVM: BaseViewModelClass
    {
        #region Private Variables
        private BindableBase _currentPageViewModel = null;
        #endregion
        public MainVM()
        {
            _currentPageViewModel = new LoginVM();
           
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
        public LoginData LData
        {
            get
            {
                return LoginData.GetInstance();
            }
        }
    }
}
