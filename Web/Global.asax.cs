using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using AutoTask;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        SchedulerControl  sc= null;

        protected void Application_Start(object sender, EventArgs e)
        {/*
            if (sc == null)
                sc = new SchedulerControl();
            sc.StartSimpleJob();*/
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            //sc.ShutDownSchedule(true);
        }
    }
}