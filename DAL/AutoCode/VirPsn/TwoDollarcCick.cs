using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:TwoDollarcCick
	/// </summary>
	public partial class TwoDollarcCick
	{
		public TwoDollarcCick()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal TDCId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TwoDollarcCick");
			strSql.Append(" where TDCId=@TDCId");
			SqlParameter[] parameters = {
					new SqlParameter("@TDCId", SqlDbType.Decimal)
			};
			parameters[0].Value = TDCId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(ZHY.Model.TwoDollarcCick model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TwoDollarcCick(");
			strSql.Append("TDCCode,TDCUsername,TDCPassword,TDCEmail,TDCFullName,TDCCountry,TDCPayment,ProxyAddress,IsEnableProxy,TDCViews,TDCReferrals,TDCIsReferrals,Status,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@TDCCode,@TDCUsername,@TDCPassword,@TDCEmail,@TDCFullName,@TDCCountry,@TDCPayment,@ProxyAddress,@IsEnableProxy,@TDCViews,@TDCReferrals,@TDCIsReferrals,@Status,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TDCCode", SqlDbType.VarChar,32),
					new SqlParameter("@TDCUsername", SqlDbType.VarChar,32),
					new SqlParameter("@TDCPassword", SqlDbType.VarChar,32),
					new SqlParameter("@TDCEmail", SqlDbType.VarChar,32),
					new SqlParameter("@TDCFullName", SqlDbType.VarChar,32),
					new SqlParameter("@TDCCountry", SqlDbType.VarChar,32),
					new SqlParameter("@TDCPayment", SqlDbType.VarChar,64),
					new SqlParameter("@ProxyAddress", SqlDbType.VarChar,64),
					new SqlParameter("@IsEnableProxy", SqlDbType.Char,1),
					new SqlParameter("@TDCViews", SqlDbType.Int,4),
					new SqlParameter("@TDCReferrals", SqlDbType.VarChar,32),
					new SqlParameter("@TDCIsReferrals", SqlDbType.Char,1),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.TDCCode;
			parameters[1].Value = model.TDCUsername;
			parameters[2].Value = model.TDCPassword;
			parameters[3].Value = model.TDCEmail;
			parameters[4].Value = model.TDCFullName;
			parameters[5].Value = model.TDCCountry;
			parameters[6].Value = model.TDCPayment;
			parameters[7].Value = model.ProxyAddress;
			parameters[8].Value = model.IsEnableProxy;
			parameters[9].Value = model.TDCViews;
			parameters[10].Value = model.TDCReferrals;
			parameters[11].Value = model.TDCIsReferrals;
			parameters[12].Value = model.Status;
			parameters[13].Value = model.CreateAt;
			parameters[14].Value = model.CreateBy;
			parameters[15].Value = model.UpdateDT;
			parameters[16].Value = model.UpdateBy;

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
		public bool Update(ZHY.Model.TwoDollarcCick model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TwoDollarcCick set ");
			strSql.Append("TDCCode=@TDCCode,");
			strSql.Append("TDCUsername=@TDCUsername,");
			strSql.Append("TDCPassword=@TDCPassword,");
			strSql.Append("TDCEmail=@TDCEmail,");
			strSql.Append("TDCFullName=@TDCFullName,");
			strSql.Append("TDCCountry=@TDCCountry,");
			strSql.Append("TDCPayment=@TDCPayment,");
			strSql.Append("ProxyAddress=@ProxyAddress,");
			strSql.Append("IsEnableProxy=@IsEnableProxy,");
			strSql.Append("TDCViews=@TDCViews,");
			strSql.Append("TDCReferrals=@TDCReferrals,");
			strSql.Append("TDCIsReferrals=@TDCIsReferrals,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where TDCId=@TDCId");
			SqlParameter[] parameters = {
					new SqlParameter("@TDCCode", SqlDbType.VarChar,32),
					new SqlParameter("@TDCUsername", SqlDbType.VarChar,32),
					new SqlParameter("@TDCPassword", SqlDbType.VarChar,32),
					new SqlParameter("@TDCEmail", SqlDbType.VarChar,32),
					new SqlParameter("@TDCFullName", SqlDbType.VarChar,32),
					new SqlParameter("@TDCCountry", SqlDbType.VarChar,32),
					new SqlParameter("@TDCPayment", SqlDbType.VarChar,64),
					new SqlParameter("@ProxyAddress", SqlDbType.VarChar,64),
					new SqlParameter("@IsEnableProxy", SqlDbType.Char,1),
					new SqlParameter("@TDCViews", SqlDbType.Int,4),
					new SqlParameter("@TDCReferrals", SqlDbType.VarChar,32),
					new SqlParameter("@TDCIsReferrals", SqlDbType.Char,1),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@TDCId", SqlDbType.Decimal,9)};
			parameters[0].Value = model.TDCCode;
			parameters[1].Value = model.TDCUsername;
			parameters[2].Value = model.TDCPassword;
			parameters[3].Value = model.TDCEmail;
			parameters[4].Value = model.TDCFullName;
			parameters[5].Value = model.TDCCountry;
			parameters[6].Value = model.TDCPayment;
			parameters[7].Value = model.ProxyAddress;
			parameters[8].Value = model.IsEnableProxy;
			parameters[9].Value = model.TDCViews;
			parameters[10].Value = model.TDCReferrals;
			parameters[11].Value = model.TDCIsReferrals;
			parameters[12].Value = model.Status;
			parameters[13].Value = model.CreateAt;
			parameters[14].Value = model.CreateBy;
			parameters[15].Value = model.UpdateDT;
			parameters[16].Value = model.UpdateBy;
			parameters[17].Value = model.TDCId;

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
		public bool Delete(decimal TDCId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TwoDollarcCick ");
			strSql.Append(" where TDCId=@TDCId");
			SqlParameter[] parameters = {
					new SqlParameter("@TDCId", SqlDbType.Decimal)
			};
			parameters[0].Value = TDCId;

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
		public bool DeleteList(string TDCIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TwoDollarcCick ");
			strSql.Append(" where TDCId in ("+TDCIdlist + ")  ");
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
		public ZHY.Model.TwoDollarcCick GetModel(decimal TDCId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TDCId,TDCCode,TDCUsername,TDCPassword,TDCEmail,TDCFullName,TDCCountry,TDCPayment,ProxyAddress,IsEnableProxy,TDCViews,TDCReferrals,TDCIsReferrals,Status,CreateAt,CreateBy,UpdateDT,UpdateBy from TwoDollarcCick ");
			strSql.Append(" where TDCId=@TDCId");
			SqlParameter[] parameters = {
					new SqlParameter("@TDCId", SqlDbType.Decimal)
			};
			parameters[0].Value = TDCId;

			ZHY.Model.TwoDollarcCick model=new ZHY.Model.TwoDollarcCick();
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
		public ZHY.Model.TwoDollarcCick DataRowToModel(DataRow row)
		{
			ZHY.Model.TwoDollarcCick model=new ZHY.Model.TwoDollarcCick();
			if (row != null)
			{
				if(row["TDCId"]!=null && row["TDCId"].ToString()!="")
				{
					model.TDCId=decimal.Parse(row["TDCId"].ToString());
				}
				if(row["TDCCode"]!=null)
				{
					model.TDCCode=row["TDCCode"].ToString();
				}
				if(row["TDCUsername"]!=null)
				{
					model.TDCUsername=row["TDCUsername"].ToString();
				}
				if(row["TDCPassword"]!=null)
				{
					model.TDCPassword=row["TDCPassword"].ToString();
				}
				if(row["TDCEmail"]!=null)
				{
					model.TDCEmail=row["TDCEmail"].ToString();
				}
				if(row["TDCFullName"]!=null)
				{
					model.TDCFullName=row["TDCFullName"].ToString();
				}
				if(row["TDCCountry"]!=null)
				{
					model.TDCCountry=row["TDCCountry"].ToString();
				}
				if(row["TDCPayment"]!=null)
				{
					model.TDCPayment=row["TDCPayment"].ToString();
				}
				if(row["ProxyAddress"]!=null)
				{
					model.ProxyAddress=row["ProxyAddress"].ToString();
				}
				if(row["IsEnableProxy"]!=null)
				{
					model.IsEnableProxy=row["IsEnableProxy"].ToString();
				}
				if(row["TDCViews"]!=null && row["TDCViews"].ToString()!="")
				{
					model.TDCViews=int.Parse(row["TDCViews"].ToString());
				}
				if(row["TDCReferrals"]!=null)
				{
					model.TDCReferrals=row["TDCReferrals"].ToString();
				}
				if(row["TDCIsReferrals"]!=null)
				{
					model.TDCIsReferrals=row["TDCIsReferrals"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
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
			strSql.Append("select TDCId,TDCCode,TDCUsername,TDCPassword,TDCEmail,TDCFullName,TDCCountry,TDCPayment,ProxyAddress,IsEnableProxy,TDCViews,TDCReferrals,TDCIsReferrals,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM TwoDollarcCick ");
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
			strSql.Append(" TDCId,TDCCode,TDCUsername,TDCPassword,TDCEmail,TDCFullName,TDCCountry,TDCPayment,ProxyAddress,IsEnableProxy,TDCViews,TDCReferrals,TDCIsReferrals,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM TwoDollarcCick ");
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
			strSql.Append("select count(1) FROM TwoDollarcCick ");
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
				strSql.Append("order by T.TDCId desc");
			}
			strSql.Append(")AS Row, T.*  from TwoDollarcCick T ");
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
			parameters[0].Value = "TwoDollarcCick";
			parameters[1].Value = "TDCId";
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

