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
            string strGetFields = " VTId,VTUserName,VTPassword,VTProxy,VSCode,VTCount,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " VirtualTask ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " VTId ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and VTUserName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        public bool Exists(string userName) 
        {
            return dal.Exists(userName);
        }

        public void RegAdmimsy()
        {
            string resHtml = "";
            string loginURL = "http://www.admimsy.com/?R=yueyi2013";
            string createURL = "http://www.admimsy.com/CreateAccount.cfm";
            HttpWebRequest requestRs = null;
            HttpWebResponse responseRs = null;
            CookieContainer adCookie = new CookieContainer();
            try
            {
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
                if (this.Exists(userName))
                {

                    return ;
                }
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
                requestRs = HttpProxy.GetHttpWebRequest("http://www.admimsy.com/CreateAccount.cfm", paInfo.PAName, ref adCookie);
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
                responseRs = (HttpWebResponse)requestRs.GetResponse();
                resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.Default).ReadToEnd();

                ZHY.Model.VirtualTask task = new ZHY.Model.VirtualTask();
                task.VSCode = "Admimsy";
                task.VTUserName = userName;
                task.VTPassword = psw;
                task.VTProxy = paInfo.PAName;
                decimal vtId = this.Add(task);
                task.VTId = vtId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {

                if (requestRs != null)
                {
                    requestRs.Abort();
                    requestRs = null;
                }

                if (responseRs != null)
                {
                    responseRs.Close();
                    responseRs = null;
                }
            
            }
            
        }


        public void SingleAutoViewAdmimsyTask()
        {
            ZHY.Model.VirtualTask model = null;
            try {

                List<ZHY.Model.VirtualTask> list = DataTableToList(this.GetList(1, " VSCode = 'Admimsy' and UpdateDT <=getdate() ", " newid() ").Tables[0]);
                if(list!=null&&list.Count>0)
                {
                    model = list[0];
                    if (!HttpProxy.CheckProxyConnected(model.VTProxy))
                    {
                        model.VTProxy = string.Empty;
                    }
                    admimsyTask(model);
                    this.Update(model);
                }
            }catch(Exception ex){

                throw new Exception(model.VTUserName+"|"+ex.Message);
            }
        }

        public void AutoAdmimsyTask() 
        {
            //System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            List<ZHY.Model.VirtualTask> list = this.GetModelList(" VSCode = 'Admimsy' and UpdateDT <=getdate() order by UpdateDT");
            bool isError = false;
            StringBuilder sbError = new StringBuilder();
            foreach(ZHY.Model.VirtualTask model in list)
            {
                try
                {
                    if (!HttpProxy.CheckProxyConnected(model.VTProxy))
                    {
                        model.VTProxy = string.Empty;
                    }
                    admimsyTask(model);
                    this.Update(model);
                }catch(Exception ex)
                {
                    isError = true;
                    sbError.AppendFormat("[{0},{1}]",model.VTUserName,ex.Message);
                    sbError.Append("\n");
                }
            }
            if (isError)
            {
                throw new Exception(sbError.ToString());
            }
        }


        private HttpWebRequest GetHttpWebRequest(string url, string proxy, ref CookieContainer adCookie)
        {
            System.GC.Collect();
            HttpWebRequest requestRs = (HttpWebRequest)WebRequest.Create(url);
            if (!string.IsNullOrEmpty(proxy))
            {
                WebProxy wbPrx = new WebProxy(proxy);
                requestRs.Proxy = wbPrx;
            }
            else {
                requestRs.Proxy = null;
            }
            requestRs.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31";
            requestRs.KeepAlive = false;
            requestRs.ProtocolVersion = HttpVersion.Version10;
            requestRs.Timeout = 30*60*1000;
            requestRs.CookieContainer = adCookie;
            return requestRs;
        }

        /// <summary>
        /// admimsy
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="psw">密码</param>
        public void admimsyTask(ZHY.Model.VirtualTask model)
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

                if (requestRs != null)
                {
                    requestRs.Abort();
                    requestRs = null;
                }

                if (responseRs != null)
                {
                    responseRs.Close();
                    responseRs = null;
                }
                System.Threading.Thread.Sleep(5000);
                //登录所需的信息
                string loginPsData = "UserName=" + model.VTUserName + "&Password=" + model.VTPassword + "&loginSubmit=Sign+In";
                //编码
                ASCIIEncoding encoding = new ASCIIEncoding();
                //编码登录信息
                byte[] data = encoding.GetBytes(loginPsData);
                //第二步登录网站
                requestRs = GetHttpWebRequest("http://www.admimsy.com/Home.cfm", model.VTProxy, ref adCookie);
                //客户端接受类型
                requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
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

                redURL = responseRs.ResponseUri.AbsoluteUri;

                resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.Default).ReadToEnd();

                if (requestRs != null)
                {
                    requestRs.Abort();
                    requestRs = null;
                }

                if (responseRs != null)
                {
                    responseRs.Close();
                    responseRs = null;
                }
                System.Threading.Thread.Sleep(5000);
                //打开广告界面
                requestRs = GetHttpWebRequest("http://www.admimsy.com/ViewAds.cfm", model.VTProxy, ref adCookie);
                requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                requestRs.Host = "www.admimsy.com";
                requestRs.Referer = redURL;
                requestRs.Method = "GET";
                responseRs = (HttpWebResponse)requestRs.GetResponse();

                resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.Default).ReadToEnd();

                if (requestRs != null)
                {
                    requestRs.Abort();
                    requestRs = null;
                }

                if (responseRs != null)
                {
                    responseRs.Close();
                    responseRs = null;
                }
                System.Threading.Thread.Sleep(5000);
                //得到需要看的广告列表
                List<string> lstADs = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "ADViewer");
                if (lstADs == null || lstADs.Count<1)
                {
                    return; //当前无广告
                }
                List<string> referView = new List<string>();
                List<string> finalADs = new List<string>();
                foreach (string ad in lstADs)
                {
                    string urlAd = "http://www.admimsy.com/" + ad.Replace("ADViewer.cfm", "TopViewAd.cfm");
                    requestRs = GetHttpWebRequest(urlAd, model.VTProxy, ref adCookie);
                    requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    requestRs.Host = "www.admimsy.com";
                    requestRs.Method = "GET";
                    requestRs.Referer = "http://www.admimsy.com/ViewAds.cfm";
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
                    if (requestRs != null)
                    {
                        requestRs.Abort();
                        requestRs = null;
                    }
                    if (responseRs != null)
                    {
                        responseRs.Close();
                        responseRs = null;
                    }
                }
                System.Threading.Thread.Sleep(5000);
                int i = 0;
                //最后一步：看广告
                foreach (string urlF in finalADs)
                {
                    try
                    {
                        //等待10秒
                        System.Threading.Thread.Sleep(10000);
                        requestRs = GetHttpWebRequest(urlF, model.VTProxy, ref adCookie);
                        requestRs.Accept = "*/*";
                        requestRs.Host = "www.admimsy.com";
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
                    catch
                    {
                        //do nothing
                    }
                    finally {
                        if (requestRs != null)
                        {
                            requestRs.Abort();
                            requestRs = null;
                        }

                        if (responseRs != null)
                        {
                            responseRs.Close();
                            responseRs = null;
                        }
                    }
                }
                model.VTCount = (model.VTCount == null || model.VTCount == 0) ? 1 : model.VTCount + 1;
                model.UpdateDT = DateTime.Now.AddMinutes(11);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (requestRs!=null)
                {
                    requestRs.Abort();
                    requestRs = null;
                }
                if (responseRs != null)
                {
                    responseRs.Close();
                    responseRs = null;
                }

            }
        }
	}
}

