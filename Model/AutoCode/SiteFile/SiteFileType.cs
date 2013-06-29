using System;
namespace ZHY.Model
{
	/// <summary>
	/// 文件类型
	/// </summary>
	[Serializable]
	public partial class SiteFileType
	{
		public SiteFileType()
		{}
		#region Model
		private int _sitefiletypeid;
		private string _sitefiletypename;
		private string _sitefiletypeicon;
		private string _sitefiletypedesc;
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int SiteFileTypeId
		{
			set{ _sitefiletypeid=value;}
			get{return _sitefiletypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SiteFileTypeName
		{
			set{ _sitefiletypename=value;}
			get{return _sitefiletypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SiteFileTypeIcon
		{
			set{ _sitefiletypeicon=value;}
			get{return _sitefiletypeicon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SiteFileTypeDesc
		{
			set{ _sitefiletypedesc=value;}
			get{return _sitefiletypedesc;}
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

