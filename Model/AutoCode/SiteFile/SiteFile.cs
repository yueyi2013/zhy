using System;
namespace ZHY.Model
{
	/// <summary>
	/// ÍøÕ¾ÎÄ¼þ
	/// </summary>
	[Serializable]
	public partial class SiteFile
	{
		public SiteFile()
		{}
		#region Model
		private int _sitefileid;
		private int? _sitefiletypeid;
		private string _sitefilename;
		private string _sitefilepath;
		private string _sitefiledesc;
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int SiteFileId
		{
			set{ _sitefileid=value;}
			get{return _sitefileid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SiteFileTypeId
		{
			set{ _sitefiletypeid=value;}
			get{return _sitefiletypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SiteFileName
		{
			set{ _sitefilename=value;}
			get{return _sitefilename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SiteFilePath
		{
			set{ _sitefilepath=value;}
			get{return _sitefilepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SiteFileDesc
		{
			set{ _sitefiledesc=value;}
			get{return _sitefiledesc;}
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

