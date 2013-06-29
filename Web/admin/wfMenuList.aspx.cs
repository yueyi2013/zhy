using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfMenuList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
             //   BindParantMenu();
                BindFun();
            }
        }

        #region 绑定DataGridView
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected override void BindPageControls()
        {
           
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

        #region 菜单绑定
        ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
        //private void BindParantMenu()
        //{
        //    this.MstGridView.DataSource = bll.GetList("ParantID=0");
        //    this.MstGridView.DataBind();
        //    if (this.MstGridView.Rows.Count > 0)
        //    {
        //        this.MstGridView.SelectedIndex = 0;
        //        BindChildMenu(this.MstGridView.SelectedDataKey["MenuID"].ToString());
        //        this.MstGridView.SelectedRow.Attributes.Add("style", "background-color:#F9E3AA");
        //    }
        //}

        /// <summary>
        /// 绑定子菜单
        /// </summary>
        /// <param name="menuID"></param>
        private void BindChildMenu(string menuID)
        {
            this.hfMenuID.Value = menuID;
            this.ItemGridView.DataSource = bll.GetList("ParantID=" + menuID);
            this.ItemGridView.DataBind();
        }

        protected void ddlParantMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChildMenu(this.ddlParantMenu.SelectedValue);
        }

        //protected void MstGridView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindChildMenu(this.MstGridView.SelectedDataKey["MenuID"].ToString()); ;
        //    this.MstGridView.SelectedRow.Attributes.Add("style", "background-color:#F9E3AA");
        //}

        private void BindMenu0() 
        {
            ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
            this.ddlParantMenu.DataSource = bll.GetList("ParantID=0");
            this.ddlParantMenu.DataBind();
        }

        /// <summary>
        /// 绑定功能
        /// </summary>
        private void BindFun() 
        {
            ZHY.BLL.Function bll = new ZHY.BLL.Function();
            this.ddlFun.DataSource = bll.GetAllList();
            this.ddlFun.DataBind();
        }

        /// <summary>
        /// 保存父菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ZHY.Model.Menu model = new ZHY.Model.Menu();
            model.MenuName = this.txtMenuName.Text;
            model.MenuDes = this.txtMenuDes.Text;
            model.MenuPicPath = null;
            model.ParantID = 0;
            model.MenuOrder = ConvertInt32(this.txtOrder0.Text,0);
            model.FunID = null;
           if (bll.Add(model) > 1)
                MessageBox.SelfInform(this.upParantMenuList, this.GetType(), "保存成功！");
            else
                MessageBox.SelfInform(this.upParantMenuList,this.GetType(),"保存失败！");
        }

        /// <summary>
        /// 保存子菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChildSave_Click(object sender, EventArgs e)
        {
            ZHY.Model.Menu model = new ZHY.Model.Menu();
            model.MenuName = this.txtMenuName.Text;
            model.MenuDes = this.txtMenuDes.Text;
            model.MenuPicPath = this.txtMenuPicPath.Text;
            model.ParantID = ConvertInt32(this.hfMenuID.Value,0);
            model.MenuOrder = ConvertInt32(this.txtMenuOrder.Text,0);
            model.FunID = ConvertInt32(this.ddlFun.SelectedValue,0);
            if (bll.Add(model) > 1)
                MessageBox.SelfInform(this.upChildMenuList, this.GetType(), "保存成功！");
            else
                MessageBox.SelfInform(this.upChildMenuList,this.GetType(),"保存失败！");
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
        /// 删除操作
        /// </summary>
        protected void btnDelete_Click(object sender, EventArgs e)
		{
           
			MstGridViewBind();
		}
        #endregion

       

    }
}
