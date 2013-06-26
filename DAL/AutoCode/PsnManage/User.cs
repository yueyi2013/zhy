using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:User
	/// </summary>
	public partial class User
	{
		public User()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
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
			strSql.Append("UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@UserPsw,@UserMedium,@UserUnitTel,@UserShotNum,@UserMobile,@UserRealName,@RoleID,@UserStatus,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
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
					new SqlParameter("@UserStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserPsw;
			parameters[2].Value = model.UserMedium;
			parameters[3].Value = model.UserUnitTel;
			parameters[4].Value = model.UserShotNum;
			parameters[5].Value = model.UserMobile;
			parameters[6].Value = model.UserRealName;
			parameters[7].Value = model.RoleID;
			parameters[8].Value = model.UserStatus;
			parameters[9].Value = model.CreateAt;
			parameters[10].Value = model.CreateBy;
			parameters[11].Value = model.UpdateDT;
			parameters[12].Value = model.UpdateBy;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.User model)
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
			strSql.Append("UserStatus=@UserStatus,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,64),
					new SqlParameter("@UserPsw", SqlDbType.VarChar,32),
					new SqlParameter("@UserMedium", SqlDbType.VarChar,512),
					new SqlParameter("@UserUnitTel", SqlDbType.VarChar,32),
					new SqlParameter("@UserShotNum", SqlDbType.VarChar,16),
					new SqlParameter("@UserMobile", SqlDbType.VarChar,16),
					new SqlParameter("@UserRealName", SqlDbType.VarChar,80),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@UserStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserPsw;
			parameters[2].Value = model.UserMedium;
			parameters[3].Value = model.UserUnitTel;
			parameters[4].Value = model.UserShotNum;
			parameters[5].Value = model.UserMobile;
			parameters[6].Value = model.UserRealName;
			parameters[7].Value = model.RoleID;
			parameters[8].Value = model.UserStatus;
			parameters[9].Value = model.CreateAt;
			parameters[10].Value = model.CreateBy;
			parameters[11].Value = model.UpdateDT;
			parameters[12].Value = model.UpdateBy;
			parameters[13].Value = model.UserID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.User GetModel(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus,CreateAt,CreateBy,UpdateDT,UpdateBy from Users ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			ZHY.Model.User model=new ZHY.Model.User();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.User DataRowToModel(DataRow row)
		{
			ZHY.Model.User model=new ZHY.Model.User();
			if (row != null)
			{
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserPsw"]!=null)
				{
					model.UserPsw=row["UserPsw"].ToString();
				}
				if(row["UserMedium"]!=null)
				{
					model.UserMedium=row["UserMedium"].ToString();
				}
				if(row["UserUnitTel"]!=null)
				{
					model.UserUnitTel=row["UserUnitTel"].ToString();
				}
				if(row["UserShotNum"]!=null)
				{
					model.UserShotNum=row["UserShotNum"].ToString();
				}
				if(row["UserMobile"]!=null)
				{
					model.UserMobile=row["UserMobile"].ToString();
				}
				if(row["UserRealName"]!=null)
				{
					model.UserRealName=row["UserRealName"].ToString();
				}
				if(row["RoleID"]!=null && row["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(row["RoleID"].ToString());
				}
				if(row["UserStatus"]!=null)
				{
					model.UserStatus=row["UserStatus"].ToString();
				}
				if(row["CreateAt"]!=null && row["CreateAt"].ToString()!="")
				{
					model.CreateAt=DateTime.Parse(row["CreateAt"].ToString());
				}
				if(row["CreateBy"]!=null)
				{
					model.CreateBy=row["CreateBy"].ToString();
				}
				if(row["UpdateDT"]!=null && row["UpdateDT"].ToString()!="")
				{
					model.UpdateDT=DateTime.Parse(row["UpdateDT"].ToString());
				}
				if(row["UpdateBy"]!=null)
				{
					model.UpdateBy=row["UpdateBy"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID,UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
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
			strSql.Append(" UserID,UserName,UserPsw,UserMedium,UserUnitTel,UserShotNum,UserMobile,UserRealName,RoleID,UserStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from Users T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[1].Value = "UserID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

