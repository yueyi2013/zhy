using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ZHY.Web.admin
{
    public partial class wfSitePromise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReadINCFile(Maticsoft.DBUtility.PubConstant.GetKeyValue("sitePromise"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WriteINCFile(Maticsoft.DBUtility.PubConstant.GetKeyValue("sitePromise"));
        }

        private void ReadINCFile(string path)
        {
            StreamReader sr=null;
            try
            {
                sr = new StreamReader(Server.MapPath(path), System.Text.Encoding.Default);
                this.ftSitePromise.Text = sr.ReadToEnd();
            }
            catch
            {
                return;
            }
            finally {
                sr.Close();
            }
        }

        private void WriteINCFile(string path)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(Server.MapPath(path), false, System.Text.Encoding.UTF8);
                sw.Write(this.ftSitePromise.Text);
                MessageBox.ResponseScript(this.Page,"保存成功！");
            }
            catch
            {
                return;
            }
            finally {
                sw.Flush();
            }
        }
    }
}
