using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZHY.DAL
{
	/// <summary>
	/// ���ݷ�����LanMu��
	/// </summary>
	public class LanMu
	{
		public LanMu()
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
        public bool Exists(int LMID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LanMu");
            strSql.Append(" where LMID=@LMID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LMID", SqlDbType.Int,4)};
            parameters[0].Value = LMID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZHY.Model.LanMu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LanMu(");
            strSql.Append("LMCode,ParantID,LMName,LMOrder,LMStyleID,LMPage,LMStatus,LMDes)");
            strSql.Append(" values (");
            strSql.Append("@LMCode,@ParantID,@LMName,@LMOrder,@LMStyleID,@LMPage,@LMStatus,@LMDes)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LMCode", SqlDbType.VarChar,128),
					new SqlParameter("@ParantID", SqlDbType.Int,4),
					new SqlParameter("@LMName", SqlDbType.VarChar,128),
					new SqlParameter("@LMOrder", SqlDbType.Int,4),
					new SqlParameter("@LMStyleID", SqlDbType.Int,4),
					new SqlParameter("@LMPage", SqlDbType.VarChar,128),
					new SqlParameter("@LMStatus", SqlDbType.Char,1),
					new SqlParameter("@LMDes", SqlDbType.VarChar,256)};
            parameters[0].Value = model.LMCode;
            parameters[1].Value = model.ParantID;
            parameters[2].Value = model.LMName;
            parameters[3].Value = model.LMOrder;
            parameters[4].Value = model.LMStyleID;
            parameters[5].Value = model.LMPage;
            parameters[6].Value = model.LMStatus;
            parameters[7].Value = model.LMDes;

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
        public void Update(ZHY.Model.LanMu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LanMu set ");
            strSql.Append("LMCode=@LMCode,");
            strSql.Append("ParantID=@ParantID,");
            strSql.Append("LMName=@LMName,");
            strSql.Append("LMOrder=@LMOrder,");
            strSql.Append("LMStyleID=@LMStyleID,");
            strSql.Append("LMPage=@LMPage,");
            strSql.Append("LMStatus=@LMStatus,");
            strSql.Append("LMDes=@LMDes");
            strSql.Append(" where LMID=@LMID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LMID", SqlDbType.Int,4),
					new SqlParameter("@LMCode", SqlDbType.VarChar,128),
					new SqlParameter("@ParantID", SqlDbType.Int,4),
					new SqlParameter("@LMName", SqlDbType.VarChar,128),
					new SqlParameter("@LMOrder", SqlDbType.Int,4),
					new SqlParameter("@LMStyleID", SqlDbType.Int,4),
					new SqlParameter("@LMPage", SqlDbType.VarChar,128),
					new SqlParameter("@LMStatus", SqlDbType.Char,1),
					new SqlParameter("@LMDes", SqlDbType.VarChar,256)};
            parameters[0].Value = model.LMID;
            parameters[1].Value = model.LMCode;
            parameters[2].Value = model.ParantID;
            parameters[3].Value = model.LMName;
            parameters[4].Value = model.LMOrder;
            parameters[5].Value = model.LMStyleID;
            parameters[6].Value = model.LMPage;
            parameters[7].Value = model.LMStatus;
            parameters[8].Value = model.LMDes;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int LMID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LanMu ");
            strSql.Append(" where LMID=@LMID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LMID", SqlDbType.Int,4)};
            parameters[0].Value = LMID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZHY.Model.LanMu GetModel(int LMID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LMID,LMCode,ParantID,LMName,LMOrder,LMStyleID,LMPage,LMStatus,LMDes from LanMu ");
            strSql.Append(" where LMID=@LMID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LMID", SqlDbType.Int,4)};
            parameters[0].Value = LMID;

            ZHY.Model.LanMu model = new ZHY.Model.LanMu();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["LMID"].ToString() != "")
                {
                    model.LMID = int.Parse(ds.Tables[0].Rows[0]["LMID"].ToString());
                }
                model.LMCode = ds.Tables[0].Rows[0]["LMCode"].ToString();
                if (ds.Tables[0].Rows[0]["ParantID"].ToString() != "")
                {
                    model.ParantID = int.Parse(ds.Tables[0].Rows[0]["ParantID"].ToString());
                }
                model.LMName = ds.Tables[0].Rows[0]["LMName"].ToString();
                if (ds.Tables[0].Rows[0]["LMOrder"].ToString() != "")
                {
                    model.LMOrder = int.Parse(ds.Tables[0].Rows[0]["LMOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LMStyleID"].ToString() != "")
                {
                    model.LMStyleID = int.Parse(ds.Tables[0].Rows[0]["LMStyleID"].ToString());
                }
                model.LMPage = ds.Tables[0].Rows[0]["LMPage"].ToString();
                model.LMStatus = ds.Tables[0].Rows[0]["LMStatus"].ToString();
                model.LMDes = ds.Tables[0].Rows[0]["LMDes"].ToString();
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
            strSql.Append("select LMID,LMCode,ParantID,LMName,LMOrder,LMStyleID,LMPage,LMStatus,LMDes ");
            strSql.Append(" FROM LanMu ");
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
            strSql.Append(" LMID,LMCode,ParantID,LMName,LMOrder,LMStyleID,LMPage,LMStatus,LMDes ");
            strSql.Append(" FROM LanMu ");
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
            parameters[0].Value = "LanMu";
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

