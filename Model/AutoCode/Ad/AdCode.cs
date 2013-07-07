using System;
namespace ZHY.Model
{
	/// <summary>
	/// ¹ã¸æ´úÂë
	/// </summary>
	[Serializable]
	public partial class AdCode
	{
		public AdCode()
		{}
		#region Model
		private int _adcodeid;
		private int? _adid;
		private string _adcodecont;
		private string _adcodedesc;
		private string _addefault="N";
		private string _status="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int AdCodeId
		{
			set{ _adcodeid=value;}
			get{return _adcodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AdId
		{
			set{ _adid=value;}
			get{return _adid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdCodeCont
		{
			set{ _adcodecont=value;}
			get{return _adcodecont;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdCodeDesc
		{
			set{ _adcodedesc=value;}
			get{return _adcodedesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdDefault
		{
			set{ _addefault=value;}
			get{return _addefault;}
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

