using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// ��վ
	/// </summary>
	public partial class VirtualSite : BaseBLL
	{
        /// <summary>
        /// ���÷�ҳ�洢����
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " VSId,VSCode,VSName,VSURL,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " VirtualSite ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " VSId ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and VSName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }
	}
}

