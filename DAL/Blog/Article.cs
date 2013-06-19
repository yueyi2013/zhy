using System.Data;
using System.Text;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
    public partial class Article : BaseDAL
    {
        /// <summary>
        /// 获取博客列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT AR.ArId,ACName,ArTitle,ArContent,ArAuthor,ArPubDate,ArClicks,ArCmtNumber,SUM(ACMTop) AS ACMTops,SUM(ACMDown) AS ACMDowns ");
            strSql.Append(" FROM Articles AR ");
            strSql.Append(" LEFT JOIN ArticleCategory AC  ON AR.ACId = AC.ACId ");
            strSql.Append(" LEFT JOIN ArticleComments ACT ON AR.ArId = ACT.ArId ");
            strSql.Append(" WHERE AR.ArStatus='A' ");
            strSql.Append(" GROUP BY AR.ArId,ACName,ArTitle,ArContent,ArAuthor,ArPubDate,ArClicks,ArCmtNumber ");
            strSql.Append(" ORDER BY AR.ArPubDate DESC ");

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
