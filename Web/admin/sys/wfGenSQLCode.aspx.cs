using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;
using ZHY.Common;

namespace Web.admin.sys
{
    public partial class wfGenSQLCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindTables();
            }
        }

        private void GenDataSQL(string tableName, StringBuilder strSql, ZHY.BLL.SetupDatabase bll) 
        {
            bll = new ZHY.BLL.SetupDatabase();
            DataSet dsSch = bll.ExecuteQuerySQL("select * from " + tableName, tableName);
            DataSet ds = bll.ExecuteQuerySQL("select * from " + tableName);
            int cols = ds.Tables[0].Columns.Count;           

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                StringBuilder strColSql = new StringBuilder();
                StringBuilder strRowSql = new StringBuilder();
                strColSql.AppendFormat("insert into {0}(", tableName);
                strRowSql.AppendFormat(" values (");
                int m = 0;
                //绑定列名
                foreach (DataColumn dc in dsSch.Tables[0].Columns)
                {
                    if (dc.AutoIncrement)
                    {
                        continue;
                    }
                    if (m == 0)
                    {
                        strColSql.Append(dc.ColumnName);
                        strRowSql.AppendFormat("'{0}'", dr[dc.ColumnName]);
                        m++;
                        continue;
                    }
                    strColSql.AppendFormat(",{0}", dc.ColumnName); 
                    strRowSql.AppendFormat(",{0}",dc.DataType.Name.Equals(SqlDbType.DateTime.ToString())?"getdate()":"'"+dr[dc.ColumnName]+"'");
                }
                strColSql.AppendFormat(")");
                strSql.Append(strColSql.ToString());
                strSql.Append(strRowSql.ToString());
                strSql.Append(");");
                strSql.Append("<br/>");
            }
        }
        
        /// <summary>
        /// 绑定表
        /// </summary>
        private void BindTables()
        {
            ZHY.BLL.SetupDatabase bll = new ZHY.BLL.SetupDatabase();
            this.lbTables.DataSource = bll.ExecuteQuerySQL("select * from INFORMATION_SCHEMA.TABLES order by TABLE_NAME");
            this.lbTables.DataBind();
        }


        private void GennerateSQLCode()
        {            
            StringBuilder strSql = new StringBuilder();
            ZHY.BLL.SetupDatabase bll = new ZHY.BLL.SetupDatabase();
            foreach(ListItem item in this.lbTables.Items)
            {
                if (item.Selected)
                {
                    GenDataSQL(item.Value, strSql, bll);
                }
            }            
            this.divSQLCode.InnerHtml = strSql.ToString();
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

        protected void btnBatchCreate_Click(object sender, EventArgs e)
        {
            string fileDir = Server.MapPath("~/"+this.txtSQLCode.Text);
            string[] str = FileOperation.GetFilePathList(fileDir);
            ZHY.BLL.SetupDatabase bll = new ZHY.BLL.SetupDatabase();
            string dbName = this.txtDBName.Text;
            StringBuilder sbInfo = new StringBuilder();
            foreach(string path in str)
            {
                sbInfo.Append(path);
                if (bll.CreateDBTables(path, dbName))
                {
                    sbInfo.Append("&nbsp;&nbsp;<font color='red'>创建成功！</font>");
                }
                else
                {
                    sbInfo.Append("&nbsp;&nbsp;<font color='red'>创建失败！</font>");
                }
                sbInfo.Append("<br/>");
            }
            this.divSQLCode.InnerHtml = sbInfo.ToString();
        }
    }
}