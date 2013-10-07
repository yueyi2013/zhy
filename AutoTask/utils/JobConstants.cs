using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoTask.utils
{
    public class JobConstants
    {
        public static string sample_cron_exp = "* 0/5 * * * ?";

        public static string RSS_FEEDS_JOB = "RSS_FEEDS";
        public static string NEWS_TOP_JOB = "NEWS_TOP";
        public static string PURGE_NEWS_JOB = "PURGE_NEWS";
        public static string GENERATE_US_PERSON_INFO_JOB = "GEN_US_PSN";
        public static string CHECK_PROXY_ADDRESS_JOB = "CHK_PROXY";
        public static string AD_MIMSY_VIEW_ADS_JOB = "VIEW_ADS";
        public static string AD_MIMSY_SIGN_UP_JOB = "MIMSY_REG";
        public static string SPYS_EXTRACT_PROXY_ADDRESS_JOB = "EXT_PROXY";
        public static string AD_MIMSY_VIEW_ADS_TWO_JOB = "VIEW_ADS2";
        public static string AD_MIMSY_SIGN_UP_TWO_JOB = "MIMSY_REG2";
        public static string AUTO_TASK_JOB_GROUP = "TASK_JOB";
    }
}
