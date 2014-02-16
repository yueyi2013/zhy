using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using ZHY.Common;
using ZHY.BLL;

namespace ZHY.ACC.BLL
{
	/// <summary>
	/// RSSChannelItem
	/// </summary>
	public partial class RSSChannelItem : BaseBLL
	{
        /// <summary>
        /// �����ű�����Access���ݿ�
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public void MoveNewsToAccessDB()
        {
            int days = Constants.DEFAULT_PURGE_NEWS_DAYS;
            bool isMovedDB = false;
            try
            {
                ZHY.BLL.SystemConfig bll = new ZHY.BLL.SystemConfig();
                ZHY.Model.SystemConfig model = bll.GetModel(Constants.SYSTEM_CONFIG_ATT_NAME_NEWS_PURGE_DAYS, Constants.SYSTEM_CONFIG_ATT_GROUP_NEWS);
                if (model != null)
                {
                    days = int.Parse(model.SCAttrValue);
                    isMovedDB = string.IsNullOrEmpty(model.SCAttrValue2)||model.SCAttrValue2.Equals("N")?false:true;
                }
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
            if (isMovedDB)
            {
                IList<ZHY.Model.RSSChannelItem> list = bllItem.loadExpireNews(days);
                string errorMsg = "";
                foreach (ZHY.Model.RSSChannelItem model in list)
                {
                    if (!dal.Add(model, ref errorMsg))
                    {
                        AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_PURGE_JOB_SUBJECT, "ִ�� MoveNewsToAccessDB() ����ʱ��������" + errorMsg);
                        break;
                    }
                }
                if (list.Count > 0)
                    bllItem.DeleteExpireNews(days);
            }
            else {
                bllItem.DeleteExpireNews(days);
            }
        }
	}
}

