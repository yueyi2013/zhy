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
            RSSFeeds.loadRssFeeds("http://world.people.com.cn/n/2013/0701/c1002-22036986.html", "gb2312");
        }
    }
}
