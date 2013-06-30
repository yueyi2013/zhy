using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
using LTP.Common;
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
            bll.AutoTaskAddTopNews();
		}
    }
}
