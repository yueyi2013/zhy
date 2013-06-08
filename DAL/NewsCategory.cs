using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:NewsCategory
	/// </summary>
	public partial class NewsCategory : BaseDAL
	{
		public NewsCategory()
		{}

        #region 成员方法



        #endregion

        #region  BasicMethod
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NewsCategoryId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NewsCategory");
			strSql.Append(" where NewsCategoryId=@NewsCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsCategoryId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.NewsCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NewsCategory(");
			strSql.Append("NewsCategoryName,NewsCategoryDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@NewsCategoryName,@NewsCategoryDesc,@NavCreateAt,@NavCreateBy,@NavUpdateDT,@NavUpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsCategoryName", SqlDbType.VarChar,10),
					new SqlParameter("@NewsCategoryDesc", SqlDbType.VarChar,30),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10)};
			parameters[0].Value = model.NewsCategoryName;
			parameters[1].Value = model.NewsCategoryDesc;
			parameters[2].Value = model.NavCreateAt;
			parameters[3].Value = model.NavCreateBy;
			parameters[4].Value = model.NavUpdateDT;
			parameters[5].Value = model.NavUpdateBy;

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
		public bool Update(ZHY.Model.NewsCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NewsCategory set ");
			strSql.Append("NewsCategoryName=@NewsCategoryName,");
			strSql.Append("NewsCategoryDesc=@NewsCategoryDesc,");
			strSql.Append("NavCreateAt=@NavCreateAt,");
			strSql.Append("NavCreateBy=@NavCreateBy,");
			strSql.Append("NavUpdateDT=@NavUpdateDT,");
			strSql.Append("NavUpdateBy=@NavUpdateBy");
			strSql.Append(" where NewsCategoryId=@NewsCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsCategoryName", SqlDbType.VarChar,10),
					new SqlParameter("@NewsCategoryDesc", SqlDbType.VarChar,30),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NewsCategoryId", SqlDbType.Int,4)};
			parameters[0].Value = model.NewsCategoryName;
			parameters[1].Value = model.NewsCategoryDesc;
			parameters[2].Value = model.NavCreateAt;
			parameters[3].Value = model.NavCreateBy;
			parameters[4].Value = model.NavUpdateDT;
			parameters[5].Value = model.NavUpdateBy;
			parameters[6].Value = model.NewsCategoryId;

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
		public bool Delete(int NewsCategoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsCategory ");
			strSql.Append(" where NewsCategoryId=@NewsCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsCategoryId;

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
		public bool DeleteList(string NewsCategoryIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsCategory ");
			strSql.Append(" where NewsCategoryId in ("+NewsCategoryIdlist + ")  ");
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
		public ZHY.Model.NewsCategory GetModel(int NewsCategoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NewsCategoryId,NewsCategoryName,NewsCategoryDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy from NewsCategory ");
			strSql.Append(" where NewsCategoryId=@NewsCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsCategoryId;

			ZHY.Model.NewsCategory model=new ZHY.Model.NewsCategory();
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
		public ZHY.Model.NewsCategory DataRowToModel(DataRow row)
		{
			ZHY.Model.NewsCategory model=new ZHY.Model.NewsCategory();
			if (row != null)
			{
				if(row["NewsCategoryId"]!=null && row["NewsCategoryId"].ToString()!="")
				{
					model.NewsCategoryId=int.Parse(row["NewsCategoryId"].ToString());
				}
				if(row["NewsCategoryName"]!=null)
				{
					model.NewsCategoryName=row["NewsCategoryName"].ToString();
				}
				if(row["NewsCategoryDesc"]!=null)
				{
					model.NewsCategoryDesc=row["NewsCategoryDesc"].ToString();
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
			strSql.Append("select NewsCategoryId,NewsCategoryName,NewsCategoryDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
			strSql.Append(" FROM NewsCategory ");
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
			strSql.Append(" NewsCategoryId,NewsCategoryName,NewsCategoryDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
			strSql.Append(" FROM NewsCategory ");
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
			strSql.Append("select count(1) FROM NewsCategory ");
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
				strSql.Append("order by T.NewsCategoryId desc");
			}
			strSql.Append(")AS Row, T.*  from NewsCategory T ");
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
			parameters[0].Value = "NewsCategory";
			parameters[1].Value = "NewsCategoryId";
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

