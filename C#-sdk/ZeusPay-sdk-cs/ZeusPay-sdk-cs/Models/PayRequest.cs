using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Models
{
    public class PayRequest:LoginRequest
    {
        /// <summary>
        /// 货币代码，字符串
        /// </summary>
        public string cur { set; get; }
        /// <summary>
        /// 按照货币代码计算的支付金额，非负浮点数
        /// </summary>
        public float amt { set; get; }
        /// <summary>
        /// 回调地址，字符串，选填
        /// </summary>
        public string callback { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string biz_identifier { set; get; }
        /// <summary>
        /// 商户站点为此次支付请求生成的交易标识，64位以内字符串
        /// </summary>
        public long transaction { set; get; }
        /// <summary>
        /// 商户站点发来的加密信息，256位以内字符串
        /// </summary>
        public string token { set; get; }
        /// <summary>
        /// 商户在支付平台的收款人账号，长整数，必填
        /// </summary>
        public long payee { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string expiry { set; get; }
        /// <summary>
        /// 说明，字符串，选填
        /// </summary>
        public string desc { set; get; }
    }
}
