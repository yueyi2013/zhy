using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// AD mimsy
	/// </summary>
	public partial class ADmimsy : BaseBLL
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
            string strGetFields = " AdmyId,AdmyCode,AdmyUserName,AdmyPassword,AdmyEmail,AdmyCountry,AdmyBirthday,AdmyGender,AdmyPayment,ProxyAddress,IsEnableProxy,AdmyViews,AdmyIsReferrals,AdmyReferrals,AdmyStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " ADmimsy ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " AdmyId ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and AdmyUserName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }



	}
}

