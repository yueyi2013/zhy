using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;
using ZHY.Common;

namespace Web.admin.site.blog
{
    public partial class wfBlog : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArticalCategory();
                BindArticalType();
                this.txtPublishDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 绑定文章分类
        /// </summary>
        private void BindArticalCategory()
        {
            ZHY.BLL.ArticleCategory bll = new ZHY.BLL.ArticleCategory();
            this.ddlArticalCategory.DataSource = bll.GetAllList();
            this.ddlArticalCategory.DataBind();
        }

        /// <summary>
        /// 绑定文章类型
        /// </summary>
        private void BindArticalType()
        {
            ZHY.BLL.ArticalType bll = new ZHY.BLL.ArticalType();
            this.ddlArticalType.DataSource = bll.GetAllList();
            this.ddlArticalType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Add();
            SelfInform(this.MyUpdatePanelPanelBody, this.GetType(), "保存成功！");
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void Add()
        {
            ZHY.Model.Article model = new ZHY.Model.Article();
            model.ArAuthor = this.txtNewsAuthor.Text;
            model.ArPubDate = DateTime.Parse(this.txtPublishDate.Value);
            model.ArTitle = this.txtNewsTitle.Text;
            model.ArTypeId = int.Parse(this.ddlArticalType.SelectedValue);
            model.ACId = int.Parse(this.ddlArticalCategory.SelectedValue);
            model.ArContent = CompressionUtil.Compress(this.ftContent.Text, "gb2312");
            model.ArStatus = this.rbStatus.SelectedItem.Value;
            ZHY.Model.User user = GetLoginUser();
            model.CreateBy = user.UserName;
            model.UpdateBy = user.UserName;
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            bll.Add(model);
        }

        /// <summary>
        /// 获取登录用户
        /// </summary>
        /// <returns></returns>
        private ZHY.Model.User GetLoginUser()
        {
            ZHY.Model.User user = new ZHY.Model.User();
            if (Session["User"] != null)
            {
                user = (ZHY.Model.User)Session["User"];
            }
            else
            {
                user.UserName = "未知用户";
            }
            return user;
        }
    }
}