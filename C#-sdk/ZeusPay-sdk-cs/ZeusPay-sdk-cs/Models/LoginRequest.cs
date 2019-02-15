using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Models
{
    public class LoginRequest
    {
        /// <summary>
        /// 商户代码，字符串，由OTC平台在商户认证后提供
        /// </summary>
        public string code { set; get; }
        /// <summary>
        /// 商户站点的用户标识(如用户ID/手机号/邮箱等)，字符串
        /// </summary>
        public string identifier { set; get; }
        /// <summary>
        /// 应用key，字符串，由OTC平台在商户认证后提供
        /// </summary>
        public string appkey { set; get; }
        /// <summary>
        /// 签名数据，用于支付平台与商户的安全传输认证
        /// </summary>
        public string sign { set; get; }
    }
}
