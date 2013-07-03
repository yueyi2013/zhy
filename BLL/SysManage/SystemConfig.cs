using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// SystemConfig
	/// </summary>
	public partial class SystemConfig
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
            string strGetFields = " SCId,SCAttrName,SCGroup,SCAttrValue,SCAttrValue2,SCAttrType,SCDescription,SCStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " SystemConfig ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " UpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "SCAttrName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.SystemConfig GetModel(string SCAttrName, string SCGroup)
        {

            return dal.GetModel(SCAttrName, SCGroup);
        }
        #endregion
	}
}

