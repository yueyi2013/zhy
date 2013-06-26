using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����User��
	/// </summary>
	public partial class User :BaseDAL
	{
		#region  ��Ա����

        /// <summary>
        /// ��֤��¼�û�
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="userpsw">����</param>
        /// <returns></returns>
        public bool ValidateUser(string username, string userpsw, ZHY.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Users");
            strSql.Append(" where UserName=@UserName and UserPsw=@UserPsw ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,64),
                    new SqlParameter("@UserPsw", SqlDbType.VarChar,32)};
            parameters[0].Value = username;
            parameters[1].Value = userpsw;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserPsw = ds.Tables[0].Rows[0]["UserPsw"].ToString();
                model.UserMedium = ds.Tables[0].Rows[0]["UserMedium"].ToString();
                model.UserUnitTel = ds.Tables[0].Rows[0]["UserUnitTel"].ToString();
                model.UserShotNum = ds.Tables[0].Rows[0]["UserShotNum"].ToString();
                model.UserMobile = ds.Tables[0].Rows[0]["UserMobile"].ToString();
                model.UserRealName = ds.Tables[0].Rows[0]["UserRealName"].ToString();
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                model.UserStatus = ds.Tables[0].Rows[0]["UserStatus"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
	}
}

