using System;
namespace ZHY.Model
{
	/// <summary>
	/// ʵ����ProTypeDetail ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProTypeDetail
	{
		public ProTypeDetail()
		{}
		#region Model
		private int _protypeid;
		private int _dtid;
		private string _prodtvalue;
		/// <summary>
		/// 
		/// </summary>
		public int ProTypeID
		{
			set{ _protypeid=value;}
			get{return _protypeid;}
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

