using System;
namespace ZHY.Model
{
	/// <summary>
	/// ʵ����ProPicture ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProPicture
	{
		public ProPicture()
		{}
		#region Model
        private int _proid;
        private string _propicurl;
        private int? _proorder;
        /// <summary>
        /// 
        /// </summary>
        public int ProID
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProPicURL
        {
            set { _propicurl = value; }
            get { return _propicurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProOrder
        {
            set { _proorder = value; }
            get { return _proorder; }
        }
		#endregion Model

	}
}

