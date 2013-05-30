using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.IO.Compression;
using System.Net;
using System.Xml;

namespace ZHY.Common
{
    public class RSSFeeds
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string loadRssFeeds(String rssURL, string encode)
        {
            HttpWebRequest hwr = null;
            HttpWebResponse hwp = null;
            string resStream = "";
            Encoding htmlEncode = null;
            if(string.IsNullOrEmpty(encode))
            {
                htmlEncode = Encoding.Default;
            }
            else if (encode.ToLower().Trim().Equals("UTF8".ToLower()))
            {
                htmlEncode = Encoding.UTF8;
            }
            else {
                htmlEncode = Encoding.GetEncoding(encode);            
            }
             
            try
            {
                hwr = (HttpWebRequest)WebRequest.Create(rssURL);
                hwr.Method = "GET";
                
                hwp = (HttpWebResponse)hwr.GetResponse();

                if (hwp.ContentEncoding.ToLower().Contains("gzip"))
                {
                    using (GZipStream stream = new GZipStream(hwp.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, htmlEncode))
                        {

                            resStream = reader.ReadToEnd();
                        }
                    }
                }
                else if (hwp.ContentEncoding.ToLower().Contains("deflate"))
                {
                    using (DeflateStream stream = new DeflateStream(hwp.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, htmlEncode))
                        {

                            resStream = reader.ReadToEnd();
                        }

                    }
                }
                else
                {
                    using (Stream stream = hwp.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, htmlEncode))
                        {

                            resStream = reader.ReadToEnd();
                        }
                    }
                }
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

        public static XmlDocument downLoadXmlFile(String url) 
        {
            try
            {
                string filePath = "temp.atom";
                WebClient myClient = new WebClient();
                myClient.DownloadFile(url, filePath);

                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(filePath);
                return xmlFile;
            }
            catch {
                return null;
            
            }
            
        }

        public static String HttpGetUrl(String url)
        {
            string strReturn = string.Empty;
            String urlEsc = url;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(urlEsc);
            req.Method = "GET";
            try
            {
                using (WebResponse wr = req.GetResponse())
                {
                    Stream stream = wr.GetResponseStream();
                    byte[] buf = new byte[1024];
                    while (true)
                    {
                        int len = stream.Read(buf, 0, buf.Length);
                        if (len <= 0)//[2011-8-22]  修改len < 0 =》 len <= 0 解决死循环
                            break;
                        strReturn += System.Text.Encoding.GetEncoding("utf-8").GetString(buf, 0, len);

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strReturn;
        }



        public static XmlDocument loadXMLDocument(String xmlSource) 
        {
            try
            {
                XmlDocument rssXml = new XmlDocument();
                rssXml.LoadXml(xmlSource);
                return rssXml;
            }
            catch {

                return null;
            }
        }

    }
}
