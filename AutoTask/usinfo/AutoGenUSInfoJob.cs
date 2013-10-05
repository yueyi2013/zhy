using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
using ZHY.Common;
using AutoTask.utils;
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
            string method = "--AutoGenUSInfoJob#Execute";
            ZHY.BLL.VirtualPersonInfo bll = new ZHY.BLL.VirtualPersonInfo();
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.GENERATE_US_PERSON_INFO_JOB, JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    bll.ExtractPsnInfoFromSite();
                }else{
                    //do nothing   
                }
            }catch(Exception ex){

                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, ex.Message);
            }
            
		}
    }
}
