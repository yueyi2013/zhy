using System;
namespace ZHY.Model
{
	/// <summary>
	/// 实体类LMStyle 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class LMStyle
	{
		public LMStyle()
		{}
		#region Model
		private int _lmstyleid;
		private string _lmstylename;
		private string _lmstyleurl;
		/// <summary>
		/// 
		/// </summary>
		public int LMStyleID
		{
			set{ _lmstyleid=value;}
			get{return _lmstyleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LMStyleName
		{
			set{ _lmstylename=value;}
			get{return _lmstylename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LMStyleURL
		{
			set{ _lmstyleurl=value;}
			get{return _lmstyleurl;}
		}
		#endregion Model

	}
}

