using System;
namespace ZHY.Model
{
	/// <summary>
	/// 实体类FriendLink 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class FriendLink
	{
		public FriendLink()
		{}
		#region Model
		private int _flid;
		private string _flname;
		private string _flsite;
		private string _flpic;
		private string _flviewmethod;
		private string _fldes;
		/// <summary>
		/// 
		/// </summary>
		public int FLID
		{
			set{ _flid=value;}
			get{return _flid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLName
		{
			set{ _flname=value;}
			get{return _flname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLSite
		{
			set{ _flsite=value;}
			get{return _flsite;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLPic
		{
			set{ _flpic=value;}
			get{return _flpic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLViewMethod
		{
			set{ _flviewmethod=value;}
			get{return _flviewmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLDes
		{
			set{ _fldes=value;}
			get{return _fldes;}
		}
		#endregion Model

	}
}

