using System;
using System.Collections.Generic;
namespace ZHY.Model
{
	/// <summary>
	/// RSSÆµµÀ
	/// </summary>
	[Serializable]
	public partial class RSSChannel
	{
		public RSSChannel()
		{}
		#region Model
		private int _rcid;
		private int? _rssid;
		private string _rctitle;
		private string _rclink;
		private string _rcdescription;
		private string _rclanguage;
		private string _rcgenerator;
		private DateTime? _rcpubdate= DateTime.Now;
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
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

