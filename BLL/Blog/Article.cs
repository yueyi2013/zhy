using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace ZHY.BLL
{
    public partial class Article
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
            string strGetFields = " ArId,ArTitle,ACId,ArTypeId,ArContent,ArAuthor,ArPubDate,ArClicks,ArIsTop,ArForbidComt,ArStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " Articles ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " UpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "ArTitle like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 获取博客列表
        /// </summary>
        public DataSet GetIndexBlogList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " * ";
            string tablename = " BlogListView ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("IndexPageBlogSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " ArPubDate ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "ArTitle like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }
    }
}
