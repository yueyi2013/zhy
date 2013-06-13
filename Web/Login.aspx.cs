using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Model;
namespace ZHY.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["GUID"] = System.Guid.NewGuid().ToString();
                this.lblGUID.Text = this.ViewState["GUID"].ToString();
            }


        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
            {
                int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                if (PassErroeCount > 3)
                {
                    txtUsername.Disabled = true;
                    txtPass.Disabled = true;
                    btnLogin.Enabled = false;
                    this.lblMsg.Text = "对不起，你错误登录了三次，系统登录锁定！";
                    return;
                }

            }

            #region 检查验证码
            if ((Session["CheckCode"] != null)&&(Session["CheckCode"].ToString().Trim() != ""))
            {
                if (Session["CheckCode"].ToString().ToLower() != this.CheckCode.Value.ToLower())
                {
                    this.lblMsg.Text = "所填写的验证码与所给的不符 !";
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
                Response.Redirect("Login.aspx");
            }
            #endregion
            Model.User user = new User();
            string username = this.txtUsername.Value;
            string psw = this.txtPass.Value;
            ZHY.BLL.User bizUser = new ZHY.BLL.User();

            if (bizUser.ValidateUser(username, psw, user))
            {
                Session["User"] = user;
                AuthenticationUsers(username);
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            else {
                this.lblMsg.Text = "用户名或密码不正确，请重新填写！";
            }
        }

        /// <summary>
        /// 向客户端发票据
        /// </summary>
        /// <param name="adminId">用户ID</param>
        public void AuthenticationUsers(string adminId)
        {
            //创建票据
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, adminId, DateTime.Now, DateTime.Now.AddHours(24), true, "");
            //获取票据信息
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            //创建HttpCookie
            HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            //设置Cookie的值
            userCookie.Value = hashTicket;
            //设置Cookie的过期时间
            userCookie.Expires = ticket.Expiration;
            //设置将次Cookie关联的域
            userCookie.Domain = FormsAuthentication.CookieDomain;
            //发送Cookie
            HttpContext.Current.Response.Cookies.Add(userCookie);
        }
    }
}
