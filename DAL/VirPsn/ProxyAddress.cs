using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����:ProxyAddress
	/// </summary>
	public partial class ProxyAddress : BaseDAL
	{
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string PAName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProxyAddress");
            strSql.Append(" where PAName=@PAName");
            SqlParameter[] parameters = {
					new SqlParameter("@PAName", SqlDbType.VarChar,32)
			};
            parameters[0].Value = PAName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}

