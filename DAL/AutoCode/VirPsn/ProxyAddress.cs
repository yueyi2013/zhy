using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:ProxyAddress
	/// </summary>
	public partial class ProxyAddress
	{
		public ProxyAddress()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PAId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProxyAddress");
			strSql.Append(" where PAId=@PAId");
			SqlParameter[] parameters = {
					new SqlParameter("@PAId", SqlDbType.Int,4)
			};
			parameters[0].Value = PAId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.ProxyAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProxyAddress(");
			strSql.Append("PAName,PAType,PAAnonymity,PACountry,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@PAName,@PAType,@PAAnonymity,@PACountry,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PAName", SqlDbType.VarChar,32),
					new SqlParameter("@PAType", SqlDbType.VarChar,8),
					new SqlParameter("@PAAnonymity", SqlDbType.VarChar,8),
					new SqlParameter("@PACountry", SqlDbType.VarChar,16),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.PAName;
			parameters[1].Value = model.PAType;
			parameters[2].Value = model.PAAnonymity;
			parameters[3].Value = model.PACountry;
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
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.ProxyAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProxyAddress set ");
			strSql.Append("PAName=@PAName,");
			strSql.Append("PAType=@PAType,");
			strSql.Append("PAAnonymity=@PAAnonymity,");
			strSql.Append("PACountry=@PACountry,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where PAId=@PAId");
			SqlParameter[] parameters = {
					new SqlParameter("@PAName", SqlDbType.VarChar,32),
					new SqlParameter("@PAType", SqlDbType.VarChar,8),
					new SqlParameter("@PAAnonymity", SqlDbType.VarChar,8),
					new SqlParameter("@PACountry", SqlDbType.VarChar,16),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@PAId", SqlDbType.Int,4)};
			parameters[0].Value = model.PAName;
			parameters[1].Value = model.PAType;
			parameters[2].Value = model.PAAnonymity;
			parameters[3].Value = model.PACountry;
			parameters[4].Value = model.CreateAt;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.UpdateDT;
			parameters[7].Value = model.UpdateBy;
			parameters[8].Value = model.PAId;

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
		public bool Delete(int PAId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProxyAddress ");
			strSql.Append(" where PAId=@PAId");
			SqlParameter[] parameters = {
					new SqlParameter("@PAId", SqlDbType.Int,4)
			};
			parameters[0].Value = PAId;

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
		public bool DeleteList(string PAIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProxyAddress ");
			strSql.Append(" where PAId in ("+PAIdlist + ")  ");
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
		public ZHY.Model.ProxyAddress GetModel(int PAId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PAId,PAName,PAType,PAAnonymity,PACountry,CreateAt,CreateBy,UpdateDT,UpdateBy from ProxyAddress ");
			strSql.Append(" where PAId=@PAId");
			SqlParameter[] parameters = {
					new SqlParameter("@PAId", SqlDbType.Int,4)
			};
			parameters[0].Value = PAId;

			ZHY.Model.ProxyAddress model=new ZHY.Model.ProxyAddress();
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
		public ZHY.Model.ProxyAddress DataRowToModel(DataRow row)
		{
			ZHY.Model.ProxyAddress model=new ZHY.Model.ProxyAddress();
			if (row != null)
			{
				if(row["PAId"]!=null && row["PAId"].ToString()!="")
				{
					model.PAId=int.Parse(row["PAId"].ToString());
				}
				if(row["PAName"]!=null)
				{
					model.PAName=row["PAName"].ToString();
				}
				if(row["PAType"]!=null)
				{
					model.PAType=row["PAType"].ToString();
				}
				if(row["PAAnonymity"]!=null)
				{
					model.PAAnonymity=row["PAAnonymity"].ToString();
				}
				if(row["PACountry"]!=null)
				{
					model.PACountry=row["PACountry"].ToString();
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
			strSql.Append("select PAId,PAName,PAType,PAAnonymity,PACountry,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM ProxyAddress ");
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
			strSql.Append(" PAId,PAName,PAType,PAAnonymity,PACountry,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM ProxyAddress ");
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
			strSql.Append("select count(1) FROM ProxyAddress ");
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
				strSql.Append("order by T.PAId desc");
			}
			strSql.Append(")AS Row, T.*  from ProxyAddress T ");
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
			parameters[0].Value = "ProxyAddress";
			parameters[1].Value = "PAId";
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

