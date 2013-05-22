using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfImageEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
                upPic(FileUpload1, 1,1, true);
                upPic(FileUpload2, 2,1, false);
                upPic(FileUpload3, 3,2, true);
                upPic(FileUpload4, 4,2, false);
                upPic(FileUpload5, 5,3, true);
                upPic(FileUpload6, 6,3, false);
                upPic(FileUpload7, 7,4, true);
                upPic(FileUpload8, 8,4, false);
                upPic(FileUpload9, 9,5, true);
                upPic(FileUpload10, 10,5, false);
                upPic(FileUpload11, 11,6, true);
                upPic(FileUpload12, 12,6, false);
        }




        private void upPic(FileUpload fuCarPic, int order,int m, bool isPic)
        {
            string fileName = fuCarPic.PostedFile.FileName;
            if (String.IsNullOrEmpty(fileName))
                return;
            string proId = Request.QueryString[0];
            string dataPath = "";
            string folder = DateTime.Now.ToString("yyyyMM");
            
            string filePath = Server.MapPath("..\\upload\\product\\" + folder + "\\");

            string[] fileType = fileName.Split('.');
            string[] stuff = { "gif", "jpg", "jpeg", "bmp", "png" };
            bool flag = false;
            foreach (string str in stuff)
            {
                if (fileType[1].Equals(str))
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                string extension = Path.GetExtension(fuCarPic.PostedFile.FileName);

                string newName = isPic? proId + "_" + m + "b" : proId + "_" + m;
                string accessFilePath = filePath + newName + extension;
                dataPath = folder + "/" + newName + extension;
                //判断该文件是否已经存在
                if (!File.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                fuCarPic.SaveAs(accessFilePath);
                ZHY.BLL.ProPicture bll = new ZHY.BLL.ProPicture();
                ZHY.Model.ProPicture model = new ZHY.Model.ProPicture();
                model.ProID = ConvertInt32(proId, 1);
                model.ProPicURL = dataPath;
                model.ProOrder = order;
                bll.Add(model);
            }
            else
            {
                MessageBox.ResponseScript(this.Page, "alert(第" + order + "个空中请上传指定类型的图片！)");
            }
        }

    }
}
