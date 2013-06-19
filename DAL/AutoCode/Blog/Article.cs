using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:Article
	/// </summary>
	public partial class Article
	{
		public Article()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ArId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Articles");
			strSql.Append(" where ArId=@ArId");
			SqlParameter[] parameters = {
					new SqlParameter("@ArId", SqlDbType.Decimal)
			};
			parameters[0].Value = ArId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Articles(");
			strSql.Append("ArTitle,ACId,ArTypeId,ArContent,ArAuthor,ArPubDate,ArClicks,ArCmtNumber,ArRecommend,ArIsTop,ArForbidComt,ArStatus,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@ArTitle,@ACId,@ArTypeId,@ArContent,@ArAuthor,@ArPubDate,@ArClicks,@ArCmtNumber,@ArRecommend,@ArIsTop,@ArForbidComt,@ArStatus,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArTitle", SqlDbType.VarChar,200),
					new SqlParameter("@ACId", SqlDbType.Int,4),
					new SqlParameter("@ArTypeId", SqlDbType.Int,4),
					new SqlParameter("@ArContent", SqlDbType.VarChar,-1),
					new SqlParameter("@ArAuthor", SqlDbType.Char,32),
					new SqlParameter("@ArPubDate", SqlDbType.DateTime),
					new SqlParameter("@ArClicks", SqlDbType.Int,4),
					new SqlParameter("@ArCmtNumber", SqlDbType.Int,4),
					new SqlParameter("@ArRecommend", SqlDbType.Char,1),
					new SqlParameter("@ArIsTop", SqlDbType.Char,1),
					new SqlParameter("@ArForbidComt", SqlDbType.Char,1),
					new SqlParameter("@ArStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ArTitle;
			parameters[1].Value = model.ACId;
			parameters[2].Value = model.ArTypeId;
			parameters[3].Value = model.ArContent;
			parameters[4].Value = model.ArAuthor;
			parameters[5].Value = model.ArPubDate;
			parameters[6].Value = model.ArClicks;
			parameters[7].Value = model.ArCmtNumber;
			parameters[8].Value = model.ArRecommend;
			parameters[9].Value = model.ArIsTop;
			parameters[10].Value = model.ArForbidComt;
			parameters[11].Value = model.ArStatus;
			parameters[12].Value = model.CreateAt;
			parameters[13].Value = model.CreateBy;
			parameters[14].Value = model.UpdateDT;
			parameters[15].Value = model.UpdateBy;

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
		public bool Update(ZHY.Model.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Articles set ");
			strSql.Append("ArTitle=@ArTitle,");
			strSql.Append("ACId=@ACId,");
			strSql.Append("ArTypeId=@ArTypeId,");
			strSql.Append("ArContent=@ArContent,");
			strSql.Append("ArAuthor=@ArAuthor,");
			strSql.Append("ArPubDate=@ArPubDate,");
			strSql.Append("ArClicks=@ArClicks,");
			strSql.Append("ArCmtNumber=@ArCmtNumber,");
			strSql.Append("ArRecommend=@ArRecommend,");
			strSql.Append("ArIsTop=@ArIsTop,");
			strSql.Append("ArForbidComt=@ArForbidComt,");
			strSql.Append("ArStatus=@ArStatus,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where ArId=@ArId");
			SqlParameter[] parameters = {
					new SqlParameter("@ArTitle", SqlDbType.VarChar,200),
					new SqlParameter("@ACId", SqlDbType.Int,4),
					new SqlParameter("@ArTypeId", SqlDbType.Int,4),
					new SqlParameter("@ArContent", SqlDbType.VarChar,-1),
					new SqlParameter("@ArAuthor", SqlDbType.Char,32),
					new SqlParameter("@ArPubDate", SqlDbType.DateTime),
					new SqlParameter("@ArClicks", SqlDbType.Int,4),
					new SqlParameter("@ArCmtNumber", SqlDbType.Int,4),
					new SqlParameter("@ArRecommend", SqlDbType.Char,1),
					new SqlParameter("@ArIsTop", SqlDbType.Char,1),
					new SqlParameter("@ArForbidComt", SqlDbType.Char,1),
					new SqlParameter("@ArStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@ArId", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ArTitle;
			parameters[1].Value = model.ACId;
			parameters[2].Value = model.ArTypeId;
			parameters[3].Value = model.ArContent;
			parameters[4].Value = model.ArAuthor;
			parameters[5].Value = model.ArPubDate;
			parameters[6].Value = model.ArClicks;
			parameters[7].Value = model.ArCmtNumber;
			parameters[8].Value = model.ArRecommend;
			parameters[9].Value = model.ArIsTop;
			parameters[10].Value = model.ArForbidComt;
			parameters[11].Value = model.ArStatus;
			parameters[12].Value = model.CreateAt;
			parameters[13].Value = model.CreateBy;
			parameters[14].Value = model.UpdateDT;
			parameters[15].Value = model.UpdateBy;
			parameters[16].Value = model.ArId;

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
		public bool Delete(decimal ArId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Articles ");
			strSql.Append(" where ArId=@ArId");
			SqlParameter[] parameters = {
					new SqlParameter("@ArId", SqlDbType.Decimal)
			};
			parameters[0].Value = ArId;

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
		public bool DeleteList(string ArIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Articles ");
			strSql.Append(" where ArId in ("+ArIdlist + ")  ");
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
		public ZHY.Model.Article GetModel(decimal ArId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ArId,ArTitle,ACId,ArTypeId,ArContent,ArAuthor,ArPubDate,ArClicks,ArCmtNumber,ArRecommend,ArIsTop,ArForbidComt,ArStatus,CreateAt,CreateBy,UpdateDT,UpdateBy from Articles ");
			strSql.Append(" where ArId=@ArId");
			SqlParameter[] parameters = {
					new SqlParameter("@ArId", SqlDbType.Decimal)
			};
			parameters[0].Value = ArId;

			ZHY.Model.Article model=new ZHY.Model.Article();
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
		public ZHY.Model.Article DataRowToModel(DataRow row)
		{
			ZHY.Model.Article model=new ZHY.Model.Article();
			if (row != null)
			{
				if(row["ArId"]!=null && row["ArId"].ToString()!="")
				{
					model.ArId=decimal.Parse(row["ArId"].ToString());
				}
				if(row["ArTitle"]!=null)
				{
					model.ArTitle=row["ArTitle"].ToString();
				}
				if(row["ACId"]!=null && row["ACId"].ToString()!="")
				{
					model.ACId=int.Parse(row["ACId"].ToString());
				}
				if(row["ArTypeId"]!=null && row["ArTypeId"].ToString()!="")
				{
					model.ArTypeId=int.Parse(row["ArTypeId"].ToString());
				}
				if(row["ArContent"]!=null)
				{
					model.ArContent=row["ArContent"].ToString();
				}
				if(row["ArAuthor"]!=null)
				{
					model.ArAuthor=row["ArAuthor"].ToString();
				}
				if(row["ArPubDate"]!=null && row["ArPubDate"].ToString()!="")
				{
					model.ArPubDate=DateTime.Parse(row["ArPubDate"].ToString());
				}
				if(row["ArClicks"]!=null && row["ArClicks"].ToString()!="")
				{
					model.ArClicks=int.Parse(row["ArClicks"].ToString());
				}
				if(row["ArCmtNumber"]!=null && row["ArCmtNumber"].ToString()!="")
				{
					model.ArCmtNumber=int.Parse(row["ArCmtNumber"].ToString());
				}
				if(row["ArRecommend"]!=null)
				{
					model.ArRecommend=row["ArRecommend"].ToString();
				}
				if(row["ArIsTop"]!=null)
				{
					model.ArIsTop=row["ArIsTop"].ToString();
				}
				if(row["ArForbidComt"]!=null)
				{
					model.ArForbidComt=row["ArForbidComt"].ToString();
				}
				if(row["ArStatus"]!=null)
				{
					model.ArStatus=row["ArStatus"].ToString();
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
			strSql.Append("select ArId,ArTitle,ACId,ArTypeId,ArContent,ArAuthor,ArPubDate,ArClicks,ArCmtNumber,ArRecommend,ArIsTop,ArForbidComt,ArStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Articles ");
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
			strSql.Append(" ArId,ArTitle,ACId,ArTypeId,ArContent,ArAuthor,ArPubDate,ArClicks,ArCmtNumber,ArRecommend,ArIsTop,ArForbidComt,ArStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Articles ");
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
			strSql.Append("select count(1) FROM Articles ");
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
				strSql.Append("order by T.ArId desc");
			}
			strSql.Append(")AS Row, T.*  from Articles T ");
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
			parameters[0].Value = "Articles";
			parameters[1].Value = "ArId";
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

