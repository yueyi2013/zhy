using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����:RSSSite
	/// </summary>
    public partial class RSSSite
	{
		public RSSSite()
		{}
		#region  BasicMethod
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RSSId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RSSSite");
			strSql.Append(" where RSSId=@RSSId");
			SqlParameter[] parameters = {
					new SqlParameter("@RSSId", SqlDbType.Int,4)
			};
			parameters[0].Value = RSSId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(ZHY.Model.RSSSite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RSSSite(");
			strSql.Append("RSSURL,RSSSource,RSSDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@RSSURL,@RSSSource,@RSSDesc,@NavCreateAt,@NavCreateBy,@NavUpdateDT,@NavUpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RSSURL", SqlDbType.VarChar,100),
					new SqlParameter("@RSSSource", SqlDbType.Char,10),
					new SqlParameter("@RSSDesc", SqlDbType.VarChar,50),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10)};
			parameters[0].Value = model.RSSURL;
			parameters[1].Value = model.RSSSource;
			parameters[2].Value = model.RSSDesc;
			parameters[3].Value = model.NavCreateAt;
			parameters[4].Value = model.NavCreateBy;
			parameters[5].Value = model.NavUpdateDT;
			parameters[6].Value = model.NavUpdateBy;

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
		/// ����һ������
		/// </summary>
		public bool Update(ZHY.Model.RSSSite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RSSSite set ");
			strSql.Append("RSSURL=@RSSURL,");
			strSql.Append("RSSSource=@RSSSource,");
			strSql.Append("RSSDesc=@RSSDesc,");
			strSql.Append("NavCreateAt=@NavCreateAt,");
			strSql.Append("NavCreateBy=@NavCreateBy,");
			strSql.Append("NavUpdateDT=@NavUpdateDT,");
			strSql.Append("NavUpdateBy=@NavUpdateBy");
			strSql.Append(" where RSSId=@RSSId");
			SqlParameter[] parameters = {
					new SqlParameter("@RSSURL", SqlDbType.VarChar,100),
					new SqlParameter("@RSSSource", SqlDbType.Char,10),
					new SqlParameter("@RSSDesc", SqlDbType.VarChar,50),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10),
					new SqlParameter("@RSSId", SqlDbType.Int,4)};
			parameters[0].Value = model.RSSURL;
			parameters[1].Value = model.RSSSource;
			parameters[2].Value = model.RSSDesc;
			parameters[3].Value = model.NavCreateAt;
			parameters[4].Value = model.NavCreateBy;
			parameters[5].Value = model.NavUpdateDT;
			parameters[6].Value = model.NavUpdateBy;
			parameters[7].Value = model.RSSId;

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
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int RSSId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RSSSite ");
			strSql.Append(" where RSSId=@RSSId");
			SqlParameter[] parameters = {
					new SqlParameter("@RSSId", SqlDbType.Int,4)
			};
			parameters[0].Value = RSSId;

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
		/// ����ɾ������
		/// </summary>
		public bool DeleteList(string RSSIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RSSSite ");
			strSql.Append(" where RSSId in ("+RSSIdlist + ")  ");
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
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.RSSSite GetModel(int RSSId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RSSId,RSSURL,RSSSource,RSSDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy from RSSSite ");
			strSql.Append(" where RSSId=@RSSId");
			SqlParameter[] parameters = {
					new SqlParameter("@RSSId", SqlDbType.Int,4)
			};
			parameters[0].Value = RSSId;

			ZHY.Model.RSSSite model=new ZHY.Model.RSSSite();
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
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.RSSSite DataRowToModel(DataRow row)
		{
			ZHY.Model.RSSSite model=new ZHY.Model.RSSSite();
			if (row != null)
			{
				if(row["RSSId"]!=null && row["RSSId"].ToString()!="")
				{
					model.RSSId=int.Parse(row["RSSId"].ToString());
				}
				if(row["RSSURL"]!=null)
				{
					model.RSSURL=row["RSSURL"].ToString();
				}
				if(row["RSSSource"]!=null)
				{
					model.RSSSource=row["RSSSource"].ToString();
				}
				if(row["RSSDesc"]!=null)
				{
					model.RSSDesc=row["RSSDesc"].ToString();
				}
				if(row["NavCreateAt"]!=null && row["NavCreateAt"].ToString()!="")
				{
					model.NavCreateAt=DateTime.Parse(row["NavCreateAt"].ToString());
				}
				if(row["NavCreateBy"]!=null)
				{
					model.NavCreateBy=row["NavCreateBy"].ToString();
				}
				if(row["NavUpdateDT"]!=null && row["NavUpdateDT"].ToString()!="")
				{
					model.NavUpdateDT=DateTime.Parse(row["NavUpdateDT"].ToString());
				}
				if(row["NavUpdateBy"]!=null)
				{
					model.NavUpdateBy=row["NavUpdateBy"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RSSId,RSSURL,RSSSource,RSSDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
			strSql.Append(" FROM RSSSite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" RSSId,RSSURL,RSSSource,RSSDesc,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
			strSql.Append(" FROM RSSSite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM RSSSite ");
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
		/// ��ҳ��ȡ�����б�
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
				strSql.Append("order by T.RSSId desc");
			}
			strSql.Append(")AS Row, T.*  from RSSSite T ");
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
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "RSSSite";
			parameters[1].Value = "RSSId";
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

