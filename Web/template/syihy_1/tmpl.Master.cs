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
                //BindNavigation();
                BindNavHtmlCode();
            }
        }

        private void BindNavHtmlCode() 
        {
            ZHY.BLL.Navigation bll = new ZHY.BLL.Navigation();
            divNav.InnerHtml = bll.genereateHTMLCodeGreen();
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
    }
}