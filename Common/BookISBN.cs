using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace ZHY.Common
{
    class BookISBN
    {

        String apikey = "111111111111111111111111111111";
        String isbnUrl = "http://api.douban.com/book/subject/isbn/"; 

        /** 
        * 从根据isbn号从豆瓣获取数据。已经申请apikey，每分钟最多40次请求，足够用。 
        * @param isbnNo 
        * @return 
        * @throws IOException  
        */
        public string fetchBookInfoByXML(string isbnNo) {  
            var requestUrl = isbnUrl + isbnNo + "?apikey=" + apikey;  
            HttpWebRequest  hwr = (HttpWebRequest)WebRequest.Create(requestUrl);
            hwr.Method = "GET";
            HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();
            string resStream= new StreamReader(hwp.GetResponseStream(), Encoding.Default).ReadToEnd();
            hwp.Close();
            return resStream;
        }
    }
}
