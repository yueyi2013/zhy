using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZHY.Common;

namespace TestSYIHY
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string htmlSource = HtmlPaserUtil.extractHtmlBatchContent("http://world.people.com.cn/n/2013/0728/c57505-22354965.html");
            string tagSourcec = "";

        }
    }
}
