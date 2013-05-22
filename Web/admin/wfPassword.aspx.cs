using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSure_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                ZHY.Model.User model = (ZHY.Model.User)Session["User"];
                ZHY.BLL.User bll = new ZHY.BLL.User();
                if (this.txtYPsw.Text == model.UserPsw)
                {
                    model.UserPsw = this.txtNPsw.Text;
                    bll.Update(model);
                    MessageBox.SelfInform(this.upPsw, this.GetType(), "密码更新成功！");
                }
                else
                {
                    MessageBox.SelfInform(this.upPsw, this.GetType(), "原密码错误！");
                }
            }
        }
    }
}
