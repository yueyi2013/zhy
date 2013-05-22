using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// 业务逻辑类Function 的摘要说明。
	/// </summary>
	public class Function
	{
		private readonly ZHY.DAL.Function dal=new ZHY.DAL.Function();
		public Function()
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
            string strGetFields = " [FunID],[FunCode],[FunName],[FunPage],[FunDes] ";
            string tablename = " Functions ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " FunCode";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "FunName like '%" + name + "'";
            }
           
            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        #endregion

        #region  自动生成的方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FunID)
        {
            return dal.Exists(FunID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Function model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ZHY.Model.Function model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FunID)
        {

            dal.Delete(FunID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Function GetModel(int FunID)
        {

            return dal.GetModel(FunID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ZHY.Model.Function GetModelByCache(int FunID)
        {

            string CacheKey = "FunctionModel-" + FunID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(FunID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZHY.Model.Function)objModel;
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
        public List<ZHY.Model.Function> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZHY.Model.Function> DataTableToList(DataTable dt)
        {
            List<ZHY.Model.Function> modelList = new List<ZHY.Model.Function>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZHY.Model.Function model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZHY.Model.Function();
                    if (dt.Rows[n]["FunID"].ToString() != "")
                    {
                        model.FunID = int.Parse(dt.Rows[n]["FunID"].ToString());
                    }
                    model.FunCode = dt.Rows[n]["FunCode"].ToString();
                    model.FunName = dt.Rows[n]["FunName"].ToString();
                    model.FunPage = dt.Rows[n]["FunPage"].ToString();
                    model.FunDes = dt.Rows[n]["FunDes"].ToString();
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

		#endregion  方法
	}
}

