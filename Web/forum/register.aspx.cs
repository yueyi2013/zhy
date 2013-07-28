using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZHY.Mail;
using ZHY.Common;
using LTP.Common;

namespace Web.forum
{
    public partial class register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["GUID"] = System.Guid.NewGuid().ToString();
                this.lblGUID.Text = this.ViewState["GUID"].ToString();
            }
        }

        protected void lbReg_Click(object sender, EventArgs e)
        {
            #region 检查验证码
            if ((Session["CheckCode"] != null) && (Session["CheckCode"].ToString().Trim() != ""))
            {
                if (Session["CheckCode"].ToString().ToLower() != this.CheckCode.Value.ToLower())
                {
                    //this..Text = "所填写的验证码与所给的不符 !";
                    Session["CheckCode"] = null;
                    return;
                }
                else
                {
                    Session["CheckCode"] = null;
                }
            }
            else
            {
               return;
            }
            #endregion
            ZHY.BLL.SystemMail bll = new ZHY.BLL.SystemMail();
            ZHY.BLL.Member bllMem = new ZHY.BLL.Member();
            List<ZHY.Model.SystemMail> list = bll.DataTableToList(bll.GetList(1," SMStatus ='A' "," SMOrder ").Tables[0]);
            ZHY.Model.SystemMail model = list[0];
            MailModel mail = new MailModel();
            mail.SmtpName = "SMTP." + model.SMHost;
            mail.Port = "25";
            mail.MailFromAddress = model.SMFromAddress;
            mail.MailPassword = model.SMMailPsw;
            mail.Subject = "[SYIHY]账户激活通知";
            StringBuilder sbBoday = new StringBuilder();
            StringBuilder sbURL = new StringBuilder();
            string uId = this.txtUserName.Text;
            sbURL.AppendFormat("您的初始登录密码是：{0}", Constants.DEFAULT_SITE_USER_PASSWORD);
            string content = FileOperation.GetFileContent(Server.MapPath("~/inc/sysmailcontent.inc"));
            sbBoday.AppendFormat(content, uId, sbURL.ToString(), 1, DateTime.Now.AddHours(1), 90);
            mail.MailContent =  sbBoday.ToString();
            if (MailUtil.SendMail(mail, this.txtEmail.Text))
            {
                ZHY.Model.Member modelMem = new ZHY.Model.Member();
                modelMem.MemMail = this.txtEmail.Text;
                modelMem.MemAccount = uId;
                modelMem.MemPsw = Constants.DEFAULT_SITE_USER_PASSWORD;
                modelMem.MemStatus = "A";
                bllMem.Add(modelMem);
                Response.Redirect("~/forum/regactive.aspx?MemEmail=" + modelMem.MemMail);
            }
            else {
                
                //MessageBox.ShowConfirm(this.upLogin, this.GetType(), "这册失败！");
                lblMsg.Text = "注册失败！";
            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            if (bll.ValidateExistedEmail(this.txtEmail.Text))
            {
                this.cvEmail.IsValid = true;
            }
            else {
                this.cvEmail.IsValid = false;
                this.cvEmail.ErrorMessage = "此邮箱已经被注册。";
            }
        }
    }
}