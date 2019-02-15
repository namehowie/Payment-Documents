using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeusPay_sdk_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Tests
{
    [TestClass()]
    public class PayHelperTests
    {
        [TestMethod()]
        public void ZeusPayLoginTest()
        {
            try
            {
                var result = PayHelper.ZeusPayLogin("http://192.168.1.240/api/public/authconnect", "173960116574380032");
                if (result == null)
                    Assert.Fail("Null");
                else
                    if (result.error != "OK")
                    Assert.Fail(result.error);
                else
                    Console.WriteLine(result.session);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}