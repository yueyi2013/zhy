using System;
namespace ZHY.Model
{
	/// <summary>
	/// ¹ã¸æ
	/// </summary>
	[Serializable]
	public partial class Advertisement
	{
		public Advertisement()
		{}
		#region Model
		private int _adid;
		private string _adlogo;
		private string _adname;
		private int? _adcategoryid;
		private string _adbgcode;
		private decimal? _adunitprice;
		private string _adunit;
		private string _adbillingcycle;
		private string _adsource;
		private string _adcodeid;
		private string _addesc;
		private string _status="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int AdId
		{
			set{ _adid=value;}
			get{return _adid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdLogo
		{
			set{ _adlogo=value;}
			get{return _adlogo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdName
		{
			set{ _adname=value;}
			get{return _adname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AdCategoryId
		{
			set{ _adcategoryid=value;}
			get{return _adcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdBgCode
		{
			set{ _adbgcode=value;}
			get{return _adbgcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AdUnitPrice
		{
			set{ _adunitprice=value;}
			get{return _adunitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdUnit
		{
			set{ _adunit=value;}
			get{return _adunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdBillingCycle
		{
			set{ _adbillingcycle=value;}
			get{return _adbillingcycle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdSource
		{
			set{ _adsource=value;}
			get{return _adsource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdCodeId
		{
			set{ _adcodeid=value;}
			get{return _adcodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdDesc
		{
			set{ _addesc=value;}
			get{return _addesc;}
		}
		/// <summary>
		/// 
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

