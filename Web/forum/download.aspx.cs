using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;

namespace Web.forum
{
    public partial class download : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!IsPostBack)
            {
                BindAdCategory();
                MstDataListBind();
            }
        }

        protected override void MstDataListBind() 
        {
            ZHY.BLL.Advertisement bll = new ZHY.BLL.Advertisement();
            int adId = int.Parse(this.hfAdID.Value);
            this.dlAdFeeds.DataSource = bll.GetList(pageIndex, "",adId, ref pageRecord);
            this.dlAdFeeds.DataBind();
            base.MstDataListBind();
        }

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
            base.pageIndexType = 1;
            base.BindPageControls();
        }

        /// <summary>
        /// 绑定分类
        /// </summary>
        private void BindAdCategory() 
        {
            ZHY.BLL.AdCategory bll = new ZHY.BLL.AdCategory();
            this.rbAdCat.DataSource = bll.GetList("Status = 'A'");
            this.rbAdCat.DataBind();
        }

        /// <summary>
        /// 搜索结果显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rbAdCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hfAdID.Value = this.rbAdCat.SelectedItem.Value;
            MstDataListBind();
        }
    }
}