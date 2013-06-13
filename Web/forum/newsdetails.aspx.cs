using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Common;

namespace Web.forum
{
    public partial class newsdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string rciid = Request.QueryString["rciid"];
                if (!string.IsNullOrEmpty(rciid))
                {
                    BindNewsItemInfo(int.Parse(rciid));
                }                
            }
        }

        private void BindNewsItemInfo(int RCItemId)
        {
            ZHY.BLL.RSSChannelItem bll = new ZHY.BLL.RSSChannelItem();
            ZHY.Model.RSSChannelItem model = bll.GetModel(RCItemId);
            if (model != null)
            {
                this.lblTitle.Text = Server.HtmlDecode(model.RCItemTitle);
                this.lblAuthor.Text = model.RCItemAuthor;
                this.lblPubDate.Text = model.RCItemPubDate.ToString();
                this.divContent.InnerHtml = HttpUtility.HtmlDecode(CompressionUtil.Decompress(model.RCItemDescription));
        
            
            }
        }
    }
}