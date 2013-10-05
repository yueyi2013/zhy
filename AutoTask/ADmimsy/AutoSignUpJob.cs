using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZHY.Common;
using Quartz;
using Common.Logging;
using AutoTask.utils;
namespace AutoTask.ADmimsy
{
    public class AutoSignUpJob :IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(AutoSignUpJob));

        public AutoSignUpJob()
		{
		}
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{
            
            string method = "--AutoSignUpJob#Execute";
            ZHY.BLL.VirtualTask bll = new ZHY.BLL.VirtualTask();
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.AD_MIMSY_SIGN_UP_JOB,JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    bll.RegAdmimsyByJob();
                }else{
                    //donothing
                }
            }
            catch (Exception ex)
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
		}
    }
}
