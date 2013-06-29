using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:SiteFile
	/// </summary>
	public partial class SiteFile
	{
		public SiteFile()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SiteFileId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SiteFile");
			strSql.Append(" where SiteFileId=@SiteFileId");
			SqlParameter[] parameters = {
					new SqlParameter("@SiteFileId", SqlDbType.Int,4)
			};
			parameters[0].Value = SiteFileId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.SiteFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SiteFile(");
			strSql.Append("SiteFileTypeId,SiteFileName,SiteFilePath,SiteFileDesc,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@SiteFileTypeId,@SiteFileName,@SiteFilePath,@SiteFileDesc,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SiteFileTypeId", SqlDbType.Int,4),
					new SqlParameter("@SiteFileName", SqlDbType.VarChar,64),
					new SqlParameter("@SiteFilePath", SqlDbType.VarChar,256),
					new SqlParameter("@SiteFileDesc", SqlDbType.VarChar,128),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.SiteFileTypeId;
			parameters[1].Value = model.SiteFileName;
			parameters[2].Value = model.SiteFilePath;
			parameters[3].Value = model.SiteFileDesc;
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
		public bool Update(ZHY.Model.SiteFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SiteFile set ");
			strSql.Append("SiteFileTypeId=@SiteFileTypeId,");
			strSql.Append("SiteFileName=@SiteFileName,");
			strSql.Append("SiteFilePath=@SiteFilePath,");
			strSql.Append("SiteFileDesc=@SiteFileDesc,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where SiteFileId=@SiteFileId");
			SqlParameter[] parameters = {
					new SqlParameter("@SiteFileTypeId", SqlDbType.Int,4),
					new SqlParameter("@SiteFileName", SqlDbType.VarChar,64),
					new SqlParameter("@SiteFilePath", SqlDbType.VarChar,256),
					new SqlParameter("@SiteFileDesc", SqlDbType.VarChar,128),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@SiteFileId", SqlDbType.Int,4)};
			parameters[0].Value = model.SiteFileTypeId;
			parameters[1].Value = model.SiteFileName;
			parameters[2].Value = model.SiteFilePath;
			parameters[3].Value = model.SiteFileDesc;
			parameters[4].Value = model.CreateAt;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.UpdateDT;
			parameters[7].Value = model.UpdateBy;
			parameters[8].Value = model.SiteFileId;

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
		public bool Delete(int SiteFileId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SiteFile ");
			strSql.Append(" where SiteFileId=@SiteFileId");
			SqlParameter[] parameters = {
					new SqlParameter("@SiteFileId", SqlDbType.Int,4)
			};
			parameters[0].Value = SiteFileId;

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
		public bool DeleteList(string SiteFileIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SiteFile ");
			strSql.Append(" where SiteFileId in ("+SiteFileIdlist + ")  ");
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
		public ZHY.Model.SiteFile GetModel(int SiteFileId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SiteFileId,SiteFileTypeId,SiteFileName,SiteFilePath,SiteFileDesc,CreateAt,CreateBy,UpdateDT,UpdateBy from SiteFile ");
			strSql.Append(" where SiteFileId=@SiteFileId");
			SqlParameter[] parameters = {
					new SqlParameter("@SiteFileId", SqlDbType.Int,4)
			};
			parameters[0].Value = SiteFileId;

			ZHY.Model.SiteFile model=new ZHY.Model.SiteFile();
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
		public ZHY.Model.SiteFile DataRowToModel(DataRow row)
		{
			ZHY.Model.SiteFile model=new ZHY.Model.SiteFile();
			if (row != null)
			{
				if(row["SiteFileId"]!=null && row["SiteFileId"].ToString()!="")
				{
					model.SiteFileId=int.Parse(row["SiteFileId"].ToString());
				}
				if(row["SiteFileTypeId"]!=null && row["SiteFileTypeId"].ToString()!="")
				{
					model.SiteFileTypeId=int.Parse(row["SiteFileTypeId"].ToString());
				}
				if(row["SiteFileName"]!=null)
				{
					model.SiteFileName=row["SiteFileName"].ToString();
				}
				if(row["SiteFilePath"]!=null)
				{
					model.SiteFilePath=row["SiteFilePath"].ToString();
				}
				if(row["SiteFileDesc"]!=null)
				{
					model.SiteFileDesc=row["SiteFileDesc"].ToString();
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
			strSql.Append("select SiteFileId,SiteFileTypeId,SiteFileName,SiteFilePath,SiteFileDesc,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM SiteFile ");
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
			strSql.Append(" SiteFileId,SiteFileTypeId,SiteFileName,SiteFilePath,SiteFileDesc,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM SiteFile ");
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
			strSql.Append("select count(1) FROM SiteFile ");
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
				strSql.Append("order by T.SiteFileId desc");
			}
			strSql.Append(")AS Row, T.*  from SiteFile T ");
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
			parameters[0].Value = "SiteFile";
			parameters[1].Value = "SiteFileId";
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

