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
    }
}
