using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using ZHY.Common;
namespace ZHY.BLL
{
	/// <summary>
	/// 代理地址
	/// </summary>
    public partial class ProxyAddress : BaseBLL
	{
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
	}
}

