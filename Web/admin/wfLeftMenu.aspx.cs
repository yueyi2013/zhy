using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Model;
using AjaxControlToolkit;

namespace ZHY.Web.admin
{
    public partial class wfLeftMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    DisplayMenu();

                }
            }           
        }

        /// <summary>
        /// 绑定子菜单
        /// </summary>
        /// <param name="MenuID"></param>
        /// <param name="dt"></param>
        /// <param name="ap"></param>
        private void BindChildMenu(string MenuID, DataTable dt, AccordionPane ap)
        {
            DataRow[] dr = dt.Select("ParantID=" + MenuID);
            //循环将父级菜单添加到Accordion控件的标题中
            for (int i = 0; i < dr.Length; i++)
            {
                HtmlGenericControl hgc = new HtmlGenericControl("div");
                hgc.Style.Add("vertical-align", "middle");
                hgc.Style.Add("text-align", "center");
                hgc.Style.Add("height", "80px");
                Image imghead = new Image();
                imghead.Style.Add("margin-top", "10px");
                imghead.ImageUrl = "~/images/MenuItem/"+dr[i]["MenuPicPath"].ToString();
                Label lblChildMenu = new Label();
                string url = ResolveUrl(dr[i]["FunPage"].ToString());

                hgc.Attributes.Add("onclick", "javascript:top.window.frames['mainFrame'].document.location.href='" + url + "';");
                lblChildMenu.Text = "<br/><a  href=" + url + " target='mainFrame'>" + dr[i]["MenuName"] + "</a>";//指定Text属性为子菜单名

                hgc.Controls.Add(imghead);
                hgc.Controls.Add(lblChildMenu);
                hgc.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#9FDF4C'");
                hgc.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
                ap.ContentContainer.Controls.Add(hgc);
            } 
        }

        /// <summary>
        /// 右侧菜单绑定
        /// </summary>
        private void DisplayMenu()
        {
            User user = (User)Session["User"];
            ZHY.BLL.Menu bll = new ZHY.BLL.Menu();
            DataTable dtP = bll.GetList("ParantID=0 order by MenuOrder").Tables[0];
            DataTable dt = bll.GetList(user.RoleID.Value);
            //循环将父级菜单添加到Accordion控件的标题中

            foreach (DataRow dr in dtP.Rows)
            {
                AccordionPane ap = new AccordionPane(); //实例化一个AccordionPane 控件
                Label lblParentMenu = new Label();
                lblParentMenu.Text = dr["MenuName"].ToString();//指定标签的Text属性为父菜单名
                lblParentMenu.Style.Add("cursor", "hand");
                lblParentMenu.Style.Add("vertical-align", "bottom");
                lblParentMenu.Style.Add("text-align", "left");
                lblParentMenu.Style.Add("margin-left", "35px");
                lblParentMenu.Style.Add("margin-top", "100px");
                lblParentMenu.Style.Add("font-size", "larger");
                ap.HeaderContainer.Controls.Add(lblParentMenu); //将标签控件添加到AccordionPane标题部分
                BindChildMenu(dr["MenuID"].ToString(), dt, ap);
                adMenu.Panes.Add(ap);
            }
        }
    }
}
