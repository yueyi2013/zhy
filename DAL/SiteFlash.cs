using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:SiteFlash
	/// </summary>
	public partial class SiteFlash : BaseDAL
	{
		public SiteFlash()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SFId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SiteFlash");
			strSql.Append(" where SFId=@SFId");
			SqlParameter[] parameters = {
					new SqlParameter("@SFId", SqlDbType.Int,4)
			};
			parameters[0].Value = SFId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.SiteFlash model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SiteFlash(");
			strSql.Append("SFPicPath,SFDetailsURL,SFConTitle,SFOrder,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@SFPicPath,@SFDetailsURL,@SFConTitle,@SFOrder,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SFPicPath", SqlDbType.VarChar,200),
					new SqlParameter("@SFDetailsURL", SqlDbType.VarChar,200),
					new SqlParameter("@SFConTitle", SqlDbType.VarChar,200),
					new SqlParameter("@SFOrder", SqlDbType.Int,4),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.SFPicPath;
			parameters[1].Value = model.SFDetailsURL;
			parameters[2].Value = model.SFConTitle;
			parameters[3].Value = model.SFOrder;
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
		public bool Update(ZHY.Model.SiteFlash model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SiteFlash set ");
			strSql.Append("SFPicPath=@SFPicPath,");
			strSql.Append("SFDetailsURL=@SFDetailsURL,");
			strSql.Append("SFConTitle=@SFConTitle,");
			strSql.Append("SFOrder=@SFOrder,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where SFId=@SFId");
			SqlParameter[] parameters = {
					new SqlParameter("@SFPicPath", SqlDbType.VarChar,200),
					new SqlParameter("@SFDetailsURL", SqlDbType.VarChar,200),
					new SqlParameter("@SFConTitle", SqlDbType.VarChar,200),
					new SqlParameter("@SFOrder", SqlDbType.Int,4),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@SFId", SqlDbType.Int,4)};
			parameters[0].Value = model.SFPicPath;
			parameters[1].Value = model.SFDetailsURL;
			parameters[2].Value = model.SFConTitle;
			parameters[3].Value = model.SFOrder;
			parameters[4].Value = model.CreateAt;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.UpdateDT;
			parameters[7].Value = model.UpdateBy;
			parameters[8].Value = model.SFId;

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
		public bool Delete(int SFId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SiteFlash ");
			strSql.Append(" where SFId=@SFId");
			SqlParameter[] parameters = {
					new SqlParameter("@SFId", SqlDbType.Int,4)
			};
			parameters[0].Value = SFId;

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
		public bool DeleteList(string SFIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SiteFlash ");
			strSql.Append(" where SFId in ("+SFIdlist + ")  ");
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
		public ZHY.Model.SiteFlash GetModel(int SFId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SFId,SFPicPath,SFDetailsURL,SFConTitle,SFOrder,CreateAt,CreateBy,UpdateDT,UpdateBy from SiteFlash ");
			strSql.Append(" where SFId=@SFId");
			SqlParameter[] parameters = {
					new SqlParameter("@SFId", SqlDbType.Int,4)
			};
			parameters[0].Value = SFId;

			ZHY.Model.SiteFlash model=new ZHY.Model.SiteFlash();
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
		public ZHY.Model.SiteFlash DataRowToModel(DataRow row)
		{
			ZHY.Model.SiteFlash model=new ZHY.Model.SiteFlash();
			if (row != null)
			{
				if(row["SFId"]!=null && row["SFId"].ToString()!="")
				{
					model.SFId=int.Parse(row["SFId"].ToString());
				}
				if(row["SFPicPath"]!=null)
				{
					model.SFPicPath=row["SFPicPath"].ToString();
				}
				if(row["SFDetailsURL"]!=null)
				{
					model.SFDetailsURL=row["SFDetailsURL"].ToString();
				}
				if(row["SFConTitle"]!=null)
				{
					model.SFConTitle=row["SFConTitle"].ToString();
				}
				if(row["SFOrder"]!=null && row["SFOrder"].ToString()!="")
				{
					model.SFOrder=int.Parse(row["SFOrder"].ToString());
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
			strSql.Append("select SFId,SFPicPath,SFDetailsURL,SFConTitle,SFOrder,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM SiteFlash ");
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
			strSql.Append(" SFId,SFPicPath,SFDetailsURL,SFConTitle,SFOrder,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM SiteFlash ");
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
			strSql.Append("select count(1) FROM SiteFlash ");
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
				strSql.Append("order by T.SFId desc");
			}
			strSql.Append(")AS Row, T.*  from SiteFlash T ");
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
			parameters[0].Value = "SiteFlash";
			parameters[1].Value = "SFId";
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

