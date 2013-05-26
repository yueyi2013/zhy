using System;
namespace ZHY.Model
{
	/// <summary>
	/// ProType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProType
	{
		public ProType()
		{}
		#region Model
		private int _protypeid;
		private string _protypename;
		private string _protypedesc;
		private string _prostatus="A";
		/// <summary>
		/// 
		/// </summary>
		public int ProTypeID
		{
			set{ _protypeid=value;}
			get{return _protypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProTypeName
		{
			set{ _protypename=value;}
			get{return _protypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProTypeDesc
		{
			set{ _protypedesc=value;}
			get{return _protypedesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProStatus
		{
			set{ _prostatus=value;}
			get{return _prostatus;}
		}
		#endregion Model

	}
}

