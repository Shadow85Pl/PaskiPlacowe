using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PaskiPlacowe.Utils
{
    static class Utils
    {
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        public static bool IsNullOrWhiteSpace(this SecureString securePassword)
        {
            return String.IsNullOrWhiteSpace(securePassword.ConvertToUnsecureString());
        }
        public static T Process<T>(this SecureString src, Func<byte[], T> func)
        {
            IntPtr bstr = IntPtr.Zero;
            byte[] workArray = null;
            try
            {
                /*** PLAINTEXT EXPOSURE BEGINS HERE ***/
                bstr = Marshal.SecureStringToBSTR(src);
                unsafe
                {
                    byte* bstrBytes = (byte*)bstr;
                    workArray = new byte[src.Length * 2];

                    for (int i = 0; i < workArray.Length; i++)
                        workArray[i] = *bstrBytes++;
                }

                return func(workArray);
            }
            finally
            {
                if (workArray != null)
                    for (int i = 0; i < workArray.Length; i++)
                        workArray[i] = 0;
                if (bstr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr);
                /*** PLAINTEXT EXPOSURE ENDS HERE ***/
            }
        }
    }
}
