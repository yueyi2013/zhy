using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.sys
{
    public partial class wfExecSQlCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            string sqlCode = this.txtSQLCode.Text;
            if (string.IsNullOrEmpty(sqlCode))
            {
                this.lblResult.Text = "请输入SQL代码！";
                this.gvResult.Visible = false;
                return;
            }
            ZHY.BLL.SetupDatabase bll = new ZHY.BLL.SetupDatabase();
            if (this.rbSQLType.SelectedItem.Value.Equals("0"))
            {                
                this.gvResult.DataSource = bll.ExecuteQuerySQL(sqlCode);
                this.gvResult.DataBind();
                this.gvResult.Visible = true;
            }
            else {
                int result = bll.ExecuteNonQuerySQL(sqlCode);
                this.lblResult.Text = result+"行受影响！";
                this.gvResult.Visible = false;
            }        

        }
    }
}