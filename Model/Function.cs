using System;
namespace ZHY.Model
{
    /// <summary>
    /// 实体类Function 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Function
    {
        public Function()
        { }
        #region Model
        private int _funid;
        private string _funcode;
        private string _funname;
        private string _funpage;
        private string _fundes;
        /// <summary>
        /// 
        /// </summary>
        public int FunID
        {
            set { _funid = value; }
            get { return _funid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FunCode
        {
            set { _funcode = value; }
            get { return _funcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FunName
        {
            set { _funname = value; }
            get { return _funname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FunPage
        {
            set { _funpage = value; }
            get { return _funpage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FunDes
        {
            set { _fundes = value; }
            get { return _fundes; }
        }
        #endregion Model

    }
}

