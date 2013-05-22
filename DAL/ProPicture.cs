using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����ProPicture��
	/// </summary>
	public class ProPicture
	{
		public ProPicture()
		{}
		#region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ProID", "ProPicture");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ProID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProPicture");
            strSql.Append(" where ProID=@ProID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4)};
            parameters[0].Value = ProID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(ZHY.Model.ProPicture model)
        {
            Delete(model.ProID, model.ProOrder.Value);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProPicture(");
            strSql.Append("ProID,ProPicURL,ProOrder)");
            strSql.Append(" values (");
            strSql.Append("@ProID,@ProPicURL,@ProOrder)");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@ProPicURL", SqlDbType.VarChar,512),
					new SqlParameter("@ProOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.ProID;
            parameters[1].Value = model.ProPicURL;
            parameters[2].Value = model.ProOrder;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZHY.Model.ProPicture model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProPicture set ");
            strSql.Append("ProPicURL=@ProPicURL,");
            strSql.Append("ProOrder=@ProOrder");
            strSql.Append(" where ProID=@ProID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@ProPicURL", SqlDbType.VarChar,512),
					new SqlParameter("@ProOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.ProID;
            parameters[1].Value = model.ProPicURL;
            parameters[2].Value = model.ProOrder;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ProID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProPicture ");
            strSql.Append(" where ProID=@ProID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4)};
            parameters[0].Value = ProID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ProID, int proOrder)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProPicture ");
            strSql.Append(" where ProID=@ProID and ProOrder=@ProOrder");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4),
                    new SqlParameter("@ProOrder", SqlDbType.Int,4)};
            parameters[0].Value = ProID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.ProPicture GetModel(int ProID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProID,ProPicURL,ProOrder from ProPicture ");
            strSql.Append(" where ProID=@ProID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4)};
            parameters[0].Value = ProID;

            ZHY.Model.ProPicture model = new ZHY.Model.ProPicture();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProID"].ToString() != "")
                {
                    model.ProID = int.Parse(ds.Tables[0].Rows[0]["ProID"].ToString());
                }
                model.ProPicURL = ds.Tables[0].Rows[0]["ProPicURL"].ToString();
                if (ds.Tables[0].Rows[0]["ProOrder"].ToString() != "")
                {
                    model.ProOrder = int.Parse(ds.Tables[0].Rows[0]["ProOrder"].ToString());
                }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProID,ProPicURL,ProOrder ");
            strSql.Append(" FROM ProPicture ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ProID,ProPicURL,ProOrder ");
            strSql.Append(" FROM ProPicture ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "ProPicture";
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

