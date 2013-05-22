using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����LMStyle��
	/// </summary>
	public class LMStyle
	{
		public LMStyle()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LMStyleID", "LMStyle"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int LMStyleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LMStyle");
			strSql.Append(" where LMStyleID=@LMStyleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LMStyleID", SqlDbType.Int,4)};
			parameters[0].Value = LMStyleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(ZHY.Model.LMStyle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LMStyle(");
			strSql.Append("LMStyleName,LMStyleURL)");
			strSql.Append(" values (");
			strSql.Append("@LMStyleName,@LMStyleURL)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LMStyleName", SqlDbType.VarChar,128),
					new SqlParameter("@LMStyleURL", SqlDbType.VarChar,128)};
			parameters[0].Value = model.LMStyleName;
			parameters[1].Value = model.LMStyleURL;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZHY.Model.LMStyle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LMStyle set ");
			strSql.Append("LMStyleName=@LMStyleName,");
			strSql.Append("LMStyleURL=@LMStyleURL");
			strSql.Append(" where LMStyleID=@LMStyleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LMStyleID", SqlDbType.Int,4),
					new SqlParameter("@LMStyleName", SqlDbType.VarChar,128),
					new SqlParameter("@LMStyleURL", SqlDbType.VarChar,128)};
			parameters[0].Value = model.LMStyleID;
			parameters[1].Value = model.LMStyleName;
			parameters[2].Value = model.LMStyleURL;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int LMStyleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LMStyle ");
			strSql.Append(" where LMStyleID=@LMStyleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LMStyleID", SqlDbType.Int,4)};
			parameters[0].Value = LMStyleID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.LMStyle GetModel(int LMStyleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LMStyleID,LMStyleName,LMStyleURL from LMStyle ");
			strSql.Append(" where LMStyleID=@LMStyleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LMStyleID", SqlDbType.Int,4)};
			parameters[0].Value = LMStyleID;

			ZHY.Model.LMStyle model=new ZHY.Model.LMStyle();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LMStyleID"].ToString()!="")
				{
					model.LMStyleID=int.Parse(ds.Tables[0].Rows[0]["LMStyleID"].ToString());
				}
				model.LMStyleName=ds.Tables[0].Rows[0]["LMStyleName"].ToString();
				model.LMStyleURL=ds.Tables[0].Rows[0]["LMStyleURL"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LMStyleID,LMStyleName,LMStyleURL ");
			strSql.Append(" FROM LMStyle ");
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
			strSql.Append(" LMStyleID,LMStyleName,LMStyleURL ");
			strSql.Append(" FROM LMStyle ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "LMStyle";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

