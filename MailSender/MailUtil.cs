using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;
using System.Net.Mime;

namespace MailSender
{
    class MailUtil
    {

        public static MailModel jobMail = null;
        public static ArrayList recList = null;

        public static bool SendMail(MailModel mail, string receiver)
        {
            try
            {
                //创建smtpclient对象
                SmtpClient client = new SmtpClient();
                client.Host = mail.SmtpName;
                client.Timeout = 30000;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mail.MailFromAddress, mail.MailPassword);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                //创建mailMessage对象 
                MailMessage message = new MailMessage(mail.MailFromAddress, receiver);
                message.Subject = mail.Subject;
                //正文默认格式为html

                var str_html = RegexHtml(mail.MailContent);
                //处理所有img标签  
                var htmlBody = GetHtmlImageUrlList(mail.MailContent, str_html);
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.AlternateViews.Add(htmlBody);
                message.Body = str_html;

                //添加附件
                if (mail.AttPathList.Count != 0)
                {
                    foreach (string path in mail.AttPathList)
                    {
                        Attachment data = new Attachment(path, MediaTypeNames.Application.Octet);
                        message.Attachments.Add(data);
                    }
                }

                ////如果发送失败，SMTP 服务器将发送 失败邮件告诉我   
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                ////异步发送完成时的处理事件   
                //client.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);   

                client.Send(message);
            }
            catch
            {
                return false;
            }
            return true;
        }

        static void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //MessageBox.Show("发送被取消");
            }
            else
            {
                if (e.Error == null)
                {
                    //MessageBox.Show("发送成功");
                }
                else
                {
                    //MessageBox.Show("发送失败： " + e.Error.Message);
                }
            }
        }

        /// <summary>
        /// 读取邮件信息
        /// </summary>
        /// <returns></returns>
        public static MailModel GetMailAssistemt()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("mails/MailAss.ser", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                return (MailModel)bf.Deserialize(fs);
            }
            catch
            {
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 保存邮件信息
        /// </summary>
        /// <param name="mailAss"></param>
        public static void SaveMailAssistemt(MailModel mailAss)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("mails/MailAss.ser", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, mailAss);
            }
            catch
            {
                return;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }

            }
        }

        public static AlternateView GetHtmlImageUrlList(string sHtmlText, string str_html)
        {
            AlternateView htmlBody = AlternateView.CreateAlternateViewFromString(str_html, Encoding.UTF8, "text/html");
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r;>]*)[^<>]*?/?[\s\t\r\n]*>",
                RegexOptions.IgnoreCase);
            MatchCollection matches = regImg.Matches(sHtmlText);
            var i = 0;
            foreach (Match match in matches)
            {
                var src = match.Groups["imgUrl"].Value;
                if (!src.Contains("http://www"))//绝对路径图片不处理  
                {
                    var fileName_index = src.LastIndexOf("\\");
                    //var cid = src.Substring(fileName_index + 1, src.Length - fileName_index - 6);
                    i++;
                    var cid = i;
                    LinkedResource lrImage = new LinkedResource(src.Replace("\"", ""), "image/gif");
                    lrImage.ContentId = cid.ToString();
                    htmlBody.LinkedResources.Add(lrImage);
                }
            }
            return htmlBody;
        }

        /// <summary>  
        /// 替换img标签的sec属性  
        /// </summary>  
        /// <param name="htmltext">html</param>  
        /// <returns></returns>  
        public static string RegexHtml(string htmltext)
        {
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r;>]*)[^<>]*?/?[\s\t\r\n]*>",
                RegexOptions.IgnoreCase);
            MatchCollection matches = regImg.Matches(htmltext);
            var i = 0;
            foreach (Match match in matches)
            {
                var src = match.Groups["imgUrl"].Value;
                if (!src.Contains("http://spimg"))
                {
                    i++;
                    var fileName_index = src.LastIndexOf("\\");
                    //var cid = src.Substring(fileName_index + 1, src.Length - fileName_index - 6);
                    var cid = i;
                    var repHtml = htmltext.Replace("\\", "/");
                    var repSrc = src.Replace("\\", "/");
                    htmltext = Regex.Replace(repHtml, repSrc, "cid:" + cid.ToString() + "\"", RegexOptions.None);
                }
            }
            return htmltext;
        }  
    }
}
