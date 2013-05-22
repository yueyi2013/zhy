using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// ҵ���߼���Menu ��ժҪ˵����
	/// </summary>
	public class Menu
	{
		private readonly ZHY.DAL.Menu dal=new ZHY.DAL.Menu();
		public Menu()
		{}

		#region  ��Ա����

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataTable GetList(int roleID)
        {
            return dal.GetList(roleID).Tables["Menu"];
        }

		#endregion  ��Ա����

        #region �Զ����ɵķ���
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int MenuID)
        {
            return dal.Exists(MenuID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.Menu model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZHY.Model.Menu model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int MenuID)
        {

            dal.Delete(MenuID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.Menu GetModel(int MenuID)
        {

            return dal.GetModel(MenuID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public ZHY.Model.Menu GetModelByCache(int MenuID)
        {

            string CacheKey = "MenuModel-" + MenuID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(MenuID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZHY.Model.Menu)objModel;
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
        public List<ZHY.Model.Menu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZHY.Model.Menu> DataTableToList(DataTable dt)
        {
            List<ZHY.Model.Menu> modelList = new List<ZHY.Model.Menu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZHY.Model.Menu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZHY.Model.Menu();
                    if (dt.Rows[n]["MenuID"].ToString() != "")
                    {
                        model.MenuID = int.Parse(dt.Rows[n]["MenuID"].ToString());
                    }
                    model.MenuName = dt.Rows[n]["MenuName"].ToString();
                    model.MenuDes = dt.Rows[n]["MenuDes"].ToString();
                    model.MenuPicPath = dt.Rows[n]["MenuPicPath"].ToString();
                    if (dt.Rows[n]["ParantID"].ToString() != "")
                    {
                        model.ParantID = int.Parse(dt.Rows[n]["ParantID"].ToString());
                    }
                    if (dt.Rows[n]["MenuOrder"].ToString() != "")
                    {
                        model.MenuOrder = int.Parse(dt.Rows[n]["MenuOrder"].ToString());
                    }
                    if (dt.Rows[n]["FunID"].ToString() != "")
                    {
                        model.FunID = int.Parse(dt.Rows[n]["FunID"].ToString());
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
        #endregion
    }
}

