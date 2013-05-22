using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZHY.DAL
{
    /// <summary>
    /// 数据访问类Product。
    /// </summary>
    public class Product
    {
        public Product()
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

        #region  自动生成代码
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ProID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Products");
            strSql.Append(" where ProID=@ProID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Decimal)};
            parameters[0].Value = ProID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products(");
            strSql.Append("ProCode,ProTypeID,ProName,ProDes,ProPrice,ProInputDate,ProPublish,ProStatus,ProRecommend,ProIsNew,ProIsHot)");
            strSql.Append(" values (");
            strSql.Append("@ProCode,@ProTypeID,@ProName,@ProDes,@ProPrice,@ProInputDate,@ProPublish,@ProStatus,@ProRecommend,@ProIsNew,@ProIsHot)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProName", SqlDbType.VarChar,256),
					new SqlParameter("@ProDes", SqlDbType.VarChar,512),
					new SqlParameter("@ProPrice", SqlDbType.Float,8),
					new SqlParameter("@ProInputDate", SqlDbType.DateTime),
					new SqlParameter("@ProPublish", SqlDbType.DateTime),
					new SqlParameter("@ProStatus", SqlDbType.Char,1),
					new SqlParameter("@ProRecommend", SqlDbType.Char,1),
					new SqlParameter("@ProIsNew", SqlDbType.Char,1),
					new SqlParameter("@ProIsHot", SqlDbType.Char,1)};
            parameters[0].Value = model.ProCode;
            parameters[1].Value = model.ProTypeID;
            parameters[2].Value = model.ProName;
            parameters[3].Value = model.ProDes;
            parameters[4].Value = model.ProPrice;
            parameters[5].Value = model.ProInputDate;
            parameters[6].Value = model.ProPublish;
            parameters[7].Value = model.ProStatus;
            parameters[8].Value = model.ProRecommend;
            parameters[9].Value = model.ProIsNew;
            parameters[10].Value = model.ProIsHot;

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
        public void Update(ZHY.Model.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            strSql.Append("ProCode=@ProCode,");
            strSql.Append("ProTypeID=@ProTypeID,");
            strSql.Append("ProName=@ProName,");
            strSql.Append("ProDes=@ProDes,");
            strSql.Append("ProPrice=@ProPrice,");
            strSql.Append("ProInputDate=@ProInputDate,");
            strSql.Append("ProPublish=@ProPublish,");
            strSql.Append("ProStatus=@ProStatus,");
            strSql.Append("ProRecommend=@ProRecommend,");
            strSql.Append("ProIsNew=@ProIsNew,");
            strSql.Append("ProIsHot=@ProIsHot");
            strSql.Append(" where ProID=@ProID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Decimal,5),
					new SqlParameter("@ProCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProName", SqlDbType.VarChar,256),
					new SqlParameter("@ProDes", SqlDbType.VarChar,512),
					new SqlParameter("@ProPrice", SqlDbType.Float,8),
					new SqlParameter("@ProInputDate", SqlDbType.DateTime),
					new SqlParameter("@ProPublish", SqlDbType.DateTime),
					new SqlParameter("@ProStatus", SqlDbType.Char,1),
					new SqlParameter("@ProRecommend", SqlDbType.Char,1),
					new SqlParameter("@ProIsNew", SqlDbType.Char,1),
					new SqlParameter("@ProIsHot", SqlDbType.Char,1)};
            parameters[0].Value = model.ProID;
            parameters[1].Value = model.ProCode;
            parameters[2].Value = model.ProTypeID;
            parameters[3].Value = model.ProName;
            parameters[4].Value = model.ProDes;
            parameters[5].Value = model.ProPrice;
            parameters[6].Value = model.ProInputDate;
            parameters[7].Value = model.ProPublish;
            parameters[8].Value = model.ProStatus;
            parameters[9].Value = model.ProRecommend;
            parameters[10].Value = model.ProIsNew;
            parameters[11].Value = model.ProIsHot;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(decimal ProID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Products ");
            strSql.Append(" where ProID=@ProID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Decimal)};
            parameters[0].Value = ProID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Product GetModel(decimal ProID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProID,ProCode,ProTypeID,ProName,ProDes,ProPrice,ProInputDate,ProPublish,ProStatus,ProRecommend,ProIsNew,ProIsHot from Products ");
            strSql.Append(" where ProID=@ProID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Decimal)};
            parameters[0].Value = ProID;

            ZHY.Model.Product model = new ZHY.Model.Product();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProID"].ToString() != "")
                {
                    model.ProID = decimal.Parse(ds.Tables[0].Rows[0]["ProID"].ToString());
                }
                model.ProCode = ds.Tables[0].Rows[0]["ProCode"].ToString();
                if (ds.Tables[0].Rows[0]["ProTypeID"].ToString() != "")
                {
                    model.ProTypeID = int.Parse(ds.Tables[0].Rows[0]["ProTypeID"].ToString());
                }
                model.ProName = ds.Tables[0].Rows[0]["ProName"].ToString();
                model.ProDes = ds.Tables[0].Rows[0]["ProDes"].ToString();
                if (ds.Tables[0].Rows[0]["ProPrice"].ToString() != "")
                {
                    model.ProPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProInputDate"].ToString() != "")
                {
                    model.ProInputDate = DateTime.Parse(ds.Tables[0].Rows[0]["ProInputDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProPublish"].ToString() != "")
                {
                    model.ProPublish = DateTime.Parse(ds.Tables[0].Rows[0]["ProPublish"].ToString());
                }
                model.ProStatus = ds.Tables[0].Rows[0]["ProStatus"].ToString();
                model.ProRecommend = ds.Tables[0].Rows[0]["ProRecommend"].ToString();
                model.ProIsNew = ds.Tables[0].Rows[0]["ProIsNew"].ToString();
                model.ProIsHot = ds.Tables[0].Rows[0]["ProIsHot"].ToString();
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
            strSql.Append("select ProID,ProCode,ProTypeID,ProName,ProDes,ProPrice,ProInputDate,ProPublish,ProStatus,ProRecommend,ProIsNew,ProIsHot ");
            strSql.Append(" FROM Products ");
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
            strSql.Append(" p.ProID,ProCode,ProTypeID,ProName,pc.ProPicURL,ProDes,ProPrice,ProInputDate,ProPublish,ProStatus,ProRecommend,ProIsNew,ProIsHot ");
            strSql.Append(" FROM Products p");
            strSql.Append(" left join ProPicture pc on p.ProID = pc.ProID");
            //strSql.Append(" where ProOrder = 0");
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
            parameters[0].Value = "Products";
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

