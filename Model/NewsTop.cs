using System;
namespace ZHY.Model
{
	/// <summary>
	/// ÐÂÎÅTOP
	/// </summary>
	[Serializable]
	public partial class NewsTop
	{
		public NewsTop()
		{}
		#region Model
		private decimal _ntid;
		private string _nttitle;
		private string _ntauthor;
		private DateTime? _ntpubdate= DateTime.Now;
		private string _ntcontent;
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public decimal NTId
		{
			set{ _ntid=value;}
			get{return _ntid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NTTitle
		{
			set{ _nttitle=value;}
			get{return _nttitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NTAuthor
		{
			set{ _ntauthor=value;}
			get{return _ntauthor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NTPubDate
		{
			set{ _ntpubdate=value;}
			get{return _ntpubdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NTContent
		{
			set{ _ntcontent=value;}
			get{return _ntcontent;}
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

