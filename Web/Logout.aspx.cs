using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace ZHY.Web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取票据
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                //删除票据
                FormsAuthentication.SignOut();
            }
            //清除Cookie
            Request.Cookies.Clear();
            HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
            HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-100);
            HttpContext.Current.Session.Abandon();
            //定向到登陆页面
            Response.Redirect("Login.aspx");
        }
    }
}
