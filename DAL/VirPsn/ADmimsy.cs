using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:ADmimsy
	/// </summary>
	public partial class ADmimsy : BaseDAL
	{
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ADmimsy");
            strSql.Append(" where AdmyUserName=@AdmyUserName");
            SqlParameter[] parameters = {
					new SqlParameter("@AdmyUserName", SqlDbType.VarChar)
			};
            parameters[0].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}

