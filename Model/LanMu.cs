using System;
namespace ZHY.Model
{
	/// <summary>
	/// 实体类LanMu 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class LanMu
	{
		public LanMu()
		{}
		#region Model
		private int _lmid;
		private string _lmcode;
		private int? _parantid;
		private string _lmname;
		private int? _lmorder;
		private int? _lmstyleid;
		private string _lmpage;
		private string _lmstatus;
		private string _lmdes;
		/// <summary>
		/// 
		/// </summary>
		public int LMID
		{
			set{ _lmid=value;}
			get{return _lmid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LMCode
		{
			set{ _lmcode=value;}
			get{return _lmcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParantID
		{
			set{ _parantid=value;}
			get{return _parantid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LMName
		{
			set{ _lmname=value;}
			get{return _lmname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LMOrder
		{
			set{ _lmorder=value;}
			get{return _lmorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LMStyleID
		{
			set{ _lmstyleid=value;}
			get{return _lmstyleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LMPage
		{
			set{ _lmpage=value;}
			get{return _lmpage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LMStatus
		{
			set{ _lmstatus=value;}
			get{return _lmstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LMDes
		{
			set{ _lmdes=value;}
			get{return _lmdes;}
		}
		#endregion Model

	}
}

