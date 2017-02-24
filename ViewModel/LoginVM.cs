using PaskiPlacowe.BaseClasses;
using PaskiPlacowe.Events;
using PaskiPlacowe.Utils;
using Prism.Commands;
using Prism.Events;
using System;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
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
        private DelegateCommand _AddNewUser;
        #endregion
        public LoginVM(IEventAggregator eventAggregator) :base(eventAggregator)
        {
            _LogInUser = new DelegateCommand(LogInUserFunc, CanLogIn);
            _Cancel = new DelegateCommand(CancelFunc);
            _AddNewUser = new DelegateCommand(AddNewUserFunc);
        }
        
        private Model.Uzytkownicy LoginBegin(bool AddingUser)
        {
            LoginErrMSG = String.Empty;
            if (this.Password != null)
                this.Password.MakeReadOnly();
            if (String.IsNullOrWhiteSpace(this.Login))
                throw new Exception(AddingUser ? Localization.Messages.MSG_LOGIN_REQUIRED: Localization.Messages.MSG_ERR_LOGIN_FAILED);
            return DB.Uzytkownicy.Where(a => a.LOGIN == this.Login).SingleOrDefault();
        }

        private void AddNewUserFunc()
        {
            try
            {
                if (LoginBegin(true)!=null)
                    throw new Exception(Localization.Messages.MSG_USER_ALREADY_EXISTS);
                using (var h = new SHA512Managed())
                {
                    Model.Uzytkownicy NewUser=new Model.Uzytkownicy()
                    {
                        NAZWA = this.Login,
                        LOGIN = this.Login,
                        HASLO = this.Password != null && !this.Password.IsNullOrWhiteSpace() ? this.Password.Process(h.ComputeHash) : null
                    };
                    DB.Uzytkownicy.Add(NewUser);
                    DB.SaveChanges();
                    LogIn(NewUser.ID_UZYTKOWNIKA); 
                }
                
            }
            catch (Exception Ex)
            {
                LoginErrMSG = Ex.Message;
            }
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
                Model.Uzytkownicy User = LoginBegin(true);
                if (User==null)
                    throw new Exception(Localization.Messages.MSG_USER_DONT_EXISTS);
                using (var h = new SHA512Managed())
                {
                    if ((this.Password != null && !this.Password.IsNullOrWhiteSpace() && User.HASLO!=null && User.HASLO.SequenceEqual(this.Password.Process(h.ComputeHash))) ||
                        ((this.Password==null || this.Password.IsNullOrWhiteSpace()) && User.HASLO==null))
                    {
                        LogIn(User.ID_UZYTKOWNIKA);
                    }
                    else
                        throw new Exception(Localization.Messages.MSG_USER_CREDENTIALS_INCORECT);
                }
            }
            catch (Exception Ex)
            {
                LoginErrMSG = Ex.Message;
            }
        }
        private void LogIn(long UserId)
        {
            eventAggregator.GetEvent<LoginEvent>().Publish(new LoginD() { Login=this.Login, UserId=UserId });
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
        public ICommand AddNewUser
        {
            get { return _AddNewUser; }
        }
        #endregion
    }
}
