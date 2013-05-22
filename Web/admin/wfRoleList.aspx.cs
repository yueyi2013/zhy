using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfRoleList : BasePage
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
            ZHY.BLL.Role bll = new ZHY.BLL.Role();
            this.MstGridView.DataSource = bll.GetAllList();
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
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int roleid = 0;
            if (roleid == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(roleid);
            }
            MessageBox.SelfInform(this.MyUpdatePanelRole, this.GetType(), "保存成功！");
            MstGridViewBind();
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void Add()
        {
            ZHY.Model.Role model = new ZHY.Model.Role();
            model.RoleName = this.txtRoleName.Text;
            model.RoleDes = this.txtRoleDes.Text;
            ZHY.BLL.Role bll = new ZHY.BLL.Role();
            bll.Add(model);
        }

        /// <summary>
        /// 新增操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                string roleid = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    ZHY.BLL.Role bll = new ZHY.BLL.Role();
                    bll.Delete(ConvertInt32(roleid, 0));
                }

            }
            MstGridViewBind();
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="RoleID"></param>
        private void ShowInfo(int RoleID)
        {
            ZHY.BLL.Role bll = new ZHY.BLL.Role();
            ZHY.Model.Role model = bll.GetModel(RoleID);
            this.txtRoleID.Text = model.RoleID.ToString();
            this.txtRoleName.Text = model.RoleName;
            this.txtRoleDes.Text = model.RoleDes;
        }

        /// <summary>
        /// 修改
        /// <summary>
        protected void btnModify_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <param name="roleid"></param>
        public void Modify(int roleid)
        {
            ZHY.Model.Role model = new ZHY.Model.Role();
            model.RoleID = ConvertInt32(this.txtRoleID.Text, 0);
            model.RoleName = this.txtRoleName.Text;
            model.RoleDes = this.txtRoleDes.Text;

            ZHY.BLL.Role bll = new ZHY.BLL.Role();
            bll.Update(model);
        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
        {
            this.txtRoleID.Text = "";
            this.txtRoleName.Text = "";
            this.txtRoleDes.Text = "";
        }
        #endregion

    }
}
