using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:NewsSite
	/// </summary>
	public partial class NewsSite : BaseDAL
	{
		public NewsSite()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NewsURLId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NewsSite");
			strSql.Append(" where NewsURLId=@NewsURLId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsURLId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsURLId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.NewsSite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NewsSite(");
			strSql.Append("NewsURL,NewsURLDesc,NewsURLStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@NewsURL,@NewsURLDesc,@NewsURLStatus,@NavCreateAt,@NavCreateBy,@NavUpdateDT,@NavUpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsURL", SqlDbType.VarChar,100),
					new SqlParameter("@NewsURLDesc", SqlDbType.VarChar,50),
					new SqlParameter("@NewsURLStatus", SqlDbType.Char,1),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10)};
			parameters[0].Value = model.NewsURL;
			parameters[1].Value = model.NewsURLDesc;
			parameters[2].Value = model.NewsURLStatus;
			parameters[3].Value = model.NavCreateAt;
			parameters[4].Value = model.NavCreateBy;
			parameters[5].Value = model.NavUpdateDT;
			parameters[6].Value = model.NavUpdateBy;

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
		public bool Update(ZHY.Model.NewsSite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NewsSite set ");
			strSql.Append("NewsURL=@NewsURL,");
			strSql.Append("NewsURLDesc=@NewsURLDesc,");
			strSql.Append("NewsURLStatus=@NewsURLStatus,");
			strSql.Append("NavCreateAt=@NavCreateAt,");
			strSql.Append("NavCreateBy=@NavCreateBy,");
			strSql.Append("NavUpdateDT=@NavUpdateDT,");
			strSql.Append("NavUpdateBy=@NavUpdateBy");
			strSql.Append(" where NewsURLId=@NewsURLId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsURL", SqlDbType.VarChar,100),
					new SqlParameter("@NewsURLDesc", SqlDbType.VarChar,50),
					new SqlParameter("@NewsURLStatus", SqlDbType.Char,1),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NewsURLId", SqlDbType.Int,4)};
			parameters[0].Value = model.NewsURL;
			parameters[1].Value = model.NewsURLDesc;
			parameters[2].Value = model.NewsURLStatus;
			parameters[3].Value = model.NavCreateAt;
			parameters[4].Value = model.NavCreateBy;
			parameters[5].Value = model.NavUpdateDT;
			parameters[6].Value = model.NavUpdateBy;
			parameters[7].Value = model.NewsURLId;

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
		public bool Delete(int NewsURLId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsSite ");
			strSql.Append(" where NewsURLId=@NewsURLId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsURLId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsURLId;

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
		public bool DeleteList(string NewsURLIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsSite ");
			strSql.Append(" where NewsURLId in ("+NewsURLIdlist + ")  ");
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
		public ZHY.Model.NewsSite GetModel(int NewsURLId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NewsURLId,NewsURL,NewsURLDesc,NewsURLStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy from NewsSite ");
			strSql.Append(" where NewsURLId=@NewsURLId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsURLId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsURLId;

			ZHY.Model.NewsSite model=new ZHY.Model.NewsSite();
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
		public ZHY.Model.NewsSite DataRowToModel(DataRow row)
		{
			ZHY.Model.NewsSite model=new ZHY.Model.NewsSite();
			if (row != null)
			{
				if(row["NewsURLId"]!=null && row["NewsURLId"].ToString()!="")
				{
					model.NewsURLId=int.Parse(row["NewsURLId"].ToString());
				}
				if(row["NewsURL"]!=null)
				{
					model.NewsURL=row["NewsURL"].ToString();
				}
				if(row["NewsURLDesc"]!=null)
				{
					model.NewsURLDesc=row["NewsURLDesc"].ToString();
				}
				if(row["NewsURLStatus"]!=null)
				{
					model.NewsURLStatus=row["NewsURLStatus"].ToString();
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
			strSql.Append("select NewsURLId,NewsURL,NewsURLDesc,NewsURLStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
			strSql.Append(" FROM NewsSite ");
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
			strSql.Append(" NewsURLId,NewsURL,NewsURLDesc,NewsURLStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
			strSql.Append(" FROM NewsSite ");
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
			strSql.Append("select count(1) FROM NewsSite ");
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
				strSql.Append("order by T.NewsURLId desc");
			}
			strSql.Append(")AS Row, T.*  from NewsSite T ");
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
			parameters[0].Value = "NewsSite";
			parameters[1].Value = "NewsURLId";
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

