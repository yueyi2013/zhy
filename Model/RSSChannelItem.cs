using System;
using System.Xml.Serialization;
namespace ZHY.Model
{
	/// <summary>
	/// RSSChannelItem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RSSChannelItem
	{
		public RSSChannelItem()
		{}
		#region Model
        [XmlIgnore()]
		private int _rcitemid;
        [XmlIgnore()]
		private int? _rcid;
        [XmlElement("title")]
		private string _rcitemtitle;
        [XmlElement("link")]
		private string _rcitemlink;
        [XmlIgnore()]
		private string _rcitemcategory;
        [XmlIgnore()]
		private string _rcitemauthor;
        [XmlElement("pubDate")]
		private DateTime? _rcitempubdate;
        [XmlIgnore()]
		private string _rcitemdescription;
        [XmlIgnore()]
		private string _rcitemcomments;
        [XmlIgnore()]
		private DateTime? _navcreateat= DateTime.Now;
        [XmlIgnore()]
		private string _navcreateby;
        [XmlIgnore()]
		private DateTime? _navupdatedt= DateTime.Now;
        [XmlIgnore()]
		private string _navupdateby;
		/// <summary>
		/// 
		/// </summary>
		public int RCItemId
		{
			set{ _rcitemid=value;}
			get{return _rcitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RCId
		{
			set{ _rcid=value;}
			get{return _rcid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCItemTitle
		{
			set{ _rcitemtitle=value;}
			get{return _rcitemtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCItemLink
		{
			set{ _rcitemlink=value;}
			get{return _rcitemlink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCItemCategory
		{
			set{ _rcitemcategory=value;}
			get{return _rcitemcategory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCItemAuthor
		{
			set{ _rcitemauthor=value;}
			get{return _rcitemauthor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RCItemPubDate
		{
			set{ _rcitempubdate=value;}
			get{return _rcitempubdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCItemDescription
		{
			set{ _rcitemdescription=value;}
			get{return _rcitemdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCItemComments
		{
			set{ _rcitemcomments=value;}
			get{return _rcitemcomments;}
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

