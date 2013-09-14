using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using ZHY.Common;
namespace ZHY.BLL
{
	/// <summary>
	/// �����ַ
	/// </summary>
    public partial class ProxyAddress : BaseBLL
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
            string strGetFields = " PAId,PAName,PAType,PAAnonymity,PACountry,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " ProxyAddress ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " PAId ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and PAName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CheckProxyAddressConnected() 
        {
            List<ZHY.Model.ProxyAddress> list = GetModelList("");
            int count = 0;
            foreach (ZHY.Model.ProxyAddress model in list)
            {
                if (!HttpProxy.CheckProxyConnected(model.PAName))
                {
                    count++;
                    Delete(model.PAId);
                }
            }
            if (count>0)
                this.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_PROXY_JOB_SUBJECT, "��" + count+"����Ч�Ĵ����ַ��");
        }
	}
}

