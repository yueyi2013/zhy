﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
using ZHY.Common;
using AutoTask.utils;

namespace AutoTask.ADmimsy
{
    public class ADmimsySignUpJob:IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(ADmimsySignUpJob));

        public ADmimsySignUpJob()
		{
		}
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{
            string method = "--ADmimsySignUpJob#Execute";
            ZHY.BLL.ADmimsy bll = new ZHY.BLL.ADmimsy();
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.AD_MIMSY_SIGN_UP_TWO_JOB, JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    bll.SignUpAdmimsyFromJob();
                }
                else
                {
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
