using System;
using System.Xml.Serialization;
namespace ZHY.Model
{
	/// <summary>
	/// RSSSite:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [XmlRootAttribute("rss")]
	[Serializable]    
	public partial class RSSSite
	{
		public RSSSite()
		{}
		#region Model
        [XmlIgnore]
		private int _rssid;
        [XmlIgnore]
		private string _rssurl;
        [XmlIgnore]
		private string _rsssource;
        [XmlIgnore]
		private string _rssdesc;
        [XmlIgnore]
		private DateTime? _navcreateat= DateTime.Now;
        [XmlIgnore]
		private string _navcreateby;
        [XmlIgnore]
		private DateTime? _navupdatedt= DateTime.Now;
        [XmlIgnore]
		private string _navupdateby;
        [XmlIgnore]
        private RSSChannel objChannel;

        public RSSChannel ObjChannel
        {
            get { return objChannel; }
            set { objChannel = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int RSSId
		{
			set{ _rssid=value;}
			get{return _rssid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RSSURL
		{
			set{ _rssurl=value;}
			get{return _rssurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RSSSource
		{
			set{ _rsssource=value;}
			get{return _rsssource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RSSDesc
		{
			set{ _rssdesc=value;}
			get{return _rssdesc;}
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

