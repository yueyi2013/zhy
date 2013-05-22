using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
    /// <summary>
    /// 数据访问类:Navigation
    /// </summary>
    public partial class Navigation
    {
        public Navigation()
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

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NavId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Navigation");
            strSql.Append(" where NavId=@NavId");
            SqlParameter[] parameters = {
					new SqlParameter("@NavId", SqlDbType.Int,4)
			};
            parameters[0].Value = NavId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Navigation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Navigation(");
            strSql.Append("NavName,NavLink,NavParantId,NavClass,NavOrder,NavDesc,NavStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy)");
            strSql.Append(" values (");
            strSql.Append("@NavName,@NavLink,@NavParantId,@NavClass,@NavOrder,@NavDesc,@NavStatus,@NavCreateAt,@NavCreateBy,@NavUpdateDT,@NavUpdateBy)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@NavName", SqlDbType.VarChar,10),
					new SqlParameter("@NavLink", SqlDbType.VarChar,50),
					new SqlParameter("@NavParantId", SqlDbType.Int,4),
					new SqlParameter("@NavClass", SqlDbType.VarChar,5),
					new SqlParameter("@NavOrder", SqlDbType.Int,4),
					new SqlParameter("@NavDesc", SqlDbType.VarChar,20),
					new SqlParameter("@NavStatus", SqlDbType.Char,1),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10)};
            parameters[0].Value = model.NavName;
            parameters[1].Value = model.NavLink;
            parameters[2].Value = model.NavParantId;
            parameters[3].Value = model.NavClass;
            parameters[4].Value = model.NavOrder;
            parameters[5].Value = model.NavDesc;
            parameters[6].Value = model.NavStatus;
            parameters[7].Value = model.NavCreateAt;
            parameters[8].Value = model.NavCreateBy;
            parameters[9].Value = model.NavUpdateDT;
            parameters[10].Value = model.NavUpdateBy;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZHY.Model.Navigation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Navigation set ");
            strSql.Append("NavName=@NavName,");
            strSql.Append("NavLink=@NavLink,");
            strSql.Append("NavParantId=@NavParantId,");
            strSql.Append("NavClass=@NavClass,");
            strSql.Append("NavOrder=@NavOrder,");
            strSql.Append("NavDesc=@NavDesc,");
            strSql.Append("NavStatus=@NavStatus,");
            strSql.Append("NavCreateAt=@NavCreateAt,");
            strSql.Append("NavCreateBy=@NavCreateBy,");
            strSql.Append("NavUpdateDT=@NavUpdateDT,");
            strSql.Append("NavUpdateBy=@NavUpdateBy");
            strSql.Append(" where NavId=@NavId");
            SqlParameter[] parameters = {
					new SqlParameter("@NavName", SqlDbType.VarChar,10),
					new SqlParameter("@NavLink", SqlDbType.VarChar,50),
					new SqlParameter("@NavParantId", SqlDbType.Int,4),
					new SqlParameter("@NavClass", SqlDbType.VarChar,5),
					new SqlParameter("@NavOrder", SqlDbType.Int,4),
					new SqlParameter("@NavDesc", SqlDbType.VarChar,20),
					new SqlParameter("@NavStatus", SqlDbType.Char,1),
					new SqlParameter("@NavCreateAt", SqlDbType.DateTime),
					new SqlParameter("@NavCreateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavUpdateDT", SqlDbType.DateTime),
					new SqlParameter("@NavUpdateBy", SqlDbType.VarChar,10),
					new SqlParameter("@NavId", SqlDbType.Int,4)};
            parameters[0].Value = model.NavName;
            parameters[1].Value = model.NavLink;
            parameters[2].Value = model.NavParantId;
            parameters[3].Value = model.NavClass;
            parameters[4].Value = model.NavOrder;
            parameters[5].Value = model.NavDesc;
            parameters[6].Value = model.NavStatus;
            parameters[7].Value = model.NavCreateAt;
            parameters[8].Value = model.NavCreateBy;
            parameters[9].Value = model.NavUpdateDT;
            parameters[10].Value = model.NavUpdateBy;
            parameters[11].Value = model.NavId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int NavId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Navigation ");
            strSql.Append(" where NavId=@NavId");
            SqlParameter[] parameters = {
					new SqlParameter("@NavId", SqlDbType.Int,4)
			};
            parameters[0].Value = NavId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string NavIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Navigation ");
            strSql.Append(" where NavId in (" + NavIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Navigation GetModel(int NavId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NavId,NavName,NavLink,NavParantId,NavClass,NavOrder,NavDesc,NavStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy from Navigation ");
            strSql.Append(" where NavId=@NavId");
            SqlParameter[] parameters = {
					new SqlParameter("@NavId", SqlDbType.Int,4)
			};
            parameters[0].Value = NavId;

            ZHY.Model.Navigation model = new ZHY.Model.Navigation();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Navigation DataRowToModel(DataRow row)
        {
            ZHY.Model.Navigation model = new ZHY.Model.Navigation();
            if (row != null)
            {
                if (row["NavId"] != null && row["NavId"].ToString() != "")
                {
                    model.NavId = int.Parse(row["NavId"].ToString());
                }
                if (row["NavName"] != null)
                {
                    model.NavName = row["NavName"].ToString();
                }
                if (row["NavLink"] != null)
                {
                    model.NavLink = row["NavLink"].ToString();
                }
                if (row["NavParantId"] != null && row["NavParantId"].ToString() != "")
                {
                    model.NavParantId = int.Parse(row["NavParantId"].ToString());
                }
                if (row["NavClass"] != null)
                {
                    model.NavClass = row["NavClass"].ToString();
                }
                if (row["NavOrder"] != null && row["NavOrder"].ToString() != "")
                {
                    model.NavOrder = int.Parse(row["NavOrder"].ToString());
                }
                if (row["NavDesc"] != null)
                {
                    model.NavDesc = row["NavDesc"].ToString();
                }
                if (row["NavStatus"] != null)
                {
                    model.NavStatus = row["NavStatus"].ToString();
                }
                if (row["NavCreateAt"] != null && row["NavCreateAt"].ToString() != "")
                {
                    model.NavCreateAt = DateTime.Parse(row["NavCreateAt"].ToString());
                }
                if (row["NavCreateBy"] != null)
                {
                    model.NavCreateBy = row["NavCreateBy"].ToString();
                }
                if (row["NavUpdateDT"] != null && row["NavUpdateDT"].ToString() != "")
                {
                    model.NavUpdateDT = DateTime.Parse(row["NavUpdateDT"].ToString());
                }
                if (row["NavUpdateBy"] != null)
                {
                    model.NavUpdateBy = row["NavUpdateBy"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NavId,NavName,NavLink,NavParantId,NavClass,NavOrder,NavDesc,NavStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
            strSql.Append(" FROM Navigation ");
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
            strSql.Append(" NavId,NavName,NavLink,NavParantId,NavClass,NavOrder,NavDesc,NavStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
            strSql.Append(" FROM Navigation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Navigation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.NavId desc");
            }
            strSql.Append(")AS Row, T.*  from Navigation T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "Navigation";
            parameters[1].Value = "NavId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

