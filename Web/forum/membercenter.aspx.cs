﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.forum
{
    public partial class membercenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["memUser"] == null || string.IsNullOrEmpty(Session["memUser"].ToString())) 
                {
                    Response.Redirect("memberlogin.aspx");
                }
            }
        }
    }
}