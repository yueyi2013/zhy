using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Member
{
    public partial class CarInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindHTML();
        }

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

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void AddPics()
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
