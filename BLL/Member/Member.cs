using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// ҵ���߼���Member ��ժҪ˵����
	/// </summary>
	public partial class Member
	{
        #region ��Ա����
        /// <summary>
        /// ���÷�ҳ�洢����
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " MemID,MemAccount,MemPsw,PsnLevelId,MemMail,MemStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " Members ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " PsnLevelId";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and MemAccount like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// ��֤��¼��Ա
        /// </summary>
        /// <param name="username">��Ա��</param>Member
        /// <param name="userpsw">����</param>
        /// <returns></returns>
        public bool ValidateMember(string memaccount, string mempsw, ZHY.Model.Member model)
        {
            return dal.ValidateMember(memaccount, mempsw, model);
        }

        /// <summary>
        /// ��֤��Ա�����Ƿ����
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidateExistedEmail(string email) 
        {
           return dal.ValidateExistedEmail(email);
        }

        public int GetMaxID()
        {
            return dal.GetMaxID();
        }

        public bool IsActiveCodeExpired(string MemId)
        {
            return dal.IsActiveCodeExpired(MemId);
        }

        /// <summary>
        /// �û�����
        /// </summary>
        /// <param name="MemId"></param>
        /// <returns></returns>
        public bool ActiveMember(string MemId) 
        {
            return dal.ActiveMember(MemId);
        }

        #endregion

	}
}

