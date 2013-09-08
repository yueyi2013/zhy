using System;
using System.Data;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

using ZHY.Common;
using ZHY.Model;

namespace ZHY.BLL
{
	/// <summary>
	/// 虚拟任务
	/// </summary>
	public partial class VirtualTask : BaseBLL
	{

        /// <summary>
        /// 调用分页存储过程
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " VTId,VTUserName,VTPassword,VTProxy,VSCode,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " VirtualTask ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " UpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and VTUserName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        public string RegAdmimsy()
        {
            string resHtml = "";
            string loginURL = "http://www.admimsy.com/?R=yueyi2013";
            string createURL = "http://www.admimsy.com/CreateAccount.cfm";
            CookieContainer adCookie = new CookieContainer();

            ZHY.BLL.VirtualPersonInfo bllPsn = new ZHY.BLL.VirtualPersonInfo();

            List<ZHY.Model.VirtualPersonInfo> lsPsn = bllPsn.DataTableToList(bllPsn.GetList(1, "", " newid() ").Tables[0]);

            ZHY.Model.VirtualPersonInfo psnInfo = lsPsn[0];

            ZHY.BLL.ProxyAddress bll = new ZHY.BLL.ProxyAddress();

            List<ZHY.Model.ProxyAddress> list = bll.DataTableToList(bll.GetList(1, "", " newid() ").Tables[0]);

            ZHY.Model.ProxyAddress paInfo = list[0];

            HttpProxy.GetResponseData(loginURL, list[0].PAName, ref adCookie);

            resHtml = HttpProxy.GetResponseData(createURL, list[0].PAName, ref adCookie);

            StringBuilder sb = new StringBuilder();
            string userName = psnInfo.VPNickName + psnInfo.VPFirstName;
            sb.AppendFormat("UserName={0}&", userName);
            string psw = psnInfo.VPPassword + psnInfo.VPLastName;
            sb.AppendFormat("Password={0}&", psw);
            sb.AppendFormat("EmailAddress={0}&", psnInfo.VPMail.Replace("@", "%40"));
            sb.AppendFormat("Gender={0}&", psnInfo.VPSex);
            sb.AppendFormat("TheMonth={0}&", psnInfo.VPBirthday.Value.Month);
            sb.AppendFormat("TheDay={0}&", psnInfo.VPBirthday.Value.Day);
            sb.AppendFormat("TheYear={0}&", psnInfo.VPBirthday.Value.Year);
            string NumberAbove = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "NumberAbove");
            sb.AppendFormat("NumberAbove={0}&", NumberAbove);
            sb.AppendFormat("NumberBelow={0}&", NumberAbove);
            sb.Append("B1=Create+Account");

            //编码
            ASCIIEncoding encoding = new ASCIIEncoding();
            //编码登录信息
            byte[] data = encoding.GetBytes(sb.ToString());
            //第二步登录网站
            HttpWebRequest requestRs = HttpProxy.GetHttpWebRequest("http://www.admimsy.com/CreateAccount.cfm", paInfo.PAName, ref adCookie);
            //设置登录方式
            requestRs.Method = "POST";
            requestRs.Referer = loginURL;
            //提交类型
            requestRs.ContentType = "application/x-www-form-urlencoded";
            requestRs.ContentLength = data.Length;
            Stream newStream = requestRs.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            resHtml = new StreamReader(requestRs.GetResponse().GetResponseStream(), Encoding.Default).ReadToEnd();

            ZHY.Model.VirtualTask task = new ZHY.Model.VirtualTask();
            task.VSCode = "Admimsy";
            task.VTUserName = userName;
            task.VTPassword = psw;
            task.VTProxy = paInfo.PAName;
            this.Add(task);

            return resHtml;
        }


        public void AutoAdmimsyTask() 
        {
            List<ZHY.Model.VirtualTask> list = this.GetModelList(" VSCode = 'Admimsy'");
            foreach(ZHY.Model.VirtualTask model in list)
            {
                admimsyTask(model);
            }
        }


        private HttpWebRequest GetHttpWebRequest(string url, string proxy, ref CookieContainer adCookie)
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

        /// <summary>
        /// admimsy
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="psw">密码</param>
        private void admimsyTask(ZHY.Model.VirtualTask model)
        {

            HttpWebRequest requestRs = null;
            HttpWebResponse responseRs = null;
            CookieContainer adCookie = new CookieContainer();
            string resHtml = "";
            try
            {
                //第一步定位到登录界面
                requestRs = GetHttpWebRequest("http://www.admimsy.com/Logout.cfm",model.VTProxy,ref adCookie);

                responseRs = (HttpWebResponse)requestRs.GetResponse();
                //得到定位到的URL
                string redURL = responseRs.ResponseUri.AbsoluteUri;
                //登录所需的信息
                string loginPsData = "UserName=" + model.VTUserName + "&Password=" + model.VTPassword + "&loginSubmit=Sign+In";
                //编码
                ASCIIEncoding encoding = new ASCIIEncoding();
                //编码登录信息
                byte[] data = encoding.GetBytes(loginPsData);
                //第二步登录网站
                requestRs = GetHttpWebRequest("http://www.admimsy.com/Home.cfm", model.VTProxy, ref adCookie);
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
                resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.Default).ReadToEnd();
                //打开广告界面
                requestRs = GetHttpWebRequest("http://www.admimsy.com/ViewAds.cfm", model.VTProxy, ref adCookie);
                requestRs.Method = "GET";
                responseRs = (HttpWebResponse)requestRs.GetResponse();

                resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.Default).ReadToEnd();
                //得到需要看的广告列表
                List<string> lstADs = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "ADViewer");
                List<string> referView = new List<string>();
                List<string> finalADs = new List<string>();
                foreach (string ad in lstADs)
                {
                    string urlAd = "http://www.admimsy.com/" + ad.Replace("ADViewer.cfm", "TopViewAd.cfm");
                    requestRs = GetHttpWebRequest(urlAd, model.VTProxy, ref adCookie);
                    requestRs.Method = "GET";
                    referView.Add(urlAd);
                    using (WebResponse response = requestRs.GetResponse())
                    {
                        using (TextReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.IndexOf("TopViewAd2.cfm") > 0)
                                {
                                    string[] ur = line.Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                    if (ur != null && ur.Length == 2)
                                    {
                                        string urlC = "http://www.admimsy.com/" + ur[1];
                                        finalADs.Add(urlC);
                                    }
                                }
                            }
                        }
                    }
                }
                int i = 0;
                //最后一步：看广告
                foreach (string urlF in finalADs)
                {
                    //等待10秒
                    System.Threading.Thread.Sleep(10000);
                    requestRs = GetHttpWebRequest(urlF, model.VTProxy, ref adCookie);
                    requestRs.Accept = "*/*";
                    requestRs.Host = "www.admimsy.com";
                    requestRs.UserAgent = "Mozilla/5.0";
                    requestRs.Referer = referView[i];
                    i++;
                    //requestRs.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                    //requestRs.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
                    //requestRs.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                    //requestRs.Headers.Add("Connection", "keep-alive");
                    //requestRs.ContentType = "text/html;charset=UTF-8";

                    requestRs.Method = "GET";
                    responseRs = (HttpWebResponse)requestRs.GetResponse();
                    resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.UTF8).ReadToEnd(); 
                }

                
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

