using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����:RSSChannelItem
	/// </summary>
    public partial class RSSChannelItem : BaseDAL
	{
        /// <summary>
        /// ������ڵ�����
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public bool DeleteExpireNews(int days)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RSSChannelItem ");
            strSql.Append(" where NavUpdateDT<@NavUpdateDT");
            SqlParameter[] parameters = {
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime)
			};
            parameters[0].Value = DateTime.Now.AddDays(days);

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}

