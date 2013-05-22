using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZHY.Model;

namespace ZHY.BLL
{
	/// <summary>
	/// 首页导航栏
	/// </summary>
	public partial class Navigation
	{
		private readonly ZHY.DAL.Navigation dal=new ZHY.DAL.Navigation();
		public Navigation()
		{}

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
        /// 生成前台导航HTML代码
        /// </summary>
        /// <returns></returns>
        public string generateHtmlCode() 
        {
            List<Model.Navigation> list = this.GetModelList("NavParantId=0 and NavStatus='A' order by NavOrder");
            List<Model.Navigation> childList = this.GetModelList("NavParantId!=0 and NavStatus='A'");
            //一级菜单栏
            StringBuilder sbMainHtml = new StringBuilder();
            //第一div开始
            sbMainHtml.Append("<div id=\"menu_out\">");
            //第二div开始
            sbMainHtml.Append("<div id=\"menu_in\">");
            //第三div开始
            sbMainHtml.Append("<div id=\"menu\">");
            //第一个 ul
            sbMainHtml.Append("<ul id=\"nav\">");
            //二级菜单栏
            StringBuilder sbSecHtml = new StringBuilder();
            //第四个div开始
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
            //第一个ul结束
            sbMainHtml.Append("</ul>");
            //第四个div结束
            sbSecHtml.Append("</div>");
            sbMainHtml.Append(sbSecHtml.ToString());
            //第三div结束
            sbMainHtml.Append("</div>");
            //第三div结束
            sbMainHtml.Append("</div>");
            //第三div结束
            sbMainHtml.Append("</div>");
            return sbMainHtml.ToString();
        }
        #endregion


		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NavId)
		{
			return dal.Exists(NavId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZHY.Model.Navigation model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.Navigation model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int NavId)
		{
			
			return dal.Delete(NavId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string NavIdlist )
		{
			return dal.DeleteList(NavIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.Navigation GetModel(int NavId)
		{
			
			return dal.GetModel(NavId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.Navigation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
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

