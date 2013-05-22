using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
    /// <summary>
    /// 业务逻辑类Role 的摘要说明。
    /// </summary>
    public class Role
    {
        private readonly ZHY.DAL.Role dal = new ZHY.DAL.Role();
        public Role()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            return dal.Exists(RoleID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Role model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ZHY.Model.Role model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RoleID)
        {

            dal.Delete(RoleID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Role GetModel(int RoleID)
        {

            return dal.GetModel(RoleID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ZHY.Model.Role GetModelByCache(int RoleID)
        {

            string CacheKey = "RoleModel-" + RoleID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(RoleID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZHY.Model.Role)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZHY.Model.Role> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZHY.Model.Role> DataTableToList(DataTable dt)
        {
            List<ZHY.Model.Role> modelList = new List<ZHY.Model.Role>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZHY.Model.Role model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZHY.Model.Role();
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    model.RoleName = dt.Rows[n]["RoleName"].ToString();
                    model.RoleDes = dt.Rows[n]["RoleDes"].ToString();
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

