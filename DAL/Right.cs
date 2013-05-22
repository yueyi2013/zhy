using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZHY.DAL
{
    /// <summary>
    /// ���ݷ�����Right��
    /// </summary>
    public class Right
    {
        public Right()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int RgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Rights");
            strSql.Append(" where RgID=@RgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RgID", SqlDbType.Int,4)};
            parameters[0].Value = RgID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.Right model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Rights(");
            strSql.Append("FunID,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@FunID,@RoleID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FunID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.FunID;
            parameters[1].Value = model.RoleID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(ZHY.Model.Right model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Rights set ");
            strSql.Append("FunID=@FunID,");
            strSql.Append("RoleID=@RoleID");
            strSql.Append(" where RgID=@RgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RgID", SqlDbType.Int,4),
					new SqlParameter("@FunID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.RgID;
            parameters[1].Value = model.FunID;
            parameters[2].Value = model.RoleID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int RgID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Rights ");
            strSql.Append(" where RgID=@RgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RgID", SqlDbType.Int,4)};
            parameters[0].Value = RgID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.Right GetModel(int RgID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RgID,FunID,RoleID from Rights ");
            strSql.Append(" where RgID=@RgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RgID", SqlDbType.Int,4)};
            parameters[0].Value = RgID;

            ZHY.Model.Right model = new ZHY.Model.Right();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RgID"].ToString() != "")
                {
                    model.RgID = int.Parse(ds.Tables[0].Rows[0]["RgID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FunID"].ToString() != "")
                {
                    model.FunID = int.Parse(ds.Tables[0].Rows[0]["FunID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
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
            strSql.Append("select RgID,FunID,RoleID ");
            strSql.Append(" FROM Rights ");
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
            strSql.Append(" RgID,FunID,RoleID ");
            strSql.Append(" FROM Rights ");
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
            parameters[0].Value = "Rights";
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

