using System;
namespace ZHY.Model
{
    /// <summary>
    /// 实体类Product 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Product
    {
        public Product()
        { }
        #region Model
        private decimal _proid;
        private string _procode;
        private int? _protypeid;
        private string _proname;
        private string _prodes;
        private decimal? _proprice;
        private DateTime? _proinputdate;
        private DateTime? _propublish;
        private string _prostatus;
        private string _prorecommend;
        private string _proisnew;
        private string _proishot;
        /// <summary>
        /// 
        /// </summary>
        public decimal ProID
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProCode
        {
            set { _procode = value; }
            get { return _procode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProTypeID
        {
            set { _protypeid = value; }
            get { return _protypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProName
        {
            set { _proname = value; }
            get { return _proname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProDes
        {
            set { _prodes = value; }
            get { return _prodes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ProPrice
        {
            set { _proprice = value; }
            get { return _proprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProInputDate
        {
            set { _proinputdate = value; }
            get { return _proinputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProPublish
        {
            set { _propublish = value; }
            get { return _propublish; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProStatus
        {
            set { _prostatus = value; }
            get { return _prostatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProRecommend
        {
            set { _prorecommend = value; }
            get { return _prorecommend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProIsNew
        {
            set { _proisnew = value; }
            get { return _proisnew; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProIsHot
        {
            set { _proishot = value; }
            get { return _proishot; }
        }
        #endregion Model

    }
}

