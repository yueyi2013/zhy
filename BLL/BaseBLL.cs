using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZHY.Mail;
using ZHY.Common;

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

    }
}
