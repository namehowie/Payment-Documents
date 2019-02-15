using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Models
{
    public class LoginResult
    {
        public string error { set; get; }
        public long id { set; get; }
        public string session { set; get; }
        public string sign { set; get; }
    }
}
