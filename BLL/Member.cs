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
		private readonly ZHY.DAL.Member dal=new ZHY.DAL.Member();
		public Member()
		{ }

        #region ��Ա����
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
        #endregion

        #region  �Զ����ɴ���
        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(decimal MemID)
		{
			return dal.Exists(MemID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZHY.Model.Member model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZHY.Model.Member model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(decimal MemID)
		{
			
			dal.Delete(MemID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.Member GetModel(decimal MemID)
		{
			
			return dal.GetModel(MemID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZHY.Model.Member GetModelByCache(decimal MemID)
		{
			
			string CacheKey = "MemberModel-" + MemID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MemID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.Member)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.Member> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.Member> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.Member> modelList = new List<ZHY.Model.Member>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.Member model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZHY.Model.Member();
					if(dt.Rows[n]["MemID"].ToString()!="")
					{
						model.MemID=decimal.Parse(dt.Rows[n]["MemID"].ToString());
					}
					model.MemAccount=dt.Rows[n]["MemAccount"].ToString();
					model.MemPsw=dt.Rows[n]["MemPsw"].ToString();
					if(dt.Rows[n]["LevelID"].ToString()!="")
					{
						model.LevelID=int.Parse(dt.Rows[n]["LevelID"].ToString());
					}
					model.MemRealName=dt.Rows[n]["MemRealName"].ToString();
					model.MemMobile=dt.Rows[n]["MemMobile"].ToString();
					model.MemShotNum=dt.Rows[n]["MemShotNum"].ToString();
					model.MemUnitTel=dt.Rows[n]["MemUnitTel"].ToString();
					model.MemMedium=dt.Rows[n]["MemMedium"].ToString();
					model.MemStatus=dt.Rows[n]["MemStatus"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion 
	}
}

