using System;
using System.Data;
using System.Text;

using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����:NewsTop
	/// </summary>
	public partial class NewsTop:BaseDAL
	{
        /// <summary>
        /// ɾ������
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

