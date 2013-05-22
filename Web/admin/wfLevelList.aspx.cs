using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfLevelList : BasePage
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

        #region 按钮操作
        /// <summary>
        /// 查询操作
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MstGridViewBind();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int levelid = 0;
            if (levelid == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(levelid);
            }
            MessageBox.SelfInform(this.MyUpdatePanelBody, this.GetType(), "保存成功！");
            MstGridViewBind();

        }

        /// <summary>
        /// 删除操作
        /// </summary>
        protected void btnDelete_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow gvr in MstGridView.Rows)
			{
				string levelid = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
				 CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
				if (chk.Checked)
				{
					ZHY.BLL.Level bll=new ZHY.BLL.Level();
					bll.Delete(ConvertInt32(levelid,0));
				}

			}
			MstGridViewBind();
		}

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="LevelID"></param>
        private void ShowInfo(int LevelID)
        {
            ZHY.BLL.Level bll = new ZHY.BLL.Level();
            ZHY.Model.Level model = bll.GetModel(LevelID);
            this.txtLevelID.Text = model.LevelID.ToString();
            this.txtLevelName.Text = model.LevelName;

        }

        /// <summary>
        /// 修改
        /// <summary>
        protected void btnModify_Click(object sender, EventArgs e)
		 {
            //string levelid = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
            //     CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
            //    if (chk.Checked)
            //    {
            //        InitData( Sysfun.ConvertToInt32(levelid,0););
            //        this.mpMstAdd.Show();
            //        btnModify.Enabled = true;
            //    }

		 }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="levelid"></param>
        public void Modify(int levelid)
        {

            ZHY.Model.Level model = new ZHY.Model.Level();
            model.LevelID = ConvertInt32(this.txtLevelID.Text,0);
            model.LevelName = this.txtLevelName.Text;

            ZHY.BLL.Level bll = new ZHY.BLL.Level();
            bll.Update(model);
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void Add()
        {
            ZHY.Model.Level model = new ZHY.Model.Level();
            model.LevelName = this.txtLevelName.Text;

            ZHY.BLL.Level bll = new ZHY.BLL.Level();
            bll.Add(model);

        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
		{
			//this.txtLevelID.Text="";
            this.txtLevelName.Text = "";

		}

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {

        }

    }
}
