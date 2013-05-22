using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// 业务逻辑类ProPicture 的摘要说明。
	/// </summary>
	public class ProPicture
	{
		private readonly ZHY.DAL.ProPicture dal=new ZHY.DAL.ProPicture();
		public ProPicture()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProID)
		{
			return dal.Exists(ProID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZHY.Model.ProPicture model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZHY.Model.ProPicture model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProID)
		{
			
			dal.Delete(ProID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.ProPicture GetModel(int ProID)
		{
			
			return dal.GetModel(ProID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZHY.Model.ProPicture GetModelByCache(int ProID)
		{
			
			string CacheKey = "ProPictureModel-" + ProID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.ProPicture)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.ProPicture> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.ProPicture> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.ProPicture> modelList = new List<ZHY.Model.ProPicture>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.ProPicture model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZHY.Model.ProPicture();
					if(dt.Rows[n]["ProID"].ToString()!="")
					{
						model.ProID=int.Parse(dt.Rows[n]["ProID"].ToString());
					}
					model.ProPicURL=dt.Rows[n]["ProPicURL"].ToString();
					if(dt.Rows[n]["ProOrder"].ToString()!="")
					{
						model.ProOrder=int.Parse(dt.Rows[n]["ProOrder"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

