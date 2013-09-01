using System;
namespace ZHY.Model
{
	/// <summary>
	/// 虚拟人物
	/// </summary>
	[Serializable]
	public partial class VirtualPersonInfo
	{
		public VirtualPersonInfo()
		{}
		#region Model
		private int _vpid;
		private string _vpfullname;
		private string _vpfirstname;
		private string _vpmiddlename;
		private string _vplastname;
		private string _vpsex="male";
		private DateTime? _vpbirthday;
		private string _vpmail;
		private string _vpnickname;
		private string _vppassword;
		private int? _vpage;
		private string _vpcollege;
		private string _vpoccupation;
		private string _vpssn;
		private int? _vpheight=175;
		private int? _vpweight=65;
		private string _vpbloodtype;
		private string _vpstate="CA";
		private string _vpcity="La Mesa";
		private string _vpstreet="7481 Mohawk St";
		private int? _vpzip=91941;
		private string _vpphone;
		private decimal? _vpvisa;
		private DateTime? _vpvisaexpirdate;
		private int? _vpcvv2;
		private string _vpbank;
		private decimal? _vproutingnumber;
		private decimal? _vpbankacct;
		private decimal? _vpmastercard;
		private DateTime? _vpmexpirdate;
		private int? _vpmcvc2;
		private string _vpsite;
		private string _vpnationality="United States";
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 人员编号
		/// </summary>
		public int VPID
		{
			set{ _vpid=value;}
			get{return _vpid;}
		}
		/// <summary>
		/// 全名
		/// </summary>
		public string VPFullName
		{
			set{ _vpfullname=value;}
			get{return _vpfullname;}
		}
		/// <summary>
		/// 名
		/// </summary>
		public string VPFirstName
		{
			set{ _vpfirstname=value;}
			get{return _vpfirstname;}
		}
		/// <summary>
		/// 中间名字
		/// </summary>
		public string VPMiddleName
		{
			set{ _vpmiddlename=value;}
			get{return _vpmiddlename;}
		}
		/// <summary>
		/// 姓
		/// </summary>
		public string VPLastName
		{
			set{ _vplastname=value;}
			get{return _vplastname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string VPSex
		{
			set{ _vpsex=value;}
			get{return _vpsex;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? VPBirthday
		{
			set{ _vpbirthday=value;}
			get{return _vpbirthday;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string VPMail
		{
			set{ _vpmail=value;}
			get{return _vpmail;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string VPNickName
		{
			set{ _vpnickname=value;}
			get{return _vpnickname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string VPPassword
		{
			set{ _vppassword=value;}
			get{return _vppassword;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public int? VPAge
		{
			set{ _vpage=value;}
			get{return _vpage;}
		}
		/// <summary>
		/// 毕业院校
		/// </summary>
		public string VPCollege
		{
			set{ _vpcollege=value;}
			get{return _vpcollege;}
		}
		/// <summary>
		/// 职业
		/// </summary>
		public string VPOccupation
		{
			set{ _vpoccupation=value;}
			get{return _vpoccupation;}
		}
		/// <summary>
		/// 社会保险号
		/// </summary>
		public string VPSsn
		{
			set{ _vpssn=value;}
			get{return _vpssn;}
		}
		/// <summary>
		/// 身高
		/// </summary>
		public int? VPHeight
		{
			set{ _vpheight=value;}
			get{return _vpheight;}
		}
		/// <summary>
		/// 体重
		/// </summary>
		public int? VPWeight
		{
			set{ _vpweight=value;}
			get{return _vpweight;}
		}
		/// <summary>
		/// 血型
		/// </summary>
		public string VPBloodType
		{
			set{ _vpbloodtype=value;}
			get{return _vpbloodtype;}
		}
		/// <summary>
		/// 美国州
		/// </summary>
		public string VPState
		{
			set{ _vpstate=value;}
			get{return _vpstate;}
		}
		/// <summary>
		/// 城市
		/// </summary>
		public string VPCity
		{
			set{ _vpcity=value;}
			get{return _vpcity;}
		}
		/// <summary>
		/// 街道
		/// </summary>
		public string VPStreet
		{
			set{ _vpstreet=value;}
			get{return _vpstreet;}
		}
		/// <summary>
		/// 邮编
		/// </summary>
		public int? VPZip
		{
			set{ _vpzip=value;}
			get{return _vpzip;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string VPPhone
		{
			set{ _vpphone=value;}
			get{return _vpphone;}
		}
		/// <summary>
		/// Visa信用卡
		/// </summary>
		public decimal? VPVisa
		{
			set{ _vpvisa=value;}
			get{return _vpvisa;}
		}
		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime? VPVisaExpirDate
		{
			set{ _vpvisaexpirdate=value;}
			get{return _vpvisaexpirdate;}
		}
		/// <summary>
		/// CVV2
		/// </summary>
		public int? VPCVV2
		{
			set{ _vpcvv2=value;}
			get{return _vpcvv2;}
		}
		/// <summary>
		/// 银行
		/// </summary>
		public string VPBank
		{
			set{ _vpbank=value;}
			get{return _vpbank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? VPRoutingNumber
		{
			set{ _vproutingnumber=value;}
			get{return _vproutingnumber;}
		}
		/// <summary>
		/// 银行账户
		/// </summary>
		public decimal? VPBankAcct
		{
			set{ _vpbankacct=value;}
			get{return _vpbankacct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? VPMasterCard
		{
			set{ _vpmastercard=value;}
			get{return _vpmastercard;}
		}
		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime? VPMExpirDate
		{
			set{ _vpmexpirdate=value;}
			get{return _vpmexpirdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VPMCVC2
		{
			set{ _vpmcvc2=value;}
			get{return _vpmcvc2;}
		}
		/// <summary>
		/// 个人网站
		/// </summary>
		public string VPSite
		{
			set{ _vpsite=value;}
			get{return _vpsite;}
		}
		/// <summary>
		///  国籍
		/// </summary>
		public string VPNationality
		{
			set{ _vpnationality=value;}
			get{return _vpnationality;}
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

