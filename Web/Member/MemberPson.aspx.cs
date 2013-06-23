using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Member
{
    public partial class MemberPson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 按钮操作
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["MemUser"] != null)
            {
                ZHY.Model.Member model = (ZHY.Model.Member)Session["MemUser"];
                Modify(model.MemID);
            }
        }

        /// <summary>
        ///  关闭
        /// </summary>
        protected void btnClose_Click(object sender, EventArgs e)
        {

            InitDataClear();
        }

        public void Modify(decimal memid)
        {

            ZHY.Model.Member model = new ZHY.Model.Member();
            // model.MemID = Sysfun.ConvertToDecimal(this.txtMemID.Text);
            model.MemAccount = this.txtMemAccount.Text;
            model.MemPsw = this.txtMemPsw.Text;
            //  model.LevelID = Sysfun.ConvertToInt32(this.txtLevelID.Text);
            
            // model.MemStatus = this.txtMemStatus.Text;

            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            bll.Update(model);
        }
        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
        {
            //this.txtMemID.Text="";
            this.txtMemAccount.Text = "";
            this.txtMemPsw.Text = "";
            //this.txtLevelID.Text="";
            this.txtMemRealName.Text = "";
            this.txtMemMobile.Text = "";
            this.txtMemShotNum.Text = "";
            this.txtMemUnitTel.Text = "";
            this.txtMemMedium.Text = "";
            //this.txtMemStatus.Text="";

        }

        #endregion
    }
}
