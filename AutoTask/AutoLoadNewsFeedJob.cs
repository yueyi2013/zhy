using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
namespace AutoTask
{
    public class AutoLoadNewsFeedJob : IJob
    {

        private static ILog _log = LogManager.GetLogger(typeof(AutoLoadNewsFeedJob));
        public AutoLoadNewsFeedJob()
		{

		}
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{

            ZHY.BLL.RSSSite bllRSSSite = new ZHY.BLL.RSSSite();
            IList<ZHY.Model.RSSSite> list = bllRSSSite.GetModelList("");
            ZHY.BLL.RSSChannel bll = new ZHY.BLL.RSSChannel();
            foreach(ZHY.Model.RSSSite model in list)
            {
                ZHY.Model.RSSChannel chlModel = bll.FetchRssFeeds(model.RSSURL);
                chlModel.RSSId = model.RSSId;
                bll.SaveBatchRssFeeds(chlModel);
            }
            _log.Info("Job finish at :"+DateTime.Now);
		}
    }
}
