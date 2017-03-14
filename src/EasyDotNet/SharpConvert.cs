using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet
{
    /// <summary>
    /// 对 Convert 类的 加工，无法转换时不会发生错误
    /// </summary>
    public class SharpConvert
    {
        public static T To<T>(Func<T> expression)
        {
            T value;
            try
            {
                value = expression();
            }
            catch
            {
                value = default(T);
            }
            return value;
        }

        public static T To<T>(Func<T> expression,T defaultValue)
        {
            T value;
            try
            {
                value = expression();
            }
            catch
            {
                value = defaultValue;
            }
            return value;
        }


        public static int ToInt32(object value, int? defaultValue = null)
        {
            return To(() => Convert.ToInt32(value),defaultValue.GetValueOrDefault()); 
        }
        public static long ToInt64(object value,long? defaultvalue = null)
        {
            return To(() => Convert.ToInt64(value), defaultvalue.GetValueOrDefault());
        }
        public static bool ToBoolean(object value,bool? defaultvalue = null)
        {
            return To(() => Convert.ToBoolean(value), defaultvalue.GetValueOrDefault());
        }
        public static DateTime ToDateTime(object value,DateTime? defaultvalue = null)
        {
            return To(() => Convert.ToDateTime(value), defaultvalue.GetValueOrDefault());
        }
        public static string ToString(object value,string defaultvalue= "")
        {
            return To(() => Convert.ToString(value));
        }
    }
}
