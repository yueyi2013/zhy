using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailSender;

namespace Web.forum
{
    public partial class register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbReg_Click(object sender, EventArgs e)
        {

        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            this.lblEmailMsg.Text = "无效的邮箱地址。";
        }
    }
}