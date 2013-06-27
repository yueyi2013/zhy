using System;
namespace ZHY.Model
{
	/// <summary>
	/// 等级类型
	/// </summary>
	[Serializable]
	public partial class PsnLevelType
	{
		public PsnLevelType()
		{}
		#region Model
		private int _psnleveltypeid;
		private string _psnleveltypename;
		private string _psnleveltypedesc;
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int PsnLevelTypeId
		{
			set{ _psnleveltypeid=value;}
			get{return _psnleveltypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PsnLevelTypeName
		{
			set{ _psnleveltypename=value;}
			get{return _psnleveltypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PsnLevelTypeDesc
		{
			set{ _psnleveltypedesc=value;}
			get{return _psnleveltypedesc;}
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

