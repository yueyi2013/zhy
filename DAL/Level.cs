using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类Level。
	/// </summary>
	public class Level
	{
		public Level()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LevelID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Levels");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.Level model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Levels(");
			strSql.Append("LevelName)");
			strSql.Append(" values (");
			strSql.Append("@LevelName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelName", SqlDbType.VarChar,256)};
			parameters[0].Value = model.LevelName;

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
		public void Update(ZHY.Model.Level model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Levels set ");
			strSql.Append("LevelName=@LevelName");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4),
					new SqlParameter("@LevelName", SqlDbType.VarChar,256)};
			parameters[0].Value = model.LevelID;
			parameters[1].Value = model.LevelName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int LevelID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Levels ");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.Level GetModel(int LevelID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LevelID,LevelName from Levels ");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

			ZHY.Model.Level model=new ZHY.Model.Level();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LevelID"].ToString()!="")
				{
					model.LevelID=int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
				}
				model.LevelName=ds.Tables[0].Rows[0]["LevelName"].ToString();
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
			strSql.Append("select LevelID,LevelName ");
			strSql.Append(" FROM Levels ");
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
			strSql.Append(" LevelID,LevelName ");
			strSql.Append(" FROM Levels ");
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
			parameters[0].Value = "Levels";
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

