using System;
namespace ZHY.Model
{
	/// <summary>
	/// ʵ����ProType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProType
	{
		public ProType()
		{}
		#region Model
		private int _protypeid;
		private string _protypename;
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
		public string ProTypeName
		{
			set{ _protypename=value;}
			get{return _protypename;}
		}
		#endregion Model

	}
}

