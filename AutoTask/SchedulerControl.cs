using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Quartz.Impl;
using Common.Logging;
namespace AutoTask
{
    public class SchedulerControl
    {
        IScheduler sched=null;
        ILog log = LogManager.GetLogger(typeof(SchedulerControl));
        public void StartSimpleJob() 
        {
            //string cronExpr = ConfigurationManager.AppSettings["cronExpr"];
            // First we must get a reference to a scheduler
            ISchedulerFactory sf = new StdSchedulerFactory();
            if (sched==null)
            {
                sched = sf.GetScheduler();
            }
            log.Info("------- Initialization Complete -----------");

            DateTime startTime = DateTime.Now.AddMinutes(1);

            log.Info("------- Scheduling Job  -------------------");

            // define the job and tie it to our HelloJob class
            IJobDetail mailJob = JobBuilder.Create<SampleJob>()
                .WithIdentity("SampleJob", "SampleJob")
                .Build();

            ITrigger mailTrigger = (ISimpleTrigger)TriggerBuilder.Create()
                                          .WithIdentity("SampleJobTrigger", "SampleJobGroup")
                                          .StartAt(startTime)
                                          .WithSimpleSchedule(x => x.WithIntervalInMinutes(5).RepeatForever())
                                          .Build();

            // Tell quartz to schedule the job using our trigger
            sched.ScheduleJob(mailJob, mailTrigger);

            // Start up the scheduler (nothing can actually run until the 
            // scheduler has been started)
            sched.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShutDownSchedule(bool waitJobFinish) 
        {
            if (sched != null)
                sched.Shutdown(waitJobFinish);
        }

    }
}
