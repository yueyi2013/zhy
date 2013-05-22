using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类Detail。
	/// </summary>
	public class Detail
	{
		public Detail()
		{ }

        #region 成员方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="strGetFields">查询列名</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序列名</param>
        /// <param name="intOrder">排序类型  1为升序</param>
        /// <param name="CountAll">返回纪录总数用于计算页面数</param>
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

        #endregion

        #region   自动生成代码
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DtID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Details");
            strSql.Append(" where DtID=@DtID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DtID", SqlDbType.Int,4)};
            parameters[0].Value = DtID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Details(");
            strSql.Append("DtName,DtDesc,DtOrder)");
            strSql.Append(" values (");
            strSql.Append("@DtName,@DtDesc,@DtOrder)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DtName", SqlDbType.VarChar,128),
					new SqlParameter("@DtDesc", SqlDbType.VarChar,256),
					new SqlParameter("@DtOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.DtName;
            parameters[1].Value = model.DtDesc;
            parameters[2].Value = model.DtOrder;

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
        /// 更新一条数据
        /// </summary>
        public void Update(ZHY.Model.Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Details set ");
            strSql.Append("DtName=@DtName,");
            strSql.Append("DtDesc=@DtDesc,");
            strSql.Append("DtOrder=@DtOrder");
            strSql.Append(" where DtID=@DtID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DtID", SqlDbType.Int,4),
					new SqlParameter("@DtName", SqlDbType.VarChar,128),
					new SqlParameter("@DtDesc", SqlDbType.VarChar,256),
					new SqlParameter("@DtOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.DtID;
            parameters[1].Value = model.DtName;
            parameters[2].Value = model.DtDesc;
            parameters[3].Value = model.DtOrder;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int DtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Details ");
            strSql.Append(" where DtID=@DtID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DtID", SqlDbType.Int,4)};
            parameters[0].Value = DtID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Detail GetModel(int DtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DtID,DtName,DtDesc,DtOrder from Details ");
            strSql.Append(" where DtID=@DtID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DtID", SqlDbType.Int,4)};
            parameters[0].Value = DtID;

            ZHY.Model.Detail model = new ZHY.Model.Detail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["DtID"].ToString() != "")
                {
                    model.DtID = int.Parse(ds.Tables[0].Rows[0]["DtID"].ToString());
                }
                model.DtName = ds.Tables[0].Rows[0]["DtName"].ToString();
                model.DtDesc = ds.Tables[0].Rows[0]["DtDesc"].ToString();
                if (ds.Tables[0].Rows[0]["DtOrder"].ToString() != "")
                {
                    model.DtOrder = int.Parse(ds.Tables[0].Rows[0]["DtOrder"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DtID,DtName,DtDesc,DtOrder ");
            strSql.Append(" FROM Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" DtID,DtName,DtDesc,DtOrder ");
            strSql.Append(" FROM Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
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
            parameters[0].Value = "Details";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

		#endregion  成员方法
	}
}

