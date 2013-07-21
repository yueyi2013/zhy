using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using ZHY.Common;

namespace Web
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //InitFlash();
                BindNewsTopModel();
                BindNewsList();
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        protected string HtmlDecode(string title)
        {
            return Server.HtmlDecode(title);
        }

        /// <summary>
        /// 标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        protected string CutTitleString(string title)
        {
            if (!string.IsNullOrEmpty(title) && title.Length > Constants.SITE_INDEX_NEWS_LIST_TITLE_WORDS)
                return title.Substring(0, Constants.SITE_INDEX_NEWS_LIST_TITLE_WORDS) + "...";
            return title;
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindNewsList()
        {
            ZHY.BLL.NewsCategory bll = new ZHY.BLL.NewsCategory();
            this.dlNewsList.DataSource = bll.GetNewsListWithCat("indexNewsList");
            this.dlNewsList.DataBind();
        }

        private void BindNewsTop() 
        {
            ZHY.BLL.NewsTop bll = new ZHY.BLL.NewsTop();
            bll.GetAllList();
            this.dlNewsTop.DataSource = bll.GetAllList();
            this.dlNewsTop.DataBind();  
        }

        /// <summary>
        /// 绑定Top News
        /// </summary>
        private void BindNewsTopModel()
        {
            ZHY.BLL.NewsTop bll = new ZHY.BLL.NewsTop();
            IList<ZHY.Model.NewsTop> list = bll.DataTableToList(bll.GetList(1, "", " newid() ").Tables[0]);
            if (list.Count > 0) 
            {
                ZHY.Model.NewsTop model = list[0];
                this.hlNew.Text = model.NTTitle;
                this.hlNew.NavigateUrl = "~/forum/newsdetails.aspx?rciid=" + model.NTId;
                this.hlNewDetail.NavigateUrl = "~/forum/newsdetails.aspx?rciid=" + model.NTId;
                string parStr = HtmlPaserUtil.ParseTags(HttpUtility.HtmlDecode(CompressionUtil.Decompress(model.NTContent, "gb2312")));

                string newCont = HtmlPaserUtil.RemoveStrSpace(parStr);
                
                if (!string.IsNullOrEmpty(newCont) && newCont.Length > Constants.SITE_INDEX_TOP_NEWS_WORDS)
                {
                    this.lblContent.Text = newCont.Substring(0, Constants.SITE_INDEX_TOP_NEWS_WORDS) + "......";
                }
                else
                {                    
                    this.lblContent.Text = newCont;
                }
            }                      
        }

        /// <summary>
        /// 初始化首页广告
        /// </summary>
        private void InitFlash()
        {/*
            StringBuilder strContent = new StringBuilder();
            this.divflashContent.InnerHtml = "";
            strContent.Append("<script type=\"text/javascript\">\r\n");
            ZHY.BLL.SiteFlash bll = new ZHY.BLL.SiteFlash();
            DataSet ds = bll.GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string pics = "", links = "", texts = "";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (pics == "")
                        pics = ds.Tables[0].Rows[i]["SFPicPath"].ToString();
                    else
                        pics = pics + "|" + ds.Tables[0].Rows[i]["SFPicPath"].ToString();
                    if (links == "")
                        links = ds.Tables[0].Rows[i]["SFDetailsURL"].ToString();
                    else
                        links = links + "|" + ds.Tables[0].Rows[i]["SFDetailsURL"].ToString();
                    if (texts == "")
                        texts = ds.Tables[0].Rows[i]["SFConTitle"].ToString();
                    else
                        texts = texts + "|" + ds.Tables[0].Rows[i]["SFConTitle"].ToString();
                }
                strContent.Append(" pics=\"" + @pics + "\"; \r\n");
                strContent.Append(" links=\"" + @links + "\"; \r\n");
                strContent.Append(" texts=\"" + @texts + "\"; \r\n");
            }
            strContent.Append("</script>\r\n");
            this.divflashContent.InnerHtml = strContent.ToString();
            */
        }
    }
}