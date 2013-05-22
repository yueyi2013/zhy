using System;
namespace ZHY.Model
{
    /// <summary>
    /// 实体类Detail 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Detail
    {
        public Detail()
        { }
        #region Model
        private int _dtid;
        private string _dtname;
        private string _dtdesc;
        private int? _dtorder;
        /// <summary>
        /// 
        /// </summary>
        public int DtID
        {
            set { _dtid = value; }
            get { return _dtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DtName
        {
            set { _dtname = value; }
            get { return _dtname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DtDesc
        {
            set { _dtdesc = value; }
            get { return _dtdesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DtOrder
        {
            set { _dtorder = value; }
            get { return _dtorder; }
        }
        #endregion Model

    }
}

