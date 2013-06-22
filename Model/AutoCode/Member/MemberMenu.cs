using System;
namespace ZHY.Model
{
	/// <summary>
	/// ª·‘±≤Àµ•¿∏
	/// </summary>
	[Serializable]
	public partial class MemberMenu
	{
		public MemberMenu()
		{}
		#region Model
		private decimal _mmid;
		private string _mmname;
		private int? _mmorder=1;
		private string _mmpicpath;
		private string _mmdesc;
		private string _mmstatus="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby="°Æsyihy.com°Ø";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="°Æsyihy.com°Ø";
		/// <summary>
		/// 
		/// </summary>
		public decimal MMId
		{
			set{ _mmid=value;}
			get{return _mmid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MMName
		{
			set{ _mmname=value;}
			get{return _mmname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MMOrder
		{
			set{ _mmorder=value;}
			get{return _mmorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MMPicPath
		{
			set{ _mmpicpath=value;}
			get{return _mmpicpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MMDesc
		{
			set{ _mmdesc=value;}
			get{return _mmdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MMStatus
		{
			set{ _mmstatus=value;}
			get{return _mmstatus;}
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

