using System;
namespace ZHY.Model
{
	/// <summary>
	/// ·¢²¼ÎÄÕÂ
	/// </summary>
	[Serializable]
	public partial class Article
	{
		public Article()
		{}
		#region Model
		private decimal _arid;
		private string _artitle;
		private int? _acid;
		private int? _artypeid;
		private string _arcontent;
		private string _arauthor;
		private DateTime? _arpubdate= DateTime.Now;
		private int? _arclicks=0;
		private int? _arcmtnumber=0;
		private string _arrecommend="N";
		private string _aristop="N";
		private string _arforbidcomt="N";
		private string _arstatus="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public decimal ArId
		{
			set{ _arid=value;}
			get{return _arid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArTitle
		{
			set{ _artitle=value;}
			get{return _artitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ACId
		{
			set{ _acid=value;}
			get{return _acid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ArTypeId
		{
			set{ _artypeid=value;}
			get{return _artypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArContent
		{
			set{ _arcontent=value;}
			get{return _arcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArAuthor
		{
			set{ _arauthor=value;}
			get{return _arauthor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ArPubDate
		{
			set{ _arpubdate=value;}
			get{return _arpubdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ArClicks
		{
			set{ _arclicks=value;}
			get{return _arclicks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ArCmtNumber
		{
			set{ _arcmtnumber=value;}
			get{return _arcmtnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArRecommend
		{
			set{ _arrecommend=value;}
			get{return _arrecommend;}
		}
		/// <summary>
		/// Y-es,N-o
		/// </summary>
		public string ArIsTop
		{
			set{ _aristop=value;}
			get{return _aristop;}
		}
		/// <summary>
		/// Y-es,N-o
		/// </summary>
		public string ArForbidComt
		{
			set{ _arforbidcomt=value;}
			get{return _arforbidcomt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArStatus
		{
			set{ _arstatus=value;}
			get{return _arstatus;}
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

