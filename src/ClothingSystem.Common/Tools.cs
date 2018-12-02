using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Common
{
    public static class Tools
    {
        public static string EncryptDESByUserPwd(string userPwd)
        {
            return DESHelper.EncryptDES(userPwd, Constant.UserDESKey);
        }

        public static string DecryptDESByUserPwd(string userPwd)
        {
            return DESHelper.DecryptDES(userPwd, Constant.UserDESKey);
        }

        public static string EncryptDESByAdminPwd(string adminPwd)
        {
            return DESHelper.EncryptDES(adminPwd, Constant.AdminDESKey);
        }

        public static string DecryptDESByAdminPwd(string adminPwd)
        {
            return DESHelper.DecryptDES(adminPwd, Constant.AdminDESKey);
        }
        
        public static string GetAppSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static string GetConnectionString(string name)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string GetToken(object user)
        {
            if (user == null)
                return string.Empty;

            var json = user.ToSerialize();
            return (json + DateTime.Now.Ticks).ToMD5(Constant.AuthenticationKey);
        }

        public static string ToMD5(this string str, string key)
        {
            var md5Provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            using (md5Provider)
            {
                var buffer = Encoding.UTF8.GetBytes(str + key);
                var res = md5Provider.ComputeHash(buffer);
                var sb = new StringBuilder();
                for (int i = 0; i < res.Length; i++)
                {
                    sb.Append(res[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
