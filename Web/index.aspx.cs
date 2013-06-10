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
                InitFlash();
                BindNewsTop();
                BindNewsList();
            }
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
            IList<ZHY.Model.NewsTop> list = bll.GetModelList("");
            if (list.Count > 0) 
            {
                ZHY.Model.NewsTop model = list[0];
                this.lblNewsTitle.Text = model.NTTitle;
                string con = HttpUtility.HtmlDecode(CompressionUtil.Decompress(model.NTContent));
                if (con.Length > 100)
                {
                    //this.lblContent.Text = con.Substring(0,100)+"......";
                }
                else
                {
                   // this.lblContent.Text = con;
                }
                
            }                      
        }

        /// <summary>
        /// 初始化首页广告
        /// </summary>
        private void InitFlash()
        {
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

        }
    }
}