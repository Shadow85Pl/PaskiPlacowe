using PaskiPlacowe.BaseClasses;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaskiPlacowe.ViewModel
{
    internal class LoginVM: BaseViewModelClass
    {
        #region private Variables
        private string _Login;
        private SecureString _Password;
        private string _LoginERRMsg;
        #endregion
        #region Commands
        private DelegateCommand _LogInUser;
        private DelegateCommand _Cancel;
        #endregion
        public LoginVM()
        {
            _LogInUser = new DelegateCommand(LogInUserFunc, CanLogIn);
            _Cancel = new DelegateCommand(CancelFunc);
        }

        private void CancelFunc()
        {
            // TODO: Cancel function with close app
            throw new NotImplementedException();
        }

        private bool CanLogIn()
        {
            return !String.IsNullOrWhiteSpace(this.Login);
        }

        private void LogInUserFunc()
        {
            try
            {

                if (String.IsNullOrWhiteSpace(this.Login))
                  throw new Exception(Localization.Strings.MSG_ERR_LOGIN_FAILED);

            }
            catch (Exception Ex)
            {
                Password = null;
                _LoginERRMsg = Ex.Message;
            }
        }
        #region Properties
        public string Login
        {
            get { return _Login; }
            set { SetProperty(ref _Login, value);
                _LogInUser.RaiseCanExecuteChanged();
            }
        }
        public SecureString Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        public string LoginErrMSG
        {
            get
            {
                return _LoginERRMsg;
            }
            set
            {
                SetProperty(ref _LoginERRMsg, value);
            }
        }
        public ICommand LogInUser
        {
            get { return _LogInUser; }
        }
        public ICommand Cancel
        {
            get { return _Cancel; }
        }
        #endregion
    }
}
