using System;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using ZHY.Model;

using System.IO;
using System.Xml;
using ZHY.Common;
using System.Web;

namespace ZHY.BLL
{
	/// <summary>
	/// RSSSite
	/// </summary>
	public partial class RSSSite
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
            string strGetFields = " [RSSId],[RSSURL],[RSSSource],[RSSDesc],[NavCreateAt],[NavCreateBy],[NavUpdateDT],[NavUpdateBy] ";
            string tablename = " RSSSite ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " NavUpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and RSSDesc like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }


        public void AutoTaskLoadFeeds()
        {
            IList<ZHY.Model.RSSSite> list = GetModelList("");
            ZHY.BLL.RSSChannel bll = new ZHY.BLL.RSSChannel();
            foreach (ZHY.Model.RSSSite model in list)
            {
                ZHY.Model.RSSChannel chlModel = bll.FetchRssFeeds(model.RSSURL);
                chlModel.RSSId = model.RSSId;
                bll.SaveBatchRssFeeds(chlModel);
            }
        }
        #endregion
	}
}

