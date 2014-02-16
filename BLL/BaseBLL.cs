using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZHY.Mail;
using ZHY.Common;
using System.Net;

namespace ZHY.BLL
{
    public class BaseBLL
    {
        private ZHY.Model.SystemConfig scModelMail = null;
        private ZHY.Model.SystemMail modelMail = null;

        public ZHY.Model.SystemConfig GetSCMailModel() 
        {
            if (scModelMail == null)
            {
                ZHY.BLL.SystemConfig bll = new ZHY.BLL.SystemConfig();
                this.scModelMail = bll.GetModel(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_RECEIVER, Constants.SYSTEM_CONFIG_ATT_GROUP_NEWS);
            }
            return scModelMail;
        }

        public ZHY.Model.SystemMail GetMailModel()
        {
            if (modelMail == null)
            {
                ZHY.BLL.SystemMail bll = new ZHY.BLL.SystemMail();
                List<ZHY.Model.SystemMail> list = bll.DataTableToList(bll.GetList(1, " SMStatus ='A' ", " SMOrder ").Tables[0]);
                this.modelMail = list[0];
            }
            return modelMail;
        }

        /// <summary>
        /// 邮件提醒
        /// </summary>
        /// <param name="subject">邮件主题</param>
        /// <param name="mailContent">邮件内容</param>
        /// <param name="receiver">收件人</param>
        /// <returns></returns>
        public bool AlertEmail(string subject,string mailContent,string receiver) 
        {
            ZHY.Model.SystemMail model = GetMailModel();
            MailModel mail = new MailModel();
            mail.SmtpName = "SMTP." + model.SMHost;
            mail.Port = "25";
            mail.MailFromAddress = model.SMFromAddress;
            mail.MailPassword = model.SMMailPsw;
            mail.Subject = subject;
            mail.MailContent =  mailContent;
            return MailUtil.SendMail(mail, receiver);
        }

        /// <summary>
        /// 邮件提醒（使用系统默认收件人）
        /// </summary>
        /// <param name="subject">邮件主题</param>
        /// <param name="mailContent">邮件内容</param>
        /// <returns></returns>
        public bool AlertEmail(string subject,string mailContent) 
        {
            bool sendSuccess = false;
            ZHY.Model.SystemConfig model = GetSCMailModel();
            if (string.IsNullOrEmpty(model.SCAttrValue))
                sendSuccess = AlertEmail(subject, mailContent, Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_RECEIVER_DEFAULT);
            else
                sendSuccess = AlertEmail(subject, mailContent, model.SCAttrValue);
            return sendSuccess;
        }

        /// <summary>
        /// 返回系统配置信息
        /// </summary>
        /// <param name="SCAttrName">属性名</param>
        /// <param name="SCGroup">属性组名</param>
        /// <returns></returns>
        public ZHY.Model.SystemConfig GetSystemConfig(string SCAttrName, string SCGroup) 
        {
            ZHY.BLL.SystemConfig bll = new ZHY.BLL.SystemConfig();
            return bll.GetModel(SCAttrName, SCGroup);
        }

        /// <summary>
        /// 检查是否启用job
        /// </summary>
        /// <param name="SCAttrName"></param>
        /// <param name="SCGroup"></param>
        /// <returns></returns>
        public bool CheckJobIsEnabled(string SCAttrName, string SCGroup)
        {
            ZHY.Model.SystemConfig model = this.GetSystemConfig(SCAttrName, SCGroup);
            if (model != null && model.SCAttrValue.Equals("Y"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 得到有效的代理地址
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.ProxyAddress GetValidProxyAddress(int count)
        {
            ZHY.BLL.ProxyAddress bll = new ZHY.BLL.ProxyAddress();

            List<ZHY.Model.ProxyAddress> list = bll.DataTableToList(bll.GetList(count, "", " newid() ").Tables[0]);

            foreach (ZHY.Model.ProxyAddress model in list)
            {
                if (HttpProxy.CheckProxyConnected(model.PAName))
                {
                    return model;
                }
            }

            return null;
        }

        /// <summary>
        /// 得到httpwebrequest 对象
        /// </summary>
        /// <param name="url"></param>
        /// <param name="proxy"></param>
        /// <param name="adCookie"></param>
        /// <returns></returns>
        public HttpWebRequest GetHttpWebRequest(string url, string proxy, ref CookieContainer adCookie)
        {
            //System.GC.Collect();
            HttpWebRequest requestRs = (HttpWebRequest)WebRequest.Create(url);
            requestRs.AllowWriteStreamBuffering = true;
            //WebHeaderCollection whc = requestRs.Headers;
            if (!string.IsNullOrEmpty(proxy))
            {
                WebProxy wbPrx = new WebProxy(proxy);
                requestRs.Proxy = wbPrx;
            }
            else
            {
                requestRs.Proxy = null;
            }
            // whc.Add("Accept-Charset:GBK,utf-8;q=0.7,*;q=0.3");
            //whc.Add("Accept-Encoding:gzip,deflate,sdch");
            // whc.Add("Accept-Language:en;q=0.8");
            requestRs.ServicePoint.ConnectionLimit = int.MaxValue;
            requestRs.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31";
            requestRs.KeepAlive = false;
            requestRs.ProtocolVersion = HttpVersion.Version11;
            requestRs.Timeout = 30 * 60 * 1000;
            requestRs.ReadWriteTimeout = 30 * 60 * 1000;
            requestRs.CookieContainer = adCookie;
            return requestRs;
        }
    }
}
