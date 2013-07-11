using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Common;
using System.Text;

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
                this.divContent.InnerHtml = HttpUtility.HtmlDecode(CompressionUtil.Decompress(model.RCItemDescription, "gb2312"));

                StringBuilder sbWB = new StringBuilder();
                sbWB.AppendFormat("<div id=\"qqwb_share__\" data-appkey=\"801383164\""
                + "data-icon=\"1\" data-counter=\"1\" data-counter_pos=\"right\""
                + "data-content=\"{0}\" data-richcontent=\"来自：{1}\" data-pic=\"{2}\"></div>", model.RCItemTitle, "syihy.com|作者：SYIHY|发布日期：" + model.RCItemPubDate, "http://www.syihy.com/images/site/title.jpg");
                this.divTXWB.InnerHtml = sbWB.ToString();

                StringBuilder sbXL = new StringBuilder();
                sbXL.AppendFormat("<wb:share-button appkey=\"2919819730\" "
                +"relateuid=\"2703774515\" type=\"button\" "
                + "title=\"{0}\" size=\"big\" count=\"n\"></wb:share-button>", model.RCItemTitle);                
                this.divXLWB.InnerHtml=sbXL.ToString();
            }
        }
    }
}