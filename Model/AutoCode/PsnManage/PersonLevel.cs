using System;
namespace ZHY.Model
{
	/// <summary>
	/// 成员等级
	/// </summary>
	[Serializable]
	public partial class PersonLevel
	{
		public PersonLevel()
		{}
		#region Model
		private int _psnlevelid;
		private int? _psnleveltypeid;
		private string _psnlevelcode;
		private string _psnlevelname;
		private string _psnleveldesc;
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int PsnLevelId
		{
			set{ _psnlevelid=value;}
			get{return _psnlevelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PsnLevelTypeId
		{
			set{ _psnleveltypeid=value;}
			get{return _psnleveltypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PsnLevelCode
		{
			set{ _psnlevelcode=value;}
			get{return _psnlevelcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PsnLevelName
		{
			set{ _psnlevelname=value;}
			get{return _psnlevelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PsnLevelDesc
		{
			set{ _psnleveldesc=value;}
			get{return _psnleveldesc;}
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

