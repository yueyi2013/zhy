using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZHY.Web;
using ZHY.Common;

namespace Web.forum
{
    public partial class news : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!IsPostBack)
            {
                BindTreeNews();
                MstDataListBind();
            }
        }

        /// <summary>
        /// 绑定左侧新闻类型
        /// </summary>
        private void BindTreeNews()
        {
            TreeNode root = new TreeNode("新闻列表", "0");
            ZHY.BLL.RSSChannel bll = new ZHY.BLL.RSSChannel();
            ZHY.BLL.NewsCategory bllCat = new ZHY.BLL.NewsCategory();
            IList<ZHY.Model.NewsCategory> listCat = bllCat.GetModelList("");
            IList<ZHY.Model.RSSChannel> list = bll.GetModelList("");
            foreach(ZHY.Model.RSSChannel model in list)
            {
                foreach (ZHY.Model.NewsCategory item in listCat)
                {
                    if (model.RCTitle.Trim().Equals(item.NewsCategoryName.Trim()))
                    {
                        TreeNode objTreeNode = new TreeNode();
                        objTreeNode.Text = model.RCTitle;
                        objTreeNode.Value = model.RCId.ToString();
                        root.ChildNodes.Add(objTreeNode);
                        break;
                    }
                }
            }
            this.tvNews.Nodes.Add(root);
        }

        /// <summary>
        /// 绑定新闻列表
        /// </summary>
        protected override void MstDataListBind()
        {
            ZHY.BLL.RSSChannelItem bll = new ZHY.BLL.RSSChannelItem();
            int rcId = int.Parse(this.hfRCID.Value);
            this.dlNewsList.DataSource = bll.GetList(pageIndex, rcId, ref pageRecord);
            this.dlNewsList.DataBind();
            base.MstDataListBind();
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected override void BindPageControls()
        {
            this.btnFirst = this.btnFirst0;
            this.btnPrev = this.btnPrev0;
            this.btnNext = this.btnNext0;
            this.btnLast = this.btnLast0;
            this.btnGo = this.btnGo0;
            this.lblPageAll = this.lblPageAll0;
            this.lblPageIndex = this.lblPageIndex0;
            this.lblPageRecord = this.lblPageRecord0;
            this.lblPageSize = this.lblPageSize0;
            this.txtPageIndex = this.txtPageIndex0;
            base.pageIndexType = 1;
            base.BindPageControls();
        }

        protected void tvNews_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.hfRCID.Value = this.tvNews.SelectedNode.Value;
            this.lblCategory.Text = this.tvNews.SelectedNode.Text;
            MstDataListBind();
        }

        /// <summary>
        /// 截取新闻内容
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public string GetNewsContent(string con) 
        {
            if (string.IsNullOrEmpty(con))
            {
                return "";
            }
            else {
                string newCont = HtmlPaserUtil.ParseTags(HttpUtility.HtmlDecode(CompressionUtil.Decompress(con, "gb2312")));
                if (!string.IsNullOrEmpty(newCont) && newCont.Length > 400)
                {
                    return newCont.Substring(0, 400)+"......";
                }
                else {
                    return newCont;
                }
            }
            
        }
    }
}