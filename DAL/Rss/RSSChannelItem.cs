using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:RSSChannelItem
	/// </summary>
    public partial class RSSChannelItem : BaseDAL
	{
        /// <summary>
        /// 清理过期的新闻
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

        /// <summary>
        /// 加载过期的数据
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public DataSet loadExpireNews(int days)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RCItemId,RCId,RCItemTitle,RCItemLink,RCItemCategory,RCItemAuthor,RCItemPubDate,RCItemDescription,RCItemComments,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
            strSql.Append(" FROM RSSChannelItem ");
            strSql.Append(" where NavUpdateDT<@NavUpdateDT");
            SqlParameter[] parameters = {
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime)
			};
            parameters[0].Value = DateTime.Now.AddDays(days);
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }
	}
}

