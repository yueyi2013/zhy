using System;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using ZHY.Model;

namespace ZHY.BLL
{
	/// <summary>
	/// RSSSite
	/// </summary>
	public partial class RSSSite
	{
		private readonly ZHY.DAL.RSSSite dal=new ZHY.DAL.RSSSite();
		public RSSSite()
		{}

        #region  BasicMethod
        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RSSId)
		{
			return dal.Exists(RSSId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZHY.Model.RSSSite model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(ZHY.Model.RSSSite model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int RSSId)
		{
			
			return dal.Delete(RSSId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string RSSIdlist )
		{
			return dal.DeleteList(RSSIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.RSSSite GetModel(int RSSId)
		{
			
			return dal.GetModel(RSSId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public ZHY.Model.RSSSite GetModelByCache(int RSSId)
		{
			
			string CacheKey = "RSSSiteModel-" + RSSId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RSSId);
					if (objModel != null)
					{
						//int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("CacheTime"), 30);
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache"); 
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.RSSSite)objModel;
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
		public List<ZHY.Model.RSSSite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.RSSSite> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.RSSSite> modelList = new List<ZHY.Model.RSSSite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.RSSSite model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

