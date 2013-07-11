using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using ZHY.Common;

namespace ZHY.BLL
{
	/// <summary>
	/// RSSChannelItem
	/// </summary>
	public partial class RSSChannelItem
	{
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
            string strGetFields = " [RCItemId],[RCId],[RCItemTitle],[RCItemLink],[RCItemCategory],[RCItemAuthor],[RCItemPubDate],[RCItemDescription],[RCItemComments],[NavCreateAt],[NavCreateBy],[NavUpdateDT],[NavUpdateBy] ";
            string tablename = " RSSChannelItem ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " NavUpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and RCItemTitle like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 调用分页存储过程
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, int rcId, ref int CountAll)
        {
            string strGetFields = " [RCItemId],[RCId],[RCItemTitle],[RCItemLink],[RCItemCategory],[RCItemAuthor],[RCItemPubDate],[RCItemDescription],[RCItemComments],[NavCreateAt],[NavCreateBy],[NavUpdateDT],[NavUpdateBy] ";
            string tablename = " RSSChannelItem ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("IndexPageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " NavUpdateDT";
            string strWhere = " RCId = '" + rcId + "'";
            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 获取最新的RSS
        /// </summary>
        /// <param name="tops"></param>
        /// <returns></returns>
        public IList<ZHY.Model.RSSChannelItem> loadNewsTop(int tops) 
        {
            return this.DataTableToList(this.GetList(tops, "", "NavUpdateDT desc").Tables[0]);
        }


        /// <summary>
        /// 清理过期的新闻
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public bool DeleteExpireNews()
        {
            int days = Constants.DEFAULT_PURGE_NEWS_DAYS;
            try
            {
                ZHY.BLL.SystemConfig bll = new ZHY.BLL.SystemConfig();
                ZHY.Model.SystemConfig model = bll.GetModel(Constants.SYSTEM_CONFIG_ATT_NAME_NEWS_PURGE_DAYS, Constants.SYSTEM_CONFIG_ATT_GROUP_NEWS);
                if (model != null)
                    days = int.Parse(model.SCAttrValue);                
            }
            catch { 
                
            
            }

            return dal.DeleteExpireNews(days);
        }
        #endregion

	}
}

