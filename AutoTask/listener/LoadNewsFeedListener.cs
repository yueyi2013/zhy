using System;
using System.Collections.Generic;
using Quartz;
using Common.Logging;
using ZHY.Common;

namespace AutoTask.listener
{
    public class LoadNewsFeedListener : IJobListener
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoadNewsFeedListener));

        public virtual string Name
        {
            get { return "job1_to_job2"; }
        }

        public virtual void JobToBeExecuted(IJobExecutionContext inContext)
        {
            log.Info("Job1Listener says: Job Is about to be executed.");
        }

        public virtual void JobExecutionVetoed(IJobExecutionContext inContext)
        {
            log.Info("Job1Listener says: Job Execution was vetoed.");
        }

        public virtual void JobWasExecuted(IJobExecutionContext inContext, JobExecutionException inException)
        {
           
        }
    }
}
