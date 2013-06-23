using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:Member
	/// </summary>
	public partial class Member
	{
		public Member()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MemID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Members");
			strSql.Append(" where MemID=@MemID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemID", SqlDbType.Decimal)
			};
			parameters[0].Value = MemID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Members(");
			strSql.Append("MemAccount,MemPsw,PsnLevelId,MemMail,MemStatus,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@MemAccount,@MemPsw,@PsnLevelId,@MemMail,@MemStatus,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MemAccount", SqlDbType.VarChar,64),
					new SqlParameter("@MemPsw", SqlDbType.VarChar,64),
					new SqlParameter("@PsnLevelId", SqlDbType.Int,4),
					new SqlParameter("@MemMail", SqlDbType.VarChar,64),
					new SqlParameter("@MemStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.MemAccount;
			parameters[1].Value = model.MemPsw;
			parameters[2].Value = model.PsnLevelId;
			parameters[3].Value = model.MemMail;
			parameters[4].Value = model.MemStatus;
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
		public bool Update(ZHY.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Members set ");
			strSql.Append("MemAccount=@MemAccount,");
			strSql.Append("MemPsw=@MemPsw,");
			strSql.Append("PsnLevelId=@PsnLevelId,");
			strSql.Append("MemMail=@MemMail,");
			strSql.Append("MemStatus=@MemStatus,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where MemID=@MemID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemAccount", SqlDbType.VarChar,64),
					new SqlParameter("@MemPsw", SqlDbType.VarChar,64),
					new SqlParameter("@PsnLevelId", SqlDbType.Int,4),
					new SqlParameter("@MemMail", SqlDbType.VarChar,64),
					new SqlParameter("@MemStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@MemID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.MemAccount;
			parameters[1].Value = model.MemPsw;
			parameters[2].Value = model.PsnLevelId;
			parameters[3].Value = model.MemMail;
			parameters[4].Value = model.MemStatus;
			parameters[5].Value = model.CreateAt;
			parameters[6].Value = model.CreateBy;
			parameters[7].Value = model.UpdateDT;
			parameters[8].Value = model.UpdateBy;
			parameters[9].Value = model.MemID;

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
		public bool Delete(decimal MemID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Members ");
			strSql.Append(" where MemID=@MemID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemID", SqlDbType.Decimal)
			};
			parameters[0].Value = MemID;

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
		public bool DeleteList(string MemIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Members ");
			strSql.Append(" where MemID in ("+MemIDlist + ")  ");
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
		public ZHY.Model.Member GetModel(decimal MemID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MemID,MemAccount,MemPsw,PsnLevelId,MemMail,MemStatus,CreateAt,CreateBy,UpdateDT,UpdateBy from Members ");
			strSql.Append(" where MemID=@MemID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemID", SqlDbType.Decimal)
			};
			parameters[0].Value = MemID;

			ZHY.Model.Member model=new ZHY.Model.Member();
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
		public ZHY.Model.Member DataRowToModel(DataRow row)
		{
			ZHY.Model.Member model=new ZHY.Model.Member();
			if (row != null)
			{
				if(row["MemID"]!=null && row["MemID"].ToString()!="")
				{
					model.MemID=decimal.Parse(row["MemID"].ToString());
				}
				if(row["MemAccount"]!=null)
				{
					model.MemAccount=row["MemAccount"].ToString();
				}
				if(row["MemPsw"]!=null)
				{
					model.MemPsw=row["MemPsw"].ToString();
				}
				if(row["PsnLevelId"]!=null && row["PsnLevelId"].ToString()!="")
				{
					model.PsnLevelId=int.Parse(row["PsnLevelId"].ToString());
				}
				if(row["MemMail"]!=null)
				{
					model.MemMail=row["MemMail"].ToString();
				}
				if(row["MemStatus"]!=null)
				{
					model.MemStatus=row["MemStatus"].ToString();
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
			strSql.Append("select MemID,MemAccount,MemPsw,PsnLevelId,MemMail,MemStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Members ");
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
			strSql.Append(" MemID,MemAccount,MemPsw,PsnLevelId,MemMail,MemStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Members ");
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
			strSql.Append("select count(1) FROM Members ");
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
				strSql.Append("order by T.MemID desc");
			}
			strSql.Append(")AS Row, T.*  from Members T ");
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
			parameters[0].Value = "Members";
			parameters[1].Value = "MemID";
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

