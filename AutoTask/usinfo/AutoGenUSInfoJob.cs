using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
namespace AutoTask.usinfo
{
    public class AutoGenUSInfoJob : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(AutoGenUSInfoJob));

        public AutoGenUSInfoJob()
		{

		}
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{
            _log.Info("job be invoked....");
            //ZHY.BLL.VirtualPersonInfo bll = new ZHY.BLL.VirtualPersonInfo();
           // bll.ExtractPsnInfoFromSite();
		}
    }
}
