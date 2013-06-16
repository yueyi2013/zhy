using System;
namespace ZHY.Model
{
	/// <summary>
	/// ÎÄÕÂÀà±ğ
	/// </summary>
	[Serializable]
	public partial class ArticleCategory
	{
		public ArticleCategory()
		{}
		#region Model
		private int _acid;
		private string _acname;
		private string _acdesc;
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public int ACId
		{
			set{ _acid=value;}
			get{return _acid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ACName
		{
			set{ _acname=value;}
			get{return _acname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ACDesc
		{
			set{ _acdesc=value;}
			get{return _acdesc;}
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

