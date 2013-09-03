using System;
namespace ZHY.Model
{
	/// <summary>
	/// 虚拟任务
	/// </summary>
	[Serializable]
	public partial class VirtualTask
	{
		public VirtualTask()
		{}
		#region Model
		private decimal _vtid;
		private string _vtusername;
		private string _vtpassword;
		private string _vtproxy="61.175.223.139:3128";
		private string _vscode="ONE";
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 任务编号
		/// </summary>
		public decimal VTId
		{
			set{ _vtid=value;}
			get{return _vtid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string VTUserName
		{
			set{ _vtusername=value;}
			get{return _vtusername;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string VTPassword
		{
			set{ _vtpassword=value;}
			get{return _vtpassword;}
		}
		/// <summary>
		/// 代理地址
		/// </summary>
		public string VTProxy
		{
			set{ _vtproxy=value;}
			get{return _vtproxy;}
		}
		/// <summary>
		/// 网站编码
		/// </summary>
		public string VSCode
		{
			set{ _vscode=value;}
			get{return _vscode;}
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

