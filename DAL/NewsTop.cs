using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:NewsTop
	/// </summary>
	public partial class NewsTop:BaseDAL
	{
		public NewsTop()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal NTId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NewsTop");
			strSql.Append(" where NTId=@NTId");
			SqlParameter[] parameters = {
					new SqlParameter("@NTId", SqlDbType.Decimal)
			};
			parameters[0].Value = NTId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.NewsTop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NewsTop(");
			strSql.Append("NTTitle,NTAuthor,NTPubDate,NTContent,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@NTTitle,@NTAuthor,@NTPubDate,@NTContent,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NTTitle", SqlDbType.VarChar,200),
					new SqlParameter("@NTAuthor", SqlDbType.VarChar,10),
					new SqlParameter("@NTPubDate", SqlDbType.DateTime),
					new SqlParameter("@NTContent", SqlDbType.VarChar,-1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.NTTitle;
			parameters[1].Value = model.NTAuthor;
			parameters[2].Value = model.NTPubDate;
			parameters[3].Value = model.NTContent;
			parameters[4].Value = model.CreateAt;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.UpdateDT;
			parameters[7].Value = model.UpdateBy;

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
		public bool Update(ZHY.Model.NewsTop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NewsTop set ");
			strSql.Append("NTTitle=@NTTitle,");
			strSql.Append("NTAuthor=@NTAuthor,");
			strSql.Append("NTPubDate=@NTPubDate,");
			strSql.Append("NTContent=@NTContent,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where NTId=@NTId");
			SqlParameter[] parameters = {
					new SqlParameter("@NTTitle", SqlDbType.VarChar,200),
					new SqlParameter("@NTAuthor", SqlDbType.VarChar,10),
					new SqlParameter("@NTPubDate", SqlDbType.DateTime),
					new SqlParameter("@NTContent", SqlDbType.VarChar,-1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@NTId", SqlDbType.Decimal,9)};
			parameters[0].Value = model.NTTitle;
			parameters[1].Value = model.NTAuthor;
			parameters[2].Value = model.NTPubDate;
			parameters[3].Value = model.NTContent;
			parameters[4].Value = model.CreateAt;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.UpdateDT;
			parameters[7].Value = model.UpdateBy;
			parameters[8].Value = model.NTId;

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
		public bool Delete(decimal NTId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsTop ");
			strSql.Append(" where NTId=@NTId");
			SqlParameter[] parameters = {
					new SqlParameter("@NTId", SqlDbType.Decimal)
			};
			parameters[0].Value = NTId;

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
		public bool DeleteList(string NTIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsTop ");
			strSql.Append(" where NTId in ("+NTIdlist + ")  ");
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
		public ZHY.Model.NewsTop GetModel(decimal NTId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NTId,NTTitle,NTAuthor,NTPubDate,NTContent,CreateAt,CreateBy,UpdateDT,UpdateBy from NewsTop ");
			strSql.Append(" where NTId=@NTId");
			SqlParameter[] parameters = {
					new SqlParameter("@NTId", SqlDbType.Decimal)
			};
			parameters[0].Value = NTId;

			ZHY.Model.NewsTop model=new ZHY.Model.NewsTop();
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
		public ZHY.Model.NewsTop DataRowToModel(DataRow row)
		{
			ZHY.Model.NewsTop model=new ZHY.Model.NewsTop();
			if (row != null)
			{
				if(row["NTId"]!=null && row["NTId"].ToString()!="")
				{
					model.NTId=decimal.Parse(row["NTId"].ToString());
				}
				if(row["NTTitle"]!=null)
				{
					model.NTTitle=row["NTTitle"].ToString();
				}
				if(row["NTAuthor"]!=null)
				{
					model.NTAuthor=row["NTAuthor"].ToString();
				}
				if(row["NTPubDate"]!=null && row["NTPubDate"].ToString()!="")
				{
					model.NTPubDate=DateTime.Parse(row["NTPubDate"].ToString());
				}
				if(row["NTContent"]!=null)
				{
					model.NTContent=row["NTContent"].ToString();
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
			strSql.Append("select NTId,NTTitle,NTAuthor,NTPubDate,NTContent,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM NewsTop ");
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
			strSql.Append(" NTId,NTTitle,NTAuthor,NTPubDate,NTContent,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM NewsTop ");
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
			strSql.Append("select count(1) FROM NewsTop ");
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
				strSql.Append("order by T.NTId desc");
			}
			strSql.Append(")AS Row, T.*  from NewsTop T ");
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
			parameters[0].Value = "NewsTop";
			parameters[1].Value = "NTId";
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

