using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.ACC.DAL
{
    /// <summary>
    /// 数据访问类:RSSChannelItem
    /// </summary>
    public partial class RSSChannelItem
    {
        public RSSChannelItem()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RCItemId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RSSChannelItem");
            strSql.Append(" where RCItemId=@RCItemId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@RCItemId", OleDbType.Integer,4)
			};
            parameters[0].Value = RCItemId;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZHY.Model.RSSChannelItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RSSChannelItem(");
            strSql.Append("RCItemId,RCId,RCItemTitle,RCItemLink,RCItemCategory,RCItemAuthor,RCItemPubDate,RCItemDescription,RCItemComments,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy)");
            strSql.Append(" values (");
            strSql.Append("@RCItemId,@RCId,@RCItemTitle,@RCItemLink,@RCItemCategory,@RCItemAuthor,@RCItemPubDate,@RCItemDescription,@RCItemComments,@NavCreateAt,@NavCreateBy,@NavUpdateDT,@NavUpdateBy)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@RCItemId", OleDbType.Integer,4), 
					new OleDbParameter("@RCId", OleDbType.Integer,4),
					new OleDbParameter("@RCItemTitle", OleDbType.VarChar,200),
					new OleDbParameter("@RCItemLink", OleDbType.VarChar,100),
					new OleDbParameter("@RCItemCategory", OleDbType.VarChar,10),
					new OleDbParameter("@RCItemAuthor", OleDbType.VarChar,10),
					new OleDbParameter("@RCItemPubDate", OleDbType.Date),
					new OleDbParameter("@RCItemDescription", OleDbType.VarChar,0),
					new OleDbParameter("@RCItemComments", OleDbType.VarChar,20),
					new OleDbParameter("@NavCreateAt", OleDbType.Date),
					new OleDbParameter("@NavCreateBy", OleDbType.VarChar,10),
					new OleDbParameter("@NavUpdateDT", OleDbType.Date),
					new OleDbParameter("@NavUpdateBy", OleDbType.VarChar,10)};
            parameters[0].Value = model.RCItemId;
            parameters[1].Value = model.RCId;
            parameters[2].Value = model.RCItemTitle;
            parameters[3].Value = model.RCItemLink;
            parameters[4].Value = model.RCItemCategory;
            parameters[5].Value = model.RCItemAuthor;
            parameters[6].Value = model.RCItemPubDate;
            parameters[7].Value = model.RCItemDescription;
            parameters[8].Value = model.RCItemComments;
            parameters[9].Value = model.NavCreateAt;
            parameters[10].Value = model.NavCreateBy;
            parameters[11].Value = model.NavUpdateDT;
            parameters[12].Value = model.NavUpdateBy;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(ZHY.Model.RSSChannelItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RSSChannelItem set ");
            strSql.Append("RCId=@RCId,");
            strSql.Append("RCItemTitle=@RCItemTitle,");
            strSql.Append("RCItemLink=@RCItemLink,");
            strSql.Append("RCItemCategory=@RCItemCategory,");
            strSql.Append("RCItemAuthor=@RCItemAuthor,");
            strSql.Append("RCItemPubDate=@RCItemPubDate,");
            strSql.Append("RCItemDescription=@RCItemDescription,");
            strSql.Append("RCItemComments=@RCItemComments,");
            strSql.Append("NavCreateAt=@NavCreateAt,");
            strSql.Append("NavCreateBy=@NavCreateBy,");
            strSql.Append("NavUpdateDT=@NavUpdateDT,");
            strSql.Append("NavUpdateBy=@NavUpdateBy");
            strSql.Append(" where RCItemId=@RCItemId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@RCId", OleDbType.Integer,4),
					new OleDbParameter("@RCItemTitle", OleDbType.VarChar,200),
					new OleDbParameter("@RCItemLink", OleDbType.VarChar,100),
					new OleDbParameter("@RCItemCategory", OleDbType.VarChar,10),
					new OleDbParameter("@RCItemAuthor", OleDbType.VarChar,10),
					new OleDbParameter("@RCItemPubDate", OleDbType.Date),
					new OleDbParameter("@RCItemDescription", OleDbType.VarChar,0),
					new OleDbParameter("@RCItemComments", OleDbType.VarChar,20),
					new OleDbParameter("@NavCreateAt", OleDbType.Date),
					new OleDbParameter("@NavCreateBy", OleDbType.VarChar,10),
					new OleDbParameter("@NavUpdateDT", OleDbType.Date),
					new OleDbParameter("@NavUpdateBy", OleDbType.VarChar,10),
					new OleDbParameter("@RCItemId", OleDbType.Integer,4)};
            parameters[0].Value = model.RCId;
            parameters[1].Value = model.RCItemTitle;
            parameters[2].Value = model.RCItemLink;
            parameters[3].Value = model.RCItemCategory;
            parameters[4].Value = model.RCItemAuthor;
            parameters[5].Value = model.RCItemPubDate;
            parameters[6].Value = model.RCItemDescription;
            parameters[7].Value = model.RCItemComments;
            parameters[8].Value = model.NavCreateAt;
            parameters[9].Value = model.NavCreateBy;
            parameters[10].Value = model.NavUpdateDT;
            parameters[11].Value = model.NavUpdateBy;
            parameters[12].Value = model.RCItemId;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int RCItemId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RSSChannelItem ");
            strSql.Append(" where RCItemId=@RCItemId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@RCItemId", OleDbType.Integer,4)
			};
            parameters[0].Value = RCItemId;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string RCItemIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RSSChannelItem ");
            strSql.Append(" where RCItemId in (" + RCItemIdlist + ")  ");
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
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
        public ZHY.Model.RSSChannelItem GetModel(int RCItemId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RCItemId,RCId,RCItemTitle,RCItemLink,RCItemCategory,RCItemAuthor,RCItemPubDate,RCItemDescription,RCItemComments,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy from RSSChannelItem ");
            strSql.Append(" where RCItemId=@RCItemId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@RCItemId", OleDbType.Integer,4)
			};
            parameters[0].Value = RCItemId;

            ZHY.Model.RSSChannelItem model = new ZHY.Model.RSSChannelItem();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
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
        public ZHY.Model.RSSChannelItem DataRowToModel(DataRow row)
        {
            ZHY.Model.RSSChannelItem model = new ZHY.Model.RSSChannelItem();
            if (row != null)
            {
                if (row["RCItemId"] != null && row["RCItemId"].ToString() != "")
                {
                    model.RCItemId = int.Parse(row["RCItemId"].ToString());
                }
                if (row["RCId"] != null && row["RCId"].ToString() != "")
                {
                    model.RCId = int.Parse(row["RCId"].ToString());
                }
                if (row["RCItemTitle"] != null)
                {
                    model.RCItemTitle = row["RCItemTitle"].ToString();
                }
                if (row["RCItemLink"] != null)
                {
                    model.RCItemLink = row["RCItemLink"].ToString();
                }
                if (row["RCItemCategory"] != null)
                {
                    model.RCItemCategory = row["RCItemCategory"].ToString();
                }
                if (row["RCItemAuthor"] != null)
                {
                    model.RCItemAuthor = row["RCItemAuthor"].ToString();
                }
                if (row["RCItemPubDate"] != null && row["RCItemPubDate"].ToString() != "")
                {
                    model.RCItemPubDate = DateTime.Parse(row["RCItemPubDate"].ToString());
                }
                if (row["RCItemDescription"] != null)
                {
                    model.RCItemDescription = row["RCItemDescription"].ToString();
                }
                if (row["RCItemComments"] != null)
                {
                    model.RCItemComments = row["RCItemComments"].ToString();
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
            strSql.Append("select RCItemId,RCId,RCItemTitle,RCItemLink,RCItemCategory,RCItemAuthor,RCItemPubDate,RCItemDescription,RCItemComments,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ");
            strSql.Append(" FROM RSSChannelItem ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM RSSChannelItem ");
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
                strSql.Append("order by T.RCItemId desc");
            }
            strSql.Append(")AS Row, T.*  from RSSChannelItem T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            OleDbParameter[] parameters = {
                    new OleDbParameter("@tblName", OleDbType.VarChar, 255),
                    new OleDbParameter("@fldName", OleDbType.VarChar, 255),
                    new OleDbParameter("@PageSize", OleDbType.Integer),
                    new OleDbParameter("@PageIndex", OleDbType.Integer),
                    new OleDbParameter("@IsReCount", OleDbType.Boolean),
                    new OleDbParameter("@OrderType", OleDbType.Boolean),
                    new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
                    };
            parameters[0].Value = "RSSChannelItem";
            parameters[1].Value = "RCItemId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

