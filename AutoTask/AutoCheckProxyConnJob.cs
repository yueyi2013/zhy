using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZHY.Common;

using Quartz;
using Common.Logging;
using AutoTask.utils;
namespace AutoTask
{
    public class AutoCheckProxyConnJob : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(AutoCheckProxyConnJob));

        public AutoCheckProxyConnJob()
		{
		}
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{
            string method = "--AutoCheckProxyConnJob#Execute";
            ZHY.BLL.ProxyAddress bll = new ZHY.BLL.ProxyAddress();
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.CHECK_PROXY_ADDRESS_JOB, JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    bll.CheckProxyAddressConnected();
                }
                else { 
                    //do nothing
                }
            }catch(Exception ex)
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
		}
    }
}
