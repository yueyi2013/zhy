using System;
namespace ZHY.Model
{
	/// <summary>
	/// 实体类ProType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProType
	{
		public ProType()
		{}
		#region Model
		private int _protypeid;
		private string _protypename;
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
		#endregion Model

	}
}

