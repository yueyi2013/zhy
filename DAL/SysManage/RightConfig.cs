using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Maticsoft.DBUtility;//请先添加引用
using System.Data.SqlClient;

namespace ZHY.DAL
{
    public partial class RightConfig:BaseDAL
    {
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByRoleId(int roleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RightConfig ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)			};
            parameters[0].Value = roleId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
