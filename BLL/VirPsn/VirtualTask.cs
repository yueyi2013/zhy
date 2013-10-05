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
	/// ��������
	/// </summary>
	public partial class VirtualTask : BaseBLL
	{

        /// <summary>
        /// ���÷�ҳ�洢����
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

        /// <summary>
        /// �ӽ��津��
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.VirtualTask RegAdmimsyByUI() 
        {
            try
            {
                StringBuilder sbLogin = new StringBuilder();
                sbLogin.AppendFormat("http://www.admimsy.com/?R={0}", "yueyi2013");
                return RegAdmimsy(sbLogin.ToString());
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        /// <summary>
        /// Job����
        /// </summary>
        public void RegAdmimsyByJob() 
        {
            string method = "VirtualTask#RegAdmimsyByJob";
            try
            {
                StringBuilder sbLogin = new StringBuilder();
                sbLogin.AppendFormat("http://www.admimsy.com/?R={0}", "yueyi2013");
                ZHY.Model.VirtualTask model = RegAdmimsy(sbLogin.ToString());
                if (model == null)
                {
                    for (int i = 0; i < 3;i++)
                    {
                        model = RegAdmimsy(sbLogin.ToString());
                        if (model!=null)
                        {
                            this.Update(model);
                            break;
                        }
                    }
                }
                else {
                    this.Update(model);
                }
            }catch(Exception ex)
            {
                throw new Exception(method+"--"+ex.Message);
            }
        }

        public ZHY.Model.VirtualTask RegAdmimsy(string loginURL)
        {
            ZHY.Model.VirtualTask model = null;
            string resHtml = "";
            string method = "VirtualTask#RegAdmimsy";
            string redURL = "";
            int step = 0;
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
                step++;
                //��һ����λ��ע��ҳ��
                HttpProxy.GetResponseData(loginURL, list[0].PAName, ref adCookie);

                resHtml = HttpProxy.GetResponseData(createURL, list[0].PAName, ref adCookie);

                StringBuilder sb = new StringBuilder();
                string userName = psnInfo.VPNickName + psnInfo.VPFirstName;
                if (this.Exists(userName))
                {
                    return null;
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

                //����
                ASCIIEncoding encoding = new ASCIIEncoding();
                //�����¼��Ϣ
                byte[] data = encoding.GetBytes(sb.ToString());
                step++;
                //�ڶ�����¼��վ
                requestRs = HttpProxy.GetHttpWebRequest("http://www.admimsy.com/CreateAccount.cfm", paInfo.PAName, ref adCookie);
                System.Net.ServicePointManager.Expect100Continue = false;
                //���õ�¼��ʽ
                requestRs.Method = "POST";
                requestRs.Referer = loginURL;
                //�ύ����
                requestRs.ContentType = "application/x-www-form-urlencoded";
                requestRs.ContentLength = data.Length;
                Stream newStream = requestRs.GetRequestStream();
                // Send the data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                using (responseRs = (HttpWebResponse)requestRs.GetResponse())
                {
                    resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.Default).ReadToEnd();
                    redURL = responseRs.ResponseUri.AbsolutePath;
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
                
                model = new ZHY.Model.VirtualTask();
                model.VSCode = "Admimsy";
                model.VTUserName = userName;
                model.VTPassword = psw;
                model.VTProxy = paInfo.PAName;
                decimal vtId = this.Add(model);
                model.VTId = vtId;

                System.Threading.Thread.Sleep(5000);
                step++;
                //�������򿪹�����
                resHtml = openAdmimsyAdviews(model, ref redURL, ref adCookie);
                step++;
                System.Threading.Thread.Sleep(5000);
                //���Ĳ��õ���Ҫ���Ĺ���б�
                List<string> lstADs = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "ADViewer");
                if (lstADs == null || lstADs.Count < 1)
                {
                    return model; //��ǰ�޹��
                }
                step++;
                List<string> referView = new List<string>();
                //���岽�õ���ʵ�Ĺ���ַ
                List<string> finalADs = getRealAdmimsyADs(model, ref adCookie, lstADs, referView);
                System.Threading.Thread.Sleep(5000);
                step++;
                //���������һ���������
                resHtml = finalAdview(model, ref adCookie, finalADs, referView);

                model.VTCount = (model.VTCount == null || model.VTCount == 0) ? 1 : model.VTCount + 1;
                model.UpdateDT = DateTime.Now.AddHours(1);
                step++;

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(method + "-" + (model==null?"UnKnownUser":model.VTUserName + "-Setp:" + step + "-" + ex.Message));
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
            List<ZHY.Model.VirtualTask> list = DataTableToList(this.GetList(3, " VSCode = 'Admimsy' and UpdateDT <=getdate() ", " newid() ").Tables[0]);
            bool isError = false;
            StringBuilder sbError = new StringBuilder();
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            foreach (ZHY.Model.VirtualTask model in list)
            {
                try
                {
                    if (!HttpProxy.CheckProxyConnected(model.VTProxy))
                    {
                        model.VTProxy = string.Empty;
                    }
                    admimsyTask(model);
                    this.Update(model);
                }
                catch (Exception ex)
                {
                    sbError.Append(model.VTUserName + "|" + ex.Message);
                    sbError.Append("\n");
                }
            }
            if (isError)
            {
                throw new Exception(sbError.ToString());
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
            requestRs.AllowWriteStreamBuffering = true;
            WebHeaderCollection whc = requestRs.Headers;
            if (!string.IsNullOrEmpty(proxy))
            {
                WebProxy wbPrx = new WebProxy(proxy);
                requestRs.Proxy = wbPrx;
            }
            else {
                requestRs.Proxy = null;
            }
           // whc.Add("Accept-Charset:GBK,utf-8;q=0.7,*;q=0.3");
            //whc.Add("Accept-Encoding:gzip,deflate,sdch");
           // whc.Add("Accept-Language:en;q=0.8");
            requestRs.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31";
            requestRs.KeepAlive = false;
            requestRs.ProtocolVersion = HttpVersion.Version11;
            requestRs.Timeout = 30*60*1000;
            requestRs.ReadWriteTimeout = 30 * 60 * 1000;
            requestRs.CookieContainer = adCookie;
            return requestRs;
        }

        /// <summary>
        /// �˳�Admimsy��վ
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string logoutAdmimsySite(ZHY.Model.VirtualTask model,ref CookieContainer adCookie) 
        {
            string redURL = "";
            HttpWebRequest requestRs = GetHttpWebRequest("http://www.admimsy.com/Logout.cfm",model.VTProxy,ref adCookie);
            HttpWebResponse responseRs = null;
            using (responseRs = (HttpWebResponse)requestRs.GetResponse())
            {
                //�õ���λ����URL
                redURL = responseRs.ResponseUri.AbsoluteUri;

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
            return redURL;
        }

        /// <summary>
        /// �ڶ�����¼Admimsy��վ
        /// </summary>
        /// <param name="model"></param>
        /// <param name="redURL"></param>
        /// <param name="adCookie"></param>
        /// <returns></returns>
        private string loginAdmimsySite(ZHY.Model.VirtualTask model, ref string redURL,ref CookieContainer adCookie) 
        {
            //���ص�HTML
            string resHtml = "";
            HttpWebResponse responseRs = null;
            //��¼�������Ϣ
            string loginPsData = "UserName=" + model.VTUserName + "&Password=" + model.VTPassword + "&loginSubmit=Sign+In";
            //����
            ASCIIEncoding encoding = new ASCIIEncoding();
            //�����¼��Ϣ
            byte[] data = encoding.GetBytes(loginPsData);
            //�ڶ�����¼��վ
            HttpWebRequest requestRs = GetHttpWebRequest("http://www.admimsy.com/Home.cfm", model.VTProxy, ref adCookie);
            System.Net.ServicePointManager.Expect100Continue = false;
            //�ͻ��˽�������
            requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            //���õ�¼��ʽ
            requestRs.Method = "POST";
            //�ύ����
            requestRs.ContentType = "application/x-www-form-urlencoded";
            requestRs.ContentLength = data.Length;
            using (Stream newStream = requestRs.GetRequestStream())
            {
                // Send the data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }

            using (responseRs = (HttpWebResponse)requestRs.GetResponse())
            {
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
            }
            return resHtml;
        }

        /// <summary>
        /// ����Ҫ���Ĺ���б�
        /// </summary>
        /// <param name="model"></param>
        /// <param name="redURL"></param>
        /// <param name="adCookie"></param>
        /// <returns></returns>
        private string openAdmimsyAdviews(ZHY.Model.VirtualTask model, ref string redURL, ref CookieContainer adCookie)
        {
            //���ص�HTML
            string resHtml = "";
            HttpWebResponse responseRs = null;

            HttpWebRequest requestRs = GetHttpWebRequest("http://www.admimsy.com/ViewAds.cfm", model.VTProxy, ref adCookie);
            requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            requestRs.Host = "www.admimsy.com";
            requestRs.Referer = redURL;
            requestRs.Method = "GET";
            using (responseRs = (HttpWebResponse)requestRs.GetResponse())
            {
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
            }
            return resHtml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstADs"></param>
        /// <returns></returns>
        private List<string> getRealAdmimsyADs(ZHY.Model.VirtualTask model, ref CookieContainer adCookie, List<string> lstADs, List<string> referView) 
        {
            HttpWebResponse responseRs = null;
            List<string> finalADs = new List<string>();
            foreach (string ad in lstADs)
            {
                string urlAd = "http://www.admimsy.com/" + ad.Replace("ADViewer.cfm", "TopViewAd.cfm");
                HttpWebRequest requestRs = GetHttpWebRequest(urlAd, model.VTProxy, ref adCookie);
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
            return finalADs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="finalADs"></param>
        /// <param name="referView"></param>
        private string finalAdview(ZHY.Model.VirtualTask model, ref CookieContainer adCookie, List<string> finalADs, List<string> referView)
        {
            HttpWebResponse responseRs = null;
            HttpWebRequest requestRs = null;
            int i = 0;
            string resHtml = "";
            foreach (string urlF in finalADs)
            {
                try
                {
                    //�ȴ�10��
                    System.Threading.Thread.Sleep(10000);
                    requestRs = GetHttpWebRequest(urlF, model.VTProxy, ref adCookie);
                    requestRs.Accept = "*/*";
                    requestRs.Host = "www.admimsy.com";
                    requestRs.Referer = referView[i];
                    i++;
                    requestRs.Method = "GET";
                    using (responseRs = (HttpWebResponse)requestRs.GetResponse())
                    {
                        resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.UTF8).ReadToEnd();

                    }
                }
                catch
                {
                    //do nothing
                }
                finally
                {
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
            return resHtml;
        }

        /// <summary>
        /// admimsy
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <param name="psw">����</param>
        public void admimsyTask(ZHY.Model.VirtualTask model)
        {
            model.VTProxy = string.Empty;
            string method = "VirtualTask#admimsyTask";
            HttpWebRequest requestRs = null;
            HttpWebResponse responseRs = null;
            CookieContainer adCookie = null;
            string resHtml = "";
            string redURL = "";
            int step = 0;
            try
            {
                adCookie = new CookieContainer();
                step++;
                //��һ����λ����¼����
                redURL = logoutAdmimsySite(model,ref adCookie);                
                System.Threading.Thread.Sleep(5000);
                step++;
                //�ڶ�����¼admimsy��վ
                resHtml = loginAdmimsySite(model, ref redURL, ref adCookie);
                System.Threading.Thread.Sleep(5000);
                step++;
                //�������򿪹�����
                resHtml = openAdmimsyAdviews(model, ref redURL, ref adCookie);
                step++;
                System.Threading.Thread.Sleep(5000);
                //���Ĳ��õ���Ҫ���Ĺ���б�
                List<string> lstADs = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "ADViewer");
                if (lstADs == null || lstADs.Count<1)
                {
                    return; //��ǰ�޹��
                }
                step++;
                List<string> referView = new List<string>();
                //���岽�õ���ʵ�Ĺ���ַ
                List<string> finalADs = getRealAdmimsyADs(model, ref adCookie,lstADs, referView);
                System.Threading.Thread.Sleep(5000);
                step++;
                //���������һ���������
                resHtml = finalAdview(model, ref adCookie, finalADs, referView);

                model.VTCount = (model.VTCount == null || model.VTCount == 0) ? 1 : model.VTCount + 1;
                model.UpdateDT = DateTime.Now.AddHours(1);
                step++;
            }
            catch (Exception ex)
            {
                throw new Exception(method +"-"+ model.VTUserName + "-Setp:" + step + "-" + ex.Message);
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

