using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;

namespace Web.admin.site.ads
{
    public partial class wfAdCodeList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!IsPostBack)
            {
                MstGridViewBind();
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
            ZHY.BLL.AdCode bll = new ZHY.BLL.AdCode();
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
            int id = ConvertInt32(this.hfAdCodeId.Value, 0);
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
                    ZHY.BLL.Article bll = new ZHY.BLL.Article();
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
            ZHY.Model.AdCode model = new ZHY.Model.AdCode();
            model.AdId = int.Parse(this.ddlAd.SelectedItem.Value);
            model.AdCodeCont = this.txtAdCodeCont.Text;
            model.AdCodeDesc = this.txtCodeDesc.Text;
            model.AdDefault = this.rbAdDefault.SelectedItem.Value;
            model.Status = this.rbStatus.SelectedItem.Value;
            ZHY.Model.User user = getLoginUser();
            model.CreateBy = user.UserName;
            model.UpdateBy = user.UserName;
            ZHY.BLL.AdCode bll = new ZHY.BLL.AdCode();
            bll.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="LMID"></param>
        private void Modify(int ID)
        {
            ZHY.BLL.AdCode bll = new ZHY.BLL.AdCode();
            ZHY.Model.AdCode model = bll.GetModel(ID);
            if (model != null)
            {                
                ZHY.Model.User user = getLoginUser();
                model.AdId = int.Parse(this.ddlAd.SelectedItem.Value);
                model.AdCodeCont = this.txtAdCodeCont.Text;
                model.AdCodeDesc = this.txtCodeDesc.Text;
                model.AdDefault = this.rbAdDefault.SelectedItem.Value;
                model.Status = this.rbStatus.SelectedItem.Value;
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
            this.hfAdCodeId.Value = "0";
            this.txtAdCodeCont.Text = "";
            this.txtCodeDesc.Text = "";
        }

        /// <summary>
        /// 初始化数据控件
        /// </summary>
        private void InitData(int rssId)
        {
            ZHY.BLL.AdCode bll = new ZHY.BLL.AdCode();
            ZHY.Model.AdCode model = bll.GetModel(rssId);
            this.hfAdCodeId.Value = model.AdCodeId.ToString();
            this.txtAdCodeCont.Text = model.AdCodeCont;
            this.txtCodeDesc.Text = model.AdCodeDesc;
        }
        #endregion
    }
}