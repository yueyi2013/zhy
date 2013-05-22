using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ZHY.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCarInfo();
                BindCarRecom();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindCarInfo();
        }

        /// <summary>
        /// 绑定汽车列表
        /// </summary>
        private void BindCarInfo()
        {
            ZHY.BLL.Product bll = new ZHY.BLL.Product();
            this.dlCarList.DataSource = bll.GetList(30, "ProStatus=2", "ProInputDate");
            this.dlCarList.DataBind();
        }

        /// <summary>
        /// 绑定推荐车型
        /// </summary>
        private void BindCarRecom() 
        {
            ZHY.BLL.Product bll = new ZHY.BLL.Product();
            dlCarList0.DataSource = bll.GetList(20, "ProStatus=2 and ProRecommend = 1", "ProInputDate");
            dlCarList0.DataBind();
        }

        protected string GetPicURL(string url)
        {
            if (string.IsNullOrEmpty(url))
                return "../upload/product/SmallPic/default.jpg";
            return "../upload/product/SmallPic/" + url;
        }
    }
}
