using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:Role
	/// </summary>
	public partial class Role
	{
		public Role()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Roles");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Roles(");
			strSql.Append("RoleName,RoleDes,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@RoleName,@RoleDes,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,128),
					new SqlParameter("@RoleDes", SqlDbType.VarChar,256),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.RoleDes;
			parameters[2].Value = model.CreateAt;
			parameters[3].Value = model.CreateBy;
			parameters[4].Value = model.UpdateDT;
			parameters[5].Value = model.UpdateBy;

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
		public bool Update(ZHY.Model.Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Roles set ");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("RoleDes=@RoleDes,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,128),
					new SqlParameter("@RoleDes", SqlDbType.VarChar,256),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.RoleDes;
			parameters[2].Value = model.CreateAt;
			parameters[3].Value = model.CreateBy;
			parameters[4].Value = model.UpdateDT;
			parameters[5].Value = model.UpdateBy;
			parameters[6].Value = model.RoleID;

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
		public bool Delete(int RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Roles ");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

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
		public bool DeleteList(string RoleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Roles ");
			strSql.Append(" where RoleID in ("+RoleIDlist + ")  ");
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
		public ZHY.Model.Role GetModel(int RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,RoleName,RoleDes,CreateAt,CreateBy,UpdateDT,UpdateBy from Roles ");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

			ZHY.Model.Role model=new ZHY.Model.Role();
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
		public ZHY.Model.Role DataRowToModel(DataRow row)
		{
			ZHY.Model.Role model=new ZHY.Model.Role();
			if (row != null)
			{
				if(row["RoleID"]!=null && row["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(row["RoleID"].ToString());
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["RoleDes"]!=null)
				{
					model.RoleDes=row["RoleDes"].ToString();
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
			strSql.Append("select RoleID,RoleName,RoleDes,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Roles ");
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
			strSql.Append(" RoleID,RoleName,RoleDes,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Roles ");
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
			strSql.Append("select count(1) FROM Roles ");
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
				strSql.Append("order by T.RoleID desc");
			}
			strSql.Append(")AS Row, T.*  from Roles T ");
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
			parameters[0].Value = "Roles";
			parameters[1].Value = "RoleID";
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

