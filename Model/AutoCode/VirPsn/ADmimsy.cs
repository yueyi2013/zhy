using System;
namespace ZHY.Model
{
	/// <summary>
	/// AD mimsy
	/// </summary>
	[Serializable]
	public partial class ADmimsy
	{
		public ADmimsy()
		{}
		#region Model
		private decimal _admyid;
		private string _admycode="Admimsy";
		private string _admyusername;
		private string _admypassword;
		private string _admyemail;
		private string _admycountry;
		private DateTime? _admybirthday;
		private string _admygender;
		private string _admypayment;
		private string _proxyaddress;
		private string _isenableproxy="Y";
		private int? _admyviews=0;
		private string _admyisreferrals="N";
		private string _admyreferrals;
		private string _admystatus="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 编号
		/// </summary>
		public decimal AdmyId
		{
			set{ _admyid=value;}
			get{return _admyid;}
		}
		/// <summary>
		/// 网站编码
		/// </summary>
		public string AdmyCode
		{
			set{ _admycode=value;}
			get{return _admycode;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string AdmyUserName
		{
			set{ _admyusername=value;}
			get{return _admyusername;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string AdmyPassword
		{
			set{ _admypassword=value;}
			get{return _admypassword;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string AdmyEmail
		{
			set{ _admyemail=value;}
			get{return _admyemail;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string AdmyCountry
		{
			set{ _admycountry=value;}
			get{return _admycountry;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? AdmyBirthday
		{
			set{ _admybirthday=value;}
			get{return _admybirthday;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string AdmyGender
		{
			set{ _admygender=value;}
			get{return _admygender;}
		}
		/// <summary>
		/// payapl
		/// </summary>
		public string AdmyPayment
		{
			set{ _admypayment=value;}
			get{return _admypayment;}
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
		public int? AdmyViews
		{
			set{ _admyviews=value;}
			get{return _admyviews;}
		}
		/// <summary>
		/// 是推荐人
		/// </summary>
		public string AdmyIsReferrals
		{
			set{ _admyisreferrals=value;}
			get{return _admyisreferrals;}
		}
		/// <summary>
		/// 推荐人
		/// </summary>
		public string AdmyReferrals
		{
			set{ _admyreferrals=value;}
			get{return _admyreferrals;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string AdmyStatus
		{
			set{ _admystatus=value;}
			get{return _admystatus;}
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

