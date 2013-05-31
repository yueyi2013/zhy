using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSYIHY
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ZHY.BLL.RSSChannel bll = new ZHY.BLL.RSSChannel();
            bll.FetchRssFeeds("http://www.people.com.cn/rss/politics.xml");
        }
    }
}
