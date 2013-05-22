using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类FriendLink。
	/// </summary>
	public class FriendLink
	{
		public FriendLink()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FLID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FriendLink");
			strSql.Append(" where FLID=@FLID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FLID", SqlDbType.Int,4)};
			parameters[0].Value = FLID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.FriendLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FriendLink(");
			strSql.Append("FLName,FLSite,FLPic,FLViewMethod,FLDes)");
			strSql.Append(" values (");
			strSql.Append("@FLName,@FLSite,@FLPic,@FLViewMethod,@FLDes)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FLName", SqlDbType.VarChar,128),
					new SqlParameter("@FLSite", SqlDbType.VarChar,256),
					new SqlParameter("@FLPic", SqlDbType.VarChar,64),
					new SqlParameter("@FLViewMethod", SqlDbType.Char,1),
					new SqlParameter("@FLDes", SqlDbType.VarChar,256)};
			parameters[0].Value = model.FLName;
			parameters[1].Value = model.FLSite;
			parameters[2].Value = model.FLPic;
			parameters[3].Value = model.FLViewMethod;
			parameters[4].Value = model.FLDes;

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
		public void Update(ZHY.Model.FriendLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FriendLink set ");
			strSql.Append("FLName=@FLName,");
			strSql.Append("FLSite=@FLSite,");
			strSql.Append("FLPic=@FLPic,");
			strSql.Append("FLViewMethod=@FLViewMethod,");
			strSql.Append("FLDes=@FLDes");
			strSql.Append(" where FLID=@FLID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FLID", SqlDbType.Int,4),
					new SqlParameter("@FLName", SqlDbType.VarChar,128),
					new SqlParameter("@FLSite", SqlDbType.VarChar,256),
					new SqlParameter("@FLPic", SqlDbType.VarChar,64),
					new SqlParameter("@FLViewMethod", SqlDbType.Char,1),
					new SqlParameter("@FLDes", SqlDbType.VarChar,256)};
			parameters[0].Value = model.FLID;
			parameters[1].Value = model.FLName;
			parameters[2].Value = model.FLSite;
			parameters[3].Value = model.FLPic;
			parameters[4].Value = model.FLViewMethod;
			parameters[5].Value = model.FLDes;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int FLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendLink ");
			strSql.Append(" where FLID=@FLID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FLID", SqlDbType.Int,4)};
			parameters[0].Value = FLID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.FriendLink GetModel(int FLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FLID,FLName,FLSite,FLPic,FLViewMethod,FLDes from FriendLink ");
			strSql.Append(" where FLID=@FLID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FLID", SqlDbType.Int,4)};
			parameters[0].Value = FLID;

			ZHY.Model.FriendLink model=new ZHY.Model.FriendLink();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FLID"].ToString()!="")
				{
					model.FLID=int.Parse(ds.Tables[0].Rows[0]["FLID"].ToString());
				}
				model.FLName=ds.Tables[0].Rows[0]["FLName"].ToString();
				model.FLSite=ds.Tables[0].Rows[0]["FLSite"].ToString();
				model.FLPic=ds.Tables[0].Rows[0]["FLPic"].ToString();
				model.FLViewMethod=ds.Tables[0].Rows[0]["FLViewMethod"].ToString();
				model.FLDes=ds.Tables[0].Rows[0]["FLDes"].ToString();
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
			strSql.Append("select FLID,FLName,FLSite,FLPic,FLViewMethod,FLDes ");
			strSql.Append(" FROM FriendLink ");
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
			strSql.Append(" FLID,FLName,FLSite,FLPic,FLViewMethod,FLDes ");
			strSql.Append(" FROM FriendLink ");
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
			parameters[0].Value = "FriendLink";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

