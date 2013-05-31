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

        #region ��Ա����
        /// <summary>
        /// ��ȡRSS Channel
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.RSSChannel FetchRssFeeds(string rssRul)
        {
            try
            {
                XmlDocument rssXml = new XmlDocument();
                String feeds = RSSFeeds.loadRssFeeds(rssRul, "UTF8");
                if (String.IsNullOrEmpty(feeds))
                {
                    return null;
                }
                rssXml.LoadXml(feeds);
                //��λ channel �ڵ�
                XmlNode chNode = rssXml.DocumentElement.FirstChild;
                ZHY.Model.RSSChannel channel = new ZHY.Model.RSSChannel();
                List<ZHY.Model.RSSChannelItem> list = new List<ZHY.Model.RSSChannelItem>();
                //��λ item �ڵ�
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
                                        if (item.RCItemLink != null)
                                        {
                                            LoadRssItemContent(item.RCItemLink, "p_content", item);
                                        }
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
            item.RCItemDescription = tagSourcec;
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
            if (objRSSChannel != null && !objRSSChannel.RCTitle.Trim().Equals(model.RCTitle.Trim()))
            {
                rcId = this.Add(model);
            }
            else {
                rcId = objRSSChannel.RCId;            
            }
            
            foreach(ZHY.Model.RSSChannelItem item in model.ItemList)
            {
                ZHY.Model.RSSChannelItem objItem = dal.GetModel(item.RCItemTitle);
                if (objItem != null && !objItem.RCItemTitle.Equals(item.RCItemTitle))
                {
                    item.RCId = rcId;
                    dal.Add(item);
                }
            }
        }
        #endregion

		#region  BasicMethod
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RCId)
		{
			return dal.Exists(RCId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZHY.Model.RSSChannel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(ZHY.Model.RSSChannel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int RCId)
		{
			
			return dal.Delete(RCId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string RCIdlist )
		{
			return dal.DeleteList(RCIdlist );
		}

        /// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.RSSChannel GetModel(string title)
		{

            return dal.GetModel(title);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.RSSChannel GetModel(int RCId)
		{
			
			return dal.GetModel(RCId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
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
		public List<ZHY.Model.RSSChannel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

