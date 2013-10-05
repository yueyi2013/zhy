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
	public partial class ADmimsy
	{
		private readonly ZHY.DAL.ADmimsy dal=new ZHY.DAL.ADmimsy();
		public ADmimsy()
		{}
		#region  BasicMethod
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(decimal AdmyId)
		{
			return dal.Exists(AdmyId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public decimal Add(ZHY.Model.ADmimsy model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(ZHY.Model.ADmimsy model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(decimal AdmyId)
		{
			
			return dal.Delete(AdmyId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string AdmyIdlist )
		{
			return dal.DeleteList(AdmyIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.ADmimsy GetModel(decimal AdmyId)
		{
			
			return dal.GetModel(AdmyId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public ZHY.Model.ADmimsy GetModelByCache(decimal AdmyId)
		{
			
			string CacheKey = "ADmimsyModel-" + AdmyId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AdmyId);
					if (objModel != null)
					{
						//int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("CacheTime"), 30);
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.ADmimsy)objModel;
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
		public List<ZHY.Model.ADmimsy> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.ADmimsy> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.ADmimsy> modelList = new List<ZHY.Model.ADmimsy>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.ADmimsy model;
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

