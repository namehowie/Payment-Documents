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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("请选择接口()");
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
        }
        static void ZeusPayLogin()
        {
            var result = PayHelper.ZeusPayLogin("http://192.168.1.240/api/public/authconnect", "173960116574380032");
            if (result == null)
                Console.WriteLine("接口异常！");
            else
            if (result.error != "OK")
                Console.WriteLine(result.error);
            else
                Console.WriteLine(JsonConvert.SerializeObject(result));
        }
        static void ZeusPay()
        {
            var result = PayHelper.ZeusPay("http://192.168.1.240/api/public/payrequest", new Models.PayRequest {
                identifier = "173960116574380032",
                callback = "http://extsite.com/pay/otc/callbac",
                cur = "BTC",
                amt = 100.32f,
                biz_identifier="",
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
