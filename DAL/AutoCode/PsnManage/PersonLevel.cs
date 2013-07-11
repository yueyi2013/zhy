using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:PersonLevel
	/// </summary>
	public partial class PersonLevel
	{
		public PersonLevel()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PsnLevelId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PersonLevel");
			strSql.Append(" where PsnLevelId=@PsnLevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@PsnLevelId", SqlDbType.Int,4)
			};
			parameters[0].Value = PsnLevelId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.PersonLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PersonLevel(");
			strSql.Append("PsnLevelTypeId,PsnLevelCode,PsnLevelName,PsnLevelDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@PsnLevelTypeId,@PsnLevelCode,@PsnLevelName,@PsnLevelDesc,@Status,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PsnLevelTypeId", SqlDbType.Int,4),
					new SqlParameter("@PsnLevelCode", SqlDbType.VarChar,64),
					new SqlParameter("@PsnLevelName", SqlDbType.VarChar,64),
					new SqlParameter("@PsnLevelDesc", SqlDbType.VarChar,200),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.PsnLevelTypeId;
			parameters[1].Value = model.PsnLevelCode;
			parameters[2].Value = model.PsnLevelName;
			parameters[3].Value = model.PsnLevelDesc;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreateAt;
			parameters[6].Value = model.CreateBy;
			parameters[7].Value = model.UpdateDT;
			parameters[8].Value = model.UpdateBy;

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
		public bool Update(ZHY.Model.PersonLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PersonLevel set ");
			strSql.Append("PsnLevelTypeId=@PsnLevelTypeId,");
			strSql.Append("PsnLevelCode=@PsnLevelCode,");
			strSql.Append("PsnLevelName=@PsnLevelName,");
			strSql.Append("PsnLevelDesc=@PsnLevelDesc,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where PsnLevelId=@PsnLevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@PsnLevelTypeId", SqlDbType.Int,4),
					new SqlParameter("@PsnLevelCode", SqlDbType.VarChar,64),
					new SqlParameter("@PsnLevelName", SqlDbType.VarChar,64),
					new SqlParameter("@PsnLevelDesc", SqlDbType.VarChar,200),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@PsnLevelId", SqlDbType.Int,4)};
			parameters[0].Value = model.PsnLevelTypeId;
			parameters[1].Value = model.PsnLevelCode;
			parameters[2].Value = model.PsnLevelName;
			parameters[3].Value = model.PsnLevelDesc;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreateAt;
			parameters[6].Value = model.CreateBy;
			parameters[7].Value = model.UpdateDT;
			parameters[8].Value = model.UpdateBy;
			parameters[9].Value = model.PsnLevelId;

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
		public bool Delete(int PsnLevelId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonLevel ");
			strSql.Append(" where PsnLevelId=@PsnLevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@PsnLevelId", SqlDbType.Int,4)
			};
			parameters[0].Value = PsnLevelId;

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
		public bool DeleteList(string PsnLevelIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonLevel ");
			strSql.Append(" where PsnLevelId in ("+PsnLevelIdlist + ")  ");
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
		public ZHY.Model.PersonLevel GetModel(int PsnLevelId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PsnLevelId,PsnLevelTypeId,PsnLevelCode,PsnLevelName,PsnLevelDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy from PersonLevel ");
			strSql.Append(" where PsnLevelId=@PsnLevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@PsnLevelId", SqlDbType.Int,4)
			};
			parameters[0].Value = PsnLevelId;

			ZHY.Model.PersonLevel model=new ZHY.Model.PersonLevel();
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
		public ZHY.Model.PersonLevel DataRowToModel(DataRow row)
		{
			ZHY.Model.PersonLevel model=new ZHY.Model.PersonLevel();
			if (row != null)
			{
				if(row["PsnLevelId"]!=null && row["PsnLevelId"].ToString()!="")
				{
					model.PsnLevelId=int.Parse(row["PsnLevelId"].ToString());
				}
				if(row["PsnLevelTypeId"]!=null && row["PsnLevelTypeId"].ToString()!="")
				{
					model.PsnLevelTypeId=int.Parse(row["PsnLevelTypeId"].ToString());
				}
				if(row["PsnLevelCode"]!=null)
				{
					model.PsnLevelCode=row["PsnLevelCode"].ToString();
				}
				if(row["PsnLevelName"]!=null)
				{
					model.PsnLevelName=row["PsnLevelName"].ToString();
				}
				if(row["PsnLevelDesc"]!=null)
				{
					model.PsnLevelDesc=row["PsnLevelDesc"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
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
			strSql.Append("select PsnLevelId,PsnLevelTypeId,PsnLevelCode,PsnLevelName,PsnLevelDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM PersonLevel ");
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
			strSql.Append(" PsnLevelId,PsnLevelTypeId,PsnLevelCode,PsnLevelName,PsnLevelDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM PersonLevel ");
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
			strSql.Append("select count(1) FROM PersonLevel ");
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
				strSql.Append("order by T.PsnLevelId desc");
			}
			strSql.Append(")AS Row, T.*  from PersonLevel T ");
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
			parameters[0].Value = "PersonLevel";
			parameters[1].Value = "PsnLevelId";
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

