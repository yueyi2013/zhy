using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using ZHY.Common;
namespace ZHY.ACC.BLL
{
	/// <summary>
	/// RSSChannelItem
	/// </summary>
	public partial class RSSChannelItem
	{
        /// <summary>
        /// 将新闻备份至Access数据库
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public void MoveNewsToAccessDB()
        {
            int days = Constants.DEFAULT_PURGE_NEWS_DAYS;
            try
            {
                ZHY.BLL.SystemConfig bll = new ZHY.BLL.SystemConfig();
                ZHY.Model.SystemConfig model = bll.GetModel(Constants.SYSTEM_CONFIG_ATT_NAME_NEWS_PURGE_DAYS, Constants.SYSTEM_CONFIG_ATT_GROUP_NEWS);
                if (model != null)
                    days = int.Parse(model.SCAttrValue);
                if (days >= 0)
                {
                    days = Constants.DEFAULT_PURGE_NEWS_DAYS;
                }
            }
            catch
            {

                days = Constants.DEFAULT_PURGE_NEWS_DAYS;
            }
            ZHY.BLL.RSSChannelItem bllItem = new ZHY.BLL.RSSChannelItem();
            IList<ZHY.Model.RSSChannelItem> list = bllItem.loadExpireNews(days);
            foreach(ZHY.Model.RSSChannelItem model in list)
            {
                dal.Add(model);
            }
            bllItem.DeleteExpireNews(days);
        }
	}
}

