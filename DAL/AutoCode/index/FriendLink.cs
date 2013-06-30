using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:FriendLink
	/// </summary>
	public partial class FriendLink
	{
		public FriendLink()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FLId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FriendLink");
			strSql.Append(" where FLId=@FLId");
			SqlParameter[] parameters = {
					new SqlParameter("@FLId", SqlDbType.Int,4)
			};
			parameters[0].Value = FLId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.FriendLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FriendLink(");
			strSql.Append("FLName,FLSiteURL,FLSitePic,FLOrder,FLDesc,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@FLName,@FLSiteURL,@FLSitePic,@FLOrder,@FLDesc,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FLName", SqlDbType.VarChar,64),
					new SqlParameter("@FLSiteURL", SqlDbType.VarChar,128),
					new SqlParameter("@FLSitePic", SqlDbType.VarChar,128),
					new SqlParameter("@FLOrder", SqlDbType.Int,4),
					new SqlParameter("@FLDesc", SqlDbType.VarChar,128),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.FLName;
			parameters[1].Value = model.FLSiteURL;
			parameters[2].Value = model.FLSitePic;
			parameters[3].Value = model.FLOrder;
			parameters[4].Value = model.FLDesc;
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
		public bool Update(ZHY.Model.FriendLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FriendLink set ");
			strSql.Append("FLName=@FLName,");
			strSql.Append("FLSiteURL=@FLSiteURL,");
			strSql.Append("FLSitePic=@FLSitePic,");
			strSql.Append("FLOrder=@FLOrder,");
			strSql.Append("FLDesc=@FLDesc,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where FLId=@FLId");
			SqlParameter[] parameters = {
					new SqlParameter("@FLName", SqlDbType.VarChar,64),
					new SqlParameter("@FLSiteURL", SqlDbType.VarChar,128),
					new SqlParameter("@FLSitePic", SqlDbType.VarChar,128),
					new SqlParameter("@FLOrder", SqlDbType.Int,4),
					new SqlParameter("@FLDesc", SqlDbType.VarChar,128),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@FLId", SqlDbType.Int,4)};
			parameters[0].Value = model.FLName;
			parameters[1].Value = model.FLSiteURL;
			parameters[2].Value = model.FLSitePic;
			parameters[3].Value = model.FLOrder;
			parameters[4].Value = model.FLDesc;
			parameters[5].Value = model.CreateAt;
			parameters[6].Value = model.CreateBy;
			parameters[7].Value = model.UpdateDT;
			parameters[8].Value = model.UpdateBy;
			parameters[9].Value = model.FLId;

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
		public bool Delete(int FLId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendLink ");
			strSql.Append(" where FLId=@FLId");
			SqlParameter[] parameters = {
					new SqlParameter("@FLId", SqlDbType.Int,4)
			};
			parameters[0].Value = FLId;

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
		public bool DeleteList(string FLIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendLink ");
			strSql.Append(" where FLId in ("+FLIdlist + ")  ");
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
		public ZHY.Model.FriendLink GetModel(int FLId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FLId,FLName,FLSiteURL,FLSitePic,FLOrder,FLDesc,CreateAt,CreateBy,UpdateDT,UpdateBy from FriendLink ");
			strSql.Append(" where FLId=@FLId");
			SqlParameter[] parameters = {
					new SqlParameter("@FLId", SqlDbType.Int,4)
			};
			parameters[0].Value = FLId;

			ZHY.Model.FriendLink model=new ZHY.Model.FriendLink();
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
		public ZHY.Model.FriendLink DataRowToModel(DataRow row)
		{
			ZHY.Model.FriendLink model=new ZHY.Model.FriendLink();
			if (row != null)
			{
				if(row["FLId"]!=null && row["FLId"].ToString()!="")
				{
					model.FLId=int.Parse(row["FLId"].ToString());
				}
				if(row["FLName"]!=null)
				{
					model.FLName=row["FLName"].ToString();
				}
				if(row["FLSiteURL"]!=null)
				{
					model.FLSiteURL=row["FLSiteURL"].ToString();
				}
				if(row["FLSitePic"]!=null)
				{
					model.FLSitePic=row["FLSitePic"].ToString();
				}
				if(row["FLOrder"]!=null && row["FLOrder"].ToString()!="")
				{
					model.FLOrder=int.Parse(row["FLOrder"].ToString());
				}
				if(row["FLDesc"]!=null)
				{
					model.FLDesc=row["FLDesc"].ToString();
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
			strSql.Append("select FLId,FLName,FLSiteURL,FLSitePic,FLOrder,FLDesc,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM FriendLink ");
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
			strSql.Append(" FLId,FLName,FLSiteURL,FLSitePic,FLOrder,FLDesc,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM FriendLink ");
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
			strSql.Append("select count(1) FROM FriendLink ");
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
				strSql.Append("order by T.FLId desc");
			}
			strSql.Append(")AS Row, T.*  from FriendLink T ");
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
			parameters[0].Value = "FriendLink";
			parameters[1].Value = "FLId";
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

