using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;
namespace ZHY.BLL
{
    /// <summary>
    /// ҵ���߼���LanMu ��ժҪ˵����
    /// </summary>
    public class LanMu
    {
        private readonly ZHY.DAL.LanMu dal = new ZHY.DAL.LanMu();
        public LanMu()
        { }
        #region ��Ա����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="LMName"></param>
        /// <param name="ConKeyWord"></param>
        /// <param name="LMParantID"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string LMName, string LMParantID, ref int CountAll)
        {
            string strGetFields = " a.*,ISNULL(b.LMName,'���ڵ�') as LMParantName ";
            string tablename = " LanMu a  left join  LanMu  b on a.LMParantID = b.LMID ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = "a.LMSeq";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(LMName))
            {
                strWhere += "LMName like '%" + LMName + "'";
            }
            if (!string.IsNullOrEmpty(LMParantID))
            {
                strWhere += " and a.LMParantID=" + LMParantID;
            }
            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }
        #endregion

        #region  �Զ����ɵķ���

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int LMID)
        {
            return dal.Exists(LMID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.LanMu model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZHY.Model.LanMu model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int LMID)
        {

            dal.Delete(LMID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.LanMu GetModel(int LMID)
        {

            return dal.GetModel(LMID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public ZHY.Model.LanMu GetModelByCache(int LMID)
        {

            string CacheKey = "LanMuModel-" + LMID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(LMID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZHY.Model.LanMu)objModel;
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
        public List<ZHY.Model.LanMu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZHY.Model.LanMu> DataTableToList(DataTable dt)
        {
            List<ZHY.Model.LanMu> modelList = new List<ZHY.Model.LanMu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZHY.Model.LanMu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZHY.Model.LanMu();
                    if (dt.Rows[n]["LMID"].ToString() != "")
                    {
                        model.LMID = int.Parse(dt.Rows[n]["LMID"].ToString());
                    }
                    model.LMCode = dt.Rows[n]["LMCode"].ToString();
                    if (dt.Rows[n]["ParantID"].ToString() != "")
                    {
                        model.ParantID = int.Parse(dt.Rows[n]["ParantID"].ToString());
                    }
                    model.LMName = dt.Rows[n]["LMName"].ToString();
                    if (dt.Rows[n]["LMOrder"].ToString() != "")
                    {
                        model.LMOrder = int.Parse(dt.Rows[n]["LMOrder"].ToString());
                    }
                    if (dt.Rows[n]["LMStyleID"].ToString() != "")
                    {
                        model.LMStyleID = int.Parse(dt.Rows[n]["LMStyleID"].ToString());
                    }
                    model.LMPage = dt.Rows[n]["LMPage"].ToString();
                    model.LMStatus = dt.Rows[n]["LMStatus"].ToString();
                    model.LMDes = dt.Rows[n]["LMDes"].ToString();
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

