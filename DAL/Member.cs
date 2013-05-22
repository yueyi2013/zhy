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
	public class Member
	{
		public Member()
		{ }
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
                if (ds.Tables[0].Rows[0]["LevelID"].ToString() != "")
                {
                    model.LevelID = int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
                }
                model.MemRealName = ds.Tables[0].Rows[0]["MemRealName"].ToString();
                model.MemMobile = ds.Tables[0].Rows[0]["MemMobile"].ToString();
                model.MemShotNum = ds.Tables[0].Rows[0]["MemShotNum"].ToString();
                model.MemUnitTel = ds.Tables[0].Rows[0]["MemUnitTel"].ToString();
                model.MemMedium = ds.Tables[0].Rows[0]["MemMedium"].ToString();
                model.MemStatus = ds.Tables[0].Rows[0]["MemStatus"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region  自动生成代码
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MemID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Members");
			strSql.Append(" where MemID=@MemID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MemID", SqlDbType.Decimal)};
			parameters[0].Value = MemID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Members(");
			strSql.Append("MemAccount,MemPsw,LevelID,MemRealName,MemMobile,MemShotNum,MemUnitTel,MemMedium,MemStatus)");
			strSql.Append(" values (");
			strSql.Append("@MemAccount,@MemPsw,@LevelID,@MemRealName,@MemMobile,@MemShotNum,@MemUnitTel,@MemMedium,@MemStatus)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MemAccount", SqlDbType.VarChar,128),
					new SqlParameter("@MemPsw", SqlDbType.VarChar,64),
					new SqlParameter("@LevelID", SqlDbType.Int,4),
					new SqlParameter("@MemRealName", SqlDbType.VarChar,80),
					new SqlParameter("@MemMobile", SqlDbType.VarChar,16),
					new SqlParameter("@MemShotNum", SqlDbType.VarChar,16),
					new SqlParameter("@MemUnitTel", SqlDbType.VarChar,32),
					new SqlParameter("@MemMedium", SqlDbType.VarChar,512),
					new SqlParameter("@MemStatus", SqlDbType.Char,1)};
			parameters[0].Value = model.MemAccount;
			parameters[1].Value = model.MemPsw;
			parameters[2].Value = model.LevelID;
			parameters[3].Value = model.MemRealName;
			parameters[4].Value = model.MemMobile;
			parameters[5].Value = model.MemShotNum;
			parameters[6].Value = model.MemUnitTel;
			parameters[7].Value = model.MemMedium;
			parameters[8].Value = model.MemStatus;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public void Update(ZHY.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Members set ");
			strSql.Append("MemAccount=@MemAccount,");
			strSql.Append("MemPsw=@MemPsw,");
			strSql.Append("LevelID=@LevelID,");
			strSql.Append("MemRealName=@MemRealName,");
			strSql.Append("MemMobile=@MemMobile,");
			strSql.Append("MemShotNum=@MemShotNum,");
			strSql.Append("MemUnitTel=@MemUnitTel,");
			strSql.Append("MemMedium=@MemMedium,");
			strSql.Append("MemStatus=@MemStatus");
			strSql.Append(" where MemID=@MemID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MemID", SqlDbType.Decimal,5),
					new SqlParameter("@MemAccount", SqlDbType.VarChar,128),
					new SqlParameter("@MemPsw", SqlDbType.VarChar,64),
					new SqlParameter("@LevelID", SqlDbType.Int,4),
					new SqlParameter("@MemRealName", SqlDbType.VarChar,80),
					new SqlParameter("@MemMobile", SqlDbType.VarChar,16),
					new SqlParameter("@MemShotNum", SqlDbType.VarChar,16),
					new SqlParameter("@MemUnitTel", SqlDbType.VarChar,32),
					new SqlParameter("@MemMedium", SqlDbType.VarChar,512),
					new SqlParameter("@MemStatus", SqlDbType.Char,1)};
			parameters[0].Value = model.MemID;
			parameters[1].Value = model.MemAccount;
			parameters[2].Value = model.MemPsw;
			parameters[3].Value = model.LevelID;
			parameters[4].Value = model.MemRealName;
			parameters[5].Value = model.MemMobile;
			parameters[6].Value = model.MemShotNum;
			parameters[7].Value = model.MemUnitTel;
			parameters[8].Value = model.MemMedium;
			parameters[9].Value = model.MemStatus;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(decimal MemID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Members ");
			strSql.Append(" where MemID=@MemID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MemID", SqlDbType.Decimal)};
			parameters[0].Value = MemID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.Member GetModel(decimal MemID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MemID,MemAccount,MemPsw,LevelID,MemRealName,MemMobile,MemShotNum,MemUnitTel,MemMedium,MemStatus from Members ");
			strSql.Append(" where MemID=@MemID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MemID", SqlDbType.Decimal)};
			parameters[0].Value = MemID;

			ZHY.Model.Member model=new ZHY.Model.Member();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MemID"].ToString()!="")
				{
					model.MemID=decimal.Parse(ds.Tables[0].Rows[0]["MemID"].ToString());
				}
				model.MemAccount=ds.Tables[0].Rows[0]["MemAccount"].ToString();
				model.MemPsw=ds.Tables[0].Rows[0]["MemPsw"].ToString();
				if(ds.Tables[0].Rows[0]["LevelID"].ToString()!="")
				{
					model.LevelID=int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
				}
				model.MemRealName=ds.Tables[0].Rows[0]["MemRealName"].ToString();
				model.MemMobile=ds.Tables[0].Rows[0]["MemMobile"].ToString();
				model.MemShotNum=ds.Tables[0].Rows[0]["MemShotNum"].ToString();
				model.MemUnitTel=ds.Tables[0].Rows[0]["MemUnitTel"].ToString();
				model.MemMedium=ds.Tables[0].Rows[0]["MemMedium"].ToString();
				model.MemStatus=ds.Tables[0].Rows[0]["MemStatus"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MemID,MemAccount,MemPsw,LevelID,MemRealName,MemMobile,MemShotNum,MemUnitTel,MemMedium,MemStatus ");
			strSql.Append(" FROM Members ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" MemID,MemAccount,MemPsw,LevelID,MemRealName,MemMobile,MemShotNum,MemUnitTel,MemMedium,MemStatus ");
			strSql.Append(" FROM Members ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "Members";
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

