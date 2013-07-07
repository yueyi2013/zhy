using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:AdCode
	/// </summary>
	public partial class AdCode
	{
		public AdCode()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AdCodeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AdCode");
			strSql.Append(" where AdCodeId=@AdCodeId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdCodeId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdCodeId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.AdCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AdCode(");
			strSql.Append("AdId,AdCodeCont,AdCodeDesc,AdDefault,Status,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@AdId,@AdCodeCont,@AdCodeDesc,@AdDefault,@Status,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AdId", SqlDbType.Int,4),
					new SqlParameter("@AdCodeCont", SqlDbType.VarChar,1024),
					new SqlParameter("@AdCodeDesc", SqlDbType.VarChar,128),
					new SqlParameter("@AdDefault", SqlDbType.Char,1),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.AdId;
			parameters[1].Value = model.AdCodeCont;
			parameters[2].Value = model.AdCodeDesc;
			parameters[3].Value = model.AdDefault;
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
		public bool Update(ZHY.Model.AdCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AdCode set ");
			strSql.Append("AdId=@AdId,");
			strSql.Append("AdCodeCont=@AdCodeCont,");
			strSql.Append("AdCodeDesc=@AdCodeDesc,");
			strSql.Append("AdDefault=@AdDefault,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where AdCodeId=@AdCodeId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdId", SqlDbType.Int,4),
					new SqlParameter("@AdCodeCont", SqlDbType.VarChar,1024),
					new SqlParameter("@AdCodeDesc", SqlDbType.VarChar,128),
					new SqlParameter("@AdDefault", SqlDbType.Char,1),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@AdCodeId", SqlDbType.Int,4)};
			parameters[0].Value = model.AdId;
			parameters[1].Value = model.AdCodeCont;
			parameters[2].Value = model.AdCodeDesc;
			parameters[3].Value = model.AdDefault;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreateAt;
			parameters[6].Value = model.CreateBy;
			parameters[7].Value = model.UpdateDT;
			parameters[8].Value = model.UpdateBy;
			parameters[9].Value = model.AdCodeId;

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
		public bool Delete(int AdCodeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdCode ");
			strSql.Append(" where AdCodeId=@AdCodeId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdCodeId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdCodeId;

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
		public bool DeleteList(string AdCodeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdCode ");
			strSql.Append(" where AdCodeId in ("+AdCodeIdlist + ")  ");
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
		public ZHY.Model.AdCode GetModel(int AdCodeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AdCodeId,AdId,AdCodeCont,AdCodeDesc,AdDefault,Status,CreateAt,CreateBy,UpdateDT,UpdateBy from AdCode ");
			strSql.Append(" where AdCodeId=@AdCodeId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdCodeId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdCodeId;

			ZHY.Model.AdCode model=new ZHY.Model.AdCode();
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
		public ZHY.Model.AdCode DataRowToModel(DataRow row)
		{
			ZHY.Model.AdCode model=new ZHY.Model.AdCode();
			if (row != null)
			{
				if(row["AdCodeId"]!=null && row["AdCodeId"].ToString()!="")
				{
					model.AdCodeId=int.Parse(row["AdCodeId"].ToString());
				}
				if(row["AdId"]!=null && row["AdId"].ToString()!="")
				{
					model.AdId=int.Parse(row["AdId"].ToString());
				}
				if(row["AdCodeCont"]!=null)
				{
					model.AdCodeCont=row["AdCodeCont"].ToString();
				}
				if(row["AdCodeDesc"]!=null)
				{
					model.AdCodeDesc=row["AdCodeDesc"].ToString();
				}
				if(row["AdDefault"]!=null)
				{
					model.AdDefault=row["AdDefault"].ToString();
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
			strSql.Append("select AdCodeId,AdId,AdCodeCont,AdCodeDesc,AdDefault,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM AdCode ");
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
			strSql.Append(" AdCodeId,AdId,AdCodeCont,AdCodeDesc,AdDefault,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM AdCode ");
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
			strSql.Append("select count(1) FROM AdCode ");
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
				strSql.Append("order by T.AdCodeId desc");
			}
			strSql.Append(")AS Row, T.*  from AdCode T ");
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
			parameters[0].Value = "AdCode";
			parameters[1].Value = "AdCodeId";
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

