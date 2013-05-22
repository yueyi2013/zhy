using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// 业务逻辑类ProTypeDetail 的摘要说明。
	/// </summary>
	public class ProTypeDetail
	{
		private readonly ZHY.DAL.ProTypeDetail dal=new ZHY.DAL.ProTypeDetail();
		public ProTypeDetail()
		{ }

        #region 成员方法
        /// <summary>
        /// 批量增加数据
        /// </summary>
        public void Add(List<ZHY.Model.ProTypeDetail> list) 
        {
            dal.Add(list);
        }

        /// <summary>
        /// 批量更新数据
        /// </summary>
        public void Update(List<ZHY.Model.ProTypeDetail> list)
        {
            dal.Update(list);
        }
        #endregion

        #region  自动生成方法

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
		public bool Exists(int ProTypeID,int DtID)
		{
			return dal.Exists(ProTypeID,DtID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZHY.Model.ProTypeDetail model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZHY.Model.ProTypeDetail model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProTypeID,int DtID)
		{
			
			dal.Delete(ProTypeID,DtID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.ProTypeDetail GetModel(int ProTypeID,int DtID)
		{
			
			return dal.GetModel(ProTypeID,DtID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZHY.Model.ProTypeDetail GetModelByCache(int ProTypeID,int DtID)
		{
			
			string CacheKey = "ProTypeDetailModel-" + ProTypeID+DtID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProTypeID,DtID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.ProTypeDetail)objModel;
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
		public List<ZHY.Model.ProTypeDetail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.ProTypeDetail> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.ProTypeDetail> modelList = new List<ZHY.Model.ProTypeDetail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.ProTypeDetail model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZHY.Model.ProTypeDetail();
					if(dt.Rows[n]["ProTypeID"].ToString()!="")
					{
						model.ProTypeID=int.Parse(dt.Rows[n]["ProTypeID"].ToString());
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

		#endregion 
	}
}

