using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ZHY.Web.admin
{
    public partial class wfUpSmallPic : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string proId = Request.QueryString["proID"];
            string dataPath = "";
            string filePath = Server.MapPath("..\\upload\\product\\SmallPic\\");
            string fileName = fuCarPic.PostedFile.FileName;
            if (String.IsNullOrEmpty(fileName))
                return;
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
                
                string extension = Path.GetExtension(fuCarPic.PostedFile.FileName);
                string newName = DateTime.Now.ToString("yyyyMMddhhmmss");
                string accessFilePath = filePath + newName + extension;
                dataPath = newName + extension;
                //判断该文件是否已经存在
                if (!File.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                
                fuCarPic.SaveAs(accessFilePath);
                ZHY.BLL.ProPicture bll = new ZHY.BLL.ProPicture();
                ZHY.Model.ProPicture model = new ZHY.Model.ProPicture();
                model.ProID = ConvertInt32(proId, 0);
                model.ProPicURL = dataPath;
                model.ProOrder = 0;
                bll.Add(model);
                MessageBox.ResponseScript(this.Page,"图片上传成功！");
            }
            else
            {
                MessageBox.ResponseScript(this.Page, "请上传指定类型的图片！");
            }
        }


    }
}
