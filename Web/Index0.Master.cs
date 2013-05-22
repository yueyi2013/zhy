using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web
{
    public partial class Index0 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MemUser"] != null)
                {
                    this.lblMember.Text = ((ZHY.Model.Member)Session["MemUser"]).MemAccount;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindLanMu() 
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void BindFriendInfo() 
        {

        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            string memaccount = this.txtUserName.Text;
            string mempsw = this.txtUserPsw.Text;
            ZHY.Model.Member model=new ZHY.Model.Member();
            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            if (bll.ValidateMember(memaccount, mempsw, model))
            {
                this.lblMember.Text = model.MemAccount;
                this.LoginForm.Style.Add("display", "none");
                this.ExitForm.Style.Add("display", "block");
                Session["MemUser"] = model;
            }
            else {
                MessageBox.SelfInform(this.upLogin, this.GetType(), "用户名或密码错误，登录失败！");
                Response.Redirect("login.html");
            }
        }
    }
}
