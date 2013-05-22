using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
    /// <summary>
    /// 业务逻辑类Right 的摘要说明。
    /// </summary>
    public class Right
    {
        private readonly ZHY.DAL.Right dal = new ZHY.DAL.Right();
        public Right()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RgID)
        {
            return dal.Exists(RgID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Right model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ZHY.Model.Right model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RgID)
        {

            dal.Delete(RgID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Right GetModel(int RgID)
        {

            return dal.GetModel(RgID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ZHY.Model.Right GetModelByCache(int RgID)
        {

            string CacheKey = "RightModel-" + RgID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(RgID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZHY.Model.Right)objModel;
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
        public List<ZHY.Model.Right> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZHY.Model.Right> DataTableToList(DataTable dt)
        {
            List<ZHY.Model.Right> modelList = new List<ZHY.Model.Right>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZHY.Model.Right model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZHY.Model.Right();
                    if (dt.Rows[n]["RgID"].ToString() != "")
                    {
                        model.RgID = int.Parse(dt.Rows[n]["RgID"].ToString());
                    }
                    if (dt.Rows[n]["FunID"].ToString() != "")
                    {
                        model.FunID = int.Parse(dt.Rows[n]["FunID"].ToString());
                    }
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
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

