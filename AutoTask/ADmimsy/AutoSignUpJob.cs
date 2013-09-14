using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZHY.Common;
using Quartz;
using Common.Logging;
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
                bll.RegAdmimsy();
            }
            catch (Exception ex)
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
		}
    }
}
