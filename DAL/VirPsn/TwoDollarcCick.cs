using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����:TwoDollarcCick
	/// </summary>
	public partial class TwoDollarcCick : BaseDAL
	{
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TwoDollarcCick");
            strSql.Append(" where TDCUsername=@TDCUsername");
            SqlParameter[] parameters = {
					new SqlParameter("@TDCUsername", SqlDbType.VarChar)
			};
            parameters[0].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}

