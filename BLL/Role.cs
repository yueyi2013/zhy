using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
    /// <summary>
    /// ҵ���߼���Role ��ժҪ˵����
    /// </summary>
    public class Role
    {
        private readonly ZHY.DAL.Role dal = new ZHY.DAL.Role();
        public Role()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int RoleID)
        {
            return dal.Exists(RoleID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.Role model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZHY.Model.Role model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int RoleID)
        {

            dal.Delete(RoleID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.Role GetModel(int RoleID)
        {

            return dal.GetModel(RoleID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
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
        public List<ZHY.Model.Role> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
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

