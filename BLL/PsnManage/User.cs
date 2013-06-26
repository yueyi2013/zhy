using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// ҵ���߼���User ��ժҪ˵����
	/// </summary>
	public partial class User
	{
		
		#region  ��Ա����
        /// <summary>
        /// ���÷�ҳ�洢����
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " UserID,UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " Users ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " UpdateDT ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "UserName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        public bool ValidateUser(string username, string userpsw, ZHY.Model.User model)
        {
            return dal.ValidateUser(username, userpsw, model);
        }

		#endregion  ��Ա����
	}
}

