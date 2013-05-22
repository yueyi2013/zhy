using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// ҵ���߼���ProDetail ��ժҪ˵����
	/// </summary>
	public class ProDetail
	{
		private readonly ZHY.DAL.ProDetail dal=new ZHY.DAL.ProDetail();
		public ProDetail()
		{ }

        #region ��Ա����
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(int proID)
        {
            return dal.GetList(proID);
        }
        #endregion

        #region  �Զ����ɴ���

        /// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProID,int DtID)
		{
			return dal.Exists(ProID,DtID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ZHY.Model.ProDetail model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZHY.Model.ProDetail model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProID,int DtID)
		{
			
			dal.Delete(ProID,DtID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.ProDetail GetModel(int ProID,int DtID)
		{
			
			return dal.GetModel(ProID,DtID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZHY.Model.ProDetail GetModelByCache(int ProID,int DtID)
		{
			
			string CacheKey = "ProDetailModel-" + ProID+DtID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProID,DtID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.ProDetail)objModel;
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
		public List<ZHY.Model.ProDetail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.ProDetail> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.ProDetail> modelList = new List<ZHY.Model.ProDetail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.ProDetail model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZHY.Model.ProDetail();
					if(dt.Rows[n]["ProID"].ToString()!="")
					{
						model.ProID=int.Parse(dt.Rows[n]["ProID"].ToString());
					}
					if(dt.Rows[n]["DtID"].ToString()!="")
					{
						model.DtID=int.Parse(dt.Rows[n]["DtID"].ToString());
					}
					model.ProDtValue=dt.Rows[n]["ProDtValue"].ToString();
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

