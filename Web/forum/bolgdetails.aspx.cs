using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Common;

namespace Web.forum
{
    public partial class bolgdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string bgid = Request.QueryString["bgid"];
                if (!string.IsNullOrEmpty(bgid))
                {
                    BindBlog(bgid);
                }
            }
        }

        private void BindBlog(string bgid)
        {
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            ZHY.Model.Article model =  bll.GetModel(decimal.Parse(bgid));
            this.lblTitle.Text = model.ArTitle;
            this.divBlog.InnerHtml = HttpUtility.HtmlDecode(CompressionUtil.Decompress(model.ArContent, "gb2312"));
        }
    }
}