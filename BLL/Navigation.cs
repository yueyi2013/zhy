using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;

namespace ZHY.BLL
{
	/// <summary>
	/// ��ҳ������
	/// </summary>
	public partial class Navigation
	{
		private readonly ZHY.DAL.Navigation dal=new ZHY.DAL.Navigation();
		public Navigation()
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
            string strGetFields = " [DtID],[DtName],[DtDesc],[DtOrder] ";
            string tablename = " Details ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = 2;
            string strOrder = " DtOrder";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "DtName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// ����ǰ̨����HTML����
        /// </summary>
        /// <returns></returns>
        public string generateHtmlCode() 
        {
            List<Model.Navigation> list = this.GetModelList("NavParantId=0 and NavStatus='A' order by NavOrder");
            List<Model.Navigation> childList = this.GetModelList("NavParantId!=0 and NavStatus='A'");
            //һ���˵���
            StringBuilder sbMainHtml = new StringBuilder();
            //��һdiv��ʼ
            sbMainHtml.Append("<div id=\"menu_out\">");
            //�ڶ�div��ʼ
            sbMainHtml.Append("<div id=\"menu_in\">");
            //����div��ʼ
            sbMainHtml.Append("<div id=\"menu\">");
            //��һ�� ul
            sbMainHtml.Append("<ul id=\"nav\">");
            //�����˵���
            StringBuilder sbSecHtml = new StringBuilder();
            //���ĸ�div��ʼ
            sbSecHtml.Append("<div id=\"menu_con\">");
            int i=0;
            foreach (Model.Navigation item in list)
            {
                StringBuilder sbChildHtml = new StringBuilder();
                sbChildHtml.Append("<li>");
                    sbChildHtml.Append("<a class=\"nav_on\" id=\"mynav");
                    sbChildHtml.Append(i);
                    sbChildHtml.Append(" onmouseover=\"javascript:qiehuan(0)\" href=\"");
                    sbChildHtml.Append(item.NavLink);
                    sbChildHtml.Append("\">");
                sbChildHtml.Append("</li>");                
                sbChildHtml.Append("<li class=\"menu_line\"></li>");

                sbSecHtml.AppendFormat("<div id=\"qh_con{0}\" style=\"display: block\">",i);
                    sbSecHtml.Append("<ul>");
                    foreach(Model.Navigation childItem in childList)
                    {
                        if(childItem.NavParantId==item.NavId)
                        {
                            sbSecHtml.Append("<li>");
                            sbSecHtml.AppendFormat("<a href=\"{0}\">",childItem.NavLink);
                            sbSecHtml.AppendFormat("<span>{0}</span>",childItem.NavName);
                            sbSecHtml.Append("</a>");
                            sbSecHtml.Append("</li>");
                            sbSecHtml.Append("<li class=\"menu_line2\"></li>");
                        }
                    }
                    sbSecHtml.Append("</ul>");
                sbSecHtml.Append("</div>");
                i++;
            }
            //��һ��ul����
            sbMainHtml.Append("</ul>");
            //���ĸ�div����
            sbSecHtml.Append("</div>");
            sbMainHtml.Append(sbSecHtml.ToString());
            //����div����
            sbMainHtml.Append("</div>");
            //����div����
            sbMainHtml.Append("</div>");
            //����div����
            sbMainHtml.Append("</div>");
            return sbMainHtml.ToString();
        }
        #endregion


		#region  BasicMethod
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int NavId)
		{
			return dal.Exists(NavId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZHY.Model.Navigation model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(ZHY.Model.Navigation model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int NavId)
		{
			
			return dal.Delete(NavId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string NavIdlist )
		{
			return dal.DeleteList(NavIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.Navigation GetModel(int NavId)
		{
			
			return dal.GetModel(NavId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public ZHY.Model.Navigation GetModelByCache(int NavId)
		{
			
			string CacheKey = "NavigationModel-" + NavId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
                {
                   
					objModel = dal.GetModel(NavId);
					if (objModel != null)
					{
						//int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("CacheTime"), 30);
						//LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.Navigation)objModel;
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
		public List<ZHY.Model.Navigation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.Navigation> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.Navigation> modelList = new List<ZHY.Model.Navigation>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.Navigation model;
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

