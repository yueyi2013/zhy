using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.Member
{
    public partial class MemPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSure_Click(object sender, EventArgs e)
        {
            if (Session["MemUser"] != null)
            {
                ZHY.Model.Member model = (ZHY.Model.Member)Session["MemUser"];
                ZHY.BLL.Member bll = new ZHY.BLL.Member();
                if (this.txtYPsw.Text == model.MemPsw)
                {
                    model.MemPsw = this.txtNPsw.Text;
                    bll.Update(model);
                    MessageBox.SelfInform(this.upPsw, this.GetType(), "密码更新成功！");
                }
                else {
                    MessageBox.SelfInform(this.upPsw,this.GetType(),"原密码错误！");
                }
            }
        }
    }
}
