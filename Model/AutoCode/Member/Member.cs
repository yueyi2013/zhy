using System;
namespace ZHY.Model
{
	/// <summary>
	/// ª·‘±Œ¨ª§
	/// </summary>
	[Serializable]
	public partial class Member
	{
		public Member()
		{}
		#region Model
		private decimal _memid;
		private string _memaccount;
		private string _mempsw="123456789";
		private int? _psnlevelid;
		private string _memmail;
		private string _memstatus="I";
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public decimal MemID
		{
			set{ _memid=value;}
			get{return _memid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemAccount
		{
			set{ _memaccount=value;}
			get{return _memaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemPsw
		{
			set{ _mempsw=value;}
			get{return _mempsw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PsnLevelId
		{
			set{ _psnlevelid=value;}
			get{return _psnlevelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemMail
		{
			set{ _memmail=value;}
			get{return _memmail;}
		}
		/// <summary>
		/// I-nactive,A-ctive
		/// </summary>
		public string MemStatus
		{
			set{ _memstatus=value;}
			get{return _memstatus;}
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

