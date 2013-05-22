using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// 业务逻辑类Member 的摘要说明。
	/// </summary>
	public partial class Member
	{
		private readonly ZHY.DAL.Member dal=new ZHY.DAL.Member();
		public Member()
		{ }

        #region 成员方法
        /// <summary>
        /// 验证登录会员
        /// </summary>
        /// <param name="username">会员名</param>Member
        /// <param name="userpsw">密码</param>
        /// <returns></returns>
        public bool ValidateMember(string memaccount, string mempsw, ZHY.Model.Member model)
        {
            return dal.ValidateMember(memaccount, mempsw, model);
        }
        #endregion

        #region  自动生成代码
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MemID)
		{
			return dal.Exists(MemID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZHY.Model.Member model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZHY.Model.Member model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(decimal MemID)
		{
			
			dal.Delete(MemID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.Member GetModel(decimal MemID)
		{
			
			return dal.GetModel(MemID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		public List<ZHY.Model.Member> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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

