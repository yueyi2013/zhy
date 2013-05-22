using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类Menu。
	/// </summary>
	public class Menu
	{
		public Menu()
		{}

		#region  成员方法

		

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int roleID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4)};
            parameters[0].Value = roleID;
            DataSet ds = DbHelperSQL.RunProcedure("GetLeftMenu", parameters, "Menu");
            return ds;
        }

		#endregion  成员方法

        #region 自动生成的方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MenuID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Menus");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)};
            parameters[0].Value = MenuID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZHY.Model.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Menus(");
            strSql.Append("MenuName,MenuDes,MenuPicPath,ParantID,MenuOrder,FunID)");
            strSql.Append(" values (");
            strSql.Append("@MenuName,@MenuDes,@MenuPicPath,@ParantID,@MenuOrder,@FunID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuName", SqlDbType.VarChar,128),
					new SqlParameter("@MenuDes", SqlDbType.VarChar,256),
					new SqlParameter("@MenuPicPath", SqlDbType.VarChar,256),
					new SqlParameter("@ParantID", SqlDbType.Int,4),
					new SqlParameter("@MenuOrder", SqlDbType.Int,4),
					new SqlParameter("@FunID", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuName;
            parameters[1].Value = model.MenuDes;
            parameters[2].Value = model.MenuPicPath;
            parameters[3].Value = model.ParantID;
            parameters[4].Value = model.MenuOrder;
            parameters[5].Value = model.FunID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(ZHY.Model.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Menus set ");
            strSql.Append("MenuName=@MenuName,");
            strSql.Append("MenuDes=@MenuDes,");
            strSql.Append("MenuPicPath=@MenuPicPath,");
            strSql.Append("ParantID=@ParantID,");
            strSql.Append("MenuOrder=@MenuOrder,");
            strSql.Append("FunID=@FunID");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.VarChar,128),
					new SqlParameter("@MenuDes", SqlDbType.VarChar,256),
					new SqlParameter("@MenuPicPath", SqlDbType.VarChar,256),
					new SqlParameter("@ParantID", SqlDbType.Int,4),
					new SqlParameter("@MenuOrder", SqlDbType.Int,4),
					new SqlParameter("@FunID", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuID;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.MenuDes;
            parameters[3].Value = model.MenuPicPath;
            parameters[4].Value = model.ParantID;
            parameters[5].Value = model.MenuOrder;
            parameters[6].Value = model.FunID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int MenuID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Menus ");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)};
            parameters[0].Value = MenuID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZHY.Model.Menu GetModel(int MenuID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MenuID,MenuName,MenuDes,MenuPicPath,ParantID,MenuOrder,FunID from Menus ");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)};
            parameters[0].Value = MenuID;

            ZHY.Model.Menu model = new ZHY.Model.Menu();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MenuID"].ToString() != "")
                {
                    model.MenuID = int.Parse(ds.Tables[0].Rows[0]["MenuID"].ToString());
                }
                model.MenuName = ds.Tables[0].Rows[0]["MenuName"].ToString();
                model.MenuDes = ds.Tables[0].Rows[0]["MenuDes"].ToString();
                model.MenuPicPath = ds.Tables[0].Rows[0]["MenuPicPath"].ToString();
                if (ds.Tables[0].Rows[0]["ParantID"].ToString() != "")
                {
                    model.ParantID = int.Parse(ds.Tables[0].Rows[0]["ParantID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MenuOrder"].ToString() != "")
                {
                    model.MenuOrder = int.Parse(ds.Tables[0].Rows[0]["MenuOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FunID"].ToString() != "")
                {
                    model.FunID = int.Parse(ds.Tables[0].Rows[0]["FunID"].ToString());
                }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MenuID,MenuName,MenuDes,MenuPicPath,ParantID,MenuOrder,FunID ");
            strSql.Append(" FROM Menus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" MenuID,MenuName,MenuDes,MenuPicPath,ParantID,MenuOrder,FunID ");
            strSql.Append(" FROM Menus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "Menus";
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

