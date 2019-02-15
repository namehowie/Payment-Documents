using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 循环测试接口
            while (true)
            {
                Console.Clear();
                Console.WriteLine("请选择接口！");
                Console.WriteLine("1、登录接口");
                Console.WriteLine("2、支付接口");
                Console.WriteLine("");
                Console.Write("请输入对应数字，否则退出：");

                var digital = Console.ReadKey();
                Console.WriteLine("");
                Console.WriteLine("");
                switch (digital.KeyChar)
                {
                    case '1':
                        ZeusPayLogin();
                        Console.ReadKey();
                        break;
                    case '2':
                        ZeusPay();
                        Console.ReadKey();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            } 
            #endregion
        }
        /// <summary>
        /// Zeus支付登录测试，需要输入Zeus支付的接口地址和商户站点的用户标识
        /// </summary>
        static void ZeusPayLogin()
        {
            var result = PayHelper.ZeusPayLogin("http://192.168.1.240/api/public/authconnect", "173960116574380032","玲珑");
            if (result == null)
                Console.WriteLine("接口异常！");
            else
            if (result.error != "OK")
                Console.WriteLine(result.error);
            else
                Console.WriteLine(JsonConvert.SerializeObject(result));
        }
        /// <summary>
        /// Zeus支付测试，需要输入Zeus支付的接口地址和及支付参数
        /// </summary>
        static void ZeusPay()
        {
            var result = PayHelper.ZeusPay("http://192.168.1.240/api/public/payrequest", new Models.PayRequest {
                identifier = "173960116574380032", 
                nickname = "玲珑",
                callback = "http://extsite.com/pay/otc/callbac",
                cur = "BTC", //币种编号
                amt = 100.32f,
                transaction = 209235432800526336L,
                token= "123421312",
                expiry="",
                desc="后台支付请求示例"
            });
            if (result == null)
                Console.WriteLine("接口异常！");
            else
            if (result.error != "OK")
                Console.WriteLine(result.error);
            else
                Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}
