using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZHY.Web;
using System.Data;

namespace Web.admin.sys
{
    public partial class wfRightList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindRoleList();
                BindFunList();
            }
        }

        /// <summary>
        /// 帮点功能列表
        /// </summary>
        private void BindFunList()
        {
            ZHY.BLL.Function bll = new ZHY.BLL.Function();
            this.chkFunlist.DataSource = bll.GetAllList();
            this.chkFunlist.DataBind(); 
        }
        
        /// <summary>
        /// 绑定角色列表
        /// </summary>
        private void BindRoleList() {
            ZHY.BLL.Role bll = new ZHY.BLL.Role();
            this.rbRoleList.DataSource = bll.GetAllList();
            this.rbRoleList.DataBind();        
        }

        /// <summary>
        ///  保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int roleId = ConvertInt32(this.hfRoleId.Value, 0);
            ZHY.BLL.RightConfig bll = new ZHY.BLL.RightConfig();
            bll.DeleteByRoleId(roleId);
            string userName = getLoginUser().UserName;
            foreach (ListItem li in this.chkFunlist.Items)
            {
                ZHY.Model.RightConfig model = new ZHY.Model.RightConfig();
                model.FunID = int.Parse(li.Value);
                model.RoleID = int.Parse(this.hfRoleId.Value);
                model.UpdateBy = userName;
                model.UpdateDT = DateTime.Now;
                model.CreateAt = DateTime.Now;
                model.CreateBy = userName;
                bll.Add(model);
            }
            SelfInform(this.MyUpdatePanelBody, this.GetType(), "保存成功！");
        }

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


        protected void rbRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hfRoleId.Value = this.rbRoleList.SelectedItem.Value;
            ZHY.BLL.RightConfig bll = new ZHY.BLL.RightConfig();
            DataSet ds = bll.GetList(" RoleID = "+this.hfRoleId.Value);
            foreach (ListItem li in this.chkFunlist.Items)
            {
                li.Selected = false;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (li.Value.Equals(dr["FunID"].ToString()))
                    {
                        li.Selected = true;
                        break;
                    }
                }
            }
        }
    }
}