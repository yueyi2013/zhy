using System;
using ZHY.Common;
namespace ZHY.Model
{
	/// <summary>
	/// Function:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class Function
	{
		public Function()
		{}
		#region Model
		private int _funid;
		private string _funcode;
		private string _funname;
		private string _funpage;
		private string _fundes;
		private DateTime? _createat= DateTime.Now;
		private string _createby;
		private DateTime? _updatedt= DateTime.Now;
		private string _updateby;
		/// <summary>
		/// 
		/// </summary>
		public int FunID
		{
			set{ _funid=value;}
			get{return _funid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FunCode
		{
			set{ _funcode=value;}
			get{return _funcode;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string FunName
		{
			set{
                _funname = value;
            }
            get {
                return _funname;
            }
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string FunPage
		{
			set{ _funpage=value;}
			get{return _funpage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FunDes
		{
			set{
                _fundes = value;
            }
            get { return _fundes; }
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

