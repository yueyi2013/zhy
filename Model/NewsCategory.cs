using System;
namespace ZHY.Model
{
	/// <summary>
	/// NewsCategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NewsCategory
	{
		public NewsCategory()
		{}
		#region Model
		private int _newscategoryid;
		private string _newscategoryname;
		private string _newscategorydesc;
		private DateTime? _navcreateat= DateTime.Now;
		private string _navcreateby;
		private DateTime? _navupdatedt= DateTime.Now;
		private string _navupdateby;
		/// <summary>
		/// 
		/// </summary>
		public int NewsCategoryId
		{
			set{ _newscategoryid=value;}
			get{return _newscategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsCategoryName
		{
			set{ _newscategoryname=value;}
			get{return _newscategoryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsCategoryDesc
		{
			set{ _newscategorydesc=value;}
			get{return _newscategorydesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NavCreateAt
		{
			set{ _navcreateat=value;}
			get{return _navcreateat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavCreateBy
		{
			set{ _navcreateby=value;}
			get{return _navcreateby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NavUpdateDT
		{
			set{ _navupdatedt=value;}
			get{return _navupdatedt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NavUpdateBy
		{
			set{ _navupdateby=value;}
			get{return _navupdateby;}
		}
		#endregion Model

	}
}

