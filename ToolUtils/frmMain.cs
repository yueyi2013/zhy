using System;
using System.Data;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ZHY.Common;

namespace ToolUtils
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
           
            InitializeComponent();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            
        }


        private void btnViewAd_Click(object sender, EventArgs e)
        {
            //admimsyTask("james00404", "james1qazxsw2");
            //admimsyTask("yueyi2013", "yueyi2013"); 
            ZHY.BLL.VirtualTask bll = new ZHY.BLL.VirtualTask();
            List<ZHY.Model.VirtualTask> list = bll.GetModelList("");
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
            }
            requestRs.CookieContainer = adCookie;
            requestRs.KeepAlive = false;
            requestRs.ProtocolVersion = HttpVersion.Version10;
            return requestRs;
        }

        /// <summary>
        /// 
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
                requestRs = GetHttpWebRequest("http://www.admimsy.com/Logout.cfm", model.VTProxy, ref adCookie);

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
                    requestRs.CookieContainer = adCookie;
                    responseRs = (HttpWebResponse)requestRs.GetResponse();
                    resHtml = new StreamReader(responseRs.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                }


            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                if (responseRs != null)
                {
                    responseRs.Close();
                }

            }
        }

        public bool AutoLogin(string loginURL,string username, string psw, ref CookieContainer adCookie)
        {
            try
            {
                string strArgs = "UserName=" + username + "&Password=" + psw + "&loginSubmit=Sign+In";
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(loginURL);
                hwr.Method = "POST";
                hwr.ContentType = "application/x-www-form-urlencoded";
                adCookie = new CookieContainer();
                hwr.CookieContainer = adCookie;
                hwr.Timeout = 1000 * 10;
                Stream stream = hwr.GetRequestStream();
                StreamWriter sw = new StreamWriter(stream, Encoding.Default);
                //把数据写入HttpWebRequest的Request流
                sw.Write(strArgs);
                sw.Close();
                stream.Close();
                HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();

                if (hwp.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                if (sw != null)
                {
                    sw.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (hwp != null)
                {
                    hwp.Close();
                }
                hwp.Close();
            }
            catch
            {
                
                return false;
            }
            finally
            {
                
            }
            return false;
        }

        private void autoRegPsn() 
        {
            this.wbHTML.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbHTML_Psn_DocumentCompleted);
            this.wbHTML.ScriptErrorsSuppressed = true;
            wbHTML.Navigate("http://cn.usinfo.me/", false);
            while (true)
            {
                if (this.wbHTML.ReadyState == WebBrowserReadyState.Complete)
                {
                    break;
                }
            }
        }


        private void btnReg_Click(object sender, EventArgs e)
        {
            RegAdmimsy();
        }

        private string RegAdmimsy() 
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
            sb.AppendFormat("UserName={0}&",userName);
            string psw = psnInfo.VPPassword + psnInfo.VPLastName;
            sb.AppendFormat("Password={0}&",psw);
            sb.AppendFormat("EmailAddress={0}&", psnInfo.VPMail.Replace("@", "%40"));
            sb.AppendFormat("Gender={0}&", psnInfo.VPSex);
            sb.AppendFormat("TheMonth={0}&", psnInfo.VPBirthday.Value.Month);
            sb.AppendFormat("TheDay={0}&", psnInfo.VPBirthday.Value.Day);
            sb.AppendFormat("TheYear={0}&", psnInfo.VPBirthday.Value.Year);
            string NumberAbove = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "NumberAbove");
            sb.AppendFormat("NumberAbove={0}&",NumberAbove);
            sb.AppendFormat("NumberBelow={0}&",NumberAbove);
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

            ZHY.BLL.VirtualTask bllTask = new ZHY.BLL.VirtualTask();
            ZHY.Model.VirtualTask task = new ZHY.Model.VirtualTask();
            task.VSCode = "Admimsy";
            task.VTUserName = userName;
            task.VTPassword = psw;
            task.VTProxy = paInfo.PAName;
            bllTask.Add(task);

            return resHtml;
        }

        private void autoReg() 
        {
            this.wbHTML.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbHTML_Reg_DocumentCompleted);
            this.wbHTML.ScriptErrorsSuppressed = true;
            wbHTML.Navigate("http://www.syihy.com/", false);
        }


        private void autoTask() 
        {
            this.wbHTML.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbHTML_DocumentCompleted);
            this.wbHTML.ScriptErrorsSuppressed = true;
            wbHTML.Navigate("http://www.admimsy.com/Logout.cfm", false);

        }


        private void btnPsnInfo_Click(object sender, EventArgs e)
        {
            GetUSPersonInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="psnCookie"></param>
        /// <returns></returns>
        private string PostData(string url, string postData, ref CookieContainer psnCookie) 
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
            catch(Exception ex)
            {
                //donoting
            }
            finally
            {
                if (responseRs != null)
                {
                    responseRs.Close();
                }
            }
            return "";
        }

        private void GetUSPersonInfo() 
        {
            
            CookieContainer psnCookie = new CookieContainer();
            string resHtml = "";
            //第一步先登录
            string loginURL = "http://cn.zeelin.com/login/ajax-check-web-login/";
            string postData = "email=709757455@qq.com&pw=1qazxsw2&use_cookie=yes";
            PostData(loginURL, postData, ref psnCookie);

            //得到定位到的URL
            loginURL = "http://cn.usinfo.me/ajax-get-new-info-by-condition/";
            //登录所需的信息
            postData = "condition_gender=random&condition_age=youth&condition_state=random&condition_city=random&condition_zip=random";

            resHtml = PostData(loginURL, postData, ref psnCookie);
            //开始解析
            ZHY.Model.VirtualPersonInfo model = new ZHY.Model.VirtualPersonInfo();
            model.VPFullName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "full_name");
            model.VPFirstName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "first_name");
            model.VPLastName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "last_name");
            model.VPMiddleName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "middle_initial");
            model.VPSex = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "gender");
            model.VPBirthday = DateTime.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "birthday"));
            model.VPAge = int.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "age"));
            model.VPCollege = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "college");
            model.VPOccupation = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "occupation");
            model.VPSsn = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "ssn");
            model.VPMail = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "email");
            model.VPNickName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "nick_name");
            //model.VPFullName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "height");
            model.VPBloodType = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "blood_type");
            //model.VPWeight = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "weight");
            model.VPState = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "state");

            model.VPCity = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "city");
            model.VPStreet = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "address");
            model.VPZip = int.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "zip"));
            model.VPPhone = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "phone");
            model.VPVisa = decimal.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_visa_number").Replace(" ", ""));
            model.VPVisaExpirDate = DateTime.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_visa_expiry_date"));

            model.VPCVV2 = int.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_visa_cvv2"));
            model.VPBank = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "bank_name");
            model.VPRoutingNumber = decimal.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "routing_number"));
            model.VPBankAcct = decimal.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "bank_account_number"));
            model.VPMasterCard = decimal.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_mastercard_number").Replace(" ", ""));
            model.VPMExpirDate = DateTime.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_mastercard_expiry_date"));
            model.VPMCVC2 = int.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_mastercard_cvc2"));
            model.VPSite = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "website");


        }

       // ZHY.BLL.VirtualPersonInfo bll = new ZHY.BLL.VirtualPersonInfo();
        private void wbHTML_Psn_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string path = e.Url.AbsolutePath;
            if (path.IndexOf("t.html") > 0)
            {
                ZHY.Model.VirtualPersonInfo model = new ZHY.Model.VirtualPersonInfo();
                HtmlElement full_name = wbHTML.Document.GetElementById("full_name");
                model.VPFullName = full_name.GetAttribute("value");

                HtmlElement first_name = wbHTML.Document.GetElementById("first_name");
                model.VPFirstName = first_name.GetAttribute("value");

                HtmlElement last_name = wbHTML.Document.GetElementById("last_name");
                model.VPLastName = last_name.GetAttribute("value");

                HtmlElement middle_initial = wbHTML.Document.GetElementById("middle_initial");
                model.VPMiddleName = middle_initial.GetAttribute("value");

                HtmlElement gender = wbHTML.Document.GetElementById("gender");
                model.VPSex = gender.GetAttribute("value");

                HtmlElement birthday = wbHTML.Document.GetElementById("birthday");
                model.VPBirthday = DateTime.Parse(birthday.GetAttribute("value"));

                HtmlElement age = wbHTML.Document.GetElementById("age");
                model.VPAge = int.Parse(age.GetAttribute("value"));

                HtmlElement college = wbHTML.Document.GetElementById("college");
                model.VPCollege = college.GetAttribute("value");

                HtmlElement occupation = wbHTML.Document.GetElementById("occupation");
                model.VPOccupation = occupation.GetAttribute("value");

                HtmlElement ssn = wbHTML.Document.GetElementById("ssn");
                model.VPSsn = ssn.GetAttribute("value");

                HtmlElement email = wbHTML.Document.GetElementById("email");
                model.VPMail = email.GetAttribute("value");

                HtmlElement nick_name = wbHTML.Document.GetElementById("nick_name");
                model.VPNickName = nick_name.GetAttribute("value");

                HtmlElement password = wbHTML.Document.GetElementById("password");
                model.VPPassword = password.GetAttribute("value");

                HtmlElement height = wbHTML.Document.GetElementById("height");
                //model.VPHeight = height.GetAttribute("value");

                HtmlElement blood_type = wbHTML.Document.GetElementById("blood_type");
                model.VPBloodType = blood_type.GetAttribute("value");

                HtmlElement weight = wbHTML.Document.GetElementById("weight");
                //model.VPWeight = weight.GetAttribute("value");

                HtmlElement state = wbHTML.Document.GetElementById("state");
                model.VPState = state.GetAttribute("value");

                HtmlElement city = wbHTML.Document.GetElementById("city");
                model.VPCity = city.GetAttribute("value");

                HtmlElement address = wbHTML.Document.GetElementById("address");
                model.VPStreet = address.GetAttribute("value");

                HtmlElement zip = wbHTML.Document.GetElementById("zip");
                model.VPZip = int.Parse(zip.GetAttribute("value"));

                HtmlElement phone = wbHTML.Document.GetElementById("phone");
                model.VPPhone = phone.GetAttribute("value");

                HtmlElement cc_visa_number = wbHTML.Document.GetElementById("cc_visa_number");
                model.VPVisa = decimal.Parse(cc_visa_number.GetAttribute("value").Replace(" ", ""));

                HtmlElement cc_visa_expiry_date = wbHTML.Document.GetElementById("cc_visa_expiry_date");
                model.VPFullName = cc_visa_expiry_date.GetAttribute("value");

                HtmlElement cc_visa_cvv2 = wbHTML.Document.GetElementById("cc_visa_cvv2");
                model.VPCVV2 = int.Parse(cc_visa_cvv2.GetAttribute("value"));

                HtmlElement bank_name = wbHTML.Document.GetElementById("bank_name");
                model.VPBank = bank_name.GetAttribute("value");

                HtmlElement routing_number = wbHTML.Document.GetElementById("routing_number");
                model.VPRoutingNumber = decimal.Parse(routing_number.GetAttribute("value"));

                HtmlElement bank_account_number = wbHTML.Document.GetElementById("bank_account_number");
                model.VPBankAcct = decimal.Parse(bank_account_number.GetAttribute("value"));

                HtmlElement cc_mastercard_number = wbHTML.Document.GetElementById("cc_mastercard_number");
                model.VPMasterCard = decimal.Parse(cc_mastercard_number.GetAttribute("value").Replace(" ", ""));

                HtmlElement cc_mastercard_expiry_date = wbHTML.Document.GetElementById("cc_mastercard_expiry_date");
                model.VPMExpirDate = DateTime.Parse(cc_mastercard_expiry_date.GetAttribute("value"));

                HtmlElement cc_mastercard_cvc2 = wbHTML.Document.GetElementById("cc_mastercard_cvc2");
                model.VPMCVC2 = int.Parse(cc_mastercard_cvc2.GetAttribute("value"));

                HtmlElement website = wbHTML.Document.GetElementById("website");
                model.VPSite = website.GetAttribute("value");
                //bll.Add(model);
            }
        }

        private void wbHTML_Reg_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) 
        {
            string path = e.Url.Host;
            if (!string.IsNullOrEmpty(path) && path.IndexOf("syihy.com") > 0 && !firstStep)
            {
                HtmlElement admimsy = wbHTML.Document.GetElementById("admimsy");
                admimsy.InvokeMember("click");
                firstStep = true;
            }

            if (!string.IsNullOrEmpty(path) && path.IndexOf("admimsy.com") > 0)
            {
                if(firstStep && !secondStep)
                {
                    HtmlElementCollection htc = wbHTML.Document.GetElementsByTagName("a");
                    foreach (HtmlElement he in htc)
                    {
                        string view = he.GetAttribute("href");
                        if (he.GetAttribute("href").LastIndexOf("CreateAccount.cfm") > 0)
                        {
                            he.InvokeMember("click");
                            secondStep = true;
                            return;
                        }
                    }
                }

                if (secondStep && !thirdStep)
                {
                    HtmlElement userName = wbHTML.Document.GetElementById("UserName");
                    userName.SetAttribute("value", "james00404");
                    HtmlElement password = wbHTML.Document.GetElementById("password");
                    password.SetAttribute("value", "james1qazxsw2");
                    HtmlElement emailAddress = wbHTML.Document.GetElementById("EmailAddress");
                    emailAddress.SetAttribute("value", "james002@gmail.com");
                    HtmlElement gender = wbHTML.Document.GetElementById("Gender");
                    gender.SetAttribute("value", "Female");                    
                    HtmlElement theMonth = wbHTML.Document.GetElementById("TheMonth");
                    theMonth.SetAttribute("value", "2");
                    HtmlElement theDay = wbHTML.Document.GetElementById("TheDay");
                    theDay.SetAttribute("value", "7");
                    HtmlElement theYear = wbHTML.Document.GetElementById("TheYear");
                    theYear.SetAttribute("value", "1982");
                    HtmlElement numberAbove = wbHTML.Document.GetElementById("NumberAbove");                    
                    HtmlElement numberBelow = wbHTML.Document.GetElementById("NumberBelow");
                    numberBelow.SetAttribute("value", numberAbove.GetAttribute("value"));
                    HtmlElement b1 = wbHTML.Document.GetElementById("B1");
                    b1.InvokeMember("click");
                    thirdStep = true;
                }

            }

        }

        private bool firstStep = false;
        private bool secondStep = false;
        private bool thirdStep = false;
        private bool fouthStep = false;
        private bool fifthStep = false;

        private bool isEndAD = false;

        private void wbHTML_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string path = e.Url.AbsolutePath;
            if (!firstStep)
            {
                try
                {
                    HtmlElement userName = wbHTML.Document.GetElementById("UserName");
                    if (userName == null)
                        return;
                    HtmlElement password = wbHTML.Document.GetElementById("Password");
                    HtmlElement loginSubmit = wbHTML.Document.GetElementById("loginSubmit");
                    userName.SetAttribute("value", "james00404");
                    password.SetAttribute("value", "james1qazxsw2");
                    loginSubmit.InvokeMember("click");
                    firstStep = true;
                    return;
                }
                catch { 
                
                }
            }
            
            
            if (firstStep && !secondStep)
            {
              HtmlElementCollection htc = wbHTML.Document.GetElementsByTagName("a");
              foreach(HtmlElement he in htc)
              {
                  string view = he.GetAttribute("href");
                  if (he.GetAttribute("href").LastIndexOf("ViewAds.cfm")>0)
                  {
                      he.InvokeMember("click");
                      secondStep = true;
                      return;
                  }
              }
            }

            if (secondStep&&!thirdStep)
            {
                HtmlElementCollection htc = wbHTML.Document.GetElementsByTagName("a");
                foreach (HtmlElement he in htc)
                {
                    string view = he.GetAttribute("href");
                    if (he.GetAttribute("href").LastIndexOf("ADViewer.cfm?A=") > 0)
                    {
                        he.InvokeMember("click");
                        thirdStep = true;
                        return;
                    }
                }
            }
            if (!string.IsNullOrEmpty(path)&&
                path.IndexOf("TopViewAd") > 0 && 
                thirdStep && !fouthStep)
            {
                try
                {
                    HtmlDocument topFrame = wbHTML.Document.Window.Frames["topFrame"].Document;
                    topFrame.InvokeScript("onfinish",null);
                    fouthStep = true;
                }
                catch {

                    Console.WriteLine("fasdfasdf");
                }
                
            }
            
            if(!string.IsNullOrEmpty(path)&&
                path.IndexOf("ADViewer") > 0 &&
                fouthStep && !fifthStep)
            {
                HtmlDocument topFrame = wbHTML.Document.Window.Frames["topFrame"].Document;
                topFrame.InvokeScript("onfinish", null);
                isEndAD = true;
                tmAdview.Start();
            }
        }

        private void tmAdview_Tick(object sender, EventArgs e)
        {
            if (isEndAD)
            {
                firstStep = true;
                secondStep = true;
                thirdStep = false;
                fouthStep = false;
                fifthStep = false;
                wbHTML.Navigate("http://www.admimsy.com/ViewAds.cfm");
                wbHTML.Document.ExecCommand("Refresh", false, null);
                isEndAD = false;
                tmAdview.Stop();
            }
        }

        private void btnTestProxy_Click(object sender, EventArgs e)
        {
            ZHY.BLL.ProxyAddress bll = new ZHY.BLL.ProxyAddress();

            List<ZHY.Model.ProxyAddress> list = bll.GetModelList(" PACountry = 'United States'");
            int i = 0;
            int j = 0;
            foreach (ZHY.Model.ProxyAddress model in list)
            {
                if(j==4)
                {
                    break;
                }
                if (HttpProxy.CheckProxyConnected(model.PAName))
                {
                    //this.lsProxy.Items.Add(model.PAName);
                    txtProxy.Text = model.PAName;
                    break;
                    j++;
                }
                else
                {
                    i++;
                    //bll.Delete(model.PAId);
                }
            }
            MessageBox.Show("无效的代理地址数：" + i);
        }

        private void btnProxyList_Click(object sender, EventArgs e)
        {
            ZHY.BLL.ProxyAddress bll = new ZHY.BLL.ProxyAddress();
            bll.ExtractProxyAddress();
        }

        private void btnCnty_Click(object sender, EventArgs e)
        {
            CookieContainer cookie = new CookieContainer();
            string resHtml = HttpProxy.GetResponseData("http://www.twodollarclick.com/index.php?view=join&", "", ref cookie);
            string value = HtmlPaserUtil.ExtractHtmlsourceBySelectTag(resHtml, "Venezuela");

        }

    }
}