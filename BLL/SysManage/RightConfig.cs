using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZHY.BLL
{
    public partial class RightConfig
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
            string strGetFields = " RiCId,FunID,RoleID,RiCIdStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " RightConfig ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " UpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "RiCId like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByRoleId(int roleId)
        {
            return dal.DeleteByRoleId(roleId);
        }
    }
}
