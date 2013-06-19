using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:ArticleComment
	/// </summary>
	public partial class ArticleComment
	{
		public ArticleComment()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ACMId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArticleComments");
			strSql.Append(" where ACMId=@ACMId");
			SqlParameter[] parameters = {
					new SqlParameter("@ACMId", SqlDbType.Decimal)
			};
			parameters[0].Value = ACMId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.ArticleComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleComments(");
			strSql.Append("ArId,ACMContent,ACMDate,ACMTop,ACMDown,ACMCmtPsn,ACMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@ArId,@ACMContent,@ACMDate,@ACMTop,@ACMDown,@ACMCmtPsn,@ACMStatus,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArId", SqlDbType.Decimal,9),
					new SqlParameter("@ACMContent", SqlDbType.VarChar,1024),
					new SqlParameter("@ACMDate", SqlDbType.DateTime),
					new SqlParameter("@ACMTop", SqlDbType.Int,4),
					new SqlParameter("@ACMDown", SqlDbType.Int,4),
					new SqlParameter("@ACMCmtPsn", SqlDbType.VarChar,64),
					new SqlParameter("@ACMStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ArId;
			parameters[1].Value = model.ACMContent;
			parameters[2].Value = model.ACMDate;
			parameters[3].Value = model.ACMTop;
			parameters[4].Value = model.ACMDown;
			parameters[5].Value = model.ACMCmtPsn;
			parameters[6].Value = model.ACMStatus;
			parameters[7].Value = model.CreateAt;
			parameters[8].Value = model.CreateBy;
			parameters[9].Value = model.UpdateDT;
			parameters[10].Value = model.UpdateBy;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.ArticleComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArticleComments set ");
			strSql.Append("ArId=@ArId,");
			strSql.Append("ACMContent=@ACMContent,");
			strSql.Append("ACMDate=@ACMDate,");
			strSql.Append("ACMTop=@ACMTop,");
			strSql.Append("ACMDown=@ACMDown,");
			strSql.Append("ACMCmtPsn=@ACMCmtPsn,");
			strSql.Append("ACMStatus=@ACMStatus,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where ACMId=@ACMId");
			SqlParameter[] parameters = {
					new SqlParameter("@ArId", SqlDbType.Decimal,9),
					new SqlParameter("@ACMContent", SqlDbType.VarChar,1024),
					new SqlParameter("@ACMDate", SqlDbType.DateTime),
					new SqlParameter("@ACMTop", SqlDbType.Int,4),
					new SqlParameter("@ACMDown", SqlDbType.Int,4),
					new SqlParameter("@ACMCmtPsn", SqlDbType.VarChar,64),
					new SqlParameter("@ACMStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@ACMId", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ArId;
			parameters[1].Value = model.ACMContent;
			parameters[2].Value = model.ACMDate;
			parameters[3].Value = model.ACMTop;
			parameters[4].Value = model.ACMDown;
			parameters[5].Value = model.ACMCmtPsn;
			parameters[6].Value = model.ACMStatus;
			parameters[7].Value = model.CreateAt;
			parameters[8].Value = model.CreateBy;
			parameters[9].Value = model.UpdateDT;
			parameters[10].Value = model.UpdateBy;
			parameters[11].Value = model.ACMId;

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
		public bool Delete(decimal ACMId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleComments ");
			strSql.Append(" where ACMId=@ACMId");
			SqlParameter[] parameters = {
					new SqlParameter("@ACMId", SqlDbType.Decimal)
			};
			parameters[0].Value = ACMId;

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
		public bool DeleteList(string ACMIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleComments ");
			strSql.Append(" where ACMId in ("+ACMIdlist + ")  ");
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
		public ZHY.Model.ArticleComment GetModel(decimal ACMId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ACMId,ArId,ACMContent,ACMDate,ACMTop,ACMDown,ACMCmtPsn,ACMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy from ArticleComments ");
			strSql.Append(" where ACMId=@ACMId");
			SqlParameter[] parameters = {
					new SqlParameter("@ACMId", SqlDbType.Decimal)
			};
			parameters[0].Value = ACMId;

			ZHY.Model.ArticleComment model=new ZHY.Model.ArticleComment();
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
		public ZHY.Model.ArticleComment DataRowToModel(DataRow row)
		{
			ZHY.Model.ArticleComment model=new ZHY.Model.ArticleComment();
			if (row != null)
			{
				if(row["ACMId"]!=null && row["ACMId"].ToString()!="")
				{
					model.ACMId=decimal.Parse(row["ACMId"].ToString());
				}
				if(row["ArId"]!=null && row["ArId"].ToString()!="")
				{
					model.ArId=decimal.Parse(row["ArId"].ToString());
				}
				if(row["ACMContent"]!=null)
				{
					model.ACMContent=row["ACMContent"].ToString();
				}
				if(row["ACMDate"]!=null && row["ACMDate"].ToString()!="")
				{
					model.ACMDate=DateTime.Parse(row["ACMDate"].ToString());
				}
				if(row["ACMTop"]!=null && row["ACMTop"].ToString()!="")
				{
					model.ACMTop=int.Parse(row["ACMTop"].ToString());
				}
				if(row["ACMDown"]!=null && row["ACMDown"].ToString()!="")
				{
					model.ACMDown=int.Parse(row["ACMDown"].ToString());
				}
				if(row["ACMCmtPsn"]!=null)
				{
					model.ACMCmtPsn=row["ACMCmtPsn"].ToString();
				}
				if(row["ACMStatus"]!=null)
				{
					model.ACMStatus=row["ACMStatus"].ToString();
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
			strSql.Append("select ACMId,ArId,ACMContent,ACMDate,ACMTop,ACMDown,ACMCmtPsn,ACMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM ArticleComments ");
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
			strSql.Append(" ACMId,ArId,ACMContent,ACMDate,ACMTop,ACMDown,ACMCmtPsn,ACMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM ArticleComments ");
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
			strSql.Append("select count(1) FROM ArticleComments ");
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
				strSql.Append("order by T.ACMId desc");
			}
			strSql.Append(")AS Row, T.*  from ArticleComments T ");
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
			parameters[0].Value = "ArticleComments";
			parameters[1].Value = "ACMId";
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

