using System;
namespace ZHY.Model
{
	/// <summary>
	/// 广告计费
	/// </summary>
	[Serializable]
	public partial class AdBilling
	{
		public AdBilling()
		{}
		#region Model
		private int _adbgid;
		private string _adbgcode;
		private string _adbgdesc;
		private string _status="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int AdBgId
		{
			set{ _adbgid=value;}
			get{return _adbgid;}
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
		public string AdBgDesc
		{
			set{ _adbgdesc=value;}
			get{return _adbgdesc;}
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

