using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace ZHY.Web
{
    public class MessageBox
    {
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
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language=\"javascript\">" + script + "</script>");

        }
        #endregion
    }
}
