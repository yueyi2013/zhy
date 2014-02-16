using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using System.Net;
using System.Text;
using ZHY.Common;
using System.IO;
using System.Web;

namespace ZHY.BLL
{
	/// <summary>
	/// TwoDollarc
	/// </summary>
	public partial class TwoDollarcCick : BaseBLL
    {
        #region 成员方法
        /// <summary>
        /// 调用分页存储过程
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " TDCId,TDCCode,TDCUsername,TDCPassword,TDCEmail,TDCFullName,TDCCountry,TDCPayment,ProxyAddress,IsEnableProxy,TDCViews,TDCReferrals,TDCIsReferrals,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " TwoDollarcCick ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " TDCId ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and TDCUsername like '%" + name + "'";
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

        #endregion

        #region 从UI看广告
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void TwoDollarcCickViewAdsFromUI(ZHY.Model.TwoDollarcCick model)
        {
            try
            {
                this.TwoDollarcCickViewAds(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region 从JOB看广告
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SCAttrName"></param>
        /// <param name="SCGroup"></param>
        public void TwoDollarcCickViewAdsFromJob(string SCAttrName, string SCGroup)
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

            List<ZHY.Model.TwoDollarcCick> list = DataTableToList(this.GetList(size, " Status = 'A' and IsEnableProxy = 'Y' and UpdateDT <=getdate() ", " newid() ").Tables[0]);
            bool isError = false;
            StringBuilder sbError = new StringBuilder();
            System.Net.ServicePointManager.DefaultConnectionLimit = 500;
            foreach (ZHY.Model.TwoDollarcCick model in list)
            {
                try
                {
                    if (!HttpProxy.CheckProxyConnected(model.ProxyAddress))
                    {
                        ZHY.BLL.ProxyAddress bllProxy = new ZHY.BLL.ProxyAddress();
                        IList<ZHY.Model.ProxyAddress> proxyLst = bllProxy.GetModelList(" PACountry like '" + model.TDCCountry + "%'");
                        if (proxyLst == null || proxyLst.Count < 1)
                        {
                            model.IsEnableProxy = "N";
                            this.Update(model);
                            return;
                        }
                        foreach (ZHY.Model.ProxyAddress proAddr in proxyLst)
                        {
                            if (HttpProxy.CheckProxyConnected(proAddr.PAName))
                            {
                                model.ProxyAddress = proAddr.PAName;
                                break;
                            }
                        }
                    }
                    this.TwoDollarcCickViewAds(model);
                    this.Update(model);
                }
                catch (Exception ex)
                {
                    sbError.Append(model.TDCUsername + "|" + ex.Message);
                    sbError.Append("\n");
                }
            }
            if (isError)
            {
                throw new Exception(sbError.ToString());
            }
        }
        #endregion

        #region 从job注册
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.TwoDollarcCick GetReferralsModel()
        {
            List<ZHY.Model.TwoDollarcCick> lsPsn = this.DataTableToList(this.GetList(1, " Status = 'A' and TDCIsReferrals = 'Y' ", " newid() ").Tables[0]);
            if (lsPsn != null && lsPsn.Count > 0)
            {
                return lsPsn[0];
            }
            return null;
        }

        /// <summary>
        /// 从job触发
        /// </summary>
        public void SignUpTwoDollarcCickFromJob()
        {
            string method = "TwoDollarcCick#SignUpTwoDollarcCickFromJob";
            try
            {
                string refs = "jans2013";
                ZHY.Model.TwoDollarcCick refModel = GetReferralsModel();
                if (refModel != null && !string.IsNullOrEmpty(refModel.TDCUsername))
                {
                    refs = refModel.TDCUsername;
                }
                StringBuilder sbLogin = new StringBuilder();
                sbLogin.AppendFormat("http://www.twodollarclick.com/index.php?ref={0}", refs);
                ZHY.Model.TwoDollarcCick model = SignUpTwoDollarcCick(sbLogin.ToString(), refs);
                if (model == null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        model = SignUpTwoDollarcCick(sbLogin.ToString(), refs);
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
        #endregion

        #region 从UI注册
        /// <summary>
        /// 从界面触发
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.TwoDollarcCick SignUpTwoDollarcCickFromUI(string refs)
        {
            try
            {
                StringBuilder sbLogin = new StringBuilder();
                sbLogin.AppendFormat("http://www.twodollarclick.com/index.php?ref={0}", refs);
                return SignUpTwoDollarcCick(sbLogin.ToString(), refs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region 得到唯一的虚拟信息
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
        #endregion

        #region 注册 TwoDollarcCick 账号
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginURL">注册地址：http://www.twodollarclick.com/index.php?view=join&action=join&</param>
        /// <param name="refs">jans2013</param>
        /// <returns></returns>
        public ZHY.Model.TwoDollarcCick SignUpTwoDollarcCick(string loginURL, string refs)
        {
            string method = "TwoDollarcCick#SignUpTwoDollarcCick";
            ZHY.Model.TwoDollarcCick model = null;
            string resHtml = "";
            string redURL = "http://www.twodollarclick.com/index.php?view=join&";
            string viewAdLink = "";
            int step = 0;
            CookieContainer adCookie = new CookieContainer();
            try
            {
                //第一步: 从数据库中获取一条虚拟人物信息
                step++;
                ZHY.Model.VirtualPersonInfo psnInfo = GetVirtualPersonInfoModel(5);
                if (psnInfo == null)
                {
                    throw new Exception(method + "--" + "没有找到人物信息。");
                }

                //第二步：从数据库中获取一条有效的代理地址
                step++;
                ZHY.Model.ProxyAddress proxyAddr = GetValidProxyAddress(5);

                if (proxyAddr == null)
                {
                    proxyAddr = new Model.ProxyAddress();

                    ZHY.Model.SystemConfig cofCnty = this.GetSystemConfig(Constants.SYSTEM_CONFIG_ATT_NAME_DEFAULT_PROXY_ADDRESS_CNTY, Constants.SYSTEM_CONFIG_ATT_GROUP_DEFAULT_PROXY_ADDRESS);
                    if (cofCnty == null || string.IsNullOrEmpty(cofCnty.SCAttrValue))
                    {
                        proxyAddr.PACountry = Constants.SYSTEM_CONFIG_ATT_VALUE_DEFAULT_PROXY_ADDRESS_CNTY;
                    }
                    else
                    {
                        proxyAddr.PACountry = cofCnty.SCAttrValue;
                    }
                }

                //第三步： 定位到注册页面
                step++;
                model = StartSignUpTwoDollarcCick(refs, ref redURL,ref resHtml,  psnInfo, proxyAddr, ref adCookie);
                decimal id = this.Add(model);
                model.TDCId = id;
                System.Threading.Thread.Sleep(5000);

                //第四步：登录网站
                step++;
                TwoDollarcCickViewAds(model);

                //第四步提取广告栏链接
                step++;
                List<string> lstMenu = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "ac=click");
                if (lstMenu == null || lstMenu.Count < 1)
                {
                    throw new Exception(method + "--" + "没有找到广告链接菜单。");
                }
                else {

                    viewAdLink = HttpUtility.HtmlDecode(lstMenu[0]);
                }

                //第五步： 打开广告界面
                step++;
                resHtml = OpenTwoDollarcCickAdviews(viewAdLink,model.ProxyAddress, ref redURL, ref adCookie);
                System.Threading.Thread.Sleep(5000);

                //第六步: 得到需要看的广告列表
                step++;
                List<string> lstAds = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "gpt.php?v=entry&type=ptc");
                if (lstMenu == null || lstMenu.Count < 1)
                {
                    return model;
                }

                //第七步： 得到真实的广告地址
                step++;
                GetRealTwoDollarcCickADs(model.ProxyAddress, ref redURL,ref adCookie, lstAds);

                model.TDCViews = (model.TDCViews == null || model.TDCViews == 0) ? 1 : model.TDCViews + 1;
                model.UpdateDT = DateTime.Now.AddHours(1);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(method + "-" + (model == null ? "UnKnownUser" : model.TDCUsername + "-Setp:" + step + "-" + ex.Message));
            }

        }
        #endregion

        #region 看广告
        /// <summary>
        /// TwoDollarcCick view ads
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="psw">密码</param>
        public void TwoDollarcCickViewAds(ZHY.Model.TwoDollarcCick model)
        {
            string method = "TwoDollarcCick#TwoDollarcCickViewAds";
            HttpWebRequest requestRs = null;
            HttpWebResponse responseRs = null;
            CookieContainer adCookie = null;
            string viewAdLink = "";
            string resHtml = "";
            string redURL = "";
            string loginUrl = "http://www.twodollarclick.com/index.php?view=login&action=login&";
            int step = 0;
            try
            {
                adCookie = new CookieContainer();

                //第一步:定位到登录界面
                step++;
                RedirectTwoDollarcCickSite(model.ProxyAddress, loginUrl, ref redURL, ref adCookie);
                System.Threading.Thread.Sleep(5000);
                //第二步:登录admimsy网站
                step++;
                resHtml = LoginTwoDollarcCickSite(model, loginUrl, ref redURL, ref adCookie);
                System.Threading.Thread.Sleep(5000);

                //第三步提取广告栏链接
                step++;
                List<string> lstMenu = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "ac=click");
                if (lstMenu == null || lstMenu.Count < 1)
                {
                    throw new Exception(method + "--" + "没有找到广告链接菜单。");
                }
                else
                {

                    viewAdLink = "http://www.twodollarclick.com/" + HttpUtility.HtmlDecode(lstMenu[0]);
                }

                //第五步： 打开广告界面
                step++;
                resHtml = OpenTwoDollarcCickAdviews(viewAdLink, model.ProxyAddress, ref redURL, ref adCookie);
                System.Threading.Thread.Sleep(5000);

                //第六步: 得到需要看的广告列表
                step++;
                List<string> lstAds = HtmlPaserUtil.ExtractHtmlsourceByTag(resHtml, "gpt.php?v=entry&type=ptc");
                if (lstMenu == null || lstMenu.Count < 1)
                {
                    return;
                }

                //第七步： 得到真实的广告地址
                step++;
                GetRealTwoDollarcCickADs(model.ProxyAddress, ref redURL, ref adCookie, lstAds);
                
                model.TDCViews = (model.TDCViews == null || model.TDCViews == 0) ? 1 : model.TDCViews + 1;
                model.UpdateDT = DateTime.Now.AddHours(1);
            }
            catch (Exception ex)
            {
                throw new Exception(method + "-" + model.TDCUsername + "-Setp:" + step + "-" + ex.Message);
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
        #endregion

        #region 注册TwoDollarcCick账号
        /// <summary>
        /// 注册ADmimsy 账号
        /// </summary>
        /// <param name="loginURL"></param>
        /// <returns></returns>
        private ZHY.Model.TwoDollarcCick StartSignUpTwoDollarcCick(string reff, ref string redURL, ref string resHtml, ZHY.Model.VirtualPersonInfo psnInfo,
            ZHY.Model.ProxyAddress proxyAddr, ref CookieContainer adCookie)
        {
            HttpWebRequest requestRs = null;
            HttpWebResponse responseRs = null;

            resHtml = HttpProxy.GetResponseData("http://www.twodollarclick.com/index.php?view=join&ref=" + reff + "&", proxyAddr.PAName, ref adCookie);

            StringBuilder sb = new StringBuilder();
            string userName = (psnInfo.VPNickName + psnInfo.VPFirstName).ToLower();
            sb.AppendFormat("uUsername={0}&", userName);
            string psw = "";
            if (!string.IsNullOrEmpty(psnInfo.VPPassword))
            {
                psw = psnInfo.VPPassword;
            }
            else
            {
                psw = psnInfo.VPLastName;
            }
            sb.AppendFormat("uPassword={0}&", psw);
            sb.AppendFormat("uVPassword={0}&", psw);
            sb.AppendFormat("uEmail={0}&", psnInfo.VPMail.Replace("@", "%40"));
            sb.AppendFormat("reff={0}&", reff);
            sb.AppendFormat("uName={0}&", psnInfo.VPFullName.Replace(" ","+"));
            string[] cnty = proxyAddr.PACountry.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string cntyValue = HtmlPaserUtil.ExtractHtmlsourceBySelectTag(resHtml, cnty[0]);
            if (string.IsNullOrEmpty(cntyValue))
            {
                throw new Exception("国家找不到。");
            }
            sb.AppendFormat("form_country={0}&", cntyValue.Replace(" ","+"));
            sb.AppendFormat("uTerms={0}&", "yes");

            //编码
            ASCIIEncoding encoding = new ASCIIEncoding();
            //编码登录信息
            byte[] data = encoding.GetBytes(sb.ToString());
            //登录网站
            requestRs = HttpProxy.GetHttpWebRequest("http://www.twodollarclick.com/index.php?view=join&action=join&ref=" + reff + "&", proxyAddr.PAName, ref adCookie);
            System.Net.ServicePointManager.Expect100Continue = false;
            //设置登录方式
            requestRs.Method = "POST";
            requestRs.Referer = "http://www.twodollarclick.com/index.php?view=join&ref=" + reff + "&";
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

            ZHY.Model.TwoDollarcCick model = new ZHY.Model.TwoDollarcCick();
            model.TDCCode = "TwoDollarcCick";
            model.TDCUsername = userName;
            model.TDCPassword = psw;
            model.ProxyAddress = proxyAddr.PAName;
            model.TDCCountry = cntyValue;
            model.TDCFullName = psnInfo.VPFullName;
            model.TDCEmail = psnInfo.VPMail;
            model.TDCReferrals = reff;
            model.TDCIsReferrals = "N";
            return model;
        }
        #endregion

        #region 定位到指定页面
        /// <summary>
        /// 退出Admimsy网站
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string RedirectTwoDollarcCickSite(string proxyAddress,string loginUrl,ref string redURL, ref CookieContainer adCookie)
        {
            HttpWebRequest requestRs = GetHttpWebRequest(loginUrl, proxyAddress, ref adCookie);
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
        #endregion

        #region 登录LoginTwoDollarcCickSite网站
        /// <summary>
        /// 第二步登录TwoDollarcCick网站
        /// </summary>
        /// <param name="model"></param>
        /// <param name="redURL"></param>
        /// <param name="adCookie"></param>
        /// <returns></returns>
        private string LoginTwoDollarcCickSite(ZHY.Model.TwoDollarcCick model, string loginUrl, ref string redURL, ref CookieContainer adCookie)
        {
            //返回的HTML
            string resHtml = "";
            HttpWebResponse responseRs = null;
            //登录所需的信息
            string loginPsData = "ipvoid=0&form_user=" + model.TDCUsername + "&form_pwd=" + model.TDCPassword;
            //编码
            ASCIIEncoding encoding = new ASCIIEncoding();
            //编码登录信息
            byte[] data = encoding.GetBytes(loginPsData);
            //第二步登录网站
            HttpWebRequest requestRs = GetHttpWebRequest(loginUrl, model.ProxyAddress, ref adCookie);
            System.Net.ServicePointManager.Expect100Continue = false;
            //客户端接受类型
            requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            //设置登录方式
            requestRs.Method = "POST";
            //
            requestRs.Host = "www.twodollarclick.com";
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
        #endregion

        #region 打开广告界面
        /// <summary>
        /// 打开需要看的广告列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="redURL"></param>
        /// <param name="adCookie"></param>
        /// <returns></returns>
        private string OpenTwoDollarcCickAdviews(string viewAdLink,string proxyAddress, ref string redURL, ref CookieContainer adCookie)
        {
            //返回的HTML
            string resHtml = "";
            HttpWebResponse responseRs = null;

            HttpWebRequest requestRs = GetHttpWebRequest(viewAdLink, proxyAddress, ref adCookie);
            requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            requestRs.Host = "www.twodollarclick.com";
            requestRs.Referer = redURL;
            requestRs.Method = "GET";
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
            return resHtml;
        }

        #endregion

        #region 得到真实的广告地址
        /// <summary>
        /// 得到真实的广告地址
        /// </summary>
        /// <param name="lstADs"></param>
        /// <returns></returns>
        private void GetRealTwoDollarcCickADs(string proxyAddress,ref string redURL, ref CookieContainer adCookie, List<string> lstADs)
        {
            HttpWebResponse responseRs = null;
            StringBuilder sbLinK = new StringBuilder(redURL);
            string refLink = sbLinK.ToString();
            CookieContainer adCookie2 = new CookieContainer();
            adCookie2 = adCookie;
            foreach (string ad in lstADs)
            {
                string urlAd = "http://www.twodollarclick.com/" + ad;

                string resHtml = OpenTwoDollarcCickAdviews(urlAd, proxyAddress, ref refLink, ref adCookie2);

                string resLink = HtmlPaserUtil.ExtractHtmlValueByFrameTag(resHtml, "surftopframe");

                string realFullLink = "http://www.twodollarclick.com/" + resLink;

                HttpWebRequest requestRs = GetHttpWebRequest(realFullLink, proxyAddress, ref adCookie);
                requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                requestRs.Host = "www.twodollarclick.com";
                requestRs.Method = "GET";
                requestRs.Referer = urlAd;

                using (WebResponse response = requestRs.GetResponse())
                {
                    using (TextReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        
                        string line;
                        string key = "";
                        string id = "";
                        string url_variables = "";
                        string timer = "";
                        string type = "";
                        string pretime = "";
                        string num = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.IndexOf("var id=") > 0)
                            {
                                string[] ur = line.Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                if (ur != null && ur.Length == 3)
                                {
                                    id =  ur[1];
                                }
                            }else  if (line.IndexOf("var url_variables=") > 0)
                            {
                                string[] ur = line.Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                if (ur != null && ur.Length == 3)
                                {
                                    url_variables =  ur[1];
                                }
                            }else if (line.IndexOf("var timer=") > 0)
                            {
                                string[] ur = line.Split(new string[] { "=",";" }, StringSplitOptions.RemoveEmptyEntries);
                                if (ur != null && ur.Length == 2)
                                {
                                    timer =  ur[1];
                                }
                            }else if (line.IndexOf("var type=") > 0)
                            {
                                string[] ur = line.Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                if (ur != null && ur.Length == 3)
                                {
                                    type =  ur[1];
                                }
                            }else  if (line.IndexOf("var key=") > 0)
                            {
                                string[] ur = line.Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                if (ur != null && ur.Length == 3)
                                {
                                    key =  ur[1];
                                }
                            }else if (line.IndexOf("var pretime=") > 0)
                            {
                                string[] ur = line.Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                                if (ur != null && ur.Length == 3)
                                {
                                    pretime =  ur[1];
                                }
                            }
                            else if (line.IndexOf("clickimages/" + key + ".png") > 0)
                            {

                                string[] ur = line.Split(new string[] { "(",")" }, StringSplitOptions.RemoveEmptyEntries);
                                if (ur != null && ur.Length == 3)
                                {
                                    num = ur[1];
                                }
                            }
                        }

                        //最后一步：完成广告任务
                        finalTwoDollarcCickAdview(proxyAddress, "http://www.twodollarclick.com/gpt.php?v=verify&buttonClicked=" +
                            num + "&id=" + id + "&type=" + type + "&pretime=" + pretime + "&" + url_variables,
                           realFullLink, ref adCookie);
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

        #endregion

        #region 完成广告任务
        /// <summary>
        /// 开始完成广告任务
        /// </summary>
        /// <param name="finalADs"></param>
        /// <param name="referView"></param>
        private string finalTwoDollarcCickAdview(string proxyAddress, string urlF, string referView, ref CookieContainer adCookie)
        {
            HttpWebResponse responseRs = null;
            HttpWebRequest requestRs = null;
            int i = 0;
            string resHtml = "";
            try
            {
                //等待10秒
                System.Threading.Thread.Sleep(30000);
                requestRs = GetHttpWebRequest(urlF, proxyAddress, ref adCookie);
                requestRs.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                requestRs.Host = "www.twodollarclick.com";
                requestRs.Referer = referView;
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
            return resHtml;
        }

        #endregion
    }
}

