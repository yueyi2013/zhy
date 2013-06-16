using System;
using System.Data;
using System.Text;

using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:NewsTop
	/// </summary>
	public partial class NewsTop:BaseDAL
	{
        /// <summary>
        /// 删除所有
        /// </summary>
        public bool Delete()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewsTop ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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

