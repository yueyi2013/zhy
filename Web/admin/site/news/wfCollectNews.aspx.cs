using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ZHY.Model;

namespace Web.admin.site.news
{
    public partial class wfCollectNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCollectNews_Click(object sender, EventArgs e)
        {
            ZHY.BLL.NewsInfo bll = new ZHY.BLL.NewsInfo();
            User user = new User();
            if (Session["User"] != null)
            {
                user = (User)Session["User"];
            }
            else
            {
                user.UserName = "未知用户";
            }
            //bll.NewsCollect(this.txtUrl.Text, user.UserName);
        }

        protected void lbViewNews_Click(object sender, EventArgs e)
        {

        }
    }
}