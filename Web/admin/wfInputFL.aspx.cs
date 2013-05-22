using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin
{
    public partial class wfInputFL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flid"></param>
        public void Modify(int flid)
        {
            ZHY.Model.FriendLink model = new ZHY.Model.FriendLink();
            // model.FLID = Sysfun.ConvertToInt32(this.txtFLID.Text);
            model.FLName = this.txtFLName.Text;
            model.FLSite = this.txtFLSite.Text;
            //model.FLPic = this.txtFLPic.Text;
            // model.FLOrder = Sysfun.ConvertToInt32(this.txtFLOrder.Text);
            //model.FLViewMethod = this.txtFLViewMethod.Text;
            model.FLDes = this.txtFLDes.Text;

            ZHY.BLL.FriendLink bll = new ZHY.BLL.FriendLink();
            bll.Update(model);
        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
        {
            //this.txtFLID.Text = "";
            this.txtFLName.Text = "";
            this.txtFLSite.Text = "";
           // this.txtFLPic.Text = "";
            this.txtFLOrder.Text = "";
            //this.txtFLViewMethod.Text = "";
            this.txtFLDes.Text = "";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FLID"></param>
        private void ShowInfo(int FLID)
        {
            ZHY.BLL.FriendLink bll = new ZHY.BLL.FriendLink();
            ZHY.Model.FriendLink model = bll.GetModel(FLID);
            //this.lblFLID.Text = model.FLID.ToString();
            this.txtFLName.Text = model.FLName;
            this.txtFLSite.Text = model.FLSite;
           // this.txtFLPic.Text = model.FLPic;
            //this.txtFLOrder.Text = model.FLOrder.ToString();
           // this.txtFLViewMethod.Text = model.FLViewMethod;
            this.txtFLDes.Text = model.FLDes;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

    }
}
