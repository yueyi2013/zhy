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
   public class AutoPurgeNewsJob : IJob
   {
       private static ILog _log = LogManager.GetLogger(typeof(SampleJob));

       public AutoPurgeNewsJob()
	   {

	   }
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{
            string method = "--AutoPurgeNewsJob#Execute";
            ZHY.ACC.BLL.RSSChannelItem bll = new ZHY.ACC.BLL.RSSChannelItem();
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.PURGE_NEWS_JOB, JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    bll.MoveNewsToAccessDB();
                }
                else { 
                    //do nothing
                }
            }
            catch (Exception ex) {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);            
            }
		}
   }
}
