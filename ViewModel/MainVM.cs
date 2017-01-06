using PaskiPlacowe.BaseClasses;
using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PaskiPlacowe.Events;

namespace PaskiPlacowe.ViewModel
{
    internal class MainVM: BaseViewModelClass
    {
        #region Private Variables
        private BindableBase _currentPageViewModel = null;
        #endregion
        public MainVM():base(null)
        {
            eventAggregator = new EventAggregator();
            eventAggregator.GetEvent<LoginEvent>().Subscribe(OnLoginEvent);
            _currentPageViewModel = new LoginVM(eventAggregator);
        }

        private void OnLoginEvent(LoginD loginData)
        {
            LoginData.GetInstance().IsLoggedIn = true;
            LoginData.GetInstance().Login = loginData.Login;
            LoginData.GetInstance().UserId = loginData.UserId;
            OnPropertyChanged("LData");
            CurrentPageViewModel = new SalarySlipVM(eventAggregator);
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
        public int SalarySlipCount
        {
            get
            {
                return DB.PaskiPlacowe.Count();
            }
        }
    }
}
