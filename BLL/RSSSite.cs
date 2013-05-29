using System;
using System.Collections.Generic;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using System.IO;
using System.Xml;
using ZHY.Common;

namespace ZHY.BLL
{
	/// <summary>
	/// RSSSite
	/// </summary>
	public partial class RSSSite
	{
		private readonly ZHY.DAL.RSSSite dal=new ZHY.DAL.RSSSite();
		public RSSSite()
		{}
        #region 成员方法
        /// <summary>
        /// 获取RSS Channel
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.RSSChannel FetchRssFeeds(String rssRul)
        {
            try
            {
                XmlDocument rssXml = new XmlDocument();
                rssXml.LoadXml(RSSFeeds.loadRssFeeds(rssRul));
                //定位 channel 节点
                XmlNode chNode = rssXml.DocumentElement.FirstChild;
                ZHY.Model.RSSChannel channel = new ZHY.Model.RSSChannel();
                List<ZHY.Model.RSSChannelItem> list = new List<ZHY.Model.RSSChannelItem>();
                //定位 item 节点
                foreach (XmlNode node in chNode.ChildNodes)
                {                    
                    switch (node.Name)
                    {
                        case "title":
                            channel.RCTitle = node.InnerText;
                            break;
                        case "link":
                            channel.RCLink = node.InnerText;
                            break;
                        case "language":
                            channel.RCLanguage = node.InnerText;
                            break;
                        case "description":
                            channel.RCDescription = node.InnerText;
                            break;
                        case "item":
                            
                            ZHY.Model.RSSChannelItem item = new ZHY.Model.RSSChannelItem();
                            foreach (XmlNode subNode in node.ChildNodes)
                            {
                                switch (subNode.Name)
                                {
                                    case "title":
                                        item.RCItemTitle = subNode.InnerText;
                                        break;
                                    case "link":
                                        item.RCItemLink = subNode.InnerText;
                                        break;
                                    case "author":
                                        item.RCItemAuthor = subNode.InnerText;
                                        break;                                        
                                    case "pubDate":
                                        item.RCItemPubDate = DateTime.Parse(subNode.InnerText);
                                        break;
                                }
                            }
                            list.Add(item);
                            break;
                    }
                }
                channel.ItemList = list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());                
            }
            return null;
        }

        public void loadRssItemContent(String itemRUL)
        {
            //String RSSFeeds.loadRssFeeds(itemRUL);
        }



        #endregion




        #region  BasicMethod
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RSSId)
		{
			return dal.Exists(RSSId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZHY.Model.RSSSite model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.RSSSite model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RSSId)
		{
			
			return dal.Delete(RSSId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RSSIdlist )
		{
			return dal.DeleteList(RSSIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.RSSSite GetModel(int RSSId)
		{
			
			return dal.GetModel(RSSId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZHY.Model.RSSSite GetModelByCache(int RSSId)
		{
			
			string CacheKey = "RSSSiteModel-" + RSSId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RSSId);
					if (objModel != null)
					{
						//int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("CacheTime"), 30);
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache"); 
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.RSSSite)objModel;
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
		public List<ZHY.Model.RSSSite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.RSSSite> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.RSSSite> modelList = new List<ZHY.Model.RSSSite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.RSSSite model;
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

