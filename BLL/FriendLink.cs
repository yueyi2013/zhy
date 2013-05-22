using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// ҵ���߼���FriendLink ��ժҪ˵����
	/// </summary>
	public class FriendLink
	{
		private readonly ZHY.DAL.FriendLink dal=new ZHY.DAL.FriendLink();
		public FriendLink()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int FLID)
		{
			return dal.Exists(FLID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZHY.Model.FriendLink model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZHY.Model.FriendLink model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int FLID)
		{
			
			dal.Delete(FLID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.FriendLink GetModel(int FLID)
		{
			
			return dal.GetModel(FLID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZHY.Model.FriendLink GetModelByCache(int FLID)
		{
			
			string CacheKey = "FriendLinkModel-" + FLID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FLID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.FriendLink)objModel;
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
		public List<ZHY.Model.FriendLink> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.FriendLink> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.FriendLink> modelList = new List<ZHY.Model.FriendLink>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.FriendLink model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZHY.Model.FriendLink();
					if(dt.Rows[n]["FLID"].ToString()!="")
					{
						model.FLID=int.Parse(dt.Rows[n]["FLID"].ToString());
					}
					model.FLName=dt.Rows[n]["FLName"].ToString();
					model.FLSite=dt.Rows[n]["FLSite"].ToString();
					model.FLPic=dt.Rows[n]["FLPic"].ToString();
					model.FLViewMethod=dt.Rows[n]["FLViewMethod"].ToString();
					model.FLDes=dt.Rows[n]["FLDes"].ToString();
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

		#endregion  ��Ա����
	}
}

