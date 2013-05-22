using System;
namespace ZHY.Model
{
	/// <summary>
	/// 实体类ProPicture 。(属性说明自动提取数据库字段的描述信息)
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

