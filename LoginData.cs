using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaskiPlacowe
{
    class LoginData
    {
        #region properties
        public Boolean IsLoggedIn { get; set; }=false;
        public String Login;
        #endregion
        private static LoginData _Instance;
        public static LoginData GetInstance()
        {
            if (_Instance == null)
                _Instance = new LoginData();
            return _Instance;
        }
    }
}
