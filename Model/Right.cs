using System;
namespace ZHY.Model
{
    /// <summary>
    /// 实体类Right 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Right
    {
        public Right()
        { }
        #region Model
        private int _rgid;
        private int? _funid;
        private int? _roleid;
        /// <summary>
        /// 
        /// </summary>
        public int RgID
        {
            set { _rgid = value; }
            get { return _rgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FunID
        {
            set { _funid = value; }
            get { return _funid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        #endregion Model

    }
}

