using System;
namespace ZHY.Model
{
	/// <summary>
	/// SystemConfig:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SystemConfig
	{
		public SystemConfig()
		{}
		#region Model
		private int _scid;
		private string _scattrname;
		private string _scgroup;
		private string _scattrvalue;
		private string _scattrvalue2;
		private string _scattrtype;
		private string _scdescription;
		private string _scstatus="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public int SCId
		{
			set{ _scid=value;}
			get{return _scid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCAttrName
		{
			set{ _scattrname=value;}
			get{return _scattrname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCGroup
		{
			set{ _scgroup=value;}
			get{return _scgroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCAttrValue
		{
			set{ _scattrvalue=value;}
			get{return _scattrvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCAttrValue2
		{
			set{ _scattrvalue2=value;}
			get{return _scattrvalue2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCAttrType
		{
			set{ _scattrtype=value;}
			get{return _scattrtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCDescription
		{
			set{ _scdescription=value;}
			get{return _scdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCStatus
		{
			set{ _scstatus=value;}
			get{return _scstatus;}
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

