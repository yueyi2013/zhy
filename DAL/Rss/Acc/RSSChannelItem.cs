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
    public partial class RSSChannelItem : BaseAccDAL
    {
        /// <summary>
        /// 增加一条数据,如果发生异常则返回异常信息
        /// </summary>
        public bool Add(ZHY.Model.RSSChannelItem model,ref string errorMsg)
        {
            try {

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
            }
            catch (OleDbException ex)
            {
                errorMsg = ex.Message;
            
            }catch(Exception ex)
            {
                errorMsg = ex.Message;
            }
            return false;
        }
    }
}

