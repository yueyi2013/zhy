using System;
namespace ZHY.Model
{
    /// <summary>
    /// 实体类Menu 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Menu
    {
        public Menu()
        { }
        #region Model
        private int _menuid;
        private string _menuname;
        private string _menudes;
        private string _menupicpath;
        private int? _parantid;
        private int? _menuorder;
        private int? _funid;
        /// <summary>
        /// 
        /// </summary>
        public int MenuID
        {
            set { _menuid = value; }
            get { return _menuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MenuName
        {
            set { _menuname = value; }
            get { return _menuname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MenuDes
        {
            set { _menudes = value; }
            get { return _menudes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MenuPicPath
        {
            set { _menupicpath = value; }
            get { return _menupicpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParantID
        {
            set { _parantid = value; }
            get { return _parantid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MenuOrder
        {
            set { _menuorder = value; }
            get { return _menuorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FunID
        {
            set { _funid = value; }
            get { return _funid; }
        }
        #endregion Model

    }
}

