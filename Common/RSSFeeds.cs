using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;

namespace ZHY.Common
{
    public class RSSFeeds
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String loadRssFeeds(String rssRul)
        {
            HttpWebRequest hwr = null;
            HttpWebResponse hwp = null;
            string resStream = "";
            try
            {
                hwr = (HttpWebRequest)WebRequest.Create(rssRul);
                hwr.Method = "GET";
                hwp = (HttpWebResponse)hwr.GetResponse();
                resStream = new StreamReader(hwp.GetResponseStream(), Encoding.Default).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally {
                if (hwp!=null)
                    hwp.Close();
            }
            return resStream;
        }
    }
}
