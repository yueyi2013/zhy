using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:ADmimsy
	/// </summary>
	public partial class ADmimsy
	{
		public ADmimsy()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal AdmyId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ADmimsy");
			strSql.Append(" where AdmyId=@AdmyId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdmyId", SqlDbType.Decimal)
			};
			parameters[0].Value = AdmyId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.ADmimsy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ADmimsy(");
			strSql.Append("AdmyCode,AdmyUserName,AdmyPassword,AdmyEmail,AdmyCountry,AdmyBirthday,AdmyGender,AdmyPayment,ProxyAddress,IsEnableProxy,AdmyViews,AdmyIsReferrals,AdmyReferrals,AdmyStatus,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@AdmyCode,@AdmyUserName,@AdmyPassword,@AdmyEmail,@AdmyCountry,@AdmyBirthday,@AdmyGender,@AdmyPayment,@ProxyAddress,@IsEnableProxy,@AdmyViews,@AdmyIsReferrals,@AdmyReferrals,@AdmyStatus,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AdmyCode", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyUserName", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyPassword", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyEmail", SqlDbType.VarChar,64),
					new SqlParameter("@AdmyCountry", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyBirthday", SqlDbType.DateTime),
					new SqlParameter("@AdmyGender", SqlDbType.VarChar,8),
					new SqlParameter("@AdmyPayment", SqlDbType.VarChar,64),
					new SqlParameter("@ProxyAddress", SqlDbType.VarChar,64),
					new SqlParameter("@IsEnableProxy", SqlDbType.Char,1),
					new SqlParameter("@AdmyViews", SqlDbType.Int,4),
					new SqlParameter("@AdmyIsReferrals", SqlDbType.Char,1),
					new SqlParameter("@AdmyReferrals", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.AdmyCode;
			parameters[1].Value = model.AdmyUserName;
			parameters[2].Value = model.AdmyPassword;
			parameters[3].Value = model.AdmyEmail;
			parameters[4].Value = model.AdmyCountry;
			parameters[5].Value = model.AdmyBirthday;
			parameters[6].Value = model.AdmyGender;
			parameters[7].Value = model.AdmyPayment;
			parameters[8].Value = model.ProxyAddress;
			parameters[9].Value = model.IsEnableProxy;
			parameters[10].Value = model.AdmyViews;
			parameters[11].Value = model.AdmyIsReferrals;
			parameters[12].Value = model.AdmyReferrals;
			parameters[13].Value = model.AdmyStatus;
			parameters[14].Value = model.CreateAt;
			parameters[15].Value = model.CreateBy;
			parameters[16].Value = model.UpdateDT;
			parameters[17].Value = model.UpdateBy;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.ADmimsy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ADmimsy set ");
			strSql.Append("AdmyCode=@AdmyCode,");
			strSql.Append("AdmyUserName=@AdmyUserName,");
			strSql.Append("AdmyPassword=@AdmyPassword,");
			strSql.Append("AdmyEmail=@AdmyEmail,");
			strSql.Append("AdmyCountry=@AdmyCountry,");
			strSql.Append("AdmyBirthday=@AdmyBirthday,");
			strSql.Append("AdmyGender=@AdmyGender,");
			strSql.Append("AdmyPayment=@AdmyPayment,");
			strSql.Append("ProxyAddress=@ProxyAddress,");
			strSql.Append("IsEnableProxy=@IsEnableProxy,");
			strSql.Append("AdmyViews=@AdmyViews,");
			strSql.Append("AdmyIsReferrals=@AdmyIsReferrals,");
			strSql.Append("AdmyReferrals=@AdmyReferrals,");
			strSql.Append("AdmyStatus=@AdmyStatus,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where AdmyId=@AdmyId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdmyCode", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyUserName", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyPassword", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyEmail", SqlDbType.VarChar,64),
					new SqlParameter("@AdmyCountry", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyBirthday", SqlDbType.DateTime),
					new SqlParameter("@AdmyGender", SqlDbType.VarChar,8),
					new SqlParameter("@AdmyPayment", SqlDbType.VarChar,64),
					new SqlParameter("@ProxyAddress", SqlDbType.VarChar,64),
					new SqlParameter("@IsEnableProxy", SqlDbType.Char,1),
					new SqlParameter("@AdmyViews", SqlDbType.Int,4),
					new SqlParameter("@AdmyIsReferrals", SqlDbType.Char,1),
					new SqlParameter("@AdmyReferrals", SqlDbType.VarChar,32),
					new SqlParameter("@AdmyStatus", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@AdmyId", SqlDbType.Decimal,9)};
			parameters[0].Value = model.AdmyCode;
			parameters[1].Value = model.AdmyUserName;
			parameters[2].Value = model.AdmyPassword;
			parameters[3].Value = model.AdmyEmail;
			parameters[4].Value = model.AdmyCountry;
			parameters[5].Value = model.AdmyBirthday;
			parameters[6].Value = model.AdmyGender;
			parameters[7].Value = model.AdmyPayment;
			parameters[8].Value = model.ProxyAddress;
			parameters[9].Value = model.IsEnableProxy;
			parameters[10].Value = model.AdmyViews;
			parameters[11].Value = model.AdmyIsReferrals;
			parameters[12].Value = model.AdmyReferrals;
			parameters[13].Value = model.AdmyStatus;
			parameters[14].Value = model.CreateAt;
			parameters[15].Value = model.CreateBy;
			parameters[16].Value = model.UpdateDT;
			parameters[17].Value = model.UpdateBy;
			parameters[18].Value = model.AdmyId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(decimal AdmyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ADmimsy ");
			strSql.Append(" where AdmyId=@AdmyId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdmyId", SqlDbType.Decimal)
			};
			parameters[0].Value = AdmyId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string AdmyIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ADmimsy ");
			strSql.Append(" where AdmyId in ("+AdmyIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public ZHY.Model.ADmimsy GetModel(decimal AdmyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AdmyId,AdmyCode,AdmyUserName,AdmyPassword,AdmyEmail,AdmyCountry,AdmyBirthday,AdmyGender,AdmyPayment,ProxyAddress,IsEnableProxy,AdmyViews,AdmyIsReferrals,AdmyReferrals,AdmyStatus,CreateAt,CreateBy,UpdateDT,UpdateBy from ADmimsy ");
			strSql.Append(" where AdmyId=@AdmyId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdmyId", SqlDbType.Decimal)
			};
			parameters[0].Value = AdmyId;

			ZHY.Model.ADmimsy model=new ZHY.Model.ADmimsy();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public ZHY.Model.ADmimsy DataRowToModel(DataRow row)
		{
			ZHY.Model.ADmimsy model=new ZHY.Model.ADmimsy();
			if (row != null)
			{
				if(row["AdmyId"]!=null && row["AdmyId"].ToString()!="")
				{
					model.AdmyId=decimal.Parse(row["AdmyId"].ToString());
				}
				if(row["AdmyCode"]!=null)
				{
					model.AdmyCode=row["AdmyCode"].ToString();
				}
				if(row["AdmyUserName"]!=null)
				{
					model.AdmyUserName=row["AdmyUserName"].ToString();
				}
				if(row["AdmyPassword"]!=null)
				{
					model.AdmyPassword=row["AdmyPassword"].ToString();
				}
				if(row["AdmyEmail"]!=null)
				{
					model.AdmyEmail=row["AdmyEmail"].ToString();
				}
				if(row["AdmyCountry"]!=null)
				{
					model.AdmyCountry=row["AdmyCountry"].ToString();
				}
				if(row["AdmyBirthday"]!=null && row["AdmyBirthday"].ToString()!="")
				{
					model.AdmyBirthday=DateTime.Parse(row["AdmyBirthday"].ToString());
				}
				if(row["AdmyGender"]!=null)
				{
					model.AdmyGender=row["AdmyGender"].ToString();
				}
				if(row["AdmyPayment"]!=null)
				{
					model.AdmyPayment=row["AdmyPayment"].ToString();
				}
				if(row["ProxyAddress"]!=null)
				{
					model.ProxyAddress=row["ProxyAddress"].ToString();
				}
				if(row["IsEnableProxy"]!=null)
				{
					model.IsEnableProxy=row["IsEnableProxy"].ToString();
				}
				if(row["AdmyViews"]!=null && row["AdmyViews"].ToString()!="")
				{
					model.AdmyViews=int.Parse(row["AdmyViews"].ToString());
				}
				if(row["AdmyIsReferrals"]!=null)
				{
					model.AdmyIsReferrals=row["AdmyIsReferrals"].ToString();
				}
				if(row["AdmyReferrals"]!=null)
				{
					model.AdmyReferrals=row["AdmyReferrals"].ToString();
				}
				if(row["AdmyStatus"]!=null)
				{
					model.AdmyStatus=row["AdmyStatus"].ToString();
				}
				if(row["CreateAt"]!=null && row["CreateAt"].ToString()!="")
				{
					model.CreateAt=DateTime.Parse(row["CreateAt"].ToString());
				}
				if(row["CreateBy"]!=null)
				{
					model.CreateBy=row["CreateBy"].ToString();
				}
				if(row["UpdateDT"]!=null && row["UpdateDT"].ToString()!="")
				{
					model.UpdateDT=DateTime.Parse(row["UpdateDT"].ToString());
				}
				if(row["UpdateBy"]!=null)
				{
					model.UpdateBy=row["UpdateBy"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AdmyId,AdmyCode,AdmyUserName,AdmyPassword,AdmyEmail,AdmyCountry,AdmyBirthday,AdmyGender,AdmyPayment,ProxyAddress,IsEnableProxy,AdmyViews,AdmyIsReferrals,AdmyReferrals,AdmyStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM ADmimsy ");
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
			strSql.Append(" AdmyId,AdmyCode,AdmyUserName,AdmyPassword,AdmyEmail,AdmyCountry,AdmyBirthday,AdmyGender,AdmyPayment,ProxyAddress,IsEnableProxy,AdmyViews,AdmyIsReferrals,AdmyReferrals,AdmyStatus,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM ADmimsy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ADmimsy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.AdmyId desc");
			}
			strSql.Append(")AS Row, T.*  from ADmimsy T ");
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
			parameters[0].Value = "ADmimsy";
			parameters[1].Value = "AdmyId";
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

