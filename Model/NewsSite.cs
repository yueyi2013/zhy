using System;
namespace ZHY.Model
{
	/// <summary>
	/// NewsSite:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NewsSite
	{
		public NewsSite()
		{}
		#region Model
		private int _newsurlid;
		private string _newsurl;
		private string _newsurldesc;
		private string _newsurlstatus="A";
		private DateTime? _navcreateat= DateTime.Now;
		private string _navcreateby;
		private DateTime? _navupdatedt= DateTime.Now;
		private string _navupdateby;
		/// <summary>
		/// 
		/// </summary>
		public int NewsURLId
		{
			set{ _newsurlid=value;}
			get{return _newsurlid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsURL
		{
			set{ _newsurl=value;}
			get{return _newsurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsURLDesc
		{
			set{ _newsurldesc=value;}
			get{return _newsurldesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsURLStatus
		{
			set{ _newsurlstatus=value;}
			get{return _newsurlstatus;}
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

