using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.template.syihy_1
{
    public partial class tmpl : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               if (Session["MemUser"] != null)
                {
                    ZHY.Model.Member model = (ZHY.Model.Member)Session["MemUser"];
                    this.hlLogin.Visible = true;
                    this.hlLogin.Text = model.MemAccount;
                    this.hlLogin.ForeColor = System.Drawing.Color.Red;
                    this.hlLogin.NavigateUrl = "~/forum/member/membercenter.aspx";
                    this.lbExit.Visible = true;
                }
                else {
                    this.lbExit.Visible = false;
                    this.hlLogin.Visible = true;
                    this.hlLogin.Text = "登录";
                    this.hlLogin.ForeColor = System.Drawing.Color.Black;
                    this.hlLogin.NavigateUrl = "~/forum/memberlogin.aspx";                
                }
                //BindNavigation();
                BindNavHtmlCode(Request.Path);
            }
        }

        private void BindFriendLink()
        {
            ZHY.BLL.FriendLink bll = new ZHY.BLL.FriendLink();
            this.dlFriendLink.DataSource = bll.GetList(12,"","");
            this.dlFriendLink.DataBind();
        }

        private void BindNavHtmlCode(string path) 
        {
            ZHY.BLL.Navigation bll = new ZHY.BLL.Navigation();
            divNav.InnerHtml = bll.genereateHTMLCodeGreen(path);
        }        

        /// <summary>
        /// 绑定菜单
        /// </summary>
        private void BindNavigation()
        {
            ZHY.BLL.Navigation bll = new ZHY.BLL.Navigation();
            DataSet ds = bll.GetAllList();
            DataRow[] dr1 = ds.Tables[0].Select("NavStatus='A' and NavParantId=0");
            string lmId = "";
            string lmName = "";
            int i = 0;
            foreach (DataRow d1 in dr1)
            {
                lmId = d1["NavId"].ToString();
                lmName = d1["NavName"].ToString();
                MenuItem fatherMenuItem = CreateMenuItem(lmId, lmName);
                if(i==0)
                {
                    fatherMenuItem.Selected = true;
                    i++;
                }
                CreateChildMenuItem(lmId, ds, fatherMenuItem);
                this.muNavigation.Items.Add(fatherMenuItem);
            }
        }

        /// <summary>
        /// 创建菜单项
        /// </summary>
        /// <param name="lmId">栏目编号</param>
        /// <param name="lmName">栏目名称</param>
        /// <returns></returns>
        private MenuItem CreateMenuItem(string lmId, string lmName)
        {
            MenuItem objMenuItem = new MenuItem();
            objMenuItem.Text = lmName;
            objMenuItem.Value = lmId;
            //objMenuItem.NavigateUrl = "../LanMu/wfLanMuList.aspx?lmId=" + lmId;
            //objMenuItem.Target = "_parent";
            return objMenuItem;
        }

        /// <summary>
        /// 创建子菜单
        /// </summary>
        /// <param name="lmId">栏目编号</param>
        /// <param name="ds">数据集合</param>
        /// <param name="fatherMenuItem">父菜单项</param>
        private void CreateChildMenuItem(string lmId, DataSet ds, MenuItem fatherMenuItem)
        {
            DataRow[] dr2 = ds.Tables[0].Select("NavStatus='A' and NavParantId=" + lmId);
            string childlmId = "";
            string childlmName = "";
            foreach (DataRow d2 in dr2)
            {
                childlmId = d2["NavId"].ToString();
                childlmName = d2["NavName"].ToString();
                MenuItem childMenuItem = CreateMenuItem(childlmId, childlmName);
                CreateChildMenuItem(childlmId, ds, childMenuItem);
                fatherMenuItem.ChildItems.Add(childMenuItem);
            }
        }

        protected void lbExit_Click(object sender, EventArgs e)
        {
            if (Session["MemUser"] != null)
                Session["MemUser"] = null;
            this.lbExit.Visible = false;
            this.hlLogin.Visible = true;
            this.hlLogin.Text = "登录";
            this.hlLogin.ForeColor = System.Drawing.Color.Black;
            this.hlLogin.NavigateUrl = "~/forum/memberlogin.aspx";
        }
    }
}