using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Models
{
    public class LoginRequest
    {
        public string code { set; get; }
        public string identifier { set; get; }
        public string appkey { set; get; }
        public string sign { set; get; }
    }
}
