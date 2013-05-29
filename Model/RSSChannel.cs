using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace ZHY.Model
{
	/// <summary>
	/// RSSChannel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
	public partial class RSSChannel
	{
		public RSSChannel()
		{}
		#region Model
        [XmlIgnore()]
		private int _rcid;
        [XmlIgnore()]
		private int? _rssid;
        [XmlElement("title")]
		private string _rctitle;
        [XmlElement("link")]
		private string _rclink;
        [XmlElement("description")]
		private string _rcdescription;
        [XmlElement("language")]
		private string _rclanguage;
        [XmlIgnore()]
		private string _rcgenerator;
        [XmlIgnore()]
		private DateTime? _rcpubdate;
        [XmlIgnore()]
		private DateTime? _rclastbuilddate;
        [XmlIgnore()]
        private IList<RSSChannelItem> itemList;

        public IList<RSSChannelItem> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int RCId
		{
			set{ _rcid=value;}
			get{return _rcid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RSSId
		{
			set{ _rssid=value;}
			get{return _rssid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCTitle
		{
			set{ _rctitle=value;}
			get{return _rctitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCLink
		{
			set{ _rclink=value;}
			get{return _rclink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCDescription
		{
			set{ _rcdescription=value;}
			get{return _rcdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCLanguage
		{
			set{ _rclanguage=value;}
			get{return _rclanguage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCGenerator
		{
			set{ _rcgenerator=value;}
			get{return _rcgenerator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RCPubDate
		{
			set{ _rcpubdate=value;}
			get{return _rcpubdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RCLastBuildDate
		{
			set{ _rclastbuilddate=value;}
			get{return _rclastbuilddate;}
		}
		#endregion Model

	}
}

