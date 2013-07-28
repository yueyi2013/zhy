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
    public partial class wfBlogList :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //InitFTB(this.ftContent);
            BindPageControls();
            if (!IsPostBack)
            {
                MstGridViewBind();
                BindArticalCategory();
                BindArticalType();
            }
        }

        #region 绑定DataGridView
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
            base.BindPageControls();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected override void MstGridViewBind()
        {
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            string name = this.txtName.Text;
            this.MstGridView.DataSource = bll.GetList(pageIndex, name, ref pageRecord);
            this.MstGridView.DataBind();
            base.MstGridViewBind();
        }

        /// <summary>
        /// 数据行绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MstGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置行颜色   
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#F9E3AA'");
                //添加自定义属性，当鼠标移走时还原该行的背景色   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MstGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string name = e.CommandName;
            string arg = e.CommandArgument.ToString();
            if (name.Equals("add"))
            {

            }
            else if (name.Equals("del"))
            {

            }
            else if (name.Equals("mod"))
            {

            }

        }
        #endregion

        #region 按钮操作
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MstGridViewBind();
        }

        /// <summary>
        ///  保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ntId = ConvertInt32(this.hfArId.Value, 0);
            if (ntId == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(ntId);
            }
            SelfInform(this.MyUpdatePanelPanelBody, this.GetType(), "保存成功！");
            MstGridViewBind();
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                string arId = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    ZHY.BLL.Article bll = new ZHY.BLL.Article();
                    bll.Delete(ConvertInt32(arId, 0));
                }
            }
            MstGridViewBind();

        }

        /// <summary>
        /// 修改按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModify_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                string newsId = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    InitData(ConvertInt32(newsId, 0));
                    this.mpMstAdd.Show();
                    btnModify.Enabled = true;
                    break;
                }
            }
        }

        /// <summary>
        ///  关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.mpMstAdd.Hide();
            InitDataClear();
        }

        private void BindArticalCategory()
        {
            ZHY.BLL.ArticleCategory bll = new ZHY.BLL.ArticleCategory();
            this.ddlArticalCategory.DataSource = bll.GetAllList();
            this.ddlArticalCategory.DataBind();
        }

        private void BindArticalType()
        {
            ZHY.BLL.ArticalType bll = new ZHY.BLL.ArticalType();
            this.ddlArticalType.DataSource = bll.GetAllList();
            this.ddlArticalType.DataBind();
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 获取登录用户
        /// </summary>
        /// <returns></returns>
        private ZHY.Model.User getLoginUser()
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

        /// <summary>
        /// 新增
        /// </summary>
        private void Add()
        {
            ZHY.Model.Article model = new ZHY.Model.Article();
            model.ArAuthor = this.txtNewsAuthor.Text;
            model.ArContent = this.txtNewsAuthor.Text;
            model.ArPubDate = DateTime.Parse(this.txtPublishDate.Value);
            model.ArTitle = this.txtNewsTitle.Text;
            model.ArTypeId = int.Parse(this.ddlArticalType.SelectedValue);
            model.ACId = int.Parse(this.ddlArticalCategory.SelectedValue);
            model.ArContent = CompressionUtil.Compress(this.ftContent.Text, "gb2312");
            model.ArStatus = this.rbStatus.SelectedItem.Value;
            ZHY.Model.User user = getLoginUser();
            model.CreateBy = user.UserName;
            model.UpdateBy = user.UserName;
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            bll.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="LMID"></param>
        private void Modify(int ID)
        {
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            ZHY.Model.Article model = bll.GetModel(ID);
            if (model != null)
            {
                model.ArAuthor = this.txtNewsAuthor.Text;
                model.ArContent = this.ftContent.Text;
                model.ArPubDate = DateTime.Parse(this.txtPublishDate.Value);
                model.ArTitle = this.txtNewsTitle.Text;
                model.ArTypeId = int.Parse(this.ddlArticalType.SelectedValue);
                model.ACId = int.Parse(this.ddlArticalCategory.SelectedValue);
                model.ArContent = CompressionUtil.Compress(this.ftContent.Text, "gb2312");
                model.ArStatus = this.rbStatus.SelectedItem.Value;
                ZHY.Model.User user = getLoginUser();
                model.UpdateBy = user.UserName;
                model.UpdateDT = DateTime.Now;
                bll.Update(model);
            }
        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
        {
            this.hfArId.Value = "0";
            this.txtNewsTitle.Text = "";
            this.txtNewsAuthor.Text = "";
            this.ftContent.Text = "";
            this.rbStatus.SelectedItem.Value = "A";
            this.txtPublishDate.Value = DateTime.Now.ToLongDateString();
        }

        /// <summary>
        /// 初始化数据控件
        /// </summary>
        private void InitData(int rssId)
        {
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            ZHY.Model.Article model = bll.GetModel(rssId);
            this.hfArId.Value = model.ArId.ToString();
            this.txtNewsTitle.Text = model.ArTitle;
            this.txtNewsAuthor.Text = model.ArAuthor;
            this.txtPublishDate.Value = model.ArPubDate.Value.ToString("yyyy-MM-dd");
            this.ftContent.Text = CompressionUtil.Decompress(model.ArContent, "gb2312");
            this.rbStatus.SelectedItem.Value = model.ArStatus;
        }
        #endregion
    }
}