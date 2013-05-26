using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:ProType
	/// </summary>
    public partial class ProType : BaseDAL
	{
		public ProType()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProTypes");
			strSql.Append(" where ProTypeID=@ProTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.ProType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProTypes(");
			strSql.Append("ProTypeName,ProTypeDesc,ProStatus)");
			strSql.Append(" values (");
			strSql.Append("@ProTypeName,@ProTypeDesc,@ProStatus)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeName", SqlDbType.VarChar,10),
					new SqlParameter("@ProTypeDesc", SqlDbType.VarChar,20),
					new SqlParameter("@ProStatus", SqlDbType.Char,1)};
			parameters[0].Value = model.ProTypeName;
			parameters[1].Value = model.ProTypeDesc;
			parameters[2].Value = model.ProStatus;

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
		public bool Update(ZHY.Model.ProType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProTypes set ");
			strSql.Append("ProTypeName=@ProTypeName,");
			strSql.Append("ProTypeDesc=@ProTypeDesc,");
			strSql.Append("ProStatus=@ProStatus");
			strSql.Append(" where ProTypeID=@ProTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeName", SqlDbType.VarChar,10),
					new SqlParameter("@ProTypeDesc", SqlDbType.VarChar,20),
					new SqlParameter("@ProStatus", SqlDbType.Char,1),
					new SqlParameter("@ProTypeID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProTypeName;
			parameters[1].Value = model.ProTypeDesc;
			parameters[2].Value = model.ProStatus;
			parameters[3].Value = model.ProTypeID;

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
		public bool Delete(int ProTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProTypes ");
			strSql.Append(" where ProTypeID=@ProTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProTypeID;

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
		public bool DeleteList(string ProTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProTypes ");
			strSql.Append(" where ProTypeID in ("+ProTypeIDlist + ")  ");
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
		public ZHY.Model.ProType GetModel(int ProTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProTypeID,ProTypeName,ProTypeDesc,ProStatus from ProTypes ");
			strSql.Append(" where ProTypeID=@ProTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProTypeID;

			ZHY.Model.ProType model=new ZHY.Model.ProType();
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
		public ZHY.Model.ProType DataRowToModel(DataRow row)
		{
			ZHY.Model.ProType model=new ZHY.Model.ProType();
			if (row != null)
			{
				if(row["ProTypeID"]!=null && row["ProTypeID"].ToString()!="")
				{
					model.ProTypeID=int.Parse(row["ProTypeID"].ToString());
				}
				if(row["ProTypeName"]!=null)
				{
					model.ProTypeName=row["ProTypeName"].ToString();
				}
				if(row["ProTypeDesc"]!=null)
				{
					model.ProTypeDesc=row["ProTypeDesc"].ToString();
				}
				if(row["ProStatus"]!=null)
				{
					model.ProStatus=row["ProStatus"].ToString();
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
			strSql.Append("select ProTypeID,ProTypeName,ProTypeDesc,ProStatus ");
			strSql.Append(" FROM ProTypes ");
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
			strSql.Append(" ProTypeID,ProTypeName,ProTypeDesc,ProStatus ");
			strSql.Append(" FROM ProTypes ");
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
			strSql.Append("select count(1) FROM ProTypes ");
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
				strSql.Append("order by T.ProTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from ProTypes T ");
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
			parameters[0].Value = "ProTypes";
			parameters[1].Value = "ProTypeID";
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

