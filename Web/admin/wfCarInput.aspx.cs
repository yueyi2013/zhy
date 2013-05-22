using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHY.Web.admin
{
    public partial class wfCarInput : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hfProTypeID.Value = Request.QueryString["proID"];
            BindHTML();
        }

        /// <summary>
        /// 绑定控件
        /// </summary>
        private void BindHTML()
        {
            ZHY.BLL.Detail bll = new ZHY.BLL.Detail();
            DataTable dt = bll.GetAllList().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i += 2)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                Label lbl = new Label();
                lbl.Text = dt.Rows[i]["DtName"].ToString() + "：";
                cell.Controls.Add(lbl);
                row.Cells.Add(cell);

                TableCell cell0 = new TableCell();
                TextBox txt0 = new TextBox();
                txt0.Width = Unit.Pixel(200);
                txt0.ID = dt.Rows[i]["DtID"].ToString();
                cell0.Controls.Add(txt0);
                row.Cells.Add(cell0);

                if (i + 1 != dt.Rows.Count)
                {
                    TableCell cell1 = new TableCell();
                    Label lbl1 = new Label();
                    lbl1.Text = dt.Rows[i + 1]["DtName"].ToString() + "：";
                    cell1.Controls.Add(lbl1);
                    row.Cells.Add(cell1);

                    TableCell cell2 = new TableCell();
                    TextBox txt1 = new TextBox();
                    txt1.Width = Unit.Pixel(200);
                    txt1.ID = dt.Rows[i + 1]["DtID"].ToString();
                    cell2.Controls.Add(txt1);
                    row.Cells.Add(cell2);
                }
                this.tabCarInput.Rows.Add(row);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string hfProTypeID = this.hfProTypeID.Value;
            ZHY.BLL.ProTypeDetail bll = new ZHY.BLL.ProTypeDetail();
            ZHY.BLL.ProPicture bll0 = new ZHY.BLL.ProPicture();
            DataTable dt = bll.GetList("ProTypeID = " + hfProTypeID).Tables[0];
            List<ZHY.Model.ProTypeDetail> list = new List<ZHY.Model.ProTypeDetail>();
            foreach (DataRow dr in dt.Rows)
            {
                System.Web.UI.Control control = this.FindControl(dr["DtID"].ToString());
                if (control != null)
                {
                    switch (control.GetType().Name)
                    {
                        case "TextBox":
                            if (control != null)
                            {
                                ZHY.Model.ProTypeDetail model = new ZHY.Model.ProTypeDetail();
                                model.DtID = ConvertInt32((control as TextBox).Text, 0);
                                model.ProTypeID = ConvertInt32(hfProTypeID, 0);
                                model.ProDtValue = (control as TextBox).Text;
                                list.Add(model);
                            }
                            break;
                        //case "FileUpload":
                        //    FileUpload fuImage = (control as FileUpload);
                        //    if (fuImage.PostedFile.FileName != "")
                        //    {

                        //        ZHY.Model.ProPicture model0 = new ZHY.Model.ProPicture();
                        //        model0.ProPicURL = AddPics(fuImage);
                        //        bll0.Add(model0);
                        //    }
                        //    break;
                    }
                }
            }
            bll.Add(list);

        }

        /// <summary>
        /// 添加图片
        /// </summary>
        private string AddPics(FileUpload fuImage)
        {
            string dataPath = "";
            string filePath = Server.MapPath("..\\upload\\product\\");
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
            return dataPath;
        }

        /// <summary>
        /// 绑定参数页面
        /// </summary>
        /// <returns></returns>
        protected string GetPamURL()
        {
            return "wfImageEdit.aspx?proID=" + this.hfProTypeID.Value;
        }
    }
}
