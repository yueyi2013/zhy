using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:AdBilling
	/// </summary>
	public partial class AdBilling
	{
		public AdBilling()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AdBgId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AdBilling");
			strSql.Append(" where AdBgId=@AdBgId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdBgId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdBgId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.AdBilling model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AdBilling(");
			strSql.Append("AdBgCode,AdBgDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@AdBgCode,@AdBgDesc,@Status,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AdBgCode", SqlDbType.VarChar,64),
					new SqlParameter("@AdBgDesc", SqlDbType.VarChar,512),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.AdBgCode;
			parameters[1].Value = model.AdBgDesc;
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
		public bool Update(ZHY.Model.AdBilling model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AdBilling set ");
			strSql.Append("AdBgCode=@AdBgCode,");
			strSql.Append("AdBgDesc=@AdBgDesc,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where AdBgId=@AdBgId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdBgCode", SqlDbType.VarChar,64),
					new SqlParameter("@AdBgDesc", SqlDbType.VarChar,512),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@AdBgId", SqlDbType.Int,4)};
			parameters[0].Value = model.AdBgCode;
			parameters[1].Value = model.AdBgDesc;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.CreateAt;
			parameters[4].Value = model.CreateBy;
			parameters[5].Value = model.UpdateDT;
			parameters[6].Value = model.UpdateBy;
			parameters[7].Value = model.AdBgId;

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
		public bool Delete(int AdBgId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdBilling ");
			strSql.Append(" where AdBgId=@AdBgId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdBgId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdBgId;

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
		public bool DeleteList(string AdBgIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdBilling ");
			strSql.Append(" where AdBgId in ("+AdBgIdlist + ")  ");
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
		public ZHY.Model.AdBilling GetModel(int AdBgId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AdBgId,AdBgCode,AdBgDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy from AdBilling ");
			strSql.Append(" where AdBgId=@AdBgId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdBgId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdBgId;

			ZHY.Model.AdBilling model=new ZHY.Model.AdBilling();
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
		public ZHY.Model.AdBilling DataRowToModel(DataRow row)
		{
			ZHY.Model.AdBilling model=new ZHY.Model.AdBilling();
			if (row != null)
			{
				if(row["AdBgId"]!=null && row["AdBgId"].ToString()!="")
				{
					model.AdBgId=int.Parse(row["AdBgId"].ToString());
				}
				if(row["AdBgCode"]!=null)
				{
					model.AdBgCode=row["AdBgCode"].ToString();
				}
				if(row["AdBgDesc"]!=null)
				{
					model.AdBgDesc=row["AdBgDesc"].ToString();
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
			strSql.Append("select AdBgId,AdBgCode,AdBgDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM AdBilling ");
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
			strSql.Append(" AdBgId,AdBgCode,AdBgDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM AdBilling ");
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
			strSql.Append("select count(1) FROM AdBilling ");
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
				strSql.Append("order by T.AdBgId desc");
			}
			strSql.Append(")AS Row, T.*  from AdBilling T ");
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
			parameters[0].Value = "AdBilling";
			parameters[1].Value = "AdBgId";
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

