using System;
namespace ZHY.Model
{
	/// <summary>
	/// ÍøÕ¾
	/// </summary>
	[Serializable]
	public partial class VirtualSite
	{
		public VirtualSite()
		{}
		#region Model
		private decimal _vsid;
		private string _vscode;
		private string _vsname;
		private string _vsurl;
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// ÍøÕ¾±àºÅ
		/// </summary>
		public decimal VSId
		{
			set{ _vsid=value;}
			get{return _vsid;}
		}
		/// <summary>
		/// ÍøÕ¾±àÂë
		/// </summary>
		public string VSCode
		{
			set{ _vscode=value;}
			get{return _vscode;}
		}
		/// <summary>
		/// ÍøÕ¾Ãû
		/// </summary>
		public string VSName
		{
			set{ _vsname=value;}
			get{return _vsname;}
		}
		/// <summary>
		/// µØÖ·
		/// </summary>
		public string VSURL
		{
			set{ _vsurl=value;}
			get{return _vsurl;}
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

