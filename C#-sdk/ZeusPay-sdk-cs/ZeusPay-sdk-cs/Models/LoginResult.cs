using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Models
{
    public class LoginResult
    {
        /// <summary>
        /// 错误代码，字符串，正确为OK，其他为对应错误的英文解释
        /// </summary>
        public string error { set; get; }
        /// <summary>
        /// 商户站点的用户在OTC平台内部对应的用户id，长整数
        /// </summary>
        public long id { set; get; }
        /// <summary>
        /// 用户登录后，OTC平台为登录用户生成的session，字符串
        /// </summary>
        public string session { set; get; }
        /// <summary>
        /// 签名数据，用于支付平台与商户的安全传输认证
        /// </summary>
        public string sign { set; get; }
    }
}
