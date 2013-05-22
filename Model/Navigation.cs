using System;
namespace ZHY.Model
{
	/// <summary>
	/// Ê×Ò³µ¼º½À¸
	/// </summary>
	[Serializable]
	public partial class Navigation
	{
		public Navigation()
		{}
		#region Model
		private int _navid;
		private string _navname;
		private string _navlink;
		private int? _navparantid=0;
		private string _navclass;
		private int? _navorder;
		private string _navdesc;
		private string _navstatus="A";
		private DateTime? _navcreateat= DateTime.Now;
		private string _navcreateby;
		private DateTime? _navupdatedt= DateTime.Now;
		private string _navupdateby;
		/// <summary>
		/// 
		/// </summary>
		public int NavId
		{
			set{ _navid=value;}
			get{return _navid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavName
		{
			set{ _navname=value;}
			get{return _navname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavLink
		{
			set{ _navlink=value;}
			get{return _navlink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NavParantId
		{
			set{ _navparantid=value;}
			get{return _navparantid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavClass
		{
			set{ _navclass=value;}
			get{return _navclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NavOrder
		{
			set{ _navorder=value;}
			get{return _navorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavDesc
		{
			set{ _navdesc=value;}
			get{return _navdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavStatus
		{
			set{ _navstatus=value;}
			get{return _navstatus;}
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

