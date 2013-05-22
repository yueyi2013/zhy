using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web
{
    public class BasePage:System.Web.UI.Page
    {
        #region 分页处理
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int pageIndex = 1;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int pageRecord = 0;
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int pageSize = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        public int pageAll = 0;
        /// <summary>
        /// 每页记录数
        /// </summary>
        public Label lblPageSize;
        /// <summary>
        /// 当前页索引
        /// </summary>
        public Label lblPageIndex;
        /// <summary>
        /// 总记录数
        /// </summary>
        public Label lblPageRecord;
        /// <summary>
        /// 总页数
        /// </summary>
        public Label lblPageAll;
        /// <summary>
        /// 当前索引
        /// </summary>
        public TextBox txtPageIndex;
        /// <summary>
        /// 下一页
        /// </summary>
        public Button btnNext;
        /// <summary>
        /// 上一页
        /// </summary>
        public Button btnPrev;
        /// <summary>
        /// 首页
        /// </summary>
        public Button btnFirst;
        /// <summary>
        /// 最后一页
        /// </summary>
        public Button btnLast;
        /// <summary>
        /// 跳转索引页
        /// </summary>
        public Button btnGo;

        /// <summary>
        /// 分页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Click(object sender, EventArgs e)
        {
            this.pageIndex = ConvertInt32(this.lblPageIndex.Text, 0);
            this.pageAll = ConvertInt32(this.lblPageAll.Text, 0);
            string btnName = ((Button)sender).ID;
            int len = btnName.Length;
            string str = btnName.Substring(0, len - 1);
            switch (str)
            {
                case "btnFirst":
                    pageIndex = 1;
                    break;
                case "btnPrev":
                    if (pageIndex != 1)
                        pageIndex--;
                    break;
                case "btnNext":
                    if (pageIndex != pageAll)
                        pageIndex++;
                    break;
                case "btnLast":
                    pageIndex = pageAll;
                    break;
                case "btnGo":
                    pageIndex = ConvertInt32(this.txtPageIndex.Text, 0);
                    break;
            }
            MstGridViewBind();
        }

        /// <summary>
        /// 分页按钮控制
        /// </summary>
        public void ButtonEnabled()
        {
            if (pageAll <= 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPrev.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnGo.Enabled = false;

            }
            else if (pageIndex == pageAll)
            {
                this.btnFirst.Enabled = true;
                this.btnPrev.Enabled = true;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnGo.Enabled = true;

            }
            else if (pageIndex == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPrev.Enabled = false;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
                this.btnGo.Enabled = true;
            }
            else
            {
                this.btnFirst.Enabled = true;
                this.btnPrev.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
                this.btnGo.Enabled = true;
            }
        }

        private void BindPageParams()
        {
            pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            pageAll = pageRecord % this.pageSize == 0 ? pageRecord / this.pageSize : pageRecord / this.pageSize + 1;
        }

        protected virtual void BindPageControls()
        {

        }

        /// <summary>
        /// DataGridView数据绑定
        /// </summary>
        protected virtual void MstGridViewBind()
        {
            BindPageParams();
            this.lblPageAll.Text = pageAll.ToString();
            this.lblPageIndex.Text = pageIndex.ToString();
            this.lblPageSize.Text = pageSize.ToString();
            this.lblPageRecord.Text = pageRecord.ToString();
            ButtonEnabled();
        }

        protected virtual void MstTextInit()
        {

        }

        protected virtual void MstTextFill()
        {

        }

        protected virtual void MstDataListBind()
        {

        }
        #endregion
        
        #region 数据操作
        /// <summary>
        /// 数字转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ConvertInt32(string value, Int32 defaultValue)
        {
            try
            {
                return Int32.Parse(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 数字转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ConvertDecimal(string value, decimal defaultValue)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///  日期转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public DateTime ConvertDateTime(string value, DateTime defaultValue)
        {
            try
            {
                return DateTime.Parse(value, System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            catch
            {
                return defaultValue;
            }
        }
        #endregion

        #region 提示信息
        /// <summary>
        /// UpdatePanel 范围内按钮提示信息
        /// </summary>
        /// <param name="myUpdatePanel"></param>
        /// <param name="text"></param>
        public static void SelfInform(Control currentUpdatePanel, Type type, string text)
        {
            ScriptManager.RegisterStartupScript(currentUpdatePanel, type, "updateScript", "alert('" + text + "')", true);
        }

        public static void ResponseWrite(Control currentUpdatePanel, Type type, string text)
        {
            ScriptManager.RegisterStartupScript(currentUpdatePanel, type, "updateScript", text, true);
        }

        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'>" + script + "</script>");

        }
        #endregion

        #region TreeView 数据绑定
        /// <summary>
        /// 绑定数
        /// </summary>
        protected TreeView tvList;
        /// <summary>
        /// 
        /// </summary>
        protected virtual void BindTreeView()
        {
            if (tvList != null)
            {
                tvList.Nodes.Clear();
            }
            TreeNode root = new TreeNode("根节点", "0");
            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            DataSet ds = bll.GetAllList();
            DataRow[] dr1 = ds.Tables[0].Select("LMParantID=0");
            string lmId = "";
            string lmName = "";
            foreach (DataRow d1 in dr1)
            {
                lmId = d1[0].ToString();
                lmName = d1[2].ToString();
                TreeNode fatherTreeNode = CreateTreeNode(lmId, lmName);
                CreateChildTreeNode(lmId, ds, fatherTreeNode);
                root.ChildNodes.Add(fatherTreeNode);
            }
            tvList.Nodes.Add(root);
        }

        /// <summary>
        /// 创建子节点
        /// </summary>
        /// <param name="lmId">栏目编号</param>
        /// <param name="ds">数据集合</param>
        /// <param name="fatherTreeNode">父菜单项</param>
        private void CreateChildTreeNode(string lmId, DataSet ds, TreeNode fatherTreeNode)
        {
            DataRow[] dr2 = ds.Tables[0].Select("LMParantID=" + lmId);
            string childlmId = "";
            string childlmName = "";
            foreach (DataRow d2 in dr2)
            {
                childlmId = d2[0].ToString();
                childlmName = d2[2].ToString();
                TreeNode childTreeNode = CreateTreeNode(childlmId, childlmName);
                CreateChildTreeNode(childlmId, ds, childTreeNode);
                fatherTreeNode.ChildNodes.Add(childTreeNode);
            }
        }

        /// <summary>
        /// 创建子节点
        /// </summary>
        /// <param name="lmId">栏目编号</param>
        /// <param name="lmName">栏目名称</param>
        /// <returns></returns>
        private TreeNode CreateTreeNode(string lmId, string lmName)
        {
            TreeNode objTreeNode = new TreeNode();
            objTreeNode.Text = lmName;
            objTreeNode.Value = lmId;
            return objTreeNode;
        }
        #endregion

        #region Menu 数据绑定
        protected Menu mnList;
        /// <summary>
        /// 数据绑定
        /// </summary>
        protected virtual void BindMenu()
        {
            ZHY.BLL.LanMu bll = new ZHY.BLL.LanMu();
            DataSet ds = bll.GetAllList();
            DataRow[] dr1 = ds.Tables[0].Select("LMLocation=1 and LMParantID=0");
            string lmId = "";
            string lmName = "";

            foreach (DataRow d1 in dr1)
            {
                lmId = d1[0].ToString();
                lmName = d1[2].ToString();
                MenuItem fatherMenuItem = CreateMenuItem(lmId, lmName);
                CreateChildMenuItem(lmId, ds, fatherMenuItem);
                mnList.Items.Add(fatherMenuItem);
            }
        }

        /// <summary>
        /// 创建子菜单
        /// </summary>
        /// <param name="lmId">栏目编号</param>
        /// <param name="ds">数据集合</param>
        /// <param name="fatherMenuItem">父菜单项</param>
        private void CreateChildMenuItem(string lmId, DataSet ds, MenuItem fatherMenuItem)
        {
            DataRow[] dr2 = ds.Tables[0].Select("LMLocation=1 and LMParantID=" + lmId);
            string childlmId = "";
            string childlmName = "";
            foreach (DataRow d2 in dr2)
            {
                childlmId = d2[0].ToString();
                childlmName = d2[2].ToString();
                MenuItem childMenuItem = CreateMenuItem(childlmId, childlmName);
                CreateChildMenuItem(childlmId, ds, childMenuItem);
                fatherMenuItem.ChildItems.Add(childMenuItem);
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
            objMenuItem.NavigateUrl = "wfLanMuList.aspx?lmId=" + lmId;
            objMenuItem.Target = "_parent";
            return objMenuItem;
        }
        #endregion
    }
}
