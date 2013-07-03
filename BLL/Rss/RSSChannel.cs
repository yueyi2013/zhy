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
	public partial class RSSChannel : BaseBLL
    {
        #region 成员属性
        private ZHY.Model.SystemConfig scModel = null;
        private int sntCount = 0;
        #endregion

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
            string strGetFields = " RCId,RSSId,RCTitle,RCLink,RCDescription,RCLanguage,RCGenerator,RCPubDate,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " RSSChannel ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " UpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and RCTitle like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ZHY.Model.SystemConfig GetSystemConfigModel()
        {
            if (scModel == null)
            {
                ZHY.BLL.SystemConfig bll = new ZHY.BLL.SystemConfig();
                scModel = bll.GetModel(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_SENT, Constants.SYSTEM_CONFIG_ATT_GROUP_NEWS);
                return scModel;
            }
            else
            {
                return scModel;
            }
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
                            //i++;
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
                   //if (i == 1)
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
            string htmlSource = RSSFeeds.loadRssFeeds(itemRUL, "gb2312");
            string tagSourcec = "";
            if (!string.IsNullOrEmpty(htmlSource))
            {
                tagSourcec = HtmlPaserUtil.extractHtmlsource(htmlSource);
            }

            ZHY.Model.SystemConfig model = GetSystemConfigModel();
            if (model != null && model.SCAttrValue.Equals(Constants.SYSTEM_CONFIG_ATT_GROUP_NEWS_VALUE_Y))
            {
                if (!string.IsNullOrEmpty(tagSourcec)&&sntCount==0)
                {
                    this.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_SEND_SUBJECT, tagSourcec);
                    sntCount++;
                }
            }

            item.RCItemDescription = CompressionUtil.Compress(HttpUtility.HtmlEncode(tagSourcec), "gb2312");

            if (model != null&&model.SCAttrValue.Equals(Constants.SYSTEM_CONFIG_ATT_GROUP_NEWS_VALUE_Y))
            {
                if (!string.IsNullOrEmpty(tagSourcec) && sntCount == 1)
                {
                    this.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_SEND_COMP_SUBJECT, HttpUtility.HtmlDecode(CompressionUtil.Decompress(item.RCItemDescription, "gb2312")));
                    sntCount++;
                }
            }
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

	}
}

