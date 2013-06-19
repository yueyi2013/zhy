using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;

namespace Web.forum
{
    public partial class bolg : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if(!IsPostBack)
            {
                BindTreeBlogList();
                MstRepeaterBind();
            }
        }

        /// <summary>
        /// 绑定左侧博客类型
        /// </summary>
        private void BindTreeBlogList()
        {
            TreeNode root = new TreeNode("全部分类", "0");
            ZHY.BLL.ArticleCategory bll = new ZHY.BLL.ArticleCategory();
            IList<ZHY.Model.ArticleCategory> list = bll.GetModelList("");
            foreach (ZHY.Model.ArticleCategory model in list)
            {
                foreach (ZHY.Model.ArticleCategory item in list)
                {
                    TreeNode objTreeNode = new TreeNode();
                    objTreeNode.Text = model.ACName;
                    objTreeNode.Value = model.ACId.ToString();
                    root.ChildNodes.Add(objTreeNode);
                    break;
                }
            }
            this.tvBolgCat.Nodes.Add(root);
        }

        /// <summary>
        /// 绑定博客列表
        /// </summary>
        protected override void MstRepeaterBind()
        {
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            string name = "";
            this.rpBolgList.DataSource = bll.GetIndexBlogList(pageIndex, name, ref pageRecord);
            this.rpBolgList.DataBind();
            base.MstRepeaterBind();
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
            base.pageIndexType = 2;
            base.BindPageControls();
        }

        protected void tvBolgCat_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.hfACID.Value = this.tvBolgCat.SelectedNode.Value;
            this.lblCategory.Text = this.tvBolgCat.SelectedNode.Text;
            MstRepeaterBind();
        }
    }
}