using System;
namespace ZHY.Model
{
    /// <summary>
    /// ʵ����Role ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class Role
    {
        public Role()
        { }
        #region Model
        private int _roleid;
        private string _rolename;
        private string _roledes;
        /// <summary>
        /// 
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoleDes
        {
            set { _roledes = value; }
            get { return _roledes; }
        }
        #endregion Model

    }
}

