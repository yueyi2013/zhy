using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:Advertisement
	/// </summary>
	public partial class Advertisement
	{
		public Advertisement()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AdId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Advertisement");
			strSql.Append(" where AdId=@AdId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.Advertisement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Advertisement(");
			strSql.Append("AdLogo,AdName,AdCategoryId,AdBgCode,AdUnitPrice,AdUnit,AdBillingCycle,AdSource,AdCode,AdDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@AdLogo,@AdName,@AdCategoryId,@AdBgCode,@AdUnitPrice,@AdUnit,@AdBillingCycle,@AdSource,@AdCode,@AdDesc,@Status,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AdLogo", SqlDbType.VarChar,512),
					new SqlParameter("@AdName", SqlDbType.VarChar,200),
					new SqlParameter("@AdCategoryId", SqlDbType.Int,4),
					new SqlParameter("@AdBgCode", SqlDbType.VarChar,64),
					new SqlParameter("@AdUnitPrice", SqlDbType.Decimal,5),
					new SqlParameter("@AdUnit", SqlDbType.VarChar,32),
					new SqlParameter("@AdBillingCycle", SqlDbType.VarChar,64),
					new SqlParameter("@AdSource", SqlDbType.VarChar,128),
					new SqlParameter("@AdCode", SqlDbType.VarChar,1024),
					new SqlParameter("@AdDesc", SqlDbType.VarChar,512),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.AdLogo;
			parameters[1].Value = model.AdName;
			parameters[2].Value = model.AdCategoryId;
			parameters[3].Value = model.AdBgCode;
			parameters[4].Value = model.AdUnitPrice;
			parameters[5].Value = model.AdUnit;
			parameters[6].Value = model.AdBillingCycle;
			parameters[7].Value = model.AdSource;
			parameters[8].Value = model.AdCode;
			parameters[9].Value = model.AdDesc;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.CreateAt;
			parameters[12].Value = model.CreateBy;
			parameters[13].Value = model.UpdateDT;
			parameters[14].Value = model.UpdateBy;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(ZHY.Model.Advertisement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Advertisement set ");
			strSql.Append("AdLogo=@AdLogo,");
			strSql.Append("AdName=@AdName,");
			strSql.Append("AdCategoryId=@AdCategoryId,");
			strSql.Append("AdBgCode=@AdBgCode,");
			strSql.Append("AdUnitPrice=@AdUnitPrice,");
			strSql.Append("AdUnit=@AdUnit,");
			strSql.Append("AdBillingCycle=@AdBillingCycle,");
			strSql.Append("AdSource=@AdSource,");
			strSql.Append("AdCode=@AdCode,");
			strSql.Append("AdDesc=@AdDesc,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where AdId=@AdId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdLogo", SqlDbType.VarChar,512),
					new SqlParameter("@AdName", SqlDbType.VarChar,200),
					new SqlParameter("@AdCategoryId", SqlDbType.Int,4),
					new SqlParameter("@AdBgCode", SqlDbType.VarChar,64),
					new SqlParameter("@AdUnitPrice", SqlDbType.Decimal,5),
					new SqlParameter("@AdUnit", SqlDbType.VarChar,32),
					new SqlParameter("@AdBillingCycle", SqlDbType.VarChar,64),
					new SqlParameter("@AdSource", SqlDbType.VarChar,128),
					new SqlParameter("@AdCode", SqlDbType.VarChar,1024),
					new SqlParameter("@AdDesc", SqlDbType.VarChar,512),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@AdId", SqlDbType.Int,4)};
			parameters[0].Value = model.AdLogo;
			parameters[1].Value = model.AdName;
			parameters[2].Value = model.AdCategoryId;
			parameters[3].Value = model.AdBgCode;
			parameters[4].Value = model.AdUnitPrice;
			parameters[5].Value = model.AdUnit;
			parameters[6].Value = model.AdBillingCycle;
			parameters[7].Value = model.AdSource;
			parameters[8].Value = model.AdCode;
			parameters[9].Value = model.AdDesc;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.CreateAt;
			parameters[12].Value = model.CreateBy;
			parameters[13].Value = model.UpdateDT;
			parameters[14].Value = model.UpdateBy;
			parameters[15].Value = model.AdId;

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
		public bool Delete(int AdId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Advertisement ");
			strSql.Append(" where AdId=@AdId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdId;

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
		public bool DeleteList(string AdIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Advertisement ");
			strSql.Append(" where AdId in ("+AdIdlist + ")  ");
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
		public ZHY.Model.Advertisement GetModel(int AdId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AdId,AdLogo,AdName,AdCategoryId,AdBgCode,AdUnitPrice,AdUnit,AdBillingCycle,AdSource,AdCode,AdDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy from Advertisement ");
			strSql.Append(" where AdId=@AdId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdId;

			ZHY.Model.Advertisement model=new ZHY.Model.Advertisement();
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
		public ZHY.Model.Advertisement DataRowToModel(DataRow row)
		{
			ZHY.Model.Advertisement model=new ZHY.Model.Advertisement();
			if (row != null)
			{
				if(row["AdId"]!=null && row["AdId"].ToString()!="")
				{
					model.AdId=int.Parse(row["AdId"].ToString());
				}
				if(row["AdLogo"]!=null)
				{
					model.AdLogo=row["AdLogo"].ToString();
				}
				if(row["AdName"]!=null)
				{
					model.AdName=row["AdName"].ToString();
				}
				if(row["AdCategoryId"]!=null && row["AdCategoryId"].ToString()!="")
				{
					model.AdCategoryId=int.Parse(row["AdCategoryId"].ToString());
				}
				if(row["AdBgCode"]!=null)
				{
					model.AdBgCode=row["AdBgCode"].ToString();
				}
				if(row["AdUnitPrice"]!=null && row["AdUnitPrice"].ToString()!="")
				{
					model.AdUnitPrice=decimal.Parse(row["AdUnitPrice"].ToString());
				}
				if(row["AdUnit"]!=null)
				{
					model.AdUnit=row["AdUnit"].ToString();
				}
				if(row["AdBillingCycle"]!=null)
				{
					model.AdBillingCycle=row["AdBillingCycle"].ToString();
				}
				if(row["AdSource"]!=null)
				{
					model.AdSource=row["AdSource"].ToString();
				}
				if(row["AdCode"]!=null)
				{
					model.AdCode=row["AdCode"].ToString();
				}
				if(row["AdDesc"]!=null)
				{
					model.AdDesc=row["AdDesc"].ToString();
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
			strSql.Append("select AdId,AdLogo,AdName,AdCategoryId,AdBgCode,AdUnitPrice,AdUnit,AdBillingCycle,AdSource,AdCode,AdDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Advertisement ");
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
			strSql.Append(" AdId,AdLogo,AdName,AdCategoryId,AdBgCode,AdUnitPrice,AdUnit,AdBillingCycle,AdSource,AdCode,AdDesc,Status,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM Advertisement ");
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
			strSql.Append("select count(1) FROM Advertisement ");
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
				strSql.Append("order by T.AdId desc");
			}
			strSql.Append(")AS Row, T.*  from Advertisement T ");
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
			parameters[0].Value = "Advertisement";
			parameters[1].Value = "AdId";
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

