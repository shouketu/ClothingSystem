using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Common
{
    public class ContextHelper
    {
        public static void WriteSession(string key, object obj)
        {
            System.Web.HttpContext.Current.Session.Add(key, obj);
        }

        public static object ReadSession(string key)
        {
            return System.Web.HttpContext.Current.Session[key];
        }

        public static string GetIp()
        {
            return System.Web.HttpContext.Current.Request.UserHostAddress;
        }

        public static void WriteCookie(string name, string val)
        {
            System.Web.HttpContext.Current.Response.Cookies.Add(new System.Web.HttpCookie(name, val));
        }

        public static string ReadCookie(string name)
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies.Get(name);
            if (cookie != null)
                return cookie.Value;
            return null;
        }

        public static AuthUserDto GetByUserCookieKey()
        {
            return GetByCookieKey(Constant.UserCookieKey);
        }

        public static AuthUserDto GetByAdminCookieKey()
        {
            return GetByCookieKey(Constant.AdminCookieKey);
        }

        public static AuthUserDto GetByCookieKey(string key)
        {
            var tokenCookie = ReadCookie(key);
            if (string.IsNullOrEmpty(tokenCookie))
                return null;

            return AuthUserCache.Get(tokenCookie);
        }
    }
}
