using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类Member。
	/// </summary>
	public partial class Member :BaseDAL
	{
        #region 成员方法
        /// <summary>
        /// 验证登录会员
        /// </summary>
        /// <param name="username">会员名</param>Member
        /// <param name="userpsw">密码</param>
        /// <returns></returns>
        public bool ValidateMember(string memaccount, string mempsw, ZHY.Model.Member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Members");
            strSql.Append(" where MemAccount=@MemAccount and MemPsw=@MemPsw ");
            SqlParameter[] parameters = {
					new SqlParameter("@MemAccount", SqlDbType.VarChar,64),
                    new SqlParameter("@MemPsw", SqlDbType.VarChar,32)};
            parameters[0].Value = memaccount;
            parameters[1].Value = mempsw;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MemID"].ToString() != "")
                {
                    model.MemID = decimal.Parse(ds.Tables[0].Rows[0]["MemID"].ToString());
                }
                model.MemAccount = ds.Tables[0].Rows[0]["MemAccount"].ToString();
                model.MemPsw = ds.Tables[0].Rows[0]["MemPsw"].ToString();
                if (ds.Tables[0].Rows[0]["PsnLevelId"].ToString() != "")
                {
                    model.PsnLevelId = int.Parse(ds.Tables[0].Rows[0]["PsnLevelId"].ToString());
                }
                model.MemStatus = ds.Tables[0].Rows[0]["MemStatus"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证邮箱是否已经存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidateExistedEmail(string email) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Members");
            strSql.Append(" where MemMail=@MemMail");
            SqlParameter[] parameters = {
					new SqlParameter("@MemMail", SqlDbType.VarChar)
			};
            parameters[0].Value = email;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsActiveCodeExpired(string MemID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Members");
            strSql.Append(" where MemAccount=@MemAccount and MemStatus='P' and UpdateDT<@UpdateDT");
            SqlParameter[] parameters = {
					new SqlParameter("@MemAccount", SqlDbType.VarChar),
                    new SqlParameter("@UpdateDT", SqlDbType.DateTime)
			};
            parameters[0].Value = MemID;
            parameters[1].Value = DateTime.Now.AddHours(-1);
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("MemID", "Members");
        }

        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="MemId"></param>
        /// <returns></returns>
        public bool ActiveMember(string MemId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Members set ");
            strSql.Append("MemStatus=@MemStatus,");
            strSql.Append("UpdateDT=@UpdateDT,");
            strSql.Append("UpdateBy=@UpdateBy");
            strSql.Append(" where MemAccount=@MemAccount");
            SqlParameter[] parameters = {                    
					new SqlParameter("@MemAccount", SqlDbType.VarChar,64),
                    new SqlParameter("@MemStatus", SqlDbType.Char,1),
                    new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
            parameters[0].Value = MemId;
            parameters[1].Value = "A";
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = MemId;

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
        #endregion

       
	}
}

