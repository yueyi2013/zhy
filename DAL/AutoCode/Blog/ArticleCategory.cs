using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����:ArticleCategory
	/// </summary>
	public partial class ArticleCategory
	{
		public ArticleCategory()
		{}
		#region  BasicMethod
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ACId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArticleCategory");
			strSql.Append(" where ACId=@ACId");
			SqlParameter[] parameters = {
					new SqlParameter("@ACId", SqlDbType.Int,4)
			};
			parameters[0].Value = ACId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(ZHY.Model.ArticleCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleCategory(");
			strSql.Append("ACName,ACDesc,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@ACName,@ACDesc,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ACName", SqlDbType.VarChar,20),
					new SqlParameter("@ACDesc", SqlDbType.VarChar,64),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ACName;
			parameters[1].Value = model.ACDesc;
			parameters[2].Value = model.CreateAt;
			parameters[3].Value = model.CreateBy;
			parameters[4].Value = model.UpdateDT;
			parameters[5].Value = model.UpdateBy;

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
		public bool Update(ZHY.Model.ArticleCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArticleCategory set ");
			strSql.Append("ACName=@ACName,");
			strSql.Append("ACDesc=@ACDesc,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where ACId=@ACId");
			SqlParameter[] parameters = {
					new SqlParameter("@ACName", SqlDbType.VarChar,20),
					new SqlParameter("@ACDesc", SqlDbType.VarChar,64),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@ACId", SqlDbType.Int,4)};
			parameters[0].Value = model.ACName;
			parameters[1].Value = model.ACDesc;
			parameters[2].Value = model.CreateAt;
			parameters[3].Value = model.CreateBy;
			parameters[4].Value = model.UpdateDT;
			parameters[5].Value = model.UpdateBy;
			parameters[6].Value = model.ACId;

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
		public bool Delete(int ACId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleCategory ");
			strSql.Append(" where ACId=@ACId");
			SqlParameter[] parameters = {
					new SqlParameter("@ACId", SqlDbType.Int,4)
			};
			parameters[0].Value = ACId;

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
		public bool DeleteList(string ACIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleCategory ");
			strSql.Append(" where ACId in ("+ACIdlist + ")  ");
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
		public ZHY.Model.ArticleCategory GetModel(int ACId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ACId,ACName,ACDesc,CreateAt,CreateBy,UpdateDT,UpdateBy from ArticleCategory ");
			strSql.Append(" where ACId=@ACId");
			SqlParameter[] parameters = {
					new SqlParameter("@ACId", SqlDbType.Int,4)
			};
			parameters[0].Value = ACId;

			ZHY.Model.ArticleCategory model=new ZHY.Model.ArticleCategory();
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
		public ZHY.Model.ArticleCategory DataRowToModel(DataRow row)
		{
			ZHY.Model.ArticleCategory model=new ZHY.Model.ArticleCategory();
			if (row != null)
			{
				if(row["ACId"]!=null && row["ACId"].ToString()!="")
				{
					model.ACId=int.Parse(row["ACId"].ToString());
				}
				if(row["ACName"]!=null)
				{
					model.ACName=row["ACName"].ToString();
				}
				if(row["ACDesc"]!=null)
				{
					model.ACDesc=row["ACDesc"].ToString();
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ACId,ACName,ACDesc,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM ArticleCategory ");
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
			strSql.Append(" ACId,ACName,ACDesc,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM ArticleCategory ");
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
			strSql.Append("select count(1) FROM ArticleCategory ");
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
				strSql.Append("order by T.ACId desc");
			}
			strSql.Append(")AS Row, T.*  from ArticleCategory T ");
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
			parameters[0].Value = "ArticleCategory";
			parameters[1].Value = "ACId";
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

