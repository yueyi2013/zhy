using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZHY.DAL
{
    /// <summary>
    /// 数据访问类Role。
    /// </summary>
    public class Role
    {
        public Role()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Roles");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Roles(");
            strSql.Append("RoleName,RoleDes)");
            strSql.Append(" values (");
            strSql.Append("@RoleName,@RoleDes)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,128),
					new SqlParameter("@RoleDes", SqlDbType.VarChar,256)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleDes;

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
        public void Update(ZHY.Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Roles set ");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleDes=@RoleDes");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.VarChar,128),
					new SqlParameter("@RoleDes", SqlDbType.VarChar,256)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.RoleDes;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Roles ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Role GetModel(int RoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleID,RoleName,RoleDes from Roles ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;

            ZHY.Model.Role model = new ZHY.Model.Role();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                model.RoleDes = ds.Tables[0].Rows[0]["RoleDes"].ToString();
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
            strSql.Append("select RoleID,RoleName,RoleDes ");
            strSql.Append(" FROM Roles ");
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
            strSql.Append(" RoleID,RoleName,RoleDes ");
            strSql.Append(" FROM Roles ");
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
            parameters[0].Value = "Roles";
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

