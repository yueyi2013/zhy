using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:AdCategory
	/// </summary>
	public partial class AdCategory
	{
		public AdCategory()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AdCategoryId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AdCategory");
			strSql.Append(" where AdCategoryId=@AdCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdCategoryId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.AdCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AdCategory(");
			strSql.Append("AdCategoryName,AdCategoryDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@AdCategoryName,@AdCategoryDesc,@Status,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AdCategoryName", SqlDbType.VarChar,64),
					new SqlParameter("@AdCategoryDesc", SqlDbType.VarChar,128),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.AdCategoryName;
			parameters[1].Value = model.AdCategoryDesc;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.CreateAt;
			parameters[4].Value = model.CreateBy;
			parameters[5].Value = model.UpdateDT;
			parameters[6].Value = model.UpdateBy;

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
		public bool Update(ZHY.Model.AdCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AdCategory set ");
			strSql.Append("AdCategoryName=@AdCategoryName,");
			strSql.Append("AdCategoryDesc=@AdCategoryDesc,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where AdCategoryId=@AdCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdCategoryName", SqlDbType.VarChar,64),
					new SqlParameter("@AdCategoryDesc", SqlDbType.VarChar,128),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@AdCategoryId", SqlDbType.Int,4)};
			parameters[0].Value = model.AdCategoryName;
			parameters[1].Value = model.AdCategoryDesc;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.CreateAt;
			parameters[4].Value = model.CreateBy;
			parameters[5].Value = model.UpdateDT;
			parameters[6].Value = model.UpdateBy;
			parameters[7].Value = model.AdCategoryId;

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
		public bool Delete(int AdCategoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdCategory ");
			strSql.Append(" where AdCategoryId=@AdCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdCategoryId;

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
		public bool DeleteList(string AdCategoryIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdCategory ");
			strSql.Append(" where AdCategoryId in ("+AdCategoryIdlist + ")  ");
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
		public ZHY.Model.AdCategory GetModel(int AdCategoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AdCategoryId,AdCategoryName,AdCategoryDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy from AdCategory ");
			strSql.Append(" where AdCategoryId=@AdCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdCategoryId;

			ZHY.Model.AdCategory model=new ZHY.Model.AdCategory();
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
		public ZHY.Model.AdCategory DataRowToModel(DataRow row)
		{
			ZHY.Model.AdCategory model=new ZHY.Model.AdCategory();
			if (row != null)
			{
				if(row["AdCategoryId"]!=null && row["AdCategoryId"].ToString()!="")
				{
					model.AdCategoryId=int.Parse(row["AdCategoryId"].ToString());
				}
				if(row["AdCategoryName"]!=null)
				{
					model.AdCategoryName=row["AdCategoryName"].ToString();
				}
				if(row["AdCategoryDesc"]!=null)
				{
					model.AdCategoryDesc=row["AdCategoryDesc"].ToString();
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
			strSql.Append("select AdCategoryId,AdCategoryName,AdCategoryDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM AdCategory ");
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
			strSql.Append(" AdCategoryId,AdCategoryName,AdCategoryDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM AdCategory ");
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
			strSql.Append("select count(1) FROM AdCategory ");
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
				strSql.Append("order by T.AdCategoryId desc");
			}
			strSql.Append(")AS Row, T.*  from AdCategory T ");
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
			parameters[0].Value = "AdCategory";
			parameters[1].Value = "AdCategoryId";
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

