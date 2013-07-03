using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
    /// <summary>
    /// 业务逻辑类Product 的摘要说明。
    /// </summary>
    public class Product
    {
        private readonly ZHY.DAL.Product dal = new ZHY.DAL.Product();
        public Product()
        { }
        #region 成员方法

        /// <summary>
        /// 调用分页存储过程
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " [ProID],[ProCode],[ProTypeID],[ProName],[ProDes],[ProPrice],[ProInputDate],[ProPublish],"
                + " ProStatusName = case when ProStatus ='1' then '待审核' when ProStatus ='2' then '已发布' end,"
                + " [ProRecommendName] = case when ProRecommend ='1' then '是' when ProRecommend ='2' then '否' end,"
                +"  ProIsNewName = case when ProIsNew ='1' then '是' when ProIsNew ='2' then '否' end,"
                +"  ProIsHotName = case when ProIsHot ='1' then '是' when ProIsHot ='2' then '否' end ";
            string tablename = " Products ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " ProInputDate,ProCode";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and ProName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        #endregion

        #region  自动生成代码
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ProID)
        {
            return dal.Exists(ProID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Product model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ZHY.Model.Product model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(decimal ProID)
        {

            dal.Delete(ProID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Product GetModel(decimal ProID)
        {

            return dal.GetModel(ProID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ZHY.Model.Product GetModelByCache(decimal ProID)
        {

            string CacheKey = "ProductModel-" + ProID;
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
                catch { }
            }
            return (ZHY.Model.Product)objModel;
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
        public List<ZHY.Model.Product> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZHY.Model.Product> DataTableToList(DataTable dt)
        {
            List<ZHY.Model.Product> modelList = new List<ZHY.Model.Product>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZHY.Model.Product model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZHY.Model.Product();
                    if (dt.Rows[n]["ProID"].ToString() != "")
                    {
                        model.ProID = decimal.Parse(dt.Rows[n]["ProID"].ToString());
                    }
                    model.ProCode = dt.Rows[n]["ProCode"].ToString();
                    if (dt.Rows[n]["ProTypeID"].ToString() != "")
                    {
                        model.ProTypeID = int.Parse(dt.Rows[n]["ProTypeID"].ToString());
                    }
                    model.ProName = dt.Rows[n]["ProName"].ToString();
                    model.ProDes = dt.Rows[n]["ProDes"].ToString();
                    if (dt.Rows[n]["ProPrice"].ToString() != "")
                    {
                        model.ProPrice = decimal.Parse(dt.Rows[n]["ProPrice"].ToString());
                    }
                    if (dt.Rows[n]["ProInputDate"].ToString() != "")
                    {
                        model.ProInputDate = DateTime.Parse(dt.Rows[n]["ProInputDate"].ToString());
                    }
                    if (dt.Rows[n]["ProPublish"].ToString() != "")
                    {
                        model.ProPublish = DateTime.Parse(dt.Rows[n]["ProPublish"].ToString());
                    }
                    model.ProStatus = dt.Rows[n]["ProStatus"].ToString();
                    model.ProRecommend = dt.Rows[n]["ProRecommend"].ToString();
                    model.ProIsNew = dt.Rows[n]["ProIsNew"].ToString();
                    model.ProIsHot = dt.Rows[n]["ProIsHot"].ToString();
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
        #endregion  自动生成代码
    }
}

