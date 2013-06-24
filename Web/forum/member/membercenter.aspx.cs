using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.forum
{
    public partial class membercenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["MemUser"] == null || string.IsNullOrEmpty(Session["MemUser"].ToString()))
                {
                    Response.Redirect("~/forum/memberlogin.aspx");
                }
                else {
                    BindMemberMenuList();
                }
            }
        }

        /// <summary>
        /// 绑定会员菜单栏
        /// </summary>
        private void BindMemberMenuList()
        {
            ZHY.BLL.MemberMenu bll = new ZHY.BLL.MemberMenu();
            this.blNav.DataSource = bll.GetList("MMStatus='A'", "MMOrder");
            this.blNav.DataBind();
        }

        protected void blNav_Click(object sender, BulletedListEventArgs e)
        {
            
        }

    }
}