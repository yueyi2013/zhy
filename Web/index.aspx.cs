using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Web
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitFlash();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindNewsList()
        {

        }

        /// <summary>
        /// 绑定Top News
        /// </summary>
        private void BindNewsTop()
        {
            ZHY.BLL.NewsTop bll = new ZHY.BLL.NewsTop();
            this.dlNewsTop.DataSource = bll.GetAllList();
            this.dlNewsTop.DataBind();            
        }

        /// <summary>
        /// 初始化首页广告
        /// </summary>
        private void InitFlash()
        {
            StringBuilder strContent = new StringBuilder();
            DataSet ds = new DataSet();
            this.divflashContent.InnerHtml = "";
            strContent.Append("<script type=\"text/javascript\">\r\n");
            ZHY.BLL.NewsSite bll = new ZHY.BLL.NewsSite();
            ds = (DataSet)bll.GetList("");
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