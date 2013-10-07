﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Common.Logging;
using ZHY.Common;
using AutoTask.utils;
namespace AutoTask
{
    public class TwodollarclickViewAdsJob:IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(TwodollarclickViewAdsJob));

        public TwodollarclickViewAdsJob()
		{

		}
		
		/// <summary> 
		/// Called by the <see cref="IScheduler" /> when a
		/// <see cref="ITrigger" /> fires that is associated with
		/// the <see cref="IJob" />.
		/// </summary>
		public virtual void  Execute(IJobExecutionContext context)
		{
            string method = "--ADmimsyViewAdsJob#Execute";
            ZHY.BLL.TwoDollarcCick bll = new ZHY.BLL.TwoDollarcCick();
            try
            {
                if (bll.CheckJobIsEnabled(JobConstants.AD_MIMSY_VIEW_ADS_TWO_JOB, JobConstants.AUTO_TASK_JOB_GROUP))
                {
                    
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
