using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:VirtualTask
	/// </summary>
	public partial class VirtualTask
	{
		public VirtualTask()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal VTId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VirtualTask");
			strSql.Append(" where VTId=@VTId");
			SqlParameter[] parameters = {
					new SqlParameter("@VTId", SqlDbType.Decimal)
			};
			parameters[0].Value = VTId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.VirtualTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VirtualTask(");
			strSql.Append("VTUserName,VTPassword,VTProxy,VSCode,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@VTUserName,@VTPassword,@VTProxy,@VSCode,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@VTUserName", SqlDbType.VarChar,32),
					new SqlParameter("@VTPassword", SqlDbType.VarChar,32),
					new SqlParameter("@VTProxy", SqlDbType.VarChar,32),
					new SqlParameter("@VSCode", SqlDbType.VarChar,16),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.VTUserName;
			parameters[1].Value = model.VTPassword;
			parameters[2].Value = model.VTProxy;
			parameters[3].Value = model.VSCode;
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
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.VirtualTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VirtualTask set ");
			strSql.Append("VTUserName=@VTUserName,");
			strSql.Append("VTPassword=@VTPassword,");
			strSql.Append("VTProxy=@VTProxy,");
			strSql.Append("VSCode=@VSCode,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where VTId=@VTId");
			SqlParameter[] parameters = {
					new SqlParameter("@VTUserName", SqlDbType.VarChar,32),
					new SqlParameter("@VTPassword", SqlDbType.VarChar,32),
					new SqlParameter("@VTProxy", SqlDbType.VarChar,32),
					new SqlParameter("@VSCode", SqlDbType.VarChar,16),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@VTId", SqlDbType.Decimal,9)};
			parameters[0].Value = model.VTUserName;
			parameters[1].Value = model.VTPassword;
			parameters[2].Value = model.VTProxy;
			parameters[3].Value = model.VSCode;
			parameters[4].Value = model.CreateAt;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.UpdateDT;
			parameters[7].Value = model.UpdateBy;
			parameters[8].Value = model.VTId;

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
		public bool Delete(decimal VTId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VirtualTask ");
			strSql.Append(" where VTId=@VTId");
			SqlParameter[] parameters = {
					new SqlParameter("@VTId", SqlDbType.Decimal)
			};
			parameters[0].Value = VTId;

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
		public bool DeleteList(string VTIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VirtualTask ");
			strSql.Append(" where VTId in ("+VTIdlist + ")  ");
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
		public ZHY.Model.VirtualTask GetModel(decimal VTId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 VTId,VTUserName,VTPassword,VTProxy,VSCode,CreateAt,CreateBy,UpdateDT,UpdateBy from VirtualTask ");
			strSql.Append(" where VTId=@VTId");
			SqlParameter[] parameters = {
					new SqlParameter("@VTId", SqlDbType.Decimal)
			};
			parameters[0].Value = VTId;

			ZHY.Model.VirtualTask model=new ZHY.Model.VirtualTask();
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
		public ZHY.Model.VirtualTask DataRowToModel(DataRow row)
		{
			ZHY.Model.VirtualTask model=new ZHY.Model.VirtualTask();
			if (row != null)
			{
				if(row["VTId"]!=null && row["VTId"].ToString()!="")
				{
					model.VTId=decimal.Parse(row["VTId"].ToString());
				}
				if(row["VTUserName"]!=null)
				{
					model.VTUserName=row["VTUserName"].ToString();
				}
				if(row["VTPassword"]!=null)
				{
					model.VTPassword=row["VTPassword"].ToString();
				}
				if(row["VTProxy"]!=null)
				{
					model.VTProxy=row["VTProxy"].ToString();
				}
				if(row["VSCode"]!=null)
				{
					model.VSCode=row["VSCode"].ToString();
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
			strSql.Append("select VTId,VTUserName,VTPassword,VTProxy,VSCode,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM VirtualTask ");
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
			strSql.Append(" VTId,VTUserName,VTPassword,VTProxy,VSCode,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM VirtualTask ");
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
			strSql.Append("select count(1) FROM VirtualTask ");
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
				strSql.Append("order by T.VTId desc");
			}
			strSql.Append(")AS Row, T.*  from VirtualTask T ");
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
			parameters[0].Value = "VirtualTask";
			parameters[1].Value = "VTId";
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

