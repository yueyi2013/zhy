using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:SystemConfig
	/// </summary>
	public partial class SystemConfig:BaseDAL
	{
		public SystemConfig()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SCId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SystemConfig");
			strSql.Append(" where SCId=@SCId");
			SqlParameter[] parameters = {
					new SqlParameter("@SCId", SqlDbType.Int,4)
			};
			parameters[0].Value = SCId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.SystemConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SystemConfig(");
			strSql.Append("SCAttrName,SCGroup,SCAttrValue,SCAttrValue2,SCAttrType,SCDescription,SCStatus,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@SCAttrName,@SCGroup,@SCAttrValue,@SCAttrValue2,@SCAttrType,@SCDescription,@SCStatus,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SCAttrName", SqlDbType.VarChar,10),
					new SqlParameter("@SCGroup", SqlDbType.VarChar,20),
					new SqlParameter("@SCAttrValue", SqlDbType.VarChar,20),
					new SqlParameter("@SCAttrValue2", SqlDbType.VarChar,20),
					new SqlParameter("@SCAttrType", SqlDbType.VarChar,10),
					new SqlParameter("@SCDescription", SqlDbType.VarChar,50),
					new SqlParameter("@SCStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.SCAttrName;
			parameters[1].Value = model.SCGroup;
			parameters[2].Value = model.SCAttrValue;
			parameters[3].Value = model.SCAttrValue2;
			parameters[4].Value = model.SCAttrType;
			parameters[5].Value = model.SCDescription;
			parameters[6].Value = model.SCStatus;
			parameters[7].Value = model.CreateAt;
			parameters[8].Value = model.CreateBy;
			parameters[9].Value = model.UpdateDT;
			parameters[10].Value = model.UpdateBy;

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
		public bool Update(ZHY.Model.SystemConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SystemConfig set ");
			strSql.Append("SCAttrName=@SCAttrName,");
			strSql.Append("SCGroup=@SCGroup,");
			strSql.Append("SCAttrValue=@SCAttrValue,");
			strSql.Append("SCAttrValue2=@SCAttrValue2,");
			strSql.Append("SCAttrType=@SCAttrType,");
			strSql.Append("SCDescription=@SCDescription,");
			strSql.Append("SCStatus=@SCStatus,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where SCId=@SCId");
			SqlParameter[] parameters = {
					new SqlParameter("@SCAttrName", SqlDbType.VarChar,10),
					new SqlParameter("@SCGroup", SqlDbType.VarChar,20),
					new SqlParameter("@SCAttrValue", SqlDbType.VarChar,20),
					new SqlParameter("@SCAttrValue2", SqlDbType.VarChar,20),
					new SqlParameter("@SCAttrType", SqlDbType.VarChar,10),
					new SqlParameter("@SCDescription", SqlDbType.VarChar,50),
					new SqlParameter("@SCStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@SCId", SqlDbType.Int,4)};
			parameters[0].Value = model.SCAttrName;
			parameters[1].Value = model.SCGroup;
			parameters[2].Value = model.SCAttrValue;
			parameters[3].Value = model.SCAttrValue2;
			parameters[4].Value = model.SCAttrType;
			parameters[5].Value = model.SCDescription;
			parameters[6].Value = model.SCStatus;
			parameters[7].Value = model.CreateAt;
			parameters[8].Value = model.CreateBy;
			parameters[9].Value = model.UpdateDT;
			parameters[10].Value = model.UpdateBy;
			parameters[11].Value = model.SCId;

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
		public bool Delete(int SCId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemConfig ");
			strSql.Append(" where SCId=@SCId");
			SqlParameter[] parameters = {
					new SqlParameter("@SCId", SqlDbType.Int,4)
			};
			parameters[0].Value = SCId;

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
		public bool DeleteList(string SCIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemConfig ");
			strSql.Append(" where SCId in ("+SCIdlist + ")  ");
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
		public ZHY.Model.SystemConfig GetModel(int SCId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SCId,SCAttrName,SCGroup,SCAttrValue,SCAttrValue2,SCAttrType,SCDescription,SCStatus,CreateAt,CreateBy,UpdateDT,UpdateBy from SystemConfig ");
			strSql.Append(" where SCId=@SCId");
			SqlParameter[] parameters = {
					new SqlParameter("@SCId", SqlDbType.Int,4)
			};
			parameters[0].Value = SCId;

			ZHY.Model.SystemConfig model=new ZHY.Model.SystemConfig();
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
		public ZHY.Model.SystemConfig DataRowToModel(DataRow row)
		{
			ZHY.Model.SystemConfig model=new ZHY.Model.SystemConfig();
			if (row != null)
			{
				if(row["SCId"]!=null && row["SCId"].ToString()!="")
				{
					model.SCId=int.Parse(row["SCId"].ToString());
				}
				if(row["SCAttrName"]!=null)
				{
					model.SCAttrName=row["SCAttrName"].ToString();
				}
				if(row["SCGroup"]!=null)
				{
					model.SCGroup=row["SCGroup"].ToString();
				}
				if(row["SCAttrValue"]!=null)
				{
					model.SCAttrValue=row["SCAttrValue"].ToString();
				}
				if(row["SCAttrValue2"]!=null)
				{
					model.SCAttrValue2=row["SCAttrValue2"].ToString();
				}
				if(row["SCAttrType"]!=null)
				{
					model.SCAttrType=row["SCAttrType"].ToString();
				}
				if(row["SCDescription"]!=null)
				{
					model.SCDescription=row["SCDescription"].ToString();
				}
				if(row["SCStatus"]!=null)
				{
					model.SCStatus=row["SCStatus"].ToString();
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
			strSql.Append("select SCId,SCAttrName,SCGroup,SCAttrValue,SCAttrValue2,SCAttrType,SCDescription,SCStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM SystemConfig ");
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
			strSql.Append(" SCId,SCAttrName,SCGroup,SCAttrValue,SCAttrValue2,SCAttrType,SCDescription,SCStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM SystemConfig ");
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
			strSql.Append("select count(1) FROM SystemConfig ");
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
				strSql.Append("order by T.SCId desc");
			}
			strSql.Append(")AS Row, T.*  from SystemConfig T ");
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
			parameters[0].Value = "SystemConfig";
			parameters[1].Value = "SCId";
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

