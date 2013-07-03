using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:SystemConfig
	/// </summary>
	public partial class SystemConfig:BaseDAL
	{
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.SystemConfig GetModel(string SCAttrName, string SCGroup)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SCId,SCAttrName,SCGroup,SCAttrValue,SCAttrValue2,SCAttrType,SCDescription,SCStatus,CreateAt,CreateBy,UpdateDT,UpdateBy from SystemConfig ");
            strSql.Append(" where SCAttrName=@SCAttrName and SCGroup=@SCGroup");
            SqlParameter[] parameters = {
					new SqlParameter("@SCAttrName", SqlDbType.VarChar,10),
					new SqlParameter("@SCGroup", SqlDbType.VarChar,20)
			};
            parameters[0].Value = SCAttrName;
            parameters[1].Value = SCGroup;

            ZHY.Model.SystemConfig model = new ZHY.Model.SystemConfig();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
	}
}

