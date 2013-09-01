using System;
namespace ZHY.Model
{
	/// <summary>
	/// 代理地址
	/// </summary>
	[Serializable]
	public partial class ProxyAddress
	{
		public ProxyAddress()
		{}
		#region Model
		private int _paid;
		private string _paname;
		private string _patype;
		private string _paanonymity;
		private string _pacountry;
		private DateTime? _createat= DateTime.Now;
		private string _createby="syihy.com";
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby="syihy.com";
		/// <summary>
		/// 编号
		/// </summary>
		public int PAId
		{
			set{ _paid=value;}
			get{return _paid;}
		}
		/// <summary>
		/// 地址名称
		/// </summary>
		public string PAName
		{
			set{ _paname=value;}
			get{return _paname;}
		}
		/// <summary>
		/// 代理类型
		/// </summary>
		public string PAType
		{
			set{ _patype=value;}
			get{return _patype;}
		}
		/// <summary>
		/// 匿名
		/// </summary>
		public string PAAnonymity
		{
			set{ _paanonymity=value;}
			get{return _paanonymity;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string PACountry
		{
			set{ _pacountry=value;}
			get{return _pacountry;}
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

