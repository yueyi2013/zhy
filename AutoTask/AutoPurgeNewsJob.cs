using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Quartz;
using Common.Logging;
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
            ZHY.ACC.BLL.RSSChannelItem bll = new ZHY.ACC.BLL.RSSChannelItem();
            bll.MoveNewsToAccessDB();
		}
   }
}
