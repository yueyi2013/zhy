using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Net;

namespace ZHY.Common
{
    public class HttpProxy
    {
        public struct Struct_INTERNET_PROXY_INFO 
        { 
            public int dwAccessType; 
            public IntPtr proxy; 
            public IntPtr proxyBypass; 
        }; 
        
        [DllImport("wininet.dll", SetLastError = true)] 
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        private bool InternetSetOption(string strProxy)
        {
            const int INTERNET_OPTION_PROXY = 38;
            const int INTERNET_OPEN_TYPE_PROXY = 3;
            //设置代理类型，直接访问，不需要通过代理服务器了
            const int INTERNET_OPEN_TYPE_DIRECT = 1;

            Struct_INTERNET_PROXY_INFO struct_IPI;

            // Filling in structure 
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
            struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy);
            struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local");

            // Allocating memory 
            IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));

            if (string.IsNullOrEmpty(strProxy) || strProxy.Trim().Length == 0)
            {
                strProxy = string.Empty;
                struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_DIRECT;
            }

            // Converting structure to IntPtr 
            Marshal.StructureToPtr(struct_IPI, intptrStruct, true);

            bool iReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, Marshal.SizeOf(struct_IPI));
            return iReturn;
        }

        /// <summary>
        /// 设置代理地址
        /// </summary>
        /// <param name="strProxy">like: 192.168.1.200:1010</param>
        public void SetHttpProxyAddress(string strProxy) 
        {
            InternetSetOption(strProxy); 
        }

        public void SomeFunc()
        {
            InternetSetOption("192.168.1.200:1010"); 
    
            System.Object nullObject = 0; 
            string strTemp = String.Empty; 
            System.Object nullObjStr = strTemp;
          //axWebBrowser1.Navigate("http://willstay.tripod.com", ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr); 
        }
    
        /// <summary>
        /// 取消代理
        /// </summary>
        /// <returns></returns>
        public bool DisableIEProxy()
        {
            return InternetSetOption(string.Empty);    
        }

        /// <summary>
        /// 检查代理是否连接成功
        /// </summary>
        /// <returns></returns>
        public static bool CheckProxyConnected(string strProxy)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Proxy = new WebProxy(strProxy);
                wc.DownloadString("http://google.com/ncr");
                return true;
            }
            catch {
            
                //do nothing
            }
            return false;
        }

        public static HttpWebRequest PostHttpWebRequest(string url, string postData, string strProxy, ref CookieContainer pstCookie)
        {
            try
            {
                //编码
                ASCIIEncoding encoding = new ASCIIEncoding();
                //编码登录信息
                byte[] data = encoding.GetBytes(postData);
                //登录网站
                HttpWebRequest requestRs = (HttpWebRequest)WebRequest.Create(url);
                if (!string.IsNullOrEmpty(strProxy))
                {
                    requestRs.Proxy = new WebProxy(strProxy);
                    requestRs.KeepAlive = false;
                    requestRs.ProtocolVersion = HttpVersion.Version10;
                }

                //设置Cookie
                requestRs.CookieContainer = pstCookie;
                //设置登录方式
                requestRs.Method = "POST";
                //提交类型
                requestRs.ContentType = "application/x-www-form-urlencoded";
                requestRs.ContentLength = data.Length;
                Stream newStream = requestRs.GetRequestStream();
                // Send the data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                return requestRs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public static HttpWebRequest GetHttpWebRequest(string url, string proxy, ref CookieContainer adCookie)
        {
            HttpWebRequest requestRs = (HttpWebRequest)WebRequest.Create(url);
            if (!string.IsNullOrEmpty(proxy))
            {
                WebProxy wbPrx = new WebProxy(proxy);
                requestRs.Proxy = wbPrx;
                requestRs.KeepAlive = false;
                requestRs.ProtocolVersion = HttpVersion.Version10;
            }
            requestRs.CookieContainer = adCookie;
            return requestRs;
        }

        public static string GetResponseData(string url, string proxy, ref CookieContainer adCookie) 
        {
            HttpWebRequest requestRs = GetHttpWebRequest(url, proxy, ref adCookie);

            HttpWebResponse responseRs = (HttpWebResponse)requestRs.GetResponse();

            return  new StreamReader(responseRs.GetResponseStream(), Encoding.Default).ReadToEnd();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="postData">提交的数据</param>
        /// <param name="psnCookie">人员信息</param>
        /// <returns></returns>
        public static string PostData(string url, string postData, string strProxy, ref CookieContainer psnCookie)
        {
            HttpWebResponse responseRs = null;
            try
            {
                //编码
                ASCIIEncoding encoding = new ASCIIEncoding();
                //编码登录信息
                byte[] data = encoding.GetBytes(postData);
                //登录网站
                HttpWebRequest requestRs = (HttpWebRequest)WebRequest.Create(url);
                if (!string.IsNullOrEmpty(strProxy))
                {
                    requestRs.Proxy = new WebProxy(strProxy);
                    requestRs.KeepAlive = false;
                    requestRs.ProtocolVersion = HttpVersion.Version10;
                }
                
                //设置Cookie
                requestRs.CookieContainer = psnCookie;
                //设置登录方式
                requestRs.Method = "POST";
                //提交类型
                requestRs.ContentType = "application/x-www-form-urlencoded";
                requestRs.ContentLength = data.Length;
                Stream newStream = requestRs.GetRequestStream();
                // Send the data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                responseRs = (HttpWebResponse)requestRs.GetResponse();
                return new StreamReader(responseRs.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (responseRs != null)
                {
                    responseRs.Close();
                }
            }
        }
    }
}
