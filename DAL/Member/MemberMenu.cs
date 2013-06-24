using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace ZHY.DAL
{
    public partial class MemberMenu:BaseDAL
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MMId,MMName,MMOrder,MMPicPath,MMDesc,MMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
            strSql.Append(" FROM MemberMenu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
