using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfIndexPic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string dataPath = "";
            string filePath = Server.MapPath("..\\upload\\shouye\\");
            string fileName = fuImage.PostedFile.FileName;
            string[] fileType = fileName.Split('.');
            string[] stuff = { "gif", "jpg", "jpeg", "bmp", "png" };
            bool flag = false;
            foreach (string str in stuff)
            {
                if (fileType[1].Equals(str))
                {
                    flag = true;
                }
            }
            if (flag)
            {
                string extension = Path.GetExtension(fuImage.PostedFile.FileName).ToUpper();
                string newName = DateTime.Now.ToString("yyyyMMddhhmmss");
                string accessFilePath = filePath + newName + extension;
                dataPath = newName + "." + extension;
                //判断该文件是否已经存在
                if (!File.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                fuImage.SaveAs(accessFilePath);
            }
            else
            {
                MessageBox.ResponseScript(this.Page, "请上传指定类型的图片！");
            }
        }
    }
}
