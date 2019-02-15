using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Utils
{
    public class SignUtil
    {
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return System.Text.Encoding.Default.GetString(result);
        }
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] formData = System.Text.Encoding.Default.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(formData);
            return BitConverter.ToString(targetData).Replace("-","");
        }
        /// <summary>
        /// 获取对象的属性和值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>返回属性与值一一对应的字典</returns>
        public static string GetPropertyValueWithOrder<T>(T obj)
        {
            string result = string.Empty;
            if (obj != null)
            {
                Type type = obj.GetType();
                var propertyInfos = type.GetProperties().OrderBy(a=>a.Name).ToList();

                foreach (PropertyInfo item in propertyInfos)
                {
                    if(item.GetValue(obj, null) != null && !string.IsNullOrEmpty(item.GetValue(obj, null).ToString()))
                        result += string.Format("{0}={1}&", item.Name, item.GetValue(obj, null).ToString());
                }
                result = result.TrimEnd('&');
                return result;
            }
            return null;
        }

    }
}
