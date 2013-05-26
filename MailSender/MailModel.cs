using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MailSender
{
    [Serializable()]
    class MailModel
    {
        private string smtpName;

        public string SmtpName
        {
            get { return smtpName; }
            set { smtpName = value; }
        }
        private string port;

        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        private string mailFromAddress;

        public string MailFromAddress
        {
            get { return mailFromAddress; }
            set { mailFromAddress = value; }
        }

        private string mailFromType;

        public string MailFromType
        {
            get { return mailFromType; }
            set { mailFromType = value; }
        }

        private string mailPassword;

        public string MailPassword
        {
            get { return mailPassword; }
            set { mailPassword = value; }
        }

        private bool isCheckedFrom = false;

        public bool IsCheckedFrom
        {
            get { return isCheckedFrom; }
            set { isCheckedFrom = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private int month;

        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        private int day;

        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        private int hour;

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        private int min;

        public int Min
        {
            get { return min; }
            set { min = value; }
        }
        private int second;

        public int Second
        {
            get { return second; }
            set { second = value; }
        }

        private ArrayList mailList = new ArrayList();
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        private string mailContent;

        public string MailContent
        {
            get { return mailContent; }
            set { mailContent = value; }
        }
        private ArrayList attPathList = new ArrayList();

        public ArrayList AttPathList
        {
            get { return attPathList; }
            set { attPathList = value; }
        }
        
    }
}
