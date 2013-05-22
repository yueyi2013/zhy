using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfFunctionList : BasePage
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
            ZHY.BLL.Function bll = new ZHY.BLL.Function();
            string name = this.txtName.Text;
            this.MstGridView.DataSource = bll.GetList(pageIndex,name,ref pageRecord);
            this.MstGridView.DataBind();
            base.MstGridViewBind();
        }

        /// <summary>
        /// 
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
            int funid = ConvertInt32(hfFunID.Value,0);
            if (funid == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(funid);
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
                string funid = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    ZHY.BLL.Function bll = new ZHY.BLL.Function();
                    bll.Delete(ConvertInt32(funid, 0));
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
                string funid = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    InitData(ConvertInt32(funid, 0));
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
        /// 新增
        /// </summary>
        private void Add()
        {
            ZHY.Model.Function model = new ZHY.Model.Function();
            model.FunCode = this.txtFunCode.Text;
            model.FunName = this.txtFunName.Text;
            model.FunPage = this.txtFunPage.Text;
            model.FunDes = this.txtFunDes.Text;

            ZHY.BLL.Function bll = new ZHY.BLL.Function();
            bll.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="LMID"></param>
        private void Modify(int ID)
        {
            ZHY.Model.Function model = new ZHY.Model.Function();
            model.FunID = ID;
            model.FunCode = this.txtFunCode.Text;
            model.FunName = this.txtFunName.Text;
            model.FunPage = this.txtFunPage.Text;
            model.FunDes = this.txtFunDes.Text;
            ZHY.BLL.Function bll = new ZHY.BLL.Function();
            bll.Update(model);
        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
        {
            this.hfFunID.Value="0";
			this.txtFunCode.Text="";
			this.txtFunName.Text="";
			this.txtFunPage.Text="";
            this.txtFunDes.Text = "";
        }

        /// <summary>
        /// 初始化数据控件
        /// </summary>
        private void InitData(int FunID)
        {
            ZHY.BLL.Function bll = new ZHY.BLL.Function();
            ZHY.Model.Function model = bll.GetModel(FunID);
            this.hfFunID.Value = model.FunID.ToString();
            this.txtFunCode.Text = model.FunCode;
            this.txtFunName.Text = model.FunName;
            this.txtFunPage.Text = model.FunPage;
            this.txtFunDes.Text = model.FunDes;
        }
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
