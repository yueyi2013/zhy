using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
using ZHY.Common;

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
                bll.ExtractProxyAddress();
            }
            catch (Exception ex)
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
		}
    }
}
