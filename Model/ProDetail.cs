using System;
namespace ZHY.Model
{
	/// <summary>
	/// ʵ����ProDetail ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProDetail
	{
		public ProDetail()
		{}
		#region Model
		private int _proid;
		private int _dtid;
		private string _prodtvalue;
		/// <summary>
		/// 
		/// </summary>
		public int ProID
		{
			set{ _proid=value;}
			get{return _proid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DtID
		{
			set{ _dtid=value;}
			get{return _dtid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProDtValue
		{
			set{ _prodtvalue=value;}
			get{return _prodtvalue;}
		}
		#endregion Model

	}
}

