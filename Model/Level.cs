using System;
namespace ZHY.Model
{
	/// <summary>
	/// ʵ����Level ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

