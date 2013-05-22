using System;
namespace ZHY.Model
{
	/// <summary>
	/// 实体类Member 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Member
	{
		public Member()
		{}
		#region Model
		private decimal _memid;
		private string _memaccount;
		private string _mempsw;
		private int? _levelid;
		private string _memrealname;
		private string _memmobile;
		private string _memshotnum;
		private string _memunittel;
		private string _memmedium;
		private string _memstatus;
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
		public int? LevelID
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemRealName
		{
			set{ _memrealname=value;}
			get{return _memrealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemMobile
		{
			set{ _memmobile=value;}
			get{return _memmobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemShotNum
		{
			set{ _memshotnum=value;}
			get{return _memshotnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemUnitTel
		{
			set{ _memunittel=value;}
			get{return _memunittel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemMedium
		{
			set{ _memmedium=value;}
			get{return _memmedium;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemStatus
		{
			set{ _memstatus=value;}
			get{return _memstatus;}
		}
		#endregion Model

	}
}

