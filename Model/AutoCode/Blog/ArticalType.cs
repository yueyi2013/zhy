using System;
namespace ZHY.Model
{
	/// <summary>
	/// ÎÄÕÂÀàĞÍ
	/// </summary>
	[Serializable]
	public partial class ArticalType
	{
		public ArticalType()
		{}
		#region Model
		private int _atid;
		private string _atname;
		private string _atdesc;
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public int ATId
		{
			set{ _atid=value;}
			get{return _atid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ATName
		{
			set{ _atname=value;}
			get{return _atname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ATDesc
		{
			set{ _atdesc=value;}
			get{return _atdesc;}
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

