using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Web.admin.sys
{
    public partial class wfGenSQLCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }


        private void GennerateSQLCode()
        {            
            StringBuilder strSql = new StringBuilder();
            
            this.divSQLCode.InnerHtml = strSql.ToString();
        }

        private void FunctionList(StringBuilder strSql) 
        {
            ZHY.BLL.Function bll = new ZHY.BLL.Function();
            List<ZHY.Model.Function> list = bll.DataTableToList(bll.GetAllList().Tables[0]);
            foreach (ZHY.Model.Function model in list)
            {
                strSql.Append("insert into Functions(");
                strSql.Append("FunCode,FunName,FunPage,FunDes,CreateAt,CreateBy,UpdateDT,UpdateBy");
                strSql.Append(")");
                strSql.Append(" values (");
                strSql.Append("'" + model.FunCode + "',");
                strSql.Append("'" + model.FunName + "',");
                strSql.Append("'" + model.FunPage + "',");
                strSql.Append("'" + model.FunDes + "',");
                strSql.Append("getdate(),");
                strSql.Append("'" + model.CreateBy + "',");
                strSql.Append("getdate(),");
                strSql.Append("'" + model.UpdateBy + "'");
                strSql.Append(");");
                strSql.Append("<br/>");
            }
        }

        private void MenuList(StringBuilder strSql)
        {

        }

        private void AdminList(StringBuilder strSql)
        {

        }

        private void MemberList(StringBuilder strSql)
        {

        }

        protected void btnGen_Click(object sender, EventArgs e)
        {
            GennerateSQLCode();
        }

        protected void btnCreateDB_Click(object sender, EventArgs e)
        {
            ZHY.BLL.SetupDatabase bll = new ZHY.BLL.SetupDatabase();
            string dbName = this.txtDBName.Text;
            string sqlFilesName = this.txtSQLCode.Text;
            StringBuilder sbInfo = new StringBuilder();
            if(this.rbSQLCodeType.SelectedItem.Value.Equals("0"))
            {
                ExecuteSQLCode(sqlFilesName, sbInfo,dbName, bll);
            }else{
                ExecuteSQLFile(sqlFilesName, sbInfo, dbName, bll);
            }
            this.divSQLCode.InnerHtml = sbInfo.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ExecuteSQLFile(string sqlFilesName, StringBuilder sbInfo, string dbName, ZHY.BLL.SetupDatabase bll)
        {
            string[] strName = { };
            if (!string.IsNullOrEmpty(sqlFilesName))
            {
                strName = sqlFilesName.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (string str in strName)
            {
                StringBuilder sb = new StringBuilder();
                sbInfo.Append(str);
                if (bll.CreateDBTables(Server.MapPath(sb.AppendFormat("~/dbscripts/tables/{0}", str).ToString()), dbName))
                {
                    sbInfo.Append("&nbsp;&nbsp;<font color='red'>创建成功！</font>");
                }
                else
                {
                    sbInfo.Append("&nbsp;&nbsp;<font color='red'>创建失败！</font>");
                }
                sbInfo.Append("<br/>");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ExecuteSQLCode(string sqlFilesName, StringBuilder sbInfo, string dbName, ZHY.BLL.SetupDatabase bll)
        {            
            sbInfo.Append(sqlFilesName);
            sbInfo.Append("<br/>");
            if (bll.CreateDBTablesBySqlCode(sqlFilesName, dbName))
            {
                sbInfo.Append("&nbsp;&nbsp;<font color='red'>创建成功！</font>");
            }
            else
            {
                sbInfo.Append("&nbsp;&nbsp;<font color='red'>创建失败！</font>");
            }            
        }
    }
}