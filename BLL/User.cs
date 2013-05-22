using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// 业务逻辑类User 的摘要说明。
	/// </summary>
	public class User
	{
		private readonly ZHY.DAL.User dal=new ZHY.DAL.User();
		public User()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

        public bool ValidateUser(string username, string userpsw, ZHY.Model.User model) 
        {
            return dal.ValidateUser(username, userpsw, model);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserID)
		{
			return dal.Exists(UserID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZHY.Model.User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZHY.Model.User model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int UserID)
		{
			
			dal.Delete(UserID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.User GetModel(int UserID)
		{
			
			return dal.GetModel(UserID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZHY.Model.User GetModelByCache(int UserID)
		{
			
			string CacheKey = "UserModel-" + UserID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.User)objModel;
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
		public List<ZHY.Model.User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.User> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.User> modelList = new List<ZHY.Model.User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZHY.Model.User();
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					model.UserName=dt.Rows[n]["UserName"].ToString();
					model.UserPsw=dt.Rows[n]["UserPsw"].ToString();
					model.UserMedium=dt.Rows[n]["UserMedium"].ToString();
					model.UserUnitTel=dt.Rows[n]["UserUnitTel"].ToString();
					model.UserShotNum=dt.Rows[n]["UserShotNum"].ToString();
					model.UserMobile=dt.Rows[n]["UserMobile"].ToString();
					model.UserRealName=dt.Rows[n]["UserRealName"].ToString();
					if(dt.Rows[n]["RoleID"].ToString()!="")
					{
						model.RoleID=int.Parse(dt.Rows[n]["RoleID"].ToString());
					}
					model.UserStatus=dt.Rows[n]["UserStatus"].ToString();
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

