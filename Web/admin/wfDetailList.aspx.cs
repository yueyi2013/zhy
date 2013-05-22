using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfDetailList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageControls();
            if (!Page.IsPostBack)
            {
                MstGridViewBind();
               // BindProType();
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

        ///// <summary>
        ///// 绑定类型
        ///// </summary>
        //private void BindProType()
        //{
        //    ZHY.BLL.ProType bll=new ZHY.BLL.ProType();
        //    this.ddlProType.DataSource = bll.GetAllList();
        //    this.ddlProType.DataBind();
        //}

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected override void MstGridViewBind()
        {
            ZHY.BLL.Detail bll = new ZHY.BLL.Detail();
            string name = this.txtName.Text;
            this.MstGridView.DataSource = bll.GetList(pageIndex, name, ref pageRecord);
            this.MstGridView.DataBind();
            base.MstGridViewBind();
        }

        /// <summary>
        /// 行样式绑定
        /// <summary>
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
        /// 数据行命令触发
        /// </summary>
        protected void MstGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			string name = e.CommandName;
			string arg = e.CommandArgument.ToString();
			if (name.Equals("add"))
			{

			}else if(name.Equals("del")){

			}else if(name.Equals("mod")){

			}
		}
        #endregion

        #region 按钮操作
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int dtid = 0;
            if (dtid == 0)
            {
                Add();
                InitDataClear();
            }
            else
            {
                Modify(dtid);
            }
            MessageBox.SelfInform(this.upDetails, this.GetType(), "保存成功！");
            MstGridViewBind();
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void Add()
        {
            ZHY.Model.Detail model = new ZHY.Model.Detail();
            model.DtName = this.txtDtName.Text;
            model.DtDesc = this.txtDtDesc.Text;
            model.DtOrder = ConvertInt32(this.txtDtOrder.Text,0);
            
            ZHY.BLL.Detail bll = new ZHY.BLL.Detail();
            bll.Add(model);

            //ZHY.BLL.ProTypeDetail bll0 = new ZHY.BLL.ProTypeDetail();
            //ZHY.Model.ProTypeDetail model0 = new ZHY.Model.ProTypeDetail();
            //model0.DtID = model.DtID;
            //model0.ProTypeID = ConvertInt32(this.ddlProType.SelectedValue, 0);
            //model0.ProDtValue = null;
            //bll0.Add(model0);
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MstGridViewBind();
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        protected void btnDelete_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow gvr in MstGridView.Rows)
			{
				 CheckBox chk = (CheckBox)gvr.FindControl("chkItem");
				if (chk.Checked)
				{
                    string dtid = MstGridView.DataKeys[gvr.RowIndex].Value.ToString();
					ZHY.BLL.Detail bll=new ZHY.BLL.Detail();
					bll.Delete(ConvertInt32(dtid,0));
				}
			}
			MstGridViewBind();
		}

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="DtID"></param>
        private void ShowInfo(int DtID)
        {
            ZHY.BLL.Detail bll = new ZHY.BLL.Detail();
            ZHY.Model.Detail model = bll.GetModel(DtID);
            this.txtDtID.Text = DtID.ToString();
            this.txtDtName.Text = model.DtName;
            this.txtDtDesc.Text = model.DtDesc;
            this.txtDtOrder.Text = model.DtOrder.ToString();

        }
       
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="dtid"></param>
        public void Modify(int dtid)
        {

            ZHY.Model.Detail model = new ZHY.Model.Detail();
            //model.DtID = Sysfun.ConvertToInt32(this.txtDtID.Text);
            model.DtName = this.txtDtName.Text;
            model.DtDesc = this.txtDtDesc.Text;
           // model.DtOrder = Sysfun.ConvertToInt32(this.txtDtOrder.Text);

            ZHY.BLL.Detail bll = new ZHY.BLL.Detail();
            bll.Update(model);
        }

        /// <summary>
        /// 初始化清空数据控件
        /// </summary>
        private void InitDataClear()
		{
            this.txtDtName.Text = "";
            this.txtDtDesc.Text = "";
            this.txtDtOrder.Text = "";
		}


        /// <summary>
        ///  新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.txtDtName.Text = "";
            this.txtDtDesc.Text = "";
            this.txtDtOrder.Text = "";
            this.txtDtName.Focus();
        }
        #endregion

    }
}
