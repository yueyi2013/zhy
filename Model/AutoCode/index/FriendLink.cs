using System;
namespace ZHY.Model
{
	/// <summary>
	/// ”—«È¡¥Ω”
	/// </summary>
	[Serializable]
	public partial class FriendLink
	{
		public FriendLink()
		{}
		#region Model
		private int _flid;
		private string _flname;
		private string _flsiteurl;
		private string _flsitepic;
		private int? _florder;
		private string _fldesc;
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int FLId
		{
			set{ _flid=value;}
			get{return _flid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLName
		{
			set{ _flname=value;}
			get{return _flname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLSiteURL
		{
			set{ _flsiteurl=value;}
			get{return _flsiteurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLSitePic
		{
			set{ _flsitepic=value;}
			get{return _flsitepic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FLOrder
		{
			set{ _florder=value;}
			get{return _florder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLDesc
		{
			set{ _fldesc=value;}
			get{return _fldesc;}
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

