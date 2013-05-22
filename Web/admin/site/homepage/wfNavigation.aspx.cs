using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;
using System.Data;

namespace Web.admin.site.homepage
{
    public partial class wfNavigation : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTreeMenu();
            }
        }

        /// <summary>
        /// 绑定父节点
        /// </summary>
        private void BindTreeMenu()
        {
            ZHY.BLL.Navigation bll = new ZHY.BLL.Navigation();
            DataTable dt = bll.GetAllList().Tables[0];
            DataRow[] dr = dt.Select("NavParantId=0");
            DataRow[] drChild = null;
            for (int i = 0; i < dr.Length; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr[i]["NavName"].ToString();
                tn.Value = dr[i]["NavId"].ToString();
                drChild = dt.Select("ParantID=" + tn.Value);
                BindChildMenu(tn, drChild);
                this.tvMenu.Nodes.Add(tn);
            }
        }

        /// <summary>
        /// 绑定子节点
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="drChild"></param>
        private void BindChildMenu(TreeNode tn, DataRow[] drChild)
        {
            for (int i = 0; i < drChild.Length; i++)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = drChild[i]["NavName"].ToString();
                tnChild.Value = drChild[i]["NavId"].ToString();
                tn.ChildNodes.Add(tnChild);
            }
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
            ZHY.Model.Menu model = new ZHY.Model.Menu();
            model.MenuName = this.txtMenuName.Text.Trim();
            if (this.ddlMenuType.SelectedValue == "0")
            {
                model.ParantID = 0;
            }
            else
            {
                model.ParantID = ConvertInt32(this.txtMenuID.Text, 0);
            }
            model.MenuID = ConvertInt32(this.txtMenuID.Text, 0);
            model.MenuOrder = ConvertInt32(this.txtMenuOrder.Text, 0);
            model.MenuPicPath = this.txtMenuPicPath.Text;
            model.MenuDes = this.txtMenuDes.Text;
            model.FunID = ConvertInt32(this.ddlFun.SelectedValue, 0);
            ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
            if (this.hfOp.Value == "1")
                bll.Add(model);
            else
                bll.Update(model);
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
            bll.Delete(ConvertInt32(this.txtMenuID.Text, 0));
        }

        /// <summary>
        /// 树节点点击时改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvMenu_OnSelectedNodeChanged(object sender, EventArgs e)
        {
           
            ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
            ZHY.Model.Menu model = bll.GetModel(ConvertInt32(this.tvMenu.SelectedNode.Value, 0));
            this.txtMenuName.Text = model.MenuName;
            this.txtMenuID.Text = model.MenuID.ToString();
            this.txtMenuOrder.Text = model.MenuOrder.ToString();
            this.txtMenuDes.Text = model.MenuDes;
            this.txtMenuPicPath.Text = model.MenuPicPath;
            this.txtParantID.Text = model.ParantID.Value.ToString();
        }

        /// <summary>
        /// 初始化录入数据
        /// </summary>
        private void initData()
        {
            string menuId = this.txtMenuID.Text;
            string parantId = this.txtParantID.Text;
            this.txtMenuName.Text = "";
            this.txtMenuDes.Text = "";
            this.txtMenuOrder.Text = "";
            this.hfOp.Value = "1";
            this.txtMenuID.Text = menuId;
            this.txtParantID.Text = parantId;
        }

    }
}