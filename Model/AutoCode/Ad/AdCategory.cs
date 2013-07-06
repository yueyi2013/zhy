using System;
namespace ZHY.Model
{
	/// <summary>
	/// 广告分类
	/// </summary>
	[Serializable]
	public partial class AdCategory
	{
		public AdCategory()
		{}
		#region Model
		private int _adcategoryid;
		private string _adcategoryname;
		private string _adcategorydesc;
		private string _status="A";
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 
		/// </summary>
		public int AdCategoryId
		{
			set{ _adcategoryid=value;}
			get{return _adcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdCategoryName
		{
			set{ _adcategoryname=value;}
			get{return _adcategoryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdCategoryDesc
		{
			set{ _adcategorydesc=value;}
			get{return _adcategorydesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
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

