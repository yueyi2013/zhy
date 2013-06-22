using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:MemberMenu
	/// </summary>
	public partial class MemberMenu
	{
		public MemberMenu()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MMId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberMenu");
			strSql.Append(" where MMId=@MMId");
			SqlParameter[] parameters = {
					new SqlParameter("@MMId", SqlDbType.Decimal)
			};
			parameters[0].Value = MMId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.MemberMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberMenu(");
			strSql.Append("MMName,MMOrder,MMPicPath,MMDesc,MMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@MMName,@MMOrder,@MMPicPath,@MMDesc,@MMStatus,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MMName", SqlDbType.VarChar,64),
					new SqlParameter("@MMOrder", SqlDbType.Int,4),
					new SqlParameter("@MMPicPath", SqlDbType.VarChar,128),
					new SqlParameter("@MMDesc", SqlDbType.VarChar,128),
					new SqlParameter("@MMStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.MMName;
			parameters[1].Value = model.MMOrder;
			parameters[2].Value = model.MMPicPath;
			parameters[3].Value = model.MMDesc;
			parameters[4].Value = model.MMStatus;
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
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.MemberMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberMenu set ");
			strSql.Append("MMName=@MMName,");
			strSql.Append("MMOrder=@MMOrder,");
			strSql.Append("MMPicPath=@MMPicPath,");
			strSql.Append("MMDesc=@MMDesc,");
			strSql.Append("MMStatus=@MMStatus,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where MMId=@MMId");
			SqlParameter[] parameters = {
					new SqlParameter("@MMName", SqlDbType.VarChar,64),
					new SqlParameter("@MMOrder", SqlDbType.Int,4),
					new SqlParameter("@MMPicPath", SqlDbType.VarChar,128),
					new SqlParameter("@MMDesc", SqlDbType.VarChar,128),
					new SqlParameter("@MMStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@MMId", SqlDbType.Decimal,9)};
			parameters[0].Value = model.MMName;
			parameters[1].Value = model.MMOrder;
			parameters[2].Value = model.MMPicPath;
			parameters[3].Value = model.MMDesc;
			parameters[4].Value = model.MMStatus;
			parameters[5].Value = model.CreateAt;
			parameters[6].Value = model.CreateBy;
			parameters[7].Value = model.UpdateDT;
			parameters[8].Value = model.UpdateBy;
			parameters[9].Value = model.MMId;

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
		public bool Delete(decimal MMId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberMenu ");
			strSql.Append(" where MMId=@MMId");
			SqlParameter[] parameters = {
					new SqlParameter("@MMId", SqlDbType.Decimal)
			};
			parameters[0].Value = MMId;

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
		public bool DeleteList(string MMIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberMenu ");
			strSql.Append(" where MMId in ("+MMIdlist + ")  ");
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
		public ZHY.Model.MemberMenu GetModel(decimal MMId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MMId,MMName,MMOrder,MMPicPath,MMDesc,MMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy from MemberMenu ");
			strSql.Append(" where MMId=@MMId");
			SqlParameter[] parameters = {
					new SqlParameter("@MMId", SqlDbType.Decimal)
			};
			parameters[0].Value = MMId;

			ZHY.Model.MemberMenu model=new ZHY.Model.MemberMenu();
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
		public ZHY.Model.MemberMenu DataRowToModel(DataRow row)
		{
			ZHY.Model.MemberMenu model=new ZHY.Model.MemberMenu();
			if (row != null)
			{
				if(row["MMId"]!=null && row["MMId"].ToString()!="")
				{
					model.MMId=decimal.Parse(row["MMId"].ToString());
				}
				if(row["MMName"]!=null)
				{
					model.MMName=row["MMName"].ToString();
				}
				if(row["MMOrder"]!=null && row["MMOrder"].ToString()!="")
				{
					model.MMOrder=int.Parse(row["MMOrder"].ToString());
				}
				if(row["MMPicPath"]!=null)
				{
					model.MMPicPath=row["MMPicPath"].ToString();
				}
				if(row["MMDesc"]!=null)
				{
					model.MMDesc=row["MMDesc"].ToString();
				}
				if(row["MMStatus"]!=null)
				{
					model.MMStatus=row["MMStatus"].ToString();
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
			strSql.Append("select MMId,MMName,MMOrder,MMPicPath,MMDesc,MMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM MemberMenu ");
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
			strSql.Append(" MMId,MMName,MMOrder,MMPicPath,MMDesc,MMStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM MemberMenu ");
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
			strSql.Append("select count(1) FROM MemberMenu ");
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
				strSql.Append("order by T.MMId desc");
			}
			strSql.Append(")AS Row, T.*  from MemberMenu T ");
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
			parameters[0].Value = "MemberMenu";
			parameters[1].Value = "MMId";
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

