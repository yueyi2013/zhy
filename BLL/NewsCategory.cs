using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
namespace ZHY.BLL
{
	/// <summary>
	/// NewsCategory
	/// </summary>
	public partial class NewsCategory
	{
		private readonly ZHY.DAL.NewsCategory dal=new ZHY.DAL.NewsCategory();
		public NewsCategory()
		{}

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
            string strGetFields = " NewsCategoryId,NewsCategoryName,NewsCategoryDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ";
            string tablename = " NewsCategory ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " NavUpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and NewsCategoryName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }


        public IList<ZHY.Model.NewsCategory> GetNewsListWithCat(string key)
        {
            int top = int.Parse(ConfigHelper.GetConfigString(key));
            ZHY.BLL.RSSChannel rcBll = new ZHY.BLL.RSSChannel();
            ZHY.BLL.RSSChannelItem riBll = new ZHY.BLL.RSSChannelItem();
            IList<ZHY.Model.RSSChannel> rcList = rcBll.GetModelList("");
            IList<ZHY.Model.NewsCategory> list = this.GetModelList("");
            foreach (ZHY.Model.NewsCategory item in list)
            {
                foreach (ZHY.Model.RSSChannel rcItem in rcList)
                {
                    if (item.NewsCategoryName.Trim().Equals(rcItem.RCTitle.Trim()))
                    {
                        item.RiList =riBll.DataTableToList(riBll.GetList(top, "RCId=" + rcItem.RCId, "NavUpdateDT desc").Tables[0]);
                    }
                }                
            }

            return list;
        }

        #endregion

        #region  BasicMethod
        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int NewsCategoryId)
		{
			return dal.Exists(NewsCategoryId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZHY.Model.NewsCategory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(ZHY.Model.NewsCategory model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int NewsCategoryId)
		{
			
			return dal.Delete(NewsCategoryId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string NewsCategoryIdlist )
		{
			return dal.DeleteList(NewsCategoryIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.NewsCategory GetModel(int NewsCategoryId)
		{
			
			return dal.GetModel(NewsCategoryId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public ZHY.Model.NewsCategory GetModelByCache(int NewsCategoryId)
		{
			
			string CacheKey = "NewsCategoryModel-" + NewsCategoryId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NewsCategoryId);
					if (objModel != null)
					{
						//int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("CacheTime"), 30);
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache"); 
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.NewsCategory)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.NewsCategory> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.NewsCategory> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.NewsCategory> modelList = new List<ZHY.Model.NewsCategory>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.NewsCategory model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

