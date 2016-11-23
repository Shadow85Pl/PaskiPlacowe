using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaskiPlacowe
{
    class Consts
    {
        public const string AppNameShort = "PaskiPlacowe";
        public const string AppNameLong = "Paski Płacowe (Salary Slip)";
        public readonly static string DBName= String.Format("{0}.db3",AppNameShort);
        public readonly static string  AppDataFolder=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Consts.AppNameShort);
        public readonly static string DBPath = Path.Combine(AppDataFolder, Consts.DBName);
    }
}
