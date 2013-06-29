using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using Maticsoft.DBUtility;//请先添加引用
using System.Diagnostics;
using ZHY.Common;

namespace ZHY.DAL
{
    public class SetupDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlFilePath"></param>
        /// <returns></returns>
        public bool CreateDBTables(string sqlFilePath,string dbName)
        {
            try
            {
                DbHelperSQL.ExecuteCommand(FileOperation.GetSqlFile(sqlFilePath, dbName));
                return true;
            }
            catch {
                return false;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlFilePath"></param>
        /// <returns></returns>
        public bool CreateDBTablesBySqlCode(string sqlCode, string dbName)
        {
            try
            {
                DbHelperSQL.ExecuteCommand(FileOperation.GetSqlFileBySQLCode(sqlCode, dbName));
                return true;
            }
            catch
            {
                return false;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteQuerySQL(string sqlCode)
        {
            try
            {

                return DbHelperSQL.Query(sqlCode);
            }
            catch
            {
                return new DataSet();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuerySQL(string sqlCode)
        {
            try
            {

                return DbHelperSQL.ExecuteSql(sqlCode);
            }
            catch
            {
                return 0;
            }
        }

        //U为用户名,P为密码,S为目标服务器的ip,infile为数据库脚本所在的路径
        public bool CreateDBTables(string userName, string psw, string targetIP, string inFile, string dbName)
        {
            try
            {
                Process sqlprocess = new Process();
                sqlprocess.StartInfo.FileName = "osql.exe";
                //U为用户名,P为密码,S为目标服务器的ip,infile为数据库脚本所在的路径
                sqlprocess.StartInfo.Arguments = String.Format("-U {0} -P {1} -S {2} -i {3} -d {4}", userName, psw, targetIP, inFile, dbName);
                sqlprocess.Start();
                //等待程序执行.Sql脚本
                sqlprocess.WaitForExit();
                sqlprocess.Close();
                return true;
            }
            catch {
                return false;            
            }
            
        }
    }
}
