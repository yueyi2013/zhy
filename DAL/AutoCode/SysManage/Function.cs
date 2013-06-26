using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:Function
	/// </summary>
	public partial class Function
	{
		public Function()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FunID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Functions");
			strSql.Append(" where FunID=@FunID");
			SqlParameter[] parameters = {
					new SqlParameter("@FunID", SqlDbType.Int,4)
			};
			parameters[0].Value = FunID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.Function model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Functions(");
			strSql.Append("FunCode,FunName,FunPage,FunDes,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@FunCode,@FunName,@FunPage,@FunDes,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FunCode", SqlDbType.VarChar,128),
					new SqlParameter("@FunName", SqlDbType.VarChar,256),
					new SqlParameter("@FunPage", SqlDbType.VarChar,128),
					new SqlParameter("@FunDes", SqlDbType.VarChar,512),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.FunCode;
			parameters[1].Value = model.FunName;
			parameters[2].Value = model.FunPage;
			parameters[3].Value = model.FunDes;
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
		public bool Update(ZHY.Model.Function model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Functions set ");
			strSql.Append("FunCode=@FunCode,");
			strSql.Append("FunName=@FunName,");
			strSql.Append("FunPage=@FunPage,");
			strSql.Append("FunDes=@FunDes,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where FunID=@FunID");
			SqlParameter[] parameters = {
					new SqlParameter("@FunCode", SqlDbType.VarChar,128),
					new SqlParameter("@FunName", SqlDbType.VarChar,256),
					new SqlParameter("@FunPage", SqlDbType.VarChar,128),
					new SqlParameter("@FunDes", SqlDbType.VarChar,512),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@FunID", SqlDbType.Int,4)};
			parameters[0].Value = model.FunCode;
			parameters[1].Value = model.FunName;
			parameters[2].Value = model.FunPage;
			parameters[3].Value = model.FunDes;
			parameters[4].Value = model.CreateAt;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.UpdateDT;
			parameters[7].Value = model.UpdateBy;
			parameters[8].Value = model.FunID;

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
		public bool Delete(int FunID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Functions ");
			strSql.Append(" where FunID=@FunID");
			SqlParameter[] parameters = {
					new SqlParameter("@FunID", SqlDbType.Int,4)
			};
			parameters[0].Value = FunID;

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
		public bool DeleteList(string FunIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Functions ");
			strSql.Append(" where FunID in ("+FunIDlist + ")  ");
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
		public ZHY.Model.Function GetModel(int FunID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FunID,FunCode,FunName,FunPage,FunDes,CreateAt,CreateBy,UpdateDT,UpdateBy from Functions ");
			strSql.Append(" where FunID=@FunID");
			SqlParameter[] parameters = {
					new SqlParameter("@FunID", SqlDbType.Int,4)
			};
			parameters[0].Value = FunID;

			ZHY.Model.Function model=new ZHY.Model.Function();
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
		public ZHY.Model.Function DataRowToModel(DataRow row)
		{
			ZHY.Model.Function model=new ZHY.Model.Function();
			if (row != null)
			{
				if(row["FunID"]!=null && row["FunID"].ToString()!="")
				{
					model.FunID=int.Parse(row["FunID"].ToString());
				}
				if(row["FunCode"]!=null)
				{
					model.FunCode=row["FunCode"].ToString();
				}
				if(row["FunName"]!=null)
				{
					model.FunName=row["FunName"].ToString();
				}
				if(row["FunPage"]!=null)
				{
					model.FunPage=row["FunPage"].ToString();
				}
				if(row["FunDes"]!=null)
				{
					model.FunDes=row["FunDes"].ToString();
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
			strSql.Append("select FunID,FunCode,FunName,FunPage,FunDes,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Functions ");
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
			strSql.Append(" FunID,FunCode,FunName,FunPage,FunDes,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Functions ");
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
			strSql.Append("select count(1) FROM Functions ");
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
				strSql.Append("order by T.FunID desc");
			}
			strSql.Append(")AS Row, T.*  from Functions T ");
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
			parameters[0].Value = "Functions";
			parameters[1].Value = "FunID";
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

