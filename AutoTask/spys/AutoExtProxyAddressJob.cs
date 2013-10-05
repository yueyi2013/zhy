using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
using ZHY.Common;
using AutoTask.utils;

namespace AutoTask.spys
{
    public class AutoExtProxyAddressJob:IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(AutoExtProxyAddressJob));

        public AutoExtProxyAddressJob()
		{
		}
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{
            string method = "--AutoExtProxyAddressJob#Execute";
            ZHY.BLL.ProxyAddress bll = new ZHY.BLL.ProxyAddress();
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.SPYS_EXTRACT_PROXY_ADDRESS_JOB, JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    bll.ExtractProxyAddress();
                }
                else { 
                    //do nothing
                }
            }
            catch (Exception ex)
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
		}
    }
}
