using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
using AutoTask.utils;
using ZHY.Common;
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
            string method = "--AutoLoadNewsFeedJob#Execute";
            ZHY.BLL.RSSSite bll = new ZHY.BLL.RSSSite();
            
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.RSS_FEEDS_JOB, JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    bll.AutoTaskLoadFeeds();
                }
                else { 
                    //do nothing
                }
                
            }
            catch (Exception ex) {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
            _log.Info("Job finish at :"+DateTime.Now);
		}
    }
}
