using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZHY.Common
{
    public class Constants
    {
        public static string SYSTEM_NAME="System";
        public static string AUTHOR_NAME = "syihy.com";
        public static string SYSTEM_CONFIG_ATT_NAME_MAIL_SENT = "MAIL_SENT";
        public static string SYSTEM_CONFIG_ATT_GROUP_NEWS = "NEWS";
        public static string SYSTEM_CONFIG_ATT_GROUP_NEWS_VALUE_Y = "Y";
        public static string SYSTEM_CONFIG_ATT_NAME_MAIL_RECEIVER = "MAIL_RECR";
        public static string SYSTEM_CONFIG_ATT_NAME_MAIL_RECEIVER_DEFAULT = "709757455@qq.com";
        public static string SYSTEM_CONFIG_ATT_NAME_MAIL_SEND_SUBJECT = "[SYIHY.COM]RSS JOB 提醒邮件";
        public static string SYSTEM_CONFIG_ATT_NAME_MAIL_SEND_COMP_SUBJECT = "[SYIHY.COM]RSS JOB 提醒邮件--压缩/解压后的内容";
        public static string SYSTEM_CONFIG_ATT_NAME_MAIL_PURGE_JOB_SUBJECT = "[SYIHY.COM]Purge JOB 提醒邮件";
        public static string SYSTEM_CONFIG_ATT_NAME_MAIL_PROXY_JOB_SUBJECT = "[SYIHY.COM]Proxy Address Invalid 提醒邮件";
        public static string SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT = "[SYIHY.COM]错误提醒邮件";
        
        public static string SYSTEM_CONFIG_ATT_NAME_NEWS_PURGE_DAYS = "PURGE_DAYS";
        public static string SYSTEM_CONFIG_ATT_NAME_NEWS_INDEX_TOPS = "INDEX_TOPS";

        public static string DEFAULT_SITE_USER_PASSWORD = "syihy001";
        public static int DEFAULT_NEWS_INDEX_TOPS = 20;
        public static int DEFAULT_PURGE_NEWS_DAYS = -7;
        //网站首页top新闻内容字数
        public static int SITE_INDEX_TOP_NEWS_WORDS = 630;
        //网站首页新闻列表标题字数
        public static int SITE_INDEX_NEWS_LIST_TITLE_WORDS = 18;
        //每次job运行生成的美国人信息人数
        public static int US_PERSON_INFO_COUNT = 10;
        //每次job运行默认查看广告的次数
        public static int DEFAULT_ADMIMSY_VIEW_ADS_COUNT = 3;
        //默认代理地址国家
        public static string SYSTEM_CONFIG_ATT_VALUE_DEFAULT_PROXY_ADDRESS_CNTY = "China";
        public static string SYSTEM_CONFIG_ATT_NAME_DEFAULT_PROXY_ADDRESS_CNTY = "CNTY";
        public static string SYSTEM_CONFIG_ATT_GROUP_DEFAULT_PROXY_ADDRESS = "DEF_PROXY";
    }
}
