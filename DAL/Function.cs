using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����Function��
	/// </summary>
	public class Function
	{
		public Function()
		{}

		#region  ��Ա����

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="strGetFields">��ѯ����</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="pageSize">ҳ���С</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="strOrder">��������</param>
        /// <param name="intOrder">��������  1Ϊ����</param>
        /// <param name="CountAll">���ؼ�¼�������ڼ���ҳ����</param>
        /// <returns></returns>
        public DataSet GetList(string tablename, string strGetFields, int PageIndex, int pageSize, string strWhere, string strOrder, int intOrder, ref int CountAll)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@tablename",tablename),
                new SqlParameter("@strGetFields",strGetFields),
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@pageSize",pageSize),
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strOrder",strOrder),
                new SqlParameter("@intOrder", intOrder),
               new SqlParameter("@CountAll", CountAll)
            };
            para[7].Direction = ParameterDirection.Output;
            return DbHelperSQL.RunProcedure("[dbo].[Pagination]", ref CountAll, para);
        }

		#endregion  ��Ա����

        #region �Զ����ɴ���
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int FunID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Functions");
            strSql.Append(" where FunID=@FunID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FunID", SqlDbType.Int,4)};
            parameters[0].Value = FunID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.Function model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Functions(");
            strSql.Append("FunCode,FunName,FunPage,FunDes)");
            strSql.Append(" values (");
            strSql.Append("@FunCode,@FunName,@FunPage,@FunDes)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FunCode", SqlDbType.VarChar,128),
					new SqlParameter("@FunName", SqlDbType.VarChar,256),
					new SqlParameter("@FunPage", SqlDbType.VarChar,128),
					new SqlParameter("@FunDes", SqlDbType.VarChar,512)};
            parameters[0].Value = model.FunCode;
            parameters[1].Value = model.FunName;
            parameters[2].Value = model.FunPage;
            parameters[3].Value = model.FunDes;

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
        public void Update(ZHY.Model.Function model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Functions set ");
            strSql.Append("FunCode=@FunCode,");
            strSql.Append("FunName=@FunName,");
            strSql.Append("FunPage=@FunPage,");
            strSql.Append("FunDes=@FunDes");
            strSql.Append(" where FunID=@FunID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FunID", SqlDbType.Int,4),
					new SqlParameter("@FunCode", SqlDbType.VarChar,128),
					new SqlParameter("@FunName", SqlDbType.VarChar,256),
					new SqlParameter("@FunPage", SqlDbType.VarChar,128),
					new SqlParameter("@FunDes", SqlDbType.VarChar,512)};
            parameters[0].Value = model.FunID;
            parameters[1].Value = model.FunCode;
            parameters[2].Value = model.FunName;
            parameters[3].Value = model.FunPage;
            parameters[4].Value = model.FunDes;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int FunID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Functions ");
            strSql.Append(" where FunID=@FunID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FunID", SqlDbType.Int,4)};
            parameters[0].Value = FunID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.Function GetModel(int FunID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FunID,FunCode,FunName,FunPage,FunDes from Functions ");
            strSql.Append(" where FunID=@FunID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FunID", SqlDbType.Int,4)};
            parameters[0].Value = FunID;

            ZHY.Model.Function model = new ZHY.Model.Function();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FunID"].ToString() != "")
                {
                    model.FunID = int.Parse(ds.Tables[0].Rows[0]["FunID"].ToString());
                }
                model.FunCode = ds.Tables[0].Rows[0]["FunCode"].ToString();
                model.FunName = ds.Tables[0].Rows[0]["FunName"].ToString();
                model.FunPage = ds.Tables[0].Rows[0]["FunPage"].ToString();
                model.FunDes = ds.Tables[0].Rows[0]["FunDes"].ToString();
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
            strSql.Append("select FunID,FunCode,FunName,FunPage,FunDes ");
            strSql.Append(" FROM Functions ");
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
            strSql.Append(" FunID,FunCode,FunName,FunPage,FunDes ");
            strSql.Append(" FROM Functions ");
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
            parameters[0].Value = "Functions";
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

