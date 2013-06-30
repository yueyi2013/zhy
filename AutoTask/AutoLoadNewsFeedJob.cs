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
            ZHY.BLL.RSSSite bll = new ZHY.BLL.RSSSite();
            bll.AutoTaskLoadFeeds();
            _log.Info("Job finish at :"+DateTime.Now);
		}
    }
}
