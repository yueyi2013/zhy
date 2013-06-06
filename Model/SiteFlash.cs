using System;
namespace ZHY.Model
{
	/// <summary>
	/// ÍøÕ¾¶¯»­
	/// </summary>
	[Serializable]
	public partial class SiteFlash
	{
		public SiteFlash()
		{}
		#region Model
		private int _sfid;
		private string _sfpicpath;
		private string _sfdetailsurl;
		private string _sfcontitle;
		private int? _sforder;
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public int SFId
		{
			set{ _sfid=value;}
			get{return _sfid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SFPicPath
		{
			set{ _sfpicpath=value;}
			get{return _sfpicpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SFDetailsURL
		{
			set{ _sfdetailsurl=value;}
			get{return _sfdetailsurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SFConTitle
		{
			set{ _sfcontitle=value;}
			get{return _sfcontitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SFOrder
		{
			set{ _sforder=value;}
			get{return _sforder;}
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

