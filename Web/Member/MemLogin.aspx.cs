using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Member
{
    public partial class MemLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string memaccount = this.txtUserName.Text;
            string mempsw = this.txtUserPsw.Text;
            ZHY.Model.Member model=new ZHY.Model.Member();
            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            if (bll.ValidateMember(memaccount, mempsw, model))
            {
                this.lblUserName.Text = model.MemAccount;
            }
            else {

                Response.Redirect("register.html");
            }

        }
    }
}
