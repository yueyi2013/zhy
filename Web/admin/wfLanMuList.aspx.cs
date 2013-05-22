using System;
using System.IO;
using System.Data;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ZHY.Web.admin
{
    public partial class wfLanMuList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!IsPostBack)
            {
                MstGridViewBind();
                BindTreeView();
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
            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            string lmName = this.txtLanMuName.Text;
            this.MstGridView.DataSource = bll.GetList(pageIndex, lmName, this.hfLMID.Value, ref pageRecord);
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
            string lmId0 = e.CommandName;
            string lmId = e.CommandArgument.ToString();
            ZHY.Model.LanMu model = new ZHY.Model.LanMu();
            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            model = bll.GetModel(ConvertInt32(lmId, 0));
            if (lmId0.Equals("add"))
            {
                //this.lbLMName.Text = model.LMName;
                //this.lblPLMId.Text = lmId;
                this.mpMstAdd.Show();
            }
            else if (lmId0.Equals("del"))
            {
                bll.Delete(ConvertInt32(lmId, 0));
                MstGridViewBind();
                BindTreeView();
            }
        }
        #endregion

        #region 绑定TreeView
        protected override void BindTreeView()
        {
            this.tvList = this.tvLanMu;
            base.BindTreeView();
        }

        protected void tvLanMu_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.hfLMID.Value = this.tvLanMu.SelectedNode.Value;
            MstGridViewBind();
        }
        #endregion

        #region 按钮操作
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLanMuName_Click(object sender, EventArgs e)
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
            int LMID = ConvertInt32(this.txtLMID.Text, 0);
            if (LMID == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(LMID);
            }
            MessageBox.SelfInform(this.MyUpdatePanelPanelBody, this.GetType(), "保存成功！");
            MstGridViewBind();
            BindTreeView();
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                string LMID = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chkLoginLog = (CheckBox)gvr.FindControl("chkItem");
                if (chkLoginLog.Checked)
                {
                    bll.Delete(ConvertInt32(LMID, 0));
                }
            }
            MstGridViewBind();
            BindTreeView();
        }

        /// <summary>
        /// 修改按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModify_Click(object sender, EventArgs e)
        {
            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                string LMID = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chkItem = (CheckBox)gvr.FindControl("chkItem");
                if (chkItem.Checked)
                {
                    ShowInfo(ConvertInt32(LMID, 0));
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
            ZHY.Model.LanMu model = new ZHY.Model.LanMu();
            model.ParantID = ConvertInt32(this.txtParantID.Text,0);
            model.LMCode = this.txtLMCode.Text;
            model.LMOrder = ConvertInt32(this.txtLMOrder.Text, 0);
            model.LMName = this.txtLMName.Text;
            model.LMStyleID = ConvertInt32(this.txtLMStyleID.Text,0);
            model.LMPage = this.txtLMPage.Text;
            model.LMStatus = this.txtLMStatus.Text;
            model.LMDes = this.txtLMDes.Text;

            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            bll.Add(model);
        }

        public void Modify(int lmid)
        {

            ZHY.Model.LanMu model = new ZHY.Model.LanMu();
            model.LMID = lmid;
            model.LMCode = this.txtLMCode.Text;
            model.LMOrder = ConvertInt32(this.txtLMOrder.Text, 0);
            model.ParantID = ConvertInt32(this.txtParantID.Text,0);
            model.LMName = this.txtLMName.Text;
            model.LMStyleID = ConvertInt32(this.txtLMStyleID.Text,0);
            model.LMPage = this.txtLMPage.Text;
            model.LMStatus = this.txtLMStatus.Text;
            model.LMDes = this.txtLMDes.Text;

            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            bll.Update(model);
        }



        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
        {
            //this.txtLMID.Text = "";
			this.txtLMCode.Text="";
			this.txtParantID.Text="";
			this.txtLMName.Text="";
			this.txtLMOrder.Text="";
			this.txtLMStyleID.Text="";
			this.txtLMPage.Text="";
			this.txtLMStatus.Text="";
			this.txtLMDes.Text="";
        }

        private void ShowInfo(int LMID)
        {
            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            ZHY.Model.LanMu model = bll.GetModel(LMID);
            //this.lblLMID.Text = model.LMID.ToString();
            this.txtLMCode.Text = model.LMCode;
            this.txtParantID.Text = model.ParantID.ToString();
            this.txtLMName.Text = model.LMName;
            this.txtLMOrder.Text = model.LMOrder.ToString();
            this.txtLMStyleID.Text = model.LMStyleID.ToString();
            this.txtLMPage.Text = model.LMPage;
            this.txtLMStatus.Text = model.LMStatus;
            this.txtLMDes.Text = model.LMDes;

        }

        #endregion
    }
}
