using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using ZHY.Common;
using System.Net;
using System.Text;

namespace ZHY.BLL
{
	/// <summary>
	/// 代理地址
	/// </summary>
    public partial class ProxyAddress : BaseBLL
	{

        /// <summary>
        /// 调用分页存储过程
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " PAId,PAName,PAType,PAAnonymity,PACountry,CreateAt,CreateBy,UpdateDT,UpdateBy ";
            string tablename = " ProxyAddress ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " PAId ";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += " and PAName like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        /// <summary>
        /// 检查代理地址的有效性
        /// </summary>
        public void CheckProxyAddressConnected() 
        {
            List<ZHY.Model.ProxyAddress> list = GetModelList("");
            int count = 0;
            foreach (ZHY.Model.ProxyAddress model in list)
            {
                if (!HttpProxy.CheckProxyConnected(model.PAName))
                {
                    count++;
                    Delete(model.PAId);
                }
            }
            if (count>0)
                this.AlertEmail(Constants.SYSTEM_CONFIG_ATT_NAME_MAIL_PROXY_JOB_SUBJECT, "有" + count+"个无效的代理地址。");
        }

        public void ExtractProxyAddress()
        {
            try
            {
                List<string>  listProxy = new List<string>();
                CookieContainer httpCookie = new CookieContainer();
                for (int i = 0; i <= 4;i++ )
                {
                    StringBuilder sbProxyURL = new StringBuilder();
                    if (i == 0)
                    {
                        sbProxyURL.Append("http://spys.ru/en/free-proxy-list/");

                    }
                    else
                    {

                        sbProxyURL.AppendFormat("http://spys.ru/en/free-proxy-list/{0}/", i);
                    }
                    string htmlSource = HttpProxy.GetResponseData(sbProxyURL.ToString(), string.Empty, ref httpCookie);
                    listProxy.AddRange(HtmlPaserUtil.ExtractHtmlValueByTableTag(htmlSource));
                }

                foreach (string str in listProxy)
                {
                    try
                    {
                        string[] row = str.Split(new string[] { "," }, StringSplitOptions.None);
                        ZHY.Model.ProxyAddress model = new Model.ProxyAddress();
                        model.PAType = row[1];
                        model.PAAnonymity = row[2];
                        model.PACountry = row[3];
                        if (HttpProxy.CheckProxyConnected(row[0], 8080))
                        {
                            model.PAName = row[0] + ":" + 8080;
                            if (!this.Exists(model.PAName))
                            {
                                this.Add(model);
                            }
                        }
                        else if (HttpProxy.CheckProxyConnected(row[0], 80))
                        {
                            model.PAName = row[0] + ":" + 80;
                            if (!this.Exists(model.PAName)) 
                            {
                                this.Add(model);
                            }
                        }
                    }
                    catch { 
                        //donothing
                    }
                }

            }
            catch (Exception ex) {


                throw ex;
            }
        }

        /// <summary>
        /// 检查代理地址是否已经存在
        /// </summary>
        public bool Exists(string PAName)
        {
            return dal.Exists(PAName);
        }


	}
}

