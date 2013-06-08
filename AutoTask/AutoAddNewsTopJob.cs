using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;

namespace AutoTask
{
    class AutoAddNewsTopJob : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(AutoAddNewsTopJob));

        public AutoAddNewsTopJob()
		{
		}
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{
            ZHY.BLL.RSSChannelItem bll = new ZHY.BLL.RSSChannelItem();
            ZHY.BLL.NewsTop bllNewsTop = new ZHY.BLL.NewsTop();
            bllNewsTop.Delete();
            IList<ZHY.Model.RSSChannelItem> list = bll.loadNewsTop(10);
            foreach (ZHY.Model.RSSChannelItem item in list)
            {
                ZHY.Model.NewsTop model = new ZHY.Model.NewsTop();
                model.NTTitle = item.RCItemTitle;
                model.NTAuthor = item.RCItemAuthor;
                model.NTPubDate = item.RCItemPubDate;
                model.NTContent = item.RCItemDescription;
                model.CreateBy = ZHY.Common.Constants.SYSTEM_NAME;
                model.UpdateBy = ZHY.Common.Constants.SYSTEM_NAME;
                bllNewsTop.Add(model);
            }
            _log.Info("job finished....");
		}
    }
}
