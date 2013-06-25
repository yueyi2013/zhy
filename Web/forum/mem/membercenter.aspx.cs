using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.forum
{
    public partial class membercenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["MemUser"] == null || string.IsNullOrEmpty(Session["MemUser"].ToString()))
                {
                    Response.Redirect("~/forum/memberlogin.aspx");
                }
                else {
                    BindMemberMenuList();
                    BindMember();
                    this.divPsnInfo.Visible = true;
                    this.divArtical.Visible = false;
                    this.divArticalCat.Visible = false;
                }
            }
        }

        /// <summary>
        /// 绑定会员菜单栏
        /// </summary>
        private void BindMemberMenuList()
        {
            ZHY.BLL.MemberMenu bll = new ZHY.BLL.MemberMenu();
            this.blNav.DataSource = bll.GetList("MMStatus='A'", "MMOrder");
            this.blNav.DataBind();
        }

        private void BindMember() 
        {
            ZHY.Model.Member model = (ZHY.Model.Member)Session["MemUser"];
            if(model!=null)
            {
                this.lblAccount.Text = model.MemAccount;
                this.lblMemMail.Text = model.MemMail;
                this.lblLevel.Text = model.PsnLevelId.ToString() + "级";
                this.lblMemStatus.Text = model.MemStatus.Equals("A") ? "正常" : "不正常";    
            }        
        }

        /// <summary>
        /// 左侧菜单栏触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void blNav_Click(object sender, BulletedListEventArgs e)
        {
            string str = this.blNav.Items[e.Index].Text;
            switch (str)
            {
                case "个人信息":
                    this.divPsnInfo.Visible = true;
                    this.divArtical.Visible = false;
                    this.divArticalCat.Visible = false;
                    break;
                case "文章管理":
                    this.divPsnInfo.Visible = false;
                    this.divArtical.Visible = true;
                    this.divArticalCat.Visible = false;
                    break;
                case "类别管理":
                    this.divPsnInfo.Visible = false;
                    this.divArtical.Visible = false;
                    this.divArticalCat.Visible = true;
                    break;
            }
        }

        private void BindArList(string memId)
        {
            ZHY.BLL.Article bll = new ZHY.BLL.Article();
            this.gvArticalCat.DataSource = bll.GetList(" UpdateBy = '" + memId + "'");
            this.gvArticalCat.DataBind();
        }

        /// <summary>
        /// 绑定文章分类列表GV
        /// </summary>
        /// <param name="memId"></param>
        private void BindArCatDG(string memId) 
        {
            ZHY.BLL.ArticleCategory bll = new ZHY.BLL.ArticleCategory();
            this.gvArticalCat.DataSource = bll.GetList(" UpdateBy = '" + memId + "'");
            this.gvArticalCat.DataBind();
        }

        /// <summary>
        /// 绑定分类DDL
        /// </summary>
        /// <param name="memId"></param>
        private void BindArCatDDl(string memId)
        {
            ZHY.BLL.ArticleCategory bll = new ZHY.BLL.ArticleCategory();
            this.ddlCategory.DataSource = bll.GetList(" UpdateBy = '" + memId + "'");
            this.ddlCategory.DataBind();
        }

        /// <summary>
        /// 绑定文章类型
        /// </summary>
        private void BindArType()
        {
            ZHY.BLL.ArticalType bll = new ZHY.BLL.ArticalType();
            this.ddlType.DataSource = bll.GetList("");
            this.ddlType.DataBind();
        }

    }
}