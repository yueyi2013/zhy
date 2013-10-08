using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using System.Net;
using System.Text;
using ZHY.Common;
using System.IO;

namespace ZHY.BLL
{
	/// <summary>
	/// AD mimsy
	/// </summary>
	public partial class ADmimsy : BaseBLL
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
            string strGetFields = " AdmyId,AdmyCode,AdmyUserName,AdmyPassword,AdmyEmail,AdmyCountry,AdmyBirthday,AdmyGender,AdmyPayment,ProxyAddress,IsEnableProxy,AdmyViews,AdmyIsReferrals,AdmyReferrals,AdmyStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " ADmimsy ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " AdmyId ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and AdmyUserName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Exists(string userName)
        {
            return dal.Exists(userName);
        }

        /// <summary>
        /// 得到唯一的虚拟信息
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.VirtualPersonInfo GetVirtualPersonInfoModel(int count)
        {
            ZHY.BLL.VirtualPersonInfo bllPsn = new ZHY.BLL.VirtualPersonInfo();

            List<ZHY.Model.VirtualPersonInfo> lsPsn = bllPsn.DataTableToList(bllPsn.GetList(count, "", " newid() ").Tables[0]);

            foreach (ZHY.Model.VirtualPersonInfo model in lsPsn)
            {
                string userName = model.VPNickName + model.VPFirstName;
                if (!this.Exists(userName.ToLower()))
                {
                    return model;
                }
            }

            return null;
        }

        /// <summary>
        /// 注册ADmimsy 账号
        /// </summary>
        /// <param name="loginURL"></param>
        /// <returns></returns>
        private ZHY.Model.ADmimsy StartSignUpAdmimsy(string loginURL,ref string redURL, ZHY.Model.VirtualPersonInfo psnInfo, 
            ZHY.Model.ProxyAddress proxyAddr, ref CookieContainer adCookie) 
        {
            string resHtml = "";
            string createURL = "http://www.admimsy.com/CreateAccount.cfm";
            HttpWebRequest requestRs = null;
            HttpWebResponse responseRs = null;

            HttpProxy.GetResponseData(loginURL, proxyAddr.PAName, ref adCookie);

            resHtml = HttpProxy.GetResponseData(createURL, proxyAddr.PAName, ref adCookie);

            StringBuilder sb = new StringBuilder();
            string userName = (psnInfo.VPNickName + psnInfo.VPFirstName).ToLower();
            sb.AppendFormat("UserName={0}&", userName);
            string psw = "";
            if (!string.IsNullOrEmpty(psnInfo.VPPassword))
            {
                psw = psnInfo.VPPassword;
            }
            else {
                psw = psnInfo.VPLastName;
            }
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
            //登录网站
            requestRs = HttpProxy.GetHttpWebRequest("http://www.admimsy.com/CreateAccount.cfm", proxyAddr.PAName, ref adCookie);
            System.Net.ServicePointManager.Expect100Continue = false;
            //设置登录方式
            requestRs.Method = "POST";
            requestRs.Referer = loginURL;
            requestRs.AllowAutoRedirect = true;
            //提交类型
            requestRs.ContentType = "application/x-www-form-urlencoded";
            requestRs.ContentLength = data.Length;
            Stream newStream = requestRs.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            using (responseRs = (HttpWebResponse)requestRs.GetResponse())
            {
                resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.Default).ReadToEnd();
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

            ZHY.Model.ADmimsy model = new ZHY.Model.ADmimsy();
            model.AdmyCode = "Admimsy";
            model.AdmyUserName = userName;
            model.AdmyPassword = psw;
            model.ProxyAddress = proxyAddr.PAName;
            model.AdmyBirthday = psnInfo.VPBirthday;
            model.AdmyCountry = proxyAddr.PACountry;
            model.AdmyGender = psnInfo.VPSex;
            model.AdmyEmail = psnInfo.VPMail;
            
            return model;
        }

        /// <summary>
        /// 从界面触发
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.ADmimsy SignUpAdmimsyFromUI(string refs)
        {
            try
            {
                StringBuilder sbLogin = new StringBuilder();
                sbLogin.AppendFormat("http://www.admimsy.com/?R={0}", refs);
                return SignUpAdmimsy(sbLogin.ToString(), refs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.ADmimsy GetReferralsModel()
        {
            List<ZHY.Model.ADmimsy> lsPsn = this.DataTableToList(this.GetList(1, " AdmyStatus = 'A' and AdmyIsReferrals = 'Y' ", " newid() ").Tables[0]);
            if (lsPsn != null && lsPsn.Count>0)
            {
                return lsPsn[0];
            }
            return null;
        }

        /// <summary>
        /// 从job触发
        /// </summary>
        public void SignUpAdmimsyFromJob()
        {
            string method = "ADmimsy#SignUpAdmimsyFromJob";
            try
            {
                string refs = "yueyi2013";
                ZHY.Model.ADmimsy refModel = GetReferralsModel();
                if (refModel != null && !string.IsNullOrEmpty(refModel.AdmyUserName))
                {
                    refs = refModel.AdmyUserName;
                }
                StringBuilder sbLogin = new StringBuilder();
                sbLogin.AppendFormat("http://www.admimsy.com/?R={0}", refs);
                ZHY.Model.ADmimsy model = SignUpAdmimsy(sbLogin.ToString(), refs);
                if (model == null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        model = SignUpAdmimsy(sbLogin.ToString(), refs);
                        if (model != null)
                        {
                            this.Update(model);
                            break;
                        }
                    }
                }
                else
                {
                    this.Update(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(method + "--" + ex.Message);
            }
        }


        public ZHY.Model.ADmimsy SignUpAdmimsy(string loginURL, string refs)
        {
            string method = "ADmimsy#SignUpAdmimsy";
            ZHY.Model.ADmimsy model = null;
            string resHtml = "";
            string redURL = "";
            int step = 0;
            CookieContainer adCookie = new CookieContainer();
            try
            {
                //第一步: 从数据库中获取一条虚拟人物信息
                step++;
                ZHY.Model.VirtualPersonInfo psnInfo = GetVirtualPersonInfoModel(5);
                if (psnInfo==null)
                {
                    throw new Exception(method+"--"+"没有找到人物信息。");
                }

                //第二步：从数据库中获取一条有效的代理地址
                step++;
                ZHY.Model.ProxyAddress proxyAddr = GetValidProxyAddress(5);

                if (proxyAddr==null)
                {
                    proxyAddr = new Model.ProxyAddress();
                    
                    ZHY.Model.SystemConfig cofCnty = this.GetSystemConfig(Constants.SYSTEM_CONFIG_ATT_NAME_DEFAULT_PROXY_ADDRESS_CNTY, Constants.SYSTEM_CONFIG_ATT_GROUP_DEFAULT_PROXY_ADDRESS);
                    if (cofCnty == null || string.IsNullOrEmpty(cofCnty.SCAttrValue))
                    {
                        proxyAddr.PACountry = Constants.SYSTEM_CONFIG_ATT_VALUE_DEFAULT_PROXY_ADDRESS_CNTY;
                    }
                    else {

                        proxyAddr.PACountry = cofCnty.SCAttrValue;
                    }
                }

                //第三步： 定位到注册页面
                step++;
                model = StartSignUpAdmimsy(loginURL,ref redURL, psnInfo, proxyAddr, ref adCookie);
                model.AdmyReferrals = refs;
                decimal id = this.Add(model);
                model.AdmyId = id;
                System.Threading.Thread.Sleep(5000);
                
                //第四步： 打开广告界面
                step++;
                resHtml = openAdmimsyAdviews(model.ProxyAddress, ref redURL, ref adCookie);
                System.Threading.Thread.Sleep(5000);

                //第五步: 得到需要看的广告列表
                step++;
                List<string> lstADs = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "ADViewer");
                if (lstADs == null || lstADs.Count < 1)
                {
                    return model; //当前无广告
                }

                //第六步： 得到真实的广告地址
                step++;
                GetRealAdmimsyADs(model.ProxyAddress, ref adCookie, lstADs);

                model.AdmyViews = (model.AdmyViews == null || model.AdmyViews == 0) ? 1 : model.AdmyViews + 1;
                model.UpdateDT = DateTime.Now.AddHours(1);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(method + "-" + (model == null ? "UnKnownUser" : model.AdmyUserName + "-Setp:" + step + "-" + ex.Message));
            }

        }

        /// <summary>
        /// 打开需要看的广告列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="redURL"></param>
        /// <param name="adCookie"></param>
        /// <returns></returns>
        private string openAdmimsyAdviews(string proxyAddress, ref string redURL, ref CookieContainer adCookie)
        {
            //返回的HTML
            string resHtml = "";
            HttpWebResponse responseRs = null;

            HttpWebRequest requestRs = GetHttpWebRequest("http://www.admimsy.com/ViewAds.cfm", proxyAddress, ref adCookie);
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
        /// 得到真实的广告地址
        /// </summary>
        /// <param name="lstADs"></param>
        /// <returns></returns>
        private void GetRealAdmimsyADs(string proxyAddress, ref CookieContainer adCookie, List<string> lstADs)
        {
            HttpWebResponse responseRs = null;
            foreach (string ad in lstADs)
            {
                string urlAd = "http://www.admimsy.com/" + ad.Replace("ADViewer.cfm", "TopViewAd.cfm");
                HttpWebRequest requestRs = GetHttpWebRequest(urlAd, proxyAddress, ref adCookie);
                requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                requestRs.Host = "www.admimsy.com";
                requestRs.Method = "GET";
                requestRs.Referer = "http://www.admimsy.com/ViewAds.cfm";
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
                                    //最后一步：完成广告任务
                                    finalAdview(proxyAddress, ref adCookie, urlC, urlAd);
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
        }

        #region 开始完成广告任务
        /// <summary>
        /// 开始完成广告任务
        /// </summary>
        /// <param name="finalADs"></param>
        /// <param name="referView"></param>
        private string finalAdview(string proxyAddress, ref CookieContainer adCookie, string urlF, string referView)
        {
            HttpWebResponse responseRs = null;
            HttpWebRequest requestRs = null;
            string resHtml = "";
            try
            {
                //等待10秒
                System.Threading.Thread.Sleep(30000);
                requestRs = GetHttpWebRequest(urlF, proxyAddress, ref adCookie);
                requestRs.Accept = "*/*";
                requestRs.Host = "www.admimsy.com";
                requestRs.Referer = referView;
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
            return resHtml;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SCAttrName"></param>
        /// <param name="SCGroup"></param>
        public void ADmimsyViewAdsFromJob(string SCAttrName, string SCGroup) 
        {
            ZHY.Model.SystemConfig config = GetSystemConfig(SCAttrName, SCGroup);
            int size = 0;
            try
            {
                if (config != null && !string.IsNullOrEmpty(config.SCAttrValue2))
                {
                    size = int.Parse(config.SCAttrValue2);
                }
                else
                {
                    size = Constants.DEFAULT_ADMIMSY_VIEW_ADS_COUNT;
                }
            }
            catch
            {
                size = Constants.DEFAULT_ADMIMSY_VIEW_ADS_COUNT;
            }

            List<ZHY.Model.ADmimsy> list = DataTableToList(this.GetList(size, " AdmyStatus = 'A' and IsEnableProxy = 'Y' and UpdateDT <=getdate() ", " newid() ").Tables[0]);
            bool isError = false;
            StringBuilder sbError = new StringBuilder();
            System.Net.ServicePointManager.DefaultConnectionLimit = 500;
            foreach (ZHY.Model.ADmimsy model in list)
            {
                try
                {
                    if (!HttpProxy.CheckProxyConnected(model.ProxyAddress))
                    {
                            ZHY.BLL.ProxyAddress bllProxy = new ZHY.BLL.ProxyAddress();
                            string[] con = model.AdmyCountry.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);
                            IList<ZHY.Model.ProxyAddress> proxyLst = bllProxy.GetModelList(" PACountry like '" + con[0]+"%'");
                            if (proxyLst == null || proxyLst.Count<1)
                            {
                                model.IsEnableProxy = "N";
                                this.Update(model);
                                return;
                            }
                            foreach(ZHY.Model.ProxyAddress proAddr in proxyLst)
                            {
                                if (HttpProxy.CheckProxyConnected(proAddr.PAName))
                                {
                                    model.ProxyAddress = proAddr.PAName;
                                    break;
                                }
                            }
                    }
                    this.ADmimsyViewAds(model);
                    this.Update(model);
                }
                catch (Exception ex)
                {
                    sbError.Append(model.AdmyUserName + "|" + ex.Message);
                    sbError.Append("\n");
                }
            }
            if (isError)
            {
                throw new Exception(sbError.ToString());
            }
        }

        public void ADmimsyViewAdsFromUI(ZHY.Model.ADmimsy model) 
        {
            try
            {
                ADmimsyViewAds(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// admimsy view ads
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="psw">密码</param>
        public void ADmimsyViewAds(ZHY.Model.ADmimsy model)
        {
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
                
                //第一步定位到登录界面
                step++;
                redURL = logoutAdmimsySite(model.ProxyAddress, ref adCookie);
                System.Threading.Thread.Sleep(5000);
                
                //第二步登录admimsy网站
                step++;
                resHtml = loginAdmimsySite(model, ref redURL, ref adCookie);
                System.Threading.Thread.Sleep(5000);
                
                //第三步打开广告界面
                step++;
                resHtml = openAdmimsyAdviews(model.ProxyAddress, ref redURL, ref adCookie);
                
                System.Threading.Thread.Sleep(5000);
                //第四步得到需要看的广告列表
                step++;
                List<string> lstADs = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "ADViewer");
                if (lstADs == null || lstADs.Count < 1)
                {
                    return; //当前无广告
                }
                //第五步得到真实的广告地址
                step++;
                GetRealAdmimsyADs(model.ProxyAddress, ref adCookie, lstADs);

                model.AdmyViews = (model.AdmyViews == null || model.AdmyViews == 0) ? 1 : model.AdmyViews + 1;
                model.UpdateDT = DateTime.Now.AddHours(1);
            }
            catch (Exception ex)
            {
                throw new Exception(method + "-" + model.AdmyUserName + "-Setp:" + step + "-" + ex.Message);
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

        /// <summary>
        /// 退出Admimsy网站
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string logoutAdmimsySite(string proxyAddress, ref CookieContainer adCookie)
        {
            string redURL = "";
            HttpWebRequest requestRs = GetHttpWebRequest("http://www.admimsy.com/Logout.cfm", proxyAddress, ref adCookie);
            HttpWebResponse responseRs = null;
            using (responseRs = (HttpWebResponse)requestRs.GetResponse())
            {
                //得到定位到的URL
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
        /// 第二步登录Admimsy网站
        /// </summary>
        /// <param name="model"></param>
        /// <param name="redURL"></param>
        /// <param name="adCookie"></param>
        /// <returns></returns>
        private string loginAdmimsySite(ZHY.Model.ADmimsy model, ref string redURL, ref CookieContainer adCookie)
        {
            //返回的HTML
            string resHtml = "";
            HttpWebResponse responseRs = null;
            //登录所需的信息
            string loginPsData = "UserName=" + model.AdmyUserName + "&Password=" + model.AdmyPassword + "&loginSubmit=Sign+In";
            //编码
            ASCIIEncoding encoding = new ASCIIEncoding();
            //编码登录信息
            byte[] data = encoding.GetBytes(loginPsData);
            //第二步登录网站
            HttpWebRequest requestRs = GetHttpWebRequest("http://www.admimsy.com/Home.cfm", model.ProxyAddress, ref adCookie);
            System.Net.ServicePointManager.Expect100Continue = false;
            //客户端接受类型
            requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            //设置登录方式
            requestRs.Method = "POST";
            //提交类型
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

	}
}

