﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZHY.BLL
{
    public partial class SystemMail
    {
        #region 成员方法
        /// <summary>
        /// 调用分页存储过程
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " SMId,SMHost,SMTimeout,SMFromAddress,SMOrder,SMMailPsw,SMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " SystemMail ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " SMHost";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and SMHost like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        #endregion
    }
}
