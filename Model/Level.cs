using System;
namespace ZHY.Model
{
	/// <summary>
	/// 实体类Level 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Level
	{
		public Level()
		{}
		#region Model
		private int _levelid;
		private string _levelname;
		/// <summary>
		/// 
		/// </summary>
		public int LevelID
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LevelName
		{
			set{ _levelname=value;}
			get{return _levelname;}
		}
		#endregion Model

	}
}

