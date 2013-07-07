using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;

namespace Web.admin.site.ads
{
    public partial class wfAdList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!IsPostBack)
            {
                MstGridViewBind();
                BindAdCategory();
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
            ZHY.BLL.Advertisement bll = new ZHY.BLL.Advertisement();
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
            int id = ConvertInt32(this.hfAdId.Value, 0);
            if (id == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(id);
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
                string id = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    ZHY.BLL.Advertisement bll = new ZHY.BLL.Advertisement();
                    bll.Delete(ConvertInt32(id, 0));
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
                string id = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    InitData(ConvertInt32(id, 0));
                    this.mpMstAdd.Show();
                    btnModify.Enabled = true;
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

        private void BindAdCategory()
        {
            ZHY.BLL.AdCategory bll = new ZHY.BLL.AdCategory();
            this.ddlAdCategory.DataSource = bll.GetAllList();
            this.ddlAdCategory.DataBind();
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
            ZHY.Model.Advertisement model = new ZHY.Model.Advertisement();
            model.AdLogo = this.txtAdLogo.Text;
            model.AdName = this.txtAdName.Text;
            model.AdCategoryId = int.Parse(this.ddlAdCategory.SelectedItem.Value);
            model.AdBgCode = this.txtAdBgCode.Text;
            model.AdUnitPrice = decimal.Parse(this.txtAdUnitPrice.Text);
            model.AdUnit = this.txtAdUnit.Text;
            model.AdBillingCycle = this.txtAdBillingCycle.Text;
            model.AdSource = HtmlEncode(this.txtAdSource.Text);
            model.AdCode = this.txtAdCode.Text;
            model.AdDesc = this.txtAdDesc.Text;
            model.Status = this.rbStatus.SelectedItem.Value;
            ZHY.Model.User user = getLoginUser();
            model.CreateBy = user.UserName;
            model.UpdateBy = user.UserName;
            ZHY.BLL.Advertisement bll = new ZHY.BLL.Advertisement();
            bll.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="LMID"></param>
        private void Modify(int ID)
        {
            ZHY.BLL.Advertisement bll = new ZHY.BLL.Advertisement();
            ZHY.Model.Advertisement model = bll.GetModel(ID);
            if (model != null)
            {
                model.AdLogo = this.txtAdLogo.Text;
                model.AdName = this.txtAdName.Text;
                model.AdCategoryId = int.Parse(this.ddlAdCategory.SelectedItem.Value);
                model.AdBgCode = this.txtAdBgCode.Text;
                model.AdUnitPrice = decimal.Parse(this.txtAdUnitPrice.Text);
                model.AdUnit = this.txtAdUnit.Text;
                model.AdBillingCycle = this.txtAdBillingCycle.Text;
                model.AdSource = this.txtAdSource.Text;
                model.AdCode = HtmlEncode(this.txtAdCode.Text);
                model.AdDesc = this.txtAdDesc.Text;
                model.Status = this.rbStatus.SelectedItem.Value;
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
            this.hfAdId.Value = "0";
            this.txtAdCode.Text = "";
            this.txtAdBillingCycle.Text = "";
            this.txtAdLogo.Text = "";
        }

        /// <summary>
        /// 初始化数据控件
        /// </summary>
        private void InitData(int rssId)
        {
            ZHY.BLL.Advertisement bll = new ZHY.BLL.Advertisement();
            ZHY.Model.Advertisement model = bll.GetModel(rssId);
            this.hfAdId.Value = model.AdId.ToString();
            this.txtAdLogo.Text = model.AdLogo;
            this.txtAdName.Text = model.AdName;
            this.ddlAdCategory.SelectedItem.Value = model.AdCategoryId.ToString();
            this.txtAdBgCode.Text = model.AdBgCode;
            this.txtAdUnitPrice.Text = model.AdUnitPrice.ToString();
            this.txtAdUnit.Text = model.AdUnit;
            this.txtAdBillingCycle.Text = model.AdBillingCycle;
            this.txtAdSource.Text = model.AdSource;
            this.txtAdCode.Text = HtmlDecode(model.AdCode);
            this.txtAdDesc.Text = model.AdDesc;
            this.rbStatus.SelectedItem.Value = model.Status;            
        }
        
        #endregion
    }
}