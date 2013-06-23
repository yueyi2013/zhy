using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.forum
{
    public partial class membervalidate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string str = Request.QueryString["user"];
                if (string.IsNullOrEmpty(str))
                {

                }
                else {
                    ActiveMemeber(str);
                }
            }
        }

        private void ActiveMemeber(string memId)
        {
            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            if (bll.IsActiveCodeExpired(memId))
            {

            }
            else
            {
                bll.ActiveMember(memId);
                Response.Redirect("~/forum/regsuccess.aspx?user=" + memId);
            }
        }
    }
}