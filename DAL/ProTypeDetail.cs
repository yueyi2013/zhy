using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
using System.Collections.Generic;
using System.Collections;
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����ProTypeDetail��
	/// </summary>
	public class ProTypeDetail
	{
		public ProTypeDetail()
		{ }

        #region ��Ա����
        /// <summary>
        /// ������������
        /// </summary>
        public void Add(List<ZHY.Model.ProTypeDetail> list)
        {
            Hashtable hs = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProTypeDetail(");
            strSql.Append("ProTypeID,DtID,ProDtValue)");
            strSql.Append(" values (");
            strSql.Append("@ProTypeID,@DtID,@ProDtValue)");
            foreach(ZHY.Model.ProTypeDetail model in list)
            {
                SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4),
					new SqlParameter("@ProDtValue", SqlDbType.VarChar,512)};
                parameters[0].Value = model.ProTypeID;
                parameters[1].Value = model.DtID;
                parameters[2].Value = model.ProDtValue;
                hs.Add(strSql,parameters);
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(hs);
        }

        /// <summary>
        /// ������������
        /// </summary>
        public void Update(List<ZHY.Model.ProTypeDetail> list)
        {
            Hashtable hs = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProTypeDetail set ");
            strSql.Append("ProDtValue=@ProDtValue");
            strSql.Append(" where ProTypeID=@ProTypeID and DtID=@DtID ");
            
            foreach (ZHY.Model.ProTypeDetail model in list)
            {
                SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4),
					new SqlParameter("@ProDtValue", SqlDbType.VarChar,512)};
                parameters[0].Value = model.ProTypeID;
                parameters[1].Value = model.DtID;
                parameters[2].Value = model.ProDtValue;
                hs.Add(strSql, parameters);
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(hs);
        }
        #endregion

        #region  �Զ����ɴ���

        /// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProTypeID", "ProTypeDetail"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProTypeID,int DtID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProTypeDetail");
			strSql.Append(" where ProTypeID=@ProTypeID and DtID=@DtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4)};
			parameters[0].Value = ProTypeID;
			parameters[1].Value = DtID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ZHY.Model.ProTypeDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProTypeDetail(");
			strSql.Append("ProTypeID,DtID,ProDtValue)");
			strSql.Append(" values (");
			strSql.Append("@ProTypeID,@DtID,@ProDtValue)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4),
					new SqlParameter("@ProDtValue", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ProTypeID;
			parameters[1].Value = model.DtID;
			parameters[2].Value = model.ProDtValue;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZHY.Model.ProTypeDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProTypeDetail set ");
			strSql.Append("ProDtValue=@ProDtValue");
			strSql.Append(" where ProTypeID=@ProTypeID and DtID=@DtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4),
					new SqlParameter("@ProDtValue", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ProTypeID;
			parameters[1].Value = model.DtID;
			parameters[2].Value = model.ProDtValue;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProTypeID,int DtID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProTypeDetail ");
			strSql.Append(" where ProTypeID=@ProTypeID and DtID=@DtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4)};
			parameters[0].Value = ProTypeID;
			parameters[1].Value = DtID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.ProTypeDetail GetModel(int ProTypeID,int DtID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProTypeID,DtID,ProDtValue from ProTypeDetail ");
			strSql.Append(" where ProTypeID=@ProTypeID and DtID=@DtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4)};
			parameters[0].Value = ProTypeID;
			parameters[1].Value = DtID;

			ZHY.Model.ProTypeDetail model=new ZHY.Model.ProTypeDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProTypeID"].ToString()!="")
				{
					model.ProTypeID=int.Parse(ds.Tables[0].Rows[0]["ProTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DtID"].ToString()!="")
				{
					model.DtID=int.Parse(ds.Tables[0].Rows[0]["DtID"].ToString());
				}
				model.ProDtValue=ds.Tables[0].Rows[0]["ProDtValue"].ToString();
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
			strSql.Append("select ProTypeID,DtID,ProDtValue ");
			strSql.Append(" FROM ProTypeDetail ");
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
			strSql.Append(" ProTypeID,DtID,ProDtValue ");
			strSql.Append(" FROM ProTypeDetail ");
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
			parameters[0].Value = "ProTypeDetail";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion 
	}
}

