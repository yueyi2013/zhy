using System;
namespace ZHY.Model
{
	/// <summary>
	/// User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User
	{
		public User()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _userpsw;
		private string _usermedium;
		private string _userunittel;
		private string _usershotnum;
		private string _usermobile;
		private string _userrealname;
		private int? _roleid;
		private string _userstatus="1";
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPsw
		{
			set{ _userpsw=value;}
			get{return _userpsw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserMedium
		{
			set{ _usermedium=value;}
			get{return _usermedium;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserUnitTel
		{
			set{ _userunittel=value;}
			get{return _userunittel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserShotNum
		{
			set{ _usershotnum=value;}
			get{return _usershotnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserMobile
		{
			set{ _usermobile=value;}
			get{return _usermobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserRealName
		{
			set{ _userrealname=value;}
			get{return _userrealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserStatus
		{
			set{ _userstatus=value;}
			get{return _userstatus;}
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

