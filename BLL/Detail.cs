using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// ҵ���߼���Detail ��ժҪ˵����
	/// </summary>
	public class Detail
	{
		private readonly ZHY.DAL.Detail dal=new ZHY.DAL.Detail();
		public Detail()
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
            string strGetFields = " [DtID],[DtName],[DtDesc],[DtOrder] ";
            string tablename = " Details ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = 2;
            string strOrder = " DtOrder";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and DtName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }
        #endregion

        #region   �Զ����ɴ���
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int DtID)
        {
            return dal.Exists(DtID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.Detail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZHY.Model.Detail model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int DtID)
        {

            dal.Delete(DtID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.Detail GetModel(int DtID)
        {

            return dal.GetModel(DtID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public ZHY.Model.Detail GetModelByCache(int DtID)
        {

            string CacheKey = "DetailModel-" + DtID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(DtID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZHY.Model.Detail)objModel;
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
        public List<ZHY.Model.Detail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZHY.Model.Detail> DataTableToList(DataTable dt)
        {
            List<ZHY.Model.Detail> modelList = new List<ZHY.Model.Detail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZHY.Model.Detail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZHY.Model.Detail();
                    if (dt.Rows[n]["DtID"].ToString() != "")
                    {
                        model.DtID = int.Parse(dt.Rows[n]["DtID"].ToString());
                    }
                    model.DtName = dt.Rows[n]["DtName"].ToString();
                    model.DtDesc = dt.Rows[n]["DtDesc"].ToString();
                    if (dt.Rows[n]["DtOrder"].ToString() != "")
                    {
                        model.DtOrder = int.Parse(dt.Rows[n]["DtOrder"].ToString());
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

