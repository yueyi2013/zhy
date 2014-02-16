using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.Cache;
using System.Threading;
using ZHY.Common;

namespace ToolUtils
{
    public partial class TestVCode : Form
    {
        public TestVCode()
        {
            InitializeComponent();
        }


        #region 线程安全操作控件
        public delegate void SetTdCtlCallBack(object sender, string text, bool isenable, Image img);

        public void SetTdCtl(object sender, string text, bool isenable, Image img)
        {
            Control obj = (Control)sender;
            if (obj.InvokeRequired)
            {
                SetTdCtlCallBack d = new SetTdCtlCallBack(SetTdCtl);
                this.Invoke(d, new object[] { sender, text, isenable, img });
            }
            else
            {
                obj.Text = text;
                obj.Enabled = isenable;
                obj.BackgroundImage = img;
            }
        }
        #endregion

        #region GetStream 获取网页流对象
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受 
        }

        /// <summary>
        /// GetStream 获取网页流对象
        /// </summary>
        /// <param name="url">要获取的网页地址</param>
        /// <param name="refer">来源网址</param>
        /// <param name="timeout">请求超时时间</param>
        /// <param name="encode">网页编码方式</param>
        /// <param name="cookie">Cookie 对象</param>
        /// <param name="myproxy">代理对象</param>
        /// <param name="err">接收错误信息字符串</param>
        /// <returns>网页流对象</returns>
        public static Stream GetStream(string url, string refer, int timeout, Encoding encode, ref CookieContainer cookie, WebProxy myproxy, out string err)
        {
            Stream stream = null;
            err = "";
            try
            {
                HttpWebResponse response = null;
                HttpWebRequest request = null;
                //如果是发送HTTPS请求
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(url) as HttpWebRequest;
                }
                else
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                }
                HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                request.ProtocolVersion = HttpVersion.Version10;
                if (cookie == null) cookie = new CookieContainer();
                request.CookieContainer = cookie;
                request.CachePolicy = noCachePolicy;
                request.Proxy = myproxy;
                request.KeepAlive = false;
                request.ServicePoint.ConnectionLimit = int.MaxValue;
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.Timeout = timeout;
                request.Method = "GET";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 2.0.50727;)";
                request.Referer = refer;
                response = (HttpWebResponse)request.GetResponse();
                cookie = request.CookieContainer;
                stream = response.GetResponseStream();
                return stream;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }
        #endregion

        private void getvcode()
        {
            //SetTdCtl(btn_getvcode, "获取中...", false, null);
            CookieContainer cookie = new CookieContainer();
            string err;
            Stream stream = GetStream("https://www.paidtoclick.ca/router.php?rid=10851", "", 10000, Encoding.UTF8, ref cookie, null, out err);
            try
            {
                StringBuilder sbCde = new StringBuilder();
                Bitmap bitmap = (Bitmap)Image.FromStream(stream);
                UnCodebase ud = new UnCodebase(bitmap);
                bitmap = ud.GrayByPixels();
                ud.ClearNoise(128, 2);

                pic_code.Image = bitmap;

                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789"); // If digit only
                ocr.Init(@"G:\Code\MIS\syihy\ToolUtils\lib\tessdata", "eng", false); // To use correct tessdata
                List<tessnet2.Word> result = ocr.DoOCR(bitmap, Rectangle.Empty);
                foreach (tessnet2.Word word in result)
                    sbCde.AppendFormat("{0} : {1}", word.Confidence, word.Text);


                MessageBox.Show(sbCde.ToString());

            }
            catch {  }
        }

        private void btn_getvcode_Click(object sender, EventArgs e)
        {
           //new Thread(getvcode).Start();
            getvcode();
        }
    }
}
