using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Common
{
    public static class StringExpansion
    {
        public static string ToSerialize<T>(this T data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public static T ToDeserialize<T>(this string json)
        {
            var res = default(T);
            try
            {
                res = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                 // todo
            }
            return res;
        }

        public static T Clone<T>(this object data) where T : class
        {
            var res = data as T;
            if (res == null)
                return ToSerialize(data).ToDeserialize<T>();
            return res;
        }

        public static int ToInt32(this string str, int val = 0)
        {
            int res;
            if (!int.TryParse(str, out res))
                res = val;
            return res;
        }

        public static string ToDayOfWeek(this DayOfWeek week)
        {
            switch (week)
            {
                case DayOfWeek.Sunday:
                    return "星期日";
                case DayOfWeek.Monday:
                    return "星期一";
                case DayOfWeek.Tuesday:
                    return "星期二";
                case DayOfWeek.Wednesday:
                    return "星期三";
                case DayOfWeek.Thursday:
                    return "星期四";
                case DayOfWeek.Friday:
                    return "星期五";
                case DayOfWeek.Saturday:
                    return "星期六";
                default:
                    return "";
            }
        }
    }
}
