using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
    /// <summary>
    /// ҵ���߼���Right ��ժҪ˵����
    /// </summary>
    public class Right
    {
        private readonly ZHY.DAL.Right dal = new ZHY.DAL.Right();
        public Right()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int RgID)
        {
            return dal.Exists(RgID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.Right model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZHY.Model.Right model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int RgID)
        {

            dal.Delete(RgID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.Right GetModel(int RgID)
        {

            return dal.GetModel(RgID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
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
        public List<ZHY.Model.Right> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
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

        #endregion  ��Ա����
    }
}

