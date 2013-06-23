using System;
namespace ZHY.Model
{
	/// <summary>
	/// œµÕ≥” œ‰
	/// </summary>
	[Serializable]
	public partial class SystemMail
	{
		public SystemMail()
		{}
		#region Model
		private int _smid;
		private string _smhost;
		private int? _smtimeout;
		private string _smfromaddress;
		private int? _smorder=0;
		private string _smmailpsw;
		private string _smstatus="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public int SMId
		{
			set{ _smid=value;}
			get{return _smid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMHost
		{
			set{ _smhost=value;}
			get{return _smhost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SMTimeout
		{
			set{ _smtimeout=value;}
			get{return _smtimeout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMFromAddress
		{
			set{ _smfromaddress=value;}
			get{return _smfromaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SMOrder
		{
			set{ _smorder=value;}
			get{return _smorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMMailPsw
		{
			set{ _smmailpsw=value;}
			get{return _smmailpsw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMStatus
		{
			set{ _smstatus=value;}
			get{return _smstatus;}
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

