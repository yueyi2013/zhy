using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
namespace ZHY.ACC.BLL
{
	/// <summary>
	/// RSSChannelItem
	/// </summary>
	public partial class RSSChannelItem
	{
        private readonly ZHY.ACC.DAL.RSSChannelItem dal = new ZHY.ACC.DAL.RSSChannelItem();
		public RSSChannelItem()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RCItemId)
		{
			return dal.Exists(RCItemId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZHY.Model.RSSChannelItem model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.RSSChannelItem model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RCItemId)
		{
			
			return dal.Delete(RCItemId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RCItemIdlist )
		{
			return dal.DeleteList(RCItemIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.RSSChannelItem GetModel(int RCItemId)
		{
			
			return dal.GetModel(RCItemId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZHY.Model.RSSChannelItem GetModelByCache(int RCItemId)
		{
			
			string CacheKey = "RSSChannelItemModel-" + RCItemId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RCItemId);
					if (objModel != null)
					{
						//int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("CacheTime"), 30);
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache"); 
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.RSSChannelItem)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.RSSChannelItem> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.RSSChannelItem> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.RSSChannelItem> modelList = new List<ZHY.Model.RSSChannelItem>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.RSSChannelItem model;
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
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

