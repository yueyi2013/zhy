using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartz;
using Quartz.Impl;
using Common.Logging;
using System.Reflection;
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
            if (sched == null)
            {
                sched = sf.GetScheduler();
            }
            else {
                sched = sf.GetScheduler("SyihyScheduler");
            }
            bool inClearJobs = true;
            if (inClearJobs && sched!=null)
            {
                log.Warn("***** Deleting existing jobs/triggers *****");
                sched.Clear();
            }
            log.Info("------- Initialization Complete -----------");        

            log.Info("------- Scheduling Job  -------------------");

            //Set auto load RSS job 
            ScheduleSimpleJob("RssFeeds", "RssFeeds", DateTime.Now.AddMinutes(1), DateTime.MaxValue, 60, true);
            //Set auto load Top news job
            ScheduleSimpleJob("NewsTop", "NewsTop", DateTime.Now.AddMinutes(1), DateTime.MaxValue, 120, true);

            // Start up the scheduler (nothing can actually run until the 
            // scheduler has been started)
            sched.Start();
        }

        /// <summary>
        /// Schedule simple job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="jobGroup"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="intervalMin"></param>
        /// <param name="isForever"></param>
        /// <param name="className"></param>
        public void ScheduleSimpleJob(string jobId, string jobGroup, DateTime startTime, DateTime endTime, int intervalMin, bool isForever)
        {
            try
            {
                // define the job and tie it to our HelloJob class
                IJobDetail simpleJob = JobBuilder.Create<AutoLoadNewsFeedJob>()
                    .WithIdentity(jobId + "Job", jobGroup + "JobGroup")
                    .Build();
                ITrigger simpleTrigger = null;
                if (isForever)
                {
                    simpleTrigger = (ISimpleTrigger)TriggerBuilder.Create()
                                              .WithIdentity(jobId + "Trigger", jobGroup + "TriggerGroup")
                                              .StartAt(startTime)
                                              .WithSimpleSchedule(x => x.WithIntervalInMinutes(intervalMin).RepeatForever())
                                              .Build();
                }
                else {
                    simpleTrigger = (ISimpleTrigger)TriggerBuilder.Create()
                                              .WithIdentity(jobId + "Trigger", jobGroup + "Trigger")
                                              .StartAt(startTime).EndAt(endTime)
                                              .WithSimpleSchedule(x => x.WithIntervalInMinutes(intervalMin))
                                              .Build();              
                
                }
                sched.ScheduleJob(simpleJob, simpleTrigger);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { 
            
            
            }
        }

        /// <summary>
        /// Schedule cron job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="jobGroup"></param>
        /// <param name="cronStr"></param>
        /// <param name="className"></param>
        public void ScheduleCronJob(string jobId, string jobGroup, string cronStr, Type className)
        {
            try
            {
                IJobDetail cronJob = JobBuilder.Create<SampleJob>()
                .WithIdentity(jobId + "Job", jobGroup + "JobGroup")
                .Build();

                ICronTrigger cronTrigger = (ICronTrigger)TriggerBuilder.Create()
                                                          .WithIdentity(jobId + "Trigger", jobGroup + "TriggerGroup")
                                                          .WithCronSchedule(cronStr)
                                                          .Build();
                sched.ScheduleJob(cronJob, cronTrigger);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {


            }
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
