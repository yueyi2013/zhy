using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;

namespace Web.Member
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 新增
        /// </summary>
        private int Add()
        {
            ZHY.Model.Member model = new ZHY.Model.Member();
            model.MemAccount = this.txtMemAccount.Text;
            model.MemPsw = this.txtMemPsw.Text;
            model.LevelID = 1;
            model.MemRealName = this.txtMemRealName.Text;
            model.MemMobile = this.txtMemMobile.Text;
            model.MemShotNum = this.txtMemShotNum.Text;
            model.MemUnitTel = this.txtMemUnitTel.Text;
            model.MemMedium = this.txtMemMedium.Text;
            model.MemStatus = "1";
            ZHY.BLL.Member bll = new ZHY.BLL.Member();
            return bll.Add(model);
        }

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSure_Click(object sender, EventArgs e)
        {
            if (Add() > 1)
            {
                MessageBox.SelfInform(upRegister, this.GetType(), "注册成功！");
                Response.Redirect("");
            }
            else {
                MessageBox.SelfInform(upRegister, this.GetType(), "这册失败！");
            }
        }
    }
}
