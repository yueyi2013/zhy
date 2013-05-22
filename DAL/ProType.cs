using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����ProType��
	/// </summary>
	public class ProType
	{
		public ProType()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProTypeID", "ProTypes"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProTypes");
			strSql.Append(" where ProTypeID=@ProTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4)};
			parameters[0].Value = ProTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(ZHY.Model.ProType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProTypes(");
			strSql.Append("ProTypeName)");
			strSql.Append(" values (");
			strSql.Append("@ProTypeName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeName", SqlDbType.VarChar,128)};
			parameters[0].Value = model.ProTypeName;

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
		public void Update(ZHY.Model.ProType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProTypes set ");
			strSql.Append("ProTypeName=@ProTypeName");
			strSql.Append(" where ProTypeID=@ProTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProTypeName", SqlDbType.VarChar,128)};
			parameters[0].Value = model.ProTypeID;
			parameters[1].Value = model.ProTypeName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProTypes ");
			strSql.Append(" where ProTypeID=@ProTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4)};
			parameters[0].Value = ProTypeID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.ProType GetModel(int ProTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProTypeID,ProTypeName from ProTypes ");
			strSql.Append(" where ProTypeID=@ProTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4)};
			parameters[0].Value = ProTypeID;

			ZHY.Model.ProType model=new ZHY.Model.ProType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProTypeID"].ToString()!="")
				{
					model.ProTypeID=int.Parse(ds.Tables[0].Rows[0]["ProTypeID"].ToString());
				}
				model.ProTypeName=ds.Tables[0].Rows[0]["ProTypeName"].ToString();
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
			strSql.Append("select ProTypeID,ProTypeName ");
			strSql.Append(" FROM ProTypes ");
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
			strSql.Append(" ProTypeID,ProTypeName ");
			strSql.Append(" FROM ProTypes ");
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
			parameters[0].Value = "ProTypes";
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

