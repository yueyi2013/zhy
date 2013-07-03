using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ZHY.BLL
{
    /// <summary>
    /// 文章评论
    /// </summary>
    public partial class ArticleComment
    {
        /// <summary>
        /// 调用分页存储过程
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " ACMId,ArId,ACMContent,ACMDate,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " ArticleComments ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " UpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and ACMContent like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }
    }
}
