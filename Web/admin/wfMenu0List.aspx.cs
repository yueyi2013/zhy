using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfMenu0List : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTreeMenu();
                BindFun();
            }
        }

        /// <summary>
        /// 绑定父节点
        /// </summary>
        private void BindTreeMenu()
        {
            ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
            DataTable dt = bll.GetAllList().Tables[0];
            DataRow[] dr = dt.Select("ParantID=0");
            DataRow[] drChild = null;
            for (int i = 0; i < dr.Length;i++ )
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr[i]["MenuName"].ToString();
                tn.Value = dr[i]["MenuID"].ToString();
                drChild = dt.Select("ParantID=" + tn.Value);
                BindChildMenu(tn,drChild);
                this.tvMenu.Nodes.Add(tn);
            }
        }

        /// <summary>
        /// 绑定子节点
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="drChild"></param>
        private void BindChildMenu(TreeNode tn,DataRow[] drChild) 
        {
            for(int i=0;i<drChild.Length;i++)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = drChild[i]["MenuName"].ToString();
                tnChild.Value = drChild[i]["MenuID"].ToString();
                tn.ChildNodes.Add(tnChild);
            }
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
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            initData();
        }

        /// <summary>
        /// 修改菜单栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModify_Click(object sender, EventArgs e)
        {
            ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
            ZHY.Model.Menu model = new ZHY.Model.Menu();
            model.MenuName = this.txtMenuName.Text.Trim();
            int menuId = ConvertInt32(this.txtMenuID.Text, 0);
            if (this.ddlMenuType.SelectedValue == "0")
            {
                model.ParantID = 0;
            }
            else
            {                
                model.ParantID = ConvertInt32(this.txtMenuID.Text, 0);
            }
            model.MenuID = ConvertInt32(this.txtMenuID.Text,0);
            model.MenuOrder = ConvertInt32(this.txtMenuOrder.Text,0);
            model.MenuPicPath = this.txtMenuPicPath.Text;
            model.MenuDes = this.txtMenuDes.Text;
            model.FunID = ConvertInt32(this.ddlFun.SelectedValue,0);
            if (this.hfOp.Value == "1")
                bll.Add(model);
            else {
                ZHY.Model.Menu pModel = bll.GetModel(menuId);
                model.ParantID = pModel.ParantID;
                bll.Update(model);
            }
                
            MessageBox.SelfInform(this.upMenu, this.GetType(), "保存成功！");
        }

        /// <summary>
        /// 删除菜单栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
            bll.Delete(ConvertInt32(this.txtMenuID.Text,0));
        }

        /// <summary>
        /// 树节点点击时改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvMenu_OnSelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.tvMenu.SelectedNode.Parent == null)
            {
                //this.ddlFun.Enabled = false;
                this.ddlMenuType.SelectedValue = "0";
            }
            else {
                //this.ddlFun.Enabled = true;
                this.txtMenuOrder.Enabled = true;
                this.ddlMenuType.SelectedValue = "1";
            }
            ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
            ZHY.Model.Menu model = bll.GetModel(ConvertInt32(this.tvMenu.SelectedNode.Value, 0));
            this.txtMenuName.Text = model.MenuName;
            this.txtMenuID.Text = model.MenuID.ToString();
            this.txtMenuOrder.Text = model.MenuOrder.ToString();
            this.txtMenuDes.Text = model.MenuDes;
            this.txtMenuPicPath.Text = model.MenuPicPath;
            this.txtParantID.Text = model.ParantID.Value.ToString();
            if (!this.txtParantID.Text.Equals("0"))
            {
                this.btnAdd.Enabled = false;
            }
            else {
                this.btnAdd.Enabled = true;
            
            }
        }

        /// <summary>
        /// 初始化录入数据
        /// </summary>
        private void initData() {
            string menuId = this.txtMenuID.Text;
            string parantId = this.txtParantID.Text;
            this.txtMenuName.Text = "";
            this.txtMenuDes.Text = "";
            this.txtMenuOrder.Text = "";
            this.hfOp.Value = "1";
            this.txtMenuID.Text = menuId;
            this.txtParantID.Text = parantId;
            if (!this.txtParantID.Text.Equals("0"))
            {
                this.ddlMenuType.SelectedItem.Value = "1";                
                this.ddlMenuType.Enabled = false;
            }
            else {
                this.ddlMenuType.SelectedItem.Value = "0";
                this.ddlMenuType.Enabled = true;                
            }
        }
    }
}
