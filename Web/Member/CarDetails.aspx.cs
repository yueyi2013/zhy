using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Member
{
    public partial class CarDetails : System.Web.UI.Page
    {
        private string proID = "";
        private string bgImg = "";
        private string slImg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                proID = Request.QueryString[0];
                if (!IsPostBack)
                {
                    //ZHY.BLL.ProDetail bll = new ZHY.BLL.ProDetail();
                    //this.dlPam.DataSource = bll.GetList(int.Parse(proID));
                   //this.dlPam.DataBind();
                    GetBigImage();
                }
            }
        }

        protected string GetDes()
        {
            ZHY.BLL.ProPicture bll = new ZHY.BLL.ProPicture();
            bll.GetAllList();
            //StringBuilder sbDes = new StringBuilder();
            //for(int i=0;){}
            //sbDes.AppendFormat("<table id=\"table{0}\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">",);
            return ""; 
        }

       public StringBuilder sbBig = new StringBuilder();
       public StringBuilder sbSml = new StringBuilder();

        protected void GetBigImage()
        {
            StringBuilder sbDes = new StringBuilder();
            
            ZHY.BLL.ProPicture bll = new ZHY.BLL.ProPicture();
            DataTable dt = bll.GetList("ProID = " + proID).Tables[0];
            int i=0,j=0;
            foreach(DataRow dr in dt.Rows){
                if (Convert.ToInt32(dr["ProOrder"]) % 2 == 0)
                {
                    sbBig.AppendFormat("<img id=\"img{0}\" src=\"../upload/product/{1}\" />", i, dr["ProPicURL"]);
                    i++;
                }
                else {
                    sbSml.AppendFormat("<td><a rel=\"img{0}\" href=\"javascript:;\"><img id=\"img{1}\" src=\"../upload/product/{2}\" /></a></td>", i, i, dr["ProPicURL"]);
                    j++;
                }
            }
           
        }

        protected string GetSmallImage() 
        {
            StringBuilder sbDes = new StringBuilder();
            sbDes.Append("");
            return "";
        }
    }
}
