using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZHY.BLL
{
    public class SetupDatabase
    {
        private readonly ZHY.DAL.SetupDatabase dal = new ZHY.DAL.SetupDatabase();
        /// <summary>
        /// 根据SQL文件创建表
        /// </summary>
        /// <param name="sqlFilePath"></param>
        public bool CreateDBTables(string sqlFilePath,string dbName)
        {
            return dal.CreateDBTables(sqlFilePath, dbName);
        }

        /// <summary>
        /// 根据SQL内容创建表
        /// </summary>
        /// <param name="sqlFilePath"></param>
        public bool CreateDBTablesBySqlCode(string sqlCode, string dbName)
        {
            return dal.CreateDBTablesBySqlCode(sqlCode, dbName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteQuerySQL(string sqlCode)
        {
            return dal.ExecuteQuerySQL(sqlCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCode"></param>
        /// <param name="srcTable"></param>
        /// <returns></returns>
        public DataSet ExecuteQuerySQL(string sqlCode, string srcTable)
        {
            return dal.ExecuteQuerySQL(sqlCode, srcTable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuerySQL(string sqlCode)
        {
            return dal.ExecuteNonQuerySQL(sqlCode);
        }
    }
}
