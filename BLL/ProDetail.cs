using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// 业务逻辑类ProDetail 的摘要说明。
	/// </summary>
	public class ProDetail
	{
		private readonly ZHY.DAL.ProDetail dal=new ZHY.DAL.ProDetail();
		public ProDetail()
		{ }

        #region 成员方法
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int proID)
        {
            return dal.GetList(proID);
        }
        #endregion

        #region  自动生成代码

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
		public bool Exists(int ProID,int DtID)
		{
			return dal.Exists(ProID,DtID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZHY.Model.ProDetail model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZHY.Model.ProDetail model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProID,int DtID)
		{
			
			dal.Delete(ProID,DtID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.ProDetail GetModel(int ProID,int DtID)
		{
			
			return dal.GetModel(ProID,DtID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		public List<ZHY.Model.ProDetail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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

