using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.forum
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["GUID"] = System.Guid.NewGuid().ToString();
                this.lblGUID.Text = this.ViewState["GUID"].ToString();
            }
        }

        protected void imgbtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            #region 检查验证码
            if ((Session["CheckCode"] != null) && (Session["CheckCode"].ToString().Trim() != ""))
            {
                if (Session["CheckCode"].ToString().ToLower() != this.CheckCode.Text.ToLower())
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
            //System.Threading.Thread.Sleep(3000);
            string memaccount = this.txtUserName.Text;
            string mempsw = this.txtUserPsw.Text;
            ZHY.Model.Member model = new ZHY.Model.Member();
            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            if (bll.ValidateMember(memaccount, mempsw, model))
            {
                Session["MemUser"] = model;
                Response.Redirect("member/membercenter.aspx");
            }
            else
            {
                this.lblMsg.Text = "用户名或密码错误，登录失败！";                
            }
        }
    }
}