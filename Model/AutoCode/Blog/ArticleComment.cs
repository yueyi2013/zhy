using System;
namespace ZHY.Model
{
	/// <summary>
	/// ÎÄÕÂÆÀÂÛ
	/// </summary>
	[Serializable]
	public partial class ArticleComment
	{
		public ArticleComment()
		{}
		#region Model
		private decimal _acmid;
		private decimal? _arid;
		private string _acmcontent;
		private DateTime? _acmdate= DateTime.Now;
		private int? _acmtop=0;
		private int? _acmdown=0;
		private string _acmcmtpsn;
		private string _acmstatus="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public decimal ACMId
		{
			set{ _acmid=value;}
			get{return _acmid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ArId
		{
			set{ _arid=value;}
			get{return _arid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ACMContent
		{
			set{ _acmcontent=value;}
			get{return _acmcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ACMDate
		{
			set{ _acmdate=value;}
			get{return _acmdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ACMTop
		{
			set{ _acmtop=value;}
			get{return _acmtop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ACMDown
		{
			set{ _acmdown=value;}
			get{return _acmdown;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ACMCmtPsn
		{
			set{ _acmcmtpsn=value;}
			get{return _acmcmtpsn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ACMStatus
		{
			set{ _acmstatus=value;}
			get{return _acmstatus;}
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

