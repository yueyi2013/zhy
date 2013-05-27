using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:NewsInfo
	/// </summary>
	public partial class NewsInfo
	{
		public NewsInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal NewsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NewsInfo");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Decimal)
			};
			parameters[0].Value = NewsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.NewsInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NewsInfo(");
			strSql.Append("NewsTitle,NewsPubDate,NewsAuthor,NewsCategory,NewsIndustry,NewsSource,NewsContents,NewsStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@NewsTitle,@NewsPubDate,@NewsAuthor,@NewsCategory,@NewsIndustry,@NewsSource,@NewsContents,@NewsStatus,@NavCreateAt,@NavCreateBy,@NavUpdateDT,@NavUpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsTitle", SqlDbType.VarChar,30),
					new SqlParameter("@NewsPubDate", SqlDbType.DateTime),
					new SqlParameter("@NewsAuthor", SqlDbType.VarChar,10),
					new SqlParameter("@NewsCategory", SqlDbType.Int,4),
					new SqlParameter("@NewsIndustry", SqlDbType.VarChar,10),
					new SqlParameter("@NewsSource", SqlDbType.VarChar,30),
					new SqlParameter("@NewsContents", SqlDbType.Text),
					new SqlParameter("@NewsStatus", SqlDbType.Char,1),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10)};
			parameters[0].Value = model.NewsTitle;
			parameters[1].Value = model.NewsPubDate;
			parameters[2].Value = model.NewsAuthor;
			parameters[3].Value = model.NewsCategory;
			parameters[4].Value = model.NewsIndustry;
			parameters[5].Value = model.NewsSource;
			parameters[6].Value = model.NewsContents;
			parameters[7].Value = model.NewsStatus;
			parameters[8].Value = model.NavCreateAt;
			parameters[9].Value = model.NavCreateBy;
			parameters[10].Value = model.NavUpdateDT;
			parameters[11].Value = model.NavUpdateBy;

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
		public bool Update(ZHY.Model.NewsInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NewsInfo set ");
			strSql.Append("NewsTitle=@NewsTitle,");
			strSql.Append("NewsPubDate=@NewsPubDate,");
			strSql.Append("NewsAuthor=@NewsAuthor,");
			strSql.Append("NewsCategory=@NewsCategory,");
			strSql.Append("NewsIndustry=@NewsIndustry,");
			strSql.Append("NewsSource=@NewsSource,");
			strSql.Append("NewsContents=@NewsContents,");
			strSql.Append("NewsStatus=@NewsStatus,");
			strSql.Append("NavCreateAt=@NavCreateAt,");
			strSql.Append("NavCreateBy=@NavCreateBy,");
			strSql.Append("NavUpdateDT=@NavUpdateDT,");
			strSql.Append("NavUpdateBy=@NavUpdateBy");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsTitle", SqlDbType.VarChar,30),
					new SqlParameter("@NewsPubDate", SqlDbType.DateTime),
					new SqlParameter("@NewsAuthor", SqlDbType.VarChar,10),
					new SqlParameter("@NewsCategory", SqlDbType.Int,4),
					new SqlParameter("@NewsIndustry", SqlDbType.VarChar,10),
					new SqlParameter("@NewsSource", SqlDbType.VarChar,30),
					new SqlParameter("@NewsContents", SqlDbType.Text),
					new SqlParameter("@NewsStatus", SqlDbType.Char,1),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NewsId", SqlDbType.Decimal,5)};
			parameters[0].Value = model.NewsTitle;
			parameters[1].Value = model.NewsPubDate;
			parameters[2].Value = model.NewsAuthor;
			parameters[3].Value = model.NewsCategory;
			parameters[4].Value = model.NewsIndustry;
			parameters[5].Value = model.NewsSource;
			parameters[6].Value = model.NewsContents;
			parameters[7].Value = model.NewsStatus;
			parameters[8].Value = model.NavCreateAt;
			parameters[9].Value = model.NavCreateBy;
			parameters[10].Value = model.NavUpdateDT;
			parameters[11].Value = model.NavUpdateBy;
			parameters[12].Value = model.NewsId;

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
		public bool Delete(decimal NewsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsInfo ");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Decimal)
			};
			parameters[0].Value = NewsId;

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
		public bool DeleteList(string NewsIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsInfo ");
			strSql.Append(" where NewsId in ("+NewsIdlist + ")  ");
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
		public ZHY.Model.NewsInfo GetModel(decimal NewsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NewsId,NewsTitle,NewsPubDate,NewsAuthor,NewsCategory,NewsIndustry,NewsSource,NewsContents,NewsStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy from NewsInfo ");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Decimal)
			};
			parameters[0].Value = NewsId;

			ZHY.Model.NewsInfo model=new ZHY.Model.NewsInfo();
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
		public ZHY.Model.NewsInfo DataRowToModel(DataRow row)
		{
			ZHY.Model.NewsInfo model=new ZHY.Model.NewsInfo();
			if (row != null)
			{
				if(row["NewsId"]!=null && row["NewsId"].ToString()!="")
				{
					model.NewsId=decimal.Parse(row["NewsId"].ToString());
				}
				if(row["NewsTitle"]!=null)
				{
					model.NewsTitle=row["NewsTitle"].ToString();
				}
				if(row["NewsPubDate"]!=null && row["NewsPubDate"].ToString()!="")
				{
					model.NewsPubDate=DateTime.Parse(row["NewsPubDate"].ToString());
				}
				if(row["NewsAuthor"]!=null)
				{
					model.NewsAuthor=row["NewsAuthor"].ToString();
				}
				if(row["NewsCategory"]!=null && row["NewsCategory"].ToString()!="")
				{
					model.NewsCategory=int.Parse(row["NewsCategory"].ToString());
				}
				if(row["NewsIndustry"]!=null)
				{
					model.NewsIndustry=row["NewsIndustry"].ToString();
				}
				if(row["NewsSource"]!=null)
				{
					model.NewsSource=row["NewsSource"].ToString();
				}
				if(row["NewsContents"]!=null)
				{
					model.NewsContents=row["NewsContents"].ToString();
				}
				if(row["NewsStatus"]!=null)
				{
					model.NewsStatus=row["NewsStatus"].ToString();
				}
				if(row["NavCreateAt"]!=null && row["NavCreateAt"].ToString()!="")
				{
					model.NavCreateAt=DateTime.Parse(row["NavCreateAt"].ToString());
				}
				if(row["NavCreateBy"]!=null)
				{
					model.NavCreateBy=row["NavCreateBy"].ToString();
				}
				if(row["NavUpdateDT"]!=null && row["NavUpdateDT"].ToString()!="")
				{
					model.NavUpdateDT=DateTime.Parse(row["NavUpdateDT"].ToString());
				}
				if(row["NavUpdateBy"]!=null)
				{
					model.NavUpdateBy=row["NavUpdateBy"].ToString();
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
			strSql.Append("select NewsId,NewsTitle,NewsPubDate,NewsAuthor,NewsCategory,NewsIndustry,NewsSource,NewsContents,NewsStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
			strSql.Append(" FROM NewsInfo ");
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
			strSql.Append(" NewsId,NewsTitle,NewsPubDate,NewsAuthor,NewsCategory,NewsIndustry,NewsSource,NewsContents,NewsStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
			strSql.Append(" FROM NewsInfo ");
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
			strSql.Append("select count(1) FROM NewsInfo ");
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
				strSql.Append("order by T.NewsId desc");
			}
			strSql.Append(")AS Row, T.*  from NewsInfo T ");
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
			parameters[0].Value = "NewsInfo";
			parameters[1].Value = "NewsId";
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

