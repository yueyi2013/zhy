using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZHY.Web.admin
{
    public partial class wfProductList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!Page.IsPostBack)
            {
                MstGridViewBind();
                BindProType();
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
        /// 绑定类型
        /// </summary>
        private void BindProType()
        {
            ZHY.BLL.ProType bll = new ZHY.BLL.ProType();
            this.ddlProType.DataSource = bll.GetAllList();
            this.ddlProType.DataBind();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected override void MstGridViewBind()
        {
            ZHY.BLL.Product bll = new ZHY.BLL.Product();
            this.MstGridView.DataSource = bll.GetList(pageIndex, this.txtName.Text, ref pageRecord);
            this.MstGridView.DataBind();
            base.MstGridViewBind();
        }

        /// <summary>
        /// 行样式绑定
        /// <summary>
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
        /// 数据行命令触发
        /// </summary>
        protected void MstGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			string name = e.CommandName;
			string arg = e.CommandArgument.ToString();
			if (name.Equals("view"))
			{
                Response.Redirect("");

			}else if(name.Equals("del")){

			}
            else if (name.Equals("pic"))
            {
                MessageBox.ResponseWrite(this.MyUpdatePanelBody, this.GetType(), "window.document.location.href=wfImageEdit.aspx?proID=" + arg);
            }
            else if (name.Equals("pam"))
            {
                Response.Redirect("wfCarInput.aspx?proID=" + arg);
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
            int proid = 0;
            if (proid == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(proid);
            }
            MessageBox.SelfInform(this.MyUpdatePanelPanelBody, this.GetType(), "保存成功！");
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
                string proId = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    ZHY.BLL.Function bll = new ZHY.BLL.Function();
                    bll.Delete(ConvertInt32(proId, 0));
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
                string proId = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    InitData(ConvertInt32(proId, 0));
                    this.mpMstAdd.Show();
                    btnModify.Enabled = true;
                    hfProID.Value = proId;
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
            ZHY.Model.Product model = new ZHY.Model.Product();
            model.ProCode = this.txtProCode.Text;
            model.ProTypeID = ConvertInt32(this.ddlProType.SelectedValue,0);
            model.ProName = this.txtProName.Text;
            model.ProDes = this.txtProDes.Text;
            model.ProPrice = decimal.Parse(this.txtProPrice.Text);
            model.ProInputDate = DateTime.Now;
            if (this.rblPublish.SelectedValue == "2")
            {
                model.ProPublish = ConvertDateTime(this.txtProPublish.Value, DateTime.MaxValue);
            }
            else
            {
                model.ProPublish = DateTime.Now;
            }
            model.ProStatus = "2";
            model.ProRecommend = this.rblProRecommend.SelectedValue;
            model.ProIsNew = this.rblProIsNew.SelectedValue;
            model.ProIsHot = this.rblProIsHot.SelectedValue;

            ZHY.BLL.Product bll = new ZHY.BLL.Product();
            bll.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="LMID"></param>
        private void Modify(int ID)
        {
            ZHY.Model.Product model = new ZHY.Model.Product();
            model.ProID = ConvertDecimal(this.txtProID.Text,0);
            model.ProCode = this.txtProCode.Text;
            model.ProTypeID = ConvertInt32(this.ddlProType.SelectedValue,0);
            model.ProName = this.txtProName.Text;
            model.ProDes = this.txtProDes.Text;
            model.ProPrice = ConvertDecimal(this.txtProPrice.Text,0);
            if (this.rblPublish.SelectedValue == "2")
            {
                model.ProPublish = ConvertDateTime(this.txtProPublish.Value, DateTime.MaxValue);
            }
            else {
                model.ProPublish = DateTime.Now;
            }
            model.ProStatus = "2";
            model.ProRecommend = this.rblProRecommend.SelectedValue;
            model.ProIsNew = this.rblProIsNew.SelectedValue;
            model.ProIsHot = this.rblProIsHot.SelectedValue;

            ZHY.BLL.Product bll = new ZHY.BLL.Product();
            bll.Update(model);
        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
        {
            //this.txtProID.Text="";
			this.txtProCode.Text="";
			this.txtProName.Text="";
			this.txtProDes.Text="";
			this.txtProPrice.Text="";
			//this.txtProInputDate.Value="";
			this.txtProPublish.Value=DateTime.Now.ToLongDateString();
			this.rblProRecommend.SelectedValue="2";
			this.rblProIsNew.SelectedValue="1";
			this.rblProIsHot.SelectedValue="2";
        }

        /// <summary>
        /// 初始化数据控件
        /// </summary>
        private void InitData(decimal proId)
        {
            ZHY.BLL.Product bll = new ZHY.BLL.Product();
            ZHY.Model.Product model = new ZHY.Model.Product();
            model = bll.GetModel(proId);
            this.txtProCode.Text = model.ProCode;
            this.txtProName.Text = model.ProName;
            this.txtProDes.Text = model.ProDes;
            this.txtProPrice.Text = model.ProPrice.Value.ToString();
            this.txtProPublish.Value = DateTime.Now.ToLongDateString();
            this.rblProRecommend.SelectedValue = model.ProRecommend;
            this.rblProIsNew.SelectedValue = model.ProIsNew;
            this.rblProIsHot.SelectedValue = model.ProIsHot;
        }

        /// <summary>
        /// 绑定参数页面
        /// </summary>
        /// <returns></returns>
        protected string GetPamURL()
        {
            return "wfCarInput.aspx?proID=" + hfProID.Value;
        }

        /// <summary>
        /// 绑定参数页面
        /// </summary>
        /// <returns></returns>
        protected string GetPamURL0()
        {
            return "wfUpSmallPic.aspx?proID=" + hfProID.Value;
        }

        protected void btnEditPic_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                string proId = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    hfProID.Value = proId;
                }
            }
            mpeUploadPic.Show();
        }

        ///// <summary>
        ///// 绑定图片页面
        ///// </summary>
        ///// <returns></returns>
        //protected string GetImgURL()
        //{
        //    return "wfImageEdit.aspx?proID=" + hfImg.Value;
        //}
        #endregion
    }
}
