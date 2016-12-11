using PaskiPlacowe.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaskiPlacowe.BaseClasses
{
    public class BaseViewModelClass: BindableBase
    {
        protected Entities DB;
        public BaseViewModelClass():base()
        {
            CheckDB();
            DB = new Entities(CreateConnectionString(Consts.DBPath).ConnectionString);
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
        private EntityConnectionStringBuilder CreateConnectionString(string dBPath)
        {
            SQLiteConnectionStringBuilder Con = new SQLiteConnectionStringBuilder()
            {
                
                DataSource = dBPath
            };
            return new EntityConnectionStringBuilder()
            {
                Metadata= "res://*/Model.SalarySlip.csdl|res://*/Model.SalarySlip.ssdl|res://*/Model.SalarySlip.msl",
                ProviderConnectionString = Con.ConnectionString,
                Provider= "System.Data.SQLite.EF6"

            };
        }

        private void CreateDB(string dBPath)
        {
            try
            {
                using (SQLiteConnection Con = new SQLiteConnection(CreateConnectionString(dBPath).ConnectionString))
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
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
