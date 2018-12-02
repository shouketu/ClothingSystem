using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace ClothingSystem.Common
{
    /// <summary>
    /// 暂时先使用这种方式存储
    /// </summary>
    public class AuthUserCache
    {
        private static int _hour = Tools.GetAppSetting("AuthUserCacheHour").ToInt32(2);

        public static void Set(string key, AuthUserDto user)
        {
            Cache cache = System.Web.HttpContext.Current.Cache;
            cache.Insert(key, user, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(_hour));    // 相对过期时间
            // cache.Insert(key, user, null, DateTime.UtcNow.AddHours(_hour), Cache.NoSlidingExpiration);  // 绝对过期
        }

        public static AuthUserDto Get(string key)
        {
            Cache cache = System.Web.HttpContext.Current.Cache;
            return cache.Get(key) as AuthUserDto;
        }

        public static void Remove(string key)
        {
            Cache cache = System.Web.HttpContext.Current.Cache;
            cache.Remove(key);
        }
    }
}
