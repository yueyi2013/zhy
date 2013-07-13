using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindNews();
            }            
        }

        private void BindNews() 
        {
            ZHY.ACC.BLL.RSSChannelItem bll = new ZHY.ACC.BLL.RSSChannelItem();
            bll.MoveNewsToAccessDB();
            this.gvNews.DataSource = bll.GetAllList();
            this.gvNews.DataBind();
        }
    }
}