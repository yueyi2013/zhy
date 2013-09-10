using System;
using System.Data;
using System.Net;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using ZHY.Common;

namespace ZHY.BLL
{
	/// <summary>
	/// 虚拟人物
	/// </summary>
	public partial class VirtualPersonInfo : BaseBLL
    {
        #region 成员属性

        #endregion

        #region 成员方法
        /// <summary>
        /// 调用分页存储过程
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " * ";
            string tablename = " VirtualPersonInfo ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " VPFullName";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and VPFullName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }


        public void ExtractPsnInfoFromSite() 
        {
            try
            {
                for (int i = 0; i < 10;i++ )
                {
                    GetUSPersonInfo();
                }
            }
            catch(Exception ex) {

                throw ex;
            }
        }

        private void GetUSPersonInfo()
        {

            CookieContainer psnCookie = new CookieContainer();
            string resHtml = "";
            //第一步先登录
            string loginURL = "http://cn.zeelin.com/login/ajax-check-web-login/";
            string postData = "email=709757455@qq.com&pw=1qazxsw2&use_cookie=yes";
            HttpProxy.PostData(loginURL, postData, string.Empty,ref psnCookie);

            //得到定位到的URL
            loginURL = "http://cn.usinfo.me/ajax-get-new-info-by-condition/";
            //登录所需的信息
            postData = "condition_gender=random&condition_age=youth&condition_state=random&condition_city=random&condition_zip=random";

            resHtml = HttpProxy.PostData(loginURL, postData, string.Empty, ref psnCookie);
            //开始解析
            ZHY.Model.VirtualPersonInfo model = new ZHY.Model.VirtualPersonInfo();
            model.VPFullName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "full_name");
            model.VPFirstName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "first_name");
            model.VPLastName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "last_name");
            model.VPMiddleName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "middle_initial");
            model.VPSex = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "gender");
            model.VPBirthday = DateTime.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "birthday"));
            model.VPAge = int.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "age"));
            model.VPCollege = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "college");
            model.VPOccupation = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "occupation");
            model.VPSsn = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "ssn");
            model.VPMail = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "email");
            model.VPNickName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "nick_name");
            //model.VPFullName = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "height");
            model.VPBloodType = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "blood_type");
            //model.VPWeight = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "weight");
            model.VPState = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "state");

            model.VPCity = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "city");
            model.VPStreet = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "address");
            model.VPZip = int.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "zip"));
            model.VPPhone = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "phone");
            model.VPVisa = decimal.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_visa_number").Replace(" ", ""));
            model.VPVisaExpirDate = DateTime.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_visa_expiry_date"));

            model.VPCVV2 = int.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_visa_cvv2"));
            model.VPBank = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "bank_name");
            model.VPRoutingNumber = decimal.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "routing_number"));
            model.VPBankAcct = decimal.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "bank_account_number"));
            model.VPMasterCard = decimal.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_mastercard_number").Replace(" ", ""));
            model.VPMExpirDate = DateTime.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_mastercard_expiry_date"));
            model.VPMCVC2 = int.Parse(HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "cc_mastercard_cvc2"));
            model.VPSite = HtmlPaserUtil.ExtractHtmlValueByInputTag(resHtml, "website");

            this.Add(model);
        }
        #endregion
	}
}

