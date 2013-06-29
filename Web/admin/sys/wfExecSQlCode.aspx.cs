using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;

namespace Web.admin.sys
{
    public partial class wfExecSQlCode : BasePage
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
                this.lblResult.Visible = false;
                if (this.gvResult.DataSource==null)
                    SelfInform(this.MyUpdatePanelBody, this.GetType(), "执行失败，请检查SQL语句！");
            }
            else {
                int result = bll.ExecuteNonQuerySQL(sqlCode);
                this.lblResult.Text = result+"行受影响！";
                this.gvResult.Visible = false;
            }        

        }
    }
}