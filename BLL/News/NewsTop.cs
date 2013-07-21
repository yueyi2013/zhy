using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using ZHY.Common;

namespace ZHY.BLL
{
	/// <summary>
	/// 新闻TOP
	/// </summary>
	public partial class NewsTop
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
            string strGetFields = " NTId,NTTitle,NTAuthor,NTPubDate,NTContent,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " NewsTop ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " UpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and NTTitle like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {

            return dal.Delete();
        }

        /// <summary>
        /// 每天自动添加TOP新闻
        /// </summary>
        public void AutoTaskAddTopNews()
        {
            ZHY.BLL.RSSChannelItem bll = new ZHY.BLL.RSSChannelItem();            
            int top = GetIndexNewsTops();
            IList<ZHY.Model.RSSChannelItem> list = bll.loadNewsTop(top);
            if (list != null && list.Count>0)
            {
                Delete();
            }
            foreach (ZHY.Model.RSSChannelItem item in list)
            {
                ZHY.Model.NewsTop model = new ZHY.Model.NewsTop();
                model.NTId = item.RCItemId;
                model.NTTitle = item.RCItemTitle;
                model.NTAuthor = item.RCItemAuthor;
                model.NTPubDate = item.RCItemPubDate;
                model.NTContent = item.RCItemDescription;
                model.CreateBy = ZHY.Common.Constants.SYSTEM_NAME;
                model.UpdateBy = ZHY.Common.Constants.SYSTEM_NAME;
                Add(model);
            }
        }

        /// <summary>
        /// 得到首页top新闻
        /// </summary>
        /// <returns></returns>
        private int GetIndexNewsTops() 
        {
            ZHY.BLL.SystemConfig bll = new ZHY.BLL.SystemConfig();            
            try{
                ZHY.Model.SystemConfig model = bll.GetModel(Constants.SYSTEM_CONFIG_ATT_NAME_NEWS_INDEX_TOPS, Constants.SYSTEM_CONFIG_ATT_GROUP_NEWS);
                if (model==null)
                {
                    return Constants.DEFAULT_NEWS_INDEX_TOPS;
                }
                return int.Parse(model.SCAttrValue);
            }catch{
                return Constants.DEFAULT_NEWS_INDEX_TOPS;
            }
        }
        #endregion
	}
}

