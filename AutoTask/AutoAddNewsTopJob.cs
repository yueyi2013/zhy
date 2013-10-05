using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
using ZHY.Common;
using AutoTask.utils;
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
            ZHY.BLL.NewsTop bll = new ZHY.BLL.NewsTop();
            string method = "--AutoAddNewsTopJob#Execute";
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.NEWS_TOP_JOB, JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    bll.AutoTaskAddTopNews();
                }
                else
                {
                    // do nothing
                }
            }
            catch (Exception ex)
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
            
		}
    }
}
