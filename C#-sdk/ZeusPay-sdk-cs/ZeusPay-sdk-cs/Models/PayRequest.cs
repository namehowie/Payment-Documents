using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Models
{
    public class PayRequest:LoginRequest
    {
        public string cur { set; get; }
        public float amt { set; get; }
        public string callback { set; get; }
        public string biz_identifier { set; get; }
        public long transaction { set; get; }
        public string token { set; get; }
        public long payee { set; get; }
        public string expiry { set; get; }
        public string desc { set; get; }
    }
}
