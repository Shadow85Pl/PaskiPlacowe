using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaskiPlacowe.ViewModel
{
    internal class MainVM: BindableBase
    {
        #region Private Variables
        private BindableBase _currentPageViewModel = null;
        #endregion
        public MainVM()
        {
            _currentPageViewModel = new LoginVM();
            CheckDB();
        }

        private void CheckDB()
        {
            string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Consts.AppNameShort);
            if (!Directory.Exists(AppDataFolder))
                Directory.CreateDirectory(AppDataFolder);
            string DBPath = Path.Combine(AppDataFolder,Consts.DBName);
            if (!File.Exists(DBPath))
            {
                // TODO: Add create db script
            }
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
