using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfMemberList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!Page.IsPostBack)
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
			if (name.Equals("add"))
			{

			}else if(name.Equals("del")){

			}else if(name.Equals("mod")){

			}
		}
        #endregion

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
        /// 新增
        /// </summary>
        private void Add()
        {
            ZHY.Model.Member model = new ZHY.Model.Member();
            model.MemAccount = this.txtMemAccount.Text;
            //model.MemPsw = this.txtMemPsw.Text;
            //model.LevelID = Sysfun.ConvertToInt32(this.txtLevelID.Text);
            model.MemRealName = this.txtMemRealName.Text;
            model.MemMobile = this.txtMemMobile.Text;
            model.MemShotNum = this.txtMemShotNum.Text;
            model.MemUnitTel = this.txtMemUnitTel.Text;
            model.MemMedium = this.txtMemMedium.Text;
            model.MemStatus = this.txtMemStatus.Text;

            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            bll.Add(model);

        }

        protected void btnModify_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  关闭
        /// </summary>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.mpMstAdd.Hide();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int memid = 0;
            if (memid == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(memid);
            }
            MessageBox.SelfInform(this.MyUpdatePanelPanelBody, this.GetType(), "保存成功！");
            MstGridViewBind();

        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
		{
			//this.txtMemID.Text="";
			this.txtMemAccount.Text="";
			//this.txtMemPsw.Text="";
			this.txtLevelID.Text="";
			this.txtMemRealName.Text="";
			this.txtMemMobile.Text="";
			this.txtMemShotNum.Text="";
			this.txtMemUnitTel.Text="";
			this.txtMemMedium.Text="";
            this.txtMemStatus.Text = "";

		}

        public void Modify(float memid)
        {

            ZHY.Model.Member model = new ZHY.Model.Member();
            //model.MemID = ConvertDecimal(this.txtMemID.Text,0);
            model.MemAccount = this.txtMemAccount.Text;
            //model.MemPsw = this.txtMemPsw.Text;
            //model.LevelID = ConvertToInt32(this.txtLevelID.Text);
            model.MemRealName = this.txtMemRealName.Text;
            model.MemMobile = this.txtMemMobile.Text;
            model.MemShotNum = this.txtMemShotNum.Text;
            model.MemUnitTel = this.txtMemUnitTel.Text;
            model.MemMedium = this.txtMemMedium.Text;
            model.MemStatus = this.txtMemStatus.Text;

            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            bll.Update(model);
        }
    }
}
