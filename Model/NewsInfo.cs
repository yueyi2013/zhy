using System;
namespace ZHY.Model
{
	/// <summary>
	/// NewsInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NewsInfo
	{
		public NewsInfo()
		{}
		#region Model
		private decimal _newsid;
		private string _newstitle;
		private DateTime? _newspubdate;
		private string _newsauthor;
		private int? _newscategory;
		private string _newsindustry;
		private string _newssource;
		private string _newscontents;
		private string _newsstatus="A";
		private DateTime? _navcreateat= DateTime.Now;
		private string _navcreateby;
		private DateTime? _navupdatedt= DateTime.Now;
		private string _navupdateby;
		/// <summary>
		/// 
		/// </summary>
		public decimal NewsId
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsTitle
		{
			set{ _newstitle=value;}
			get{return _newstitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NewsPubDate
		{
			set{ _newspubdate=value;}
			get{return _newspubdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsAuthor
		{
			set{ _newsauthor=value;}
			get{return _newsauthor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NewsCategory
		{
			set{ _newscategory=value;}
			get{return _newscategory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsIndustry
		{
			set{ _newsindustry=value;}
			get{return _newsindustry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsSource
		{
			set{ _newssource=value;}
			get{return _newssource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsContents
		{
			set{ _newscontents=value;}
			get{return _newscontents;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsStatus
		{
			set{ _newsstatus=value;}
			get{return _newsstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NavCreateAt
		{
			set{ _navcreateat=value;}
			get{return _navcreateat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavCreateBy
		{
			set{ _navcreateby=value;}
			get{return _navcreateby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NavUpdateDT
		{
			set{ _navupdatedt=value;}
			get{return _navupdatedt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavUpdateBy
		{
			set{ _navupdateby=value;}
			get{return _navupdateby;}
		}
		#endregion Model

	}
}

