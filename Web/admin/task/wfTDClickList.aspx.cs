using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZHY.Web;
using System.Text;
using ZHY.Common;

namespace Web.admin.task
{
    public partial class wfTDClickList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!IsPostBack)
            {
                MstGridViewBind();
            }
        }

        #region 绑定DataGridView
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
            base.BindPageControls();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected override void MstGridViewBind()
        {
            ZHY.BLL.TwoDollarcCick bll = new ZHY.BLL.TwoDollarcCick();
            string name = this.txtName.Text;
            this.MstGridView.DataSource = bll.GetList(pageIndex, name, ref pageRecord);
            this.MstGridView.DataBind();
            base.MstGridViewBind();
        }

        /// <summary>
        /// 数据行绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MstGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置行颜色   
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#F9E3AA'");
                //添加自定义属性，当鼠标移走时还原该行的背景色   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MstGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string name = e.CommandName;
            string arg = e.CommandArgument.ToString();
            if (name.Equals("add"))
            {

            }
            else if (name.Equals("del"))
            {

            }
            else if (name.Equals("mod"))
            {

            }

        }
        #endregion

        #region 按钮操作
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MstGridViewBind();
        }

        /// <summary>
        ///  自动注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAutoReg_Click(object sender, EventArgs e)
        {
            ZHY.BLL.TwoDollarcCick bll = new ZHY.BLL.TwoDollarcCick();
            ZHY.Model.TwoDollarcCick model = null;
            string referralName = "jans2013";
            try
            {
                StringBuilder sbLogin = new StringBuilder();

                if (!string.IsNullOrEmpty(this.txtTDCUsername.Text))
                {
                    referralName = txtTDCUsername.Text.Trim();
                }

                sbLogin.AppendFormat(referralName);
                model = bll.SignUpTwoDollarcCickFromUI(sbLogin.ToString());
                bll.Update(model);
            }
            catch (Exception ex)
            {

                SelfInform(this.MyUpdatePanelPanelBody, this.GetType(), model != null ? ex.Message : model.TDCUsername + "|" + ex.Message);
                return;
            }
            SelfInform(this.MyUpdatePanelPanelBody, this.GetType(), "自动注册成功！-推荐人" + referralName);
            this.txtTDCCode.Text = model.TDCCode;
            this.txtTDCUsername.Text = model.TDCUsername;
            this.txtTDCPassword.Text = model.TDCPassword;
            this.txtProxyAddress.Text = model.ProxyAddress;
        }

        /// <summary>
        ///  保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = ConvertInt32(this.hfTDCId.Value, 0);
            if (id == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(id);
            }
            SelfInform(this.MyUpdatePanelPanelBody, this.GetType(), "保存成功！");
            MstGridViewBind();
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ZHY.BLL.TwoDollarcCick bll = new ZHY.BLL.TwoDollarcCick();
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                string id = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    bll.Delete(ConvertInt32(id, 0));
                }
            }
            MstGridViewBind();

        }

        /// <summary>
        /// 开始任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTask_Click(object sender, EventArgs e)
        {
            ZHY.BLL.TwoDollarcCick bll = new ZHY.BLL.TwoDollarcCick();
            ZHY.Model.TwoDollarcCick model = null;
            StringBuilder sbError = new StringBuilder();
            string method = "wfTDClickList.aspx.cs#btnTask_Click";
            int i = 0;
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                try
                {
                    string id = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                    CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                    if (chk.Checked)
                    {
                        model = bll.GetModel(decimal.Parse(id));
                        if (!HttpProxy.CheckProxyConnected(model.ProxyAddress))
                        {
                            ZHY.BLL.ProxyAddress bllProxy = new ZHY.BLL.ProxyAddress();
                            IList<ZHY.Model.ProxyAddress> proxyLst = bllProxy.GetModelList(" PACountry like '" +model.TDCCountry + "%'");
                            if (proxyLst == null || proxyLst.Count < 1)
                            {
                                model.IsEnableProxy = "N";
                                bll.Update(model);
                                return;
                            }
                            foreach (ZHY.Model.ProxyAddress proAddr in proxyLst)
                            {
                                if (HttpProxy.CheckProxyConnected(proAddr.PAName))
                                {
                                    model.ProxyAddress = proAddr.PAName;
                                    break;
                                }
                            }
                        }
                        bll.TwoDollarcCickViewAdsFromUI(model);
                        bll.Update(model);
                    }
                }
                catch (Exception ex)
                {
                    if (i == 0)
                    {
                        sbError.Append(model.TDCUsername);
                    }
                    else
                    {
                        sbError.Append(",");
                        sbError.Append(model.TDCUsername);
                    }
                    i++;
                    sbError.Append(ex.Message);
                }
                finally
                {


                }
            }
            if (i > 0)
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, "未完成的任务[" + sbError.ToString() + "]");
            }
            else
            {
                bll.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_ERROR_ALERT_JOB_SUBJECT + method, "任务完成！");
            }
        }

        /// <summary>
        /// 修改按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModify_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in MstGridView.Rows)
            {
                string id = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
                CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
                if (chk.Checked)
                {
                    InitData(ConvertInt32(id, 0));
                    this.mpMstAdd.Show();
                    btnModify.Enabled = true;
                    break;
                }
            }
        }

        /// <summary>
        ///  关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.mpMstAdd.Hide();
            InitDataClear();
        }
        #endregion

        #region 公共方法

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

        /// <summary>
        /// 新增
        /// </summary>
        private void Add()
        {
            ZHY.Model.TwoDollarcCick model = new ZHY.Model.TwoDollarcCick();
            model.TDCCode = this.txtTDCCode.Text;
            model.TDCUsername = this.txtTDCUsername.Text;
            model.TDCPassword = this.txtTDCPassword.Text;
            model.ProxyAddress = this.txtProxyAddress.Text;
            ZHY.Model.User user = getLoginUser();
            model.CreateBy = user.UserName;
            model.UpdateBy = user.UserName;
            ZHY.BLL.TwoDollarcCick bll = new ZHY.BLL.TwoDollarcCick();
            bll.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="LMID"></param>
        private void Modify(int ID)
        {
            ZHY.BLL.TwoDollarcCick bll = new ZHY.BLL.TwoDollarcCick();
            ZHY.Model.TwoDollarcCick model = bll.GetModel(ID);
            if (model != null)
            {
                model.TDCCode = this.txtTDCCode.Text;
                model.TDCUsername = this.txtTDCUsername.Text;
                model.TDCPassword = this.txtTDCPassword.Text;
                model.ProxyAddress = this.txtProxyAddress.Text;
                ZHY.Model.User user = getLoginUser();
                model.UpdateBy = user.UserName;
                model.UpdateDT = DateTime.Now;
                bll.Update(model);
            }
        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
        {
            this.hfTDCId.Value = "0";
            this.txtTDCCode.Text = "";
            this.txtTDCUsername.Text = "";
            this.txtTDCPassword.Text = "";
            this.txtProxyAddress.Text = "";
        }

        /// <summary>
        /// 初始化数据控件
        /// </summary>
        private void InitData(int id)
        {
            ZHY.BLL.TwoDollarcCick bll = new ZHY.BLL.TwoDollarcCick();
            ZHY.Model.TwoDollarcCick model = bll.GetModel(id);
            this.hfTDCId.Value = model.TDCId.ToString();
            this.txtTDCCode.Text = model.TDCCode;
            this.txtTDCUsername.Text = model.TDCUsername;
            this.txtTDCPassword.Text = model.TDCPassword;
            this.txtProxyAddress.Text = model.ProxyAddress;
        }
        #endregion
    }
}