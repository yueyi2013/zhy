using System;
namespace ZHY.Model
{
	/// <summary>
	/// TwoDollarcCick
	/// </summary>
	[Serializable]
	public partial class TwoDollarcCick
	{
		public TwoDollarcCick()
		{}
		#region Model
		private decimal _tdcid;
		private string _tdccode;
		private string _tdcusername;
		private string _tdcpassword;
		private string _tdcemail;
		private string _tdcfullname;
		private string _tdccountry;
		private string _tdcpayment;
		private string _proxyaddress;
		private string _isenableproxy="Y";
		private int? _tdcviews=0;
		private string _tdcreferrals;
		private string _tdcisreferrals="N";
		private string _status="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 编号
		/// </summary>
		public decimal TDCId
		{
			set{ _tdcid=value;}
			get{return _tdcid;}
		}
		/// <summary>
		/// 网站编码
		/// </summary>
		public string TDCCode
		{
			set{ _tdccode=value;}
			get{return _tdccode;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string TDCUsername
		{
			set{ _tdcusername=value;}
			get{return _tdcusername;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string TDCPassword
		{
			set{ _tdcpassword=value;}
			get{return _tdcpassword;}
		}
		/// <summary>
		/// 邮件
		/// </summary>
		public string TDCEmail
		{
			set{ _tdcemail=value;}
			get{return _tdcemail;}
		}
		/// <summary>
		/// 全名
		/// </summary>
		public string TDCFullName
		{
			set{ _tdcfullname=value;}
			get{return _tdcfullname;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string TDCCountry
		{
			set{ _tdccountry=value;}
			get{return _tdccountry;}
		}
		/// <summary>
		/// payapl
		/// </summary>
		public string TDCPayment
		{
			set{ _tdcpayment=value;}
			get{return _tdcpayment;}
		}
		/// <summary>
		/// 代理地址
		/// </summary>
		public string ProxyAddress
		{
			set{ _proxyaddress=value;}
			get{return _proxyaddress;}
		}
		/// <summary>
		/// 启用代理
		/// </summary>
		public string IsEnableProxy
		{
			set{ _isenableproxy=value;}
			get{return _isenableproxy;}
		}
		/// <summary>
		/// 广告次数
		/// </summary>
		public int? TDCViews
		{
			set{ _tdcviews=value;}
			get{return _tdcviews;}
		}
		/// <summary>
		/// 推荐人
		/// </summary>
		public string TDCReferrals
		{
			set{ _tdcreferrals=value;}
			get{return _tdcreferrals;}
		}
		/// <summary>
		/// 是推荐人
		/// </summary>
		public string TDCIsReferrals
		{
			set{ _tdcisreferrals=value;}
			get{return _tdcisreferrals;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateAt
		{
			set{ _createat=value;}
			get{return _createat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateDT
		{
			set{ _updatedt=value;}
			get{return _updatedt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateBy
		{
			set{ _updateby=value;}
			get{return _updateby;}
		}
		#endregion Model

	}
}

