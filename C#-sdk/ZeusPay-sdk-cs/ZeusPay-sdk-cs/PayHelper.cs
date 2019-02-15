using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusPay_sdk_cs.Models;
using ZeusPay_sdk_cs.Utils;

namespace ZeusPay_sdk_cs
{
    public class PayHelper
    {
        /// <summary>
        /// Zeus登录接口
        /// </summary>
        /// <param name="url">接口Url地址</param>
        /// <param name="identifier">商户站点的用户标识</param>
        /// <returns>接口返回对象</returns>
        public static LoginResult ZeusPayLogin(string url, string identifier,string nickname)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["code"]) || string.IsNullOrEmpty(ConfigurationManager.AppSettings["appkey"]) || string.IsNullOrEmpty(ConfigurationManager.AppSettings["signkey"]))
                throw new Exception();
            var request = new LoginRequest
            {
                code = ConfigurationManager.AppSettings["code"],
                appkey = ConfigurationManager.AppSettings["appkey"],
                identifier = identifier,
                nickname = nickname
            };
            var str = SignUtil.GetPropertyValueWithOrder<LoginRequest>(request);
            str += "&key=" + ConfigurationManager.AppSettings["signkey"];
            request.sign = SignUtil.GetMD5(str);
            var json = JsonConvert.SerializeObject(request);
            str = HttpUtil.Post(url, json);

            return str == null ? null : JsonConvert.DeserializeObject<LoginResult>(str);
        }

        /// <summary>
        /// Zeus支付接口
        /// </summary>
        /// <param name="url">接口Url地址</param>
        /// <param name="req">支付接口参数</param>
        /// <returns>接口返回对象</returns>
        public static LoginResult ZeusPay(string url, PayRequest req)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["code"]) || string.IsNullOrEmpty(ConfigurationManager.AppSettings["appkey"]) || string.IsNullOrEmpty(ConfigurationManager.AppSettings["signkey"]) || string.IsNullOrEmpty(ConfigurationManager.AppSettings["payee"]))
                throw new Exception();
            req.code = ConfigurationManager.AppSettings["code"];
            req.appkey = ConfigurationManager.AppSettings["appkey"];
            req.payee = long.Parse(ConfigurationManager.AppSettings["payee"]);
            var str = SignUtil.GetPropertyValueWithOrder<LoginRequest>(req);
            str += "&key=" + ConfigurationManager.AppSettings["signkey"];
            req.sign = SignUtil.GetMD5(str);
            var json = JsonConvert.SerializeObject(req);
            str = HttpUtil.Post(url, json);

            return str == null ? null : JsonConvert.DeserializeObject<LoginResult>(str);
        }
    }
}
