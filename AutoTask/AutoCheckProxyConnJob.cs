using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZHY.Common;

using Quartz;
using Common.Logging;
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
                bll.CheckProxyAddressConnected();
            }catch(Exception ex)
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
		}
    }
}
