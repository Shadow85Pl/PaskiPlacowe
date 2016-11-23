using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            if (!Directory.Exists(Consts.AppDataFolder))
                Directory.CreateDirectory(Consts.AppDataFolder);
            if (!File.Exists(Consts.DBPath))
            {
                CreateDB(Consts.DBPath);
            }
        }

        private void CreateDB(string dBPath)
        {
            SQLiteConnectionStringBuilder ConStr = new SQLiteConnectionStringBuilder();
            ConStr.DataSource = dBPath;
            try
            {
                using (SQLiteConnection Con = new SQLiteConnection(ConStr.ConnectionString))
                {
                    Con.Open();
                    try
                    {
                        using (SQLiteCommand Com = Con.CreateCommand())
                        {
                            Com.CommandText = PaskiPlacowe.Properties.Resources.SalarySlip;
                            Com.ExecuteNonQuery();
                        }
                    }
                    finally
                    {
                        Con.Close();
                    }
                }
            }finally
            {
                GC.Collect();
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
