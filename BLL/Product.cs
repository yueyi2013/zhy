using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
    /// <summary>
    /// ҵ���߼���Product ��ժҪ˵����
    /// </summary>
    public class Product
    {
        private readonly ZHY.DAL.Product dal = new ZHY.DAL.Product();
        public Product()
        { }
        #region ��Ա����

        /// <summary>
        /// ���÷�ҳ�洢����
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " [ProID],[ProCode],[ProTypeID],[ProName],[ProDes],[ProPrice],[ProInputDate],[ProPublish],"
                + " ProStatusName = case when ProStatus ='1' then '�����' when ProStatus ='2' then '�ѷ���' end,"
                + " [ProRecommendName] = case when ProRecommend ='1' then '��' when ProRecommend ='2' then '��' end,"
                +"  ProIsNewName = case when ProIsNew ='1' then '��' when ProIsNew ='2' then '��' end,"
                +"  ProIsHotName = case when ProIsHot ='1' then '��' when ProIsHot ='2' then '��' end ";
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

        #region  �Զ����ɴ���
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(decimal ProID)
        {
            return dal.Exists(ProID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.Product model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZHY.Model.Product model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(decimal ProID)
        {

            dal.Delete(ProID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.Product GetModel(decimal ProID)
        {

            return dal.GetModel(ProID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
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
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZHY.Model.Product> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        #endregion  �Զ����ɴ���
    }
}

