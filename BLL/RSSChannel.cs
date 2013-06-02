using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;

using System.IO;
using System.Xml;
using ZHY.Common;
using System.Web;
namespace ZHY.BLL
{
	/// <summary>
	/// RSSChannel
	/// </summary>
	public partial class RSSChannel
	{
		private readonly ZHY.DAL.RSSChannel dal=new ZHY.DAL.RSSChannel();
		public RSSChannel()
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
            string strGetFields = " [FunID],[FunCode],[FunName],[FunPage],[FunDes] ";
            string tablename = " Functions ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " FunCode";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "FunName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 获取RSS Channel
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.RSSChannel FetchRssFeeds(string rssUrl)
        {
            try
            {
                XmlDocument rssXml = new XmlDocument();
                String feeds = RSSFeeds.loadRssFeeds(rssUrl, "UTF8");
                if (String.IsNullOrEmpty(feeds))
                {
                    return null;
                }
                rssXml.LoadXml(feeds);
                //定位 channel 节点
                XmlNode chNode = rssXml.DocumentElement.FirstChild;
                ZHY.Model.RSSChannel channel = new ZHY.Model.RSSChannel();
                List<ZHY.Model.RSSChannelItem> list = new List<ZHY.Model.RSSChannelItem>();
                //var i = 0;
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
                           // i++;
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
                                        if (item.RCItemLink != null)
                                        {
                                            LoadRssItemContent(item.RCItemLink, "p_content", item);
                                        }
                                        break;
                                    case "author":
                                        item.RCItemAuthor = string.IsNullOrEmpty(subNode.InnerText) ? Constants.AUTHOR_NAME: subNode.InnerText;
                                        break;
                                    case "pubDate":
                                        item.RCItemPubDate = DateTime.Parse(subNode.InnerText);
                                        break;
                                }
                            }
                            list.Add(item);
                            break;
                    }
                   // if (i == 1)
                   //     break;
                }
                channel.ItemList = list;
                return channel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemRUL"></param>
        /// <param name="contentId"></param>
        /// <param name="item"></param>
        public void LoadRssItemContent(string itemRUL, string contentId, ZHY.Model.RSSChannelItem item)
        {
            string htmlSource = RSSFeeds.loadRssFeeds(itemRUL, "");
            string tagSourcec = "";
            if (!string.IsNullOrEmpty(htmlSource))
            {
                tagSourcec = HtmlPaserUtil.extractHtmlsource(htmlSource);
            }

            item.RCItemDescription = CompressionUtil.Compress(HttpUtility.HtmlEncode(tagSourcec));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void SaveBatchRssFeeds(ZHY.Model.RSSChannel model)
        {
            ZHY.DAL.RSSChannelItem dal = new DAL.RSSChannelItem();
            ZHY.Model.RSSChannel objRSSChannel = this.GetModel(model.RCTitle);
            int rcId = 0;
            if (objRSSChannel == null)
            {
                model.CreateBy = Constants.SYSTEM_NAME; 
                model.UpdateBy = Constants.SYSTEM_NAME;
                rcId = this.Add(model);
            }
            else{
                rcId = objRSSChannel.RCId;            
            }
            
            foreach(ZHY.Model.RSSChannelItem item in model.ItemList)
            {
                if (!dal.Exists(item.RCItemTitle))
                {
                    item.RCId = rcId;
                    item.RCItemAuthor = string.IsNullOrEmpty(item.RCItemAuthor) ? Constants.AUTHOR_NAME : item.RCItemAuthor;
                    item.NavCreateBy = Constants.SYSTEM_NAME;
                    item.NavUpdateBy = Constants.SYSTEM_NAME;
                    dal.Add(item);
                }
            }
        }
        #endregion

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RCId)
		{
			return dal.Exists(RCId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZHY.Model.RSSChannel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.RSSChannel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RCId)
		{
			
			return dal.Delete(RCId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RCIdlist )
		{
			return dal.DeleteList(RCIdlist );
		}

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.RSSChannel GetModel(string title)
		{

            return dal.GetModel(title);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.RSSChannel GetModel(int RCId)
		{
			
			return dal.GetModel(RCId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZHY.Model.RSSChannel GetModelByCache(int RCId)
		{
			
			string CacheKey = "RSSChannelModel-" + RCId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RCId);
					if (objModel != null)
					{
						//int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("CacheTime"), 30);
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache"); 
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.RSSChannel)objModel;
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
		public List<ZHY.Model.RSSChannel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZHY.Model.RSSChannel> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.RSSChannel> modelList = new List<ZHY.Model.RSSChannel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.RSSChannel model;
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

