using System;
namespace ZHY.Model
{
	/// <summary>
	/// »®œﬁ≈‰÷√
	/// </summary>
	[Serializable]
	public partial class RightConfig
	{
		public RightConfig()
		{}
		#region Model
		private int _ricid;
		private int? _funid;
		private int? _roleid;
		private string _ricidstatus="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public int RiCId
		{
			set{ _ricid=value;}
			get{return _ricid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FunID
		{
			set{ _funid=value;}
			get{return _funid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RiCIdStatus
		{
			set{ _ricidstatus=value;}
			get{return _ricidstatus;}
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

