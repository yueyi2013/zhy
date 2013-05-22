using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����ProDetail��
	/// </summary>
	public class ProDetail
	{
		public ProDetail()
		{ }

        #region ��Ա����
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(int proID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProID,DtID,ProDtValue,DtName ");
            strSql.Append(" FROM ProDetail pd");
            strSql.Append(" left join  Details d on pd.DtID = d.DtID");
            strSql.Append(" where proID =" + proID);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region  �Զ����ɴ���

        /// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProID", "ProDetail"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProID,int DtID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProDetail");
			strSql.Append(" where ProID=@ProID and DtID=@DtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4)};
			parameters[0].Value = ProID;
			parameters[1].Value = DtID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ZHY.Model.ProDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProDetail(");
			strSql.Append("ProID,DtID,ProDtValue)");
			strSql.Append(" values (");
			strSql.Append("@ProID,@DtID,@ProDtValue)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4),
					new SqlParameter("@ProDtValue", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ProID;
			parameters[1].Value = model.DtID;
			parameters[2].Value = model.ProDtValue;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZHY.Model.ProDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProDetail set ");
			strSql.Append("ProDtValue=@ProDtValue");
			strSql.Append(" where ProID=@ProID and DtID=@DtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4),
					new SqlParameter("@ProDtValue", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ProID;
			parameters[1].Value = model.DtID;
			parameters[2].Value = model.ProDtValue;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProID,int DtID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProDetail ");
			strSql.Append(" where ProID=@ProID and DtID=@DtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4)};
			parameters[0].Value = ProID;
			parameters[1].Value = DtID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.ProDetail GetModel(int ProID,int DtID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProID,DtID,ProDtValue from ProDetail ");
			strSql.Append(" where ProID=@ProID and DtID=@DtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@DtID", SqlDbType.Int,4)};
			parameters[0].Value = ProID;
			parameters[1].Value = DtID;

			ZHY.Model.ProDetail model=new ZHY.Model.ProDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProID"].ToString()!="")
				{
					model.ProID=int.Parse(ds.Tables[0].Rows[0]["ProID"].ToString());
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
			strSql.Append("select ProID,DtID,ProDtValue ");
			strSql.Append(" FROM ProDetail ");
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
			strSql.Append(" ProID,DtID,ProDtValue ");
			strSql.Append(" FROM ProDetail ");
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
			parameters[0].Value = "ProDetail";
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

