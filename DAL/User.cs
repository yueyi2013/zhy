using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类User。
	/// </summary>
	public class User
	{
		public User()
		{}
		#region  成员方法

        /// <summary>
        /// 验证登录用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userpsw">密码</param>
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

        #region 自动生成代码


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserID", "Users");
        }

        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
			parameters[0].Value = UserID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");
			strSql.Append("UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@UserPsw,@UserMedium,@UserUnitTel,@UserShotNum,@UserMobile,@UserRealName,@RoleID,@UserStatus)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,64),
					new SqlParameter("@UserPsw", SqlDbType.VarChar,32),
					new SqlParameter("@UserMedium", SqlDbType.VarChar,512),
					new SqlParameter("@UserUnitTel", SqlDbType.VarChar,32),
					new SqlParameter("@UserShotNum", SqlDbType.VarChar,16),
					new SqlParameter("@UserMobile", SqlDbType.VarChar,16),
					new SqlParameter("@UserRealName", SqlDbType.VarChar,80),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@UserStatus", SqlDbType.Char,1)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserPsw;
			parameters[2].Value = model.UserMedium;
			parameters[3].Value = model.UserUnitTel;
			parameters[4].Value = model.UserShotNum;
			parameters[5].Value = model.UserMobile;
			parameters[6].Value = model.UserRealName;
			parameters[7].Value = model.RoleID;
			parameters[8].Value = model.UserStatus;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZHY.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserPsw=@UserPsw,");
			strSql.Append("UserMedium=@UserMedium,");
			strSql.Append("UserUnitTel=@UserUnitTel,");
			strSql.Append("UserShotNum=@UserShotNum,");
			strSql.Append("UserMobile=@UserMobile,");
			strSql.Append("UserRealName=@UserRealName,");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("UserStatus=@UserStatus");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,64),
					new SqlParameter("@UserPsw", SqlDbType.VarChar,32),
					new SqlParameter("@UserMedium", SqlDbType.VarChar,512),
					new SqlParameter("@UserUnitTel", SqlDbType.VarChar,32),
					new SqlParameter("@UserShotNum", SqlDbType.VarChar,16),
					new SqlParameter("@UserMobile", SqlDbType.VarChar,16),
					new SqlParameter("@UserRealName", SqlDbType.VarChar,80),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@UserStatus", SqlDbType.Char,1)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.UserPsw;
			parameters[3].Value = model.UserMedium;
			parameters[4].Value = model.UserUnitTel;
			parameters[5].Value = model.UserShotNum;
			parameters[6].Value = model.UserMobile;
			parameters[7].Value = model.UserRealName;
			parameters[8].Value = model.RoleID;
			parameters[9].Value = model.UserStatus;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
			parameters[0].Value = UserID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.User GetModel(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus from Users ");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
			parameters[0].Value = UserID;

			ZHY.Model.User model=new ZHY.Model.User();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.UserPsw=ds.Tables[0].Rows[0]["UserPsw"].ToString();
				model.UserMedium=ds.Tables[0].Rows[0]["UserMedium"].ToString();
				model.UserUnitTel=ds.Tables[0].Rows[0]["UserUnitTel"].ToString();
				model.UserShotNum=ds.Tables[0].Rows[0]["UserShotNum"].ToString();
				model.UserMobile=ds.Tables[0].Rows[0]["UserMobile"].ToString();
				model.UserRealName=ds.Tables[0].Rows[0]["UserRealName"].ToString();
				if(ds.Tables[0].Rows[0]["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
				}
				model.UserStatus=ds.Tables[0].Rows[0]["UserStatus"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID,UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus ");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" UserID,UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus ");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Users";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

