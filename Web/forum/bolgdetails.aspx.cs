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
                    CheckUserLogin();
                }
            }
        }

        /// <summary>
        /// 检查用户是否已经登录
        /// </summary>
        private void CheckUserLogin()
        {
            if (Session["MemUser"] != null)
            {
                this.divComments.Disabled = false;
                this.divLogin.Disabled = true;
            }else{
                this.divComments.Disabled = true;
                this.divLogin.Disabled = false;
            }
        }

        private void BindBlog(string bgid)
        {
            StringBuilder sbWB = new StringBuilder();            
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            ZHY.Model.Article model =  bll.GetModel(decimal.Parse(bgid));
            if (model==null)
            {
                Response.Redirect("bolg.aspx");
            }
            this.lblTitle.Text = model.ArTitle;
            Page.Title = model.ArTitle;
            this.divBlog.InnerHtml = CompressionUtil.Decompress(model.ArContent, "gb2312");
            sbWB.AppendFormat("<div id=\"qqwb_share__\" data-appkey=\"801383164\""
            +"data-icon=\"1\" data-counter=\"1\" data-counter_pos=\"right\""
            + "data-content=\"{0}\" data-richcontent=\"来自：{1}\" data-pic=\"{2}\"></div>", model.ArTitle, "syihy.com|作者：SYIHY|发布日期："+model.ArPubDate, "http://www.syihy.com/images/site/title.jpg");
            this.divTXWB.InnerHtml = sbWB.ToString();

            StringBuilder sbXL = new StringBuilder();
            sbXL.AppendFormat("<wb:share-button appkey=\"2919819730\" relateuid=\"2703774515\""
            + "relateuid=\"2703774515\" type=\"button\" "
            + "title=\"{0}\" size=\"big\" count=\"n\"></wb:share-button>", model.ArTitle);
            this.divXLWB.InnerHtml = sbXL.ToString();
        }
    }
}