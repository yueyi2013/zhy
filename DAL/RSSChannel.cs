using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:RSSChannel
	/// </summary>
    public partial class RSSChannel : BaseDAL
	{
		public RSSChannel()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RCId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RSSChannel");
			strSql.Append(" where RCId=@RCId");
			SqlParameter[] parameters = {
					new SqlParameter("@RCId", SqlDbType.Int,4)
			};
			parameters[0].Value = RCId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.RSSChannel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RSSChannel(");
			strSql.Append("RSSId,RCTitle,RCLink,RCDescription,RCLanguage,RCGenerator,RCPubDate,RCLastBuildDate)");
			strSql.Append(" values (");
			strSql.Append("@RSSId,@RCTitle,@RCLink,@RCDescription,@RCLanguage,@RCGenerator,@RCPubDate,@RCLastBuildDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RSSId", SqlDbType.Int,4),
					new SqlParameter("@RCTitle", SqlDbType.VarChar,20),
					new SqlParameter("@RCLink", SqlDbType.VarChar,100),
					new SqlParameter("@RCDescription", SqlDbType.VarChar,50),
					new SqlParameter("@RCLanguage", SqlDbType.VarChar,10),
					new SqlParameter("@RCGenerator", SqlDbType.VarChar,20),
					new SqlParameter("@RCPubDate", SqlDbType.DateTime),
					new SqlParameter("@RCLastBuildDate", SqlDbType.DateTime)};
			parameters[0].Value = model.RSSId;
			parameters[1].Value = model.RCTitle;
			parameters[2].Value = model.RCLink;
			parameters[3].Value = model.RCDescription;
			parameters[4].Value = model.RCLanguage;
			parameters[5].Value = model.RCGenerator;
			parameters[6].Value = model.RCPubDate;
			parameters[7].Value = model.RCLastBuildDate;

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
		public bool Update(ZHY.Model.RSSChannel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RSSChannel set ");
			strSql.Append("RSSId=@RSSId,");
			strSql.Append("RCTitle=@RCTitle,");
			strSql.Append("RCLink=@RCLink,");
			strSql.Append("RCDescription=@RCDescription,");
			strSql.Append("RCLanguage=@RCLanguage,");
			strSql.Append("RCGenerator=@RCGenerator,");
			strSql.Append("RCPubDate=@RCPubDate,");
			strSql.Append("RCLastBuildDate=@RCLastBuildDate");
			strSql.Append(" where RCId=@RCId");
			SqlParameter[] parameters = {
					new SqlParameter("@RSSId", SqlDbType.Int,4),
					new SqlParameter("@RCTitle", SqlDbType.VarChar,20),
					new SqlParameter("@RCLink", SqlDbType.VarChar,100),
					new SqlParameter("@RCDescription", SqlDbType.VarChar,50),
					new SqlParameter("@RCLanguage", SqlDbType.VarChar,10),
					new SqlParameter("@RCGenerator", SqlDbType.VarChar,20),
					new SqlParameter("@RCPubDate", SqlDbType.DateTime),
					new SqlParameter("@RCLastBuildDate", SqlDbType.DateTime),
					new SqlParameter("@RCId", SqlDbType.Int,4)};
			parameters[0].Value = model.RSSId;
			parameters[1].Value = model.RCTitle;
			parameters[2].Value = model.RCLink;
			parameters[3].Value = model.RCDescription;
			parameters[4].Value = model.RCLanguage;
			parameters[5].Value = model.RCGenerator;
			parameters[6].Value = model.RCPubDate;
			parameters[7].Value = model.RCLastBuildDate;
			parameters[8].Value = model.RCId;

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
		public bool Delete(int RCId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RSSChannel ");
			strSql.Append(" where RCId=@RCId");
			SqlParameter[] parameters = {
					new SqlParameter("@RCId", SqlDbType.Int,4)
			};
			parameters[0].Value = RCId;

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
		public bool DeleteList(string RCIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RSSChannel ");
			strSql.Append(" where RCId in ("+RCIdlist + ")  ");
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
        public ZHY.Model.RSSChannel GetModel(string title)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RCId,RSSId,RCTitle,RCLink,RCDescription,RCLanguage,RCGenerator,RCPubDate,RCLastBuildDate from RSSChannel ");
            strSql.Append(" where RCTitle=@RCTitle");
            SqlParameter[] parameters = {
					new SqlParameter("@RCTitle", SqlDbType.VarChar,20)
			};
            parameters[0].Value = title;

            ZHY.Model.RSSChannel model = new ZHY.Model.RSSChannel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
		public ZHY.Model.RSSChannel GetModel(int RCId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RCId,RSSId,RCTitle,RCLink,RCDescription,RCLanguage,RCGenerator,RCPubDate,RCLastBuildDate from RSSChannel ");
			strSql.Append(" where RCId=@RCId");
			SqlParameter[] parameters = {
					new SqlParameter("@RCId", SqlDbType.Int,4)
			};
			parameters[0].Value = RCId;

			ZHY.Model.RSSChannel model=new ZHY.Model.RSSChannel();
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
		public ZHY.Model.RSSChannel DataRowToModel(DataRow row)
		{
			ZHY.Model.RSSChannel model=new ZHY.Model.RSSChannel();
			if (row != null)
			{
				if(row["RCId"]!=null && row["RCId"].ToString()!="")
				{
					model.RCId=int.Parse(row["RCId"].ToString());
				}
				if(row["RSSId"]!=null && row["RSSId"].ToString()!="")
				{
					model.RSSId=int.Parse(row["RSSId"].ToString());
				}
				if(row["RCTitle"]!=null)
				{
					model.RCTitle=row["RCTitle"].ToString();
				}
				if(row["RCLink"]!=null)
				{
					model.RCLink=row["RCLink"].ToString();
				}
				if(row["RCDescription"]!=null)
				{
					model.RCDescription=row["RCDescription"].ToString();
				}
				if(row["RCLanguage"]!=null)
				{
					model.RCLanguage=row["RCLanguage"].ToString();
				}
				if(row["RCGenerator"]!=null)
				{
					model.RCGenerator=row["RCGenerator"].ToString();
				}
				if(row["RCPubDate"]!=null && row["RCPubDate"].ToString()!="")
				{
					model.RCPubDate=DateTime.Parse(row["RCPubDate"].ToString());
				}
				if(row["RCLastBuildDate"]!=null && row["RCLastBuildDate"].ToString()!="")
				{
					model.RCLastBuildDate=DateTime.Parse(row["RCLastBuildDate"].ToString());
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
			strSql.Append("select RCId,RSSId,RCTitle,RCLink,RCDescription,RCLanguage,RCGenerator,RCPubDate,RCLastBuildDate ");
			strSql.Append(" FROM RSSChannel ");
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
			strSql.Append(" RCId,RSSId,RCTitle,RCLink,RCDescription,RCLanguage,RCGenerator,RCPubDate,RCLastBuildDate ");
			strSql.Append(" FROM RSSChannel ");
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
			strSql.Append("select count(1) FROM RSSChannel ");
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
				strSql.Append("order by T.RCId desc");
			}
			strSql.Append(")AS Row, T.*  from RSSChannel T ");
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
			parameters[0].Value = "RSSChannel";
			parameters[1].Value = "RCId";
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

