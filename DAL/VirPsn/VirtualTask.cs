using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����:VirtualTask
	/// </summary>
	public partial class VirtualTask : BaseDAL
	{
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VirtualTask");
            strSql.Append(" where VTUserName=@VTUserName");
            SqlParameter[] parameters = {
					new SqlParameter("@VTUserName", SqlDbType.VarChar)
			};
            parameters[0].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}

