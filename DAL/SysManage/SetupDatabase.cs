using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Maticsoft.DBUtility;//请先添加引用
using System.Diagnostics;

namespace ZHY.DAL
{
    public class SetupDatabase
    {
        public void ExecuteSQL(string sqlFilePath)
        {
            using (StreamReader strRead = File.OpenText(sqlFilePath))
            {
                string strContent = strRead.ReadToEnd();
                strRead.Close();
                DbHelperSQL.ExecuteSql(strContent);
            }
        }

        //U为用户名,P为密码,S为目标服务器的ip,infile为数据库脚本所在的路径
        public bool ExecuteSQL(string userName,string psw,string targetIP,string inFile,string dbName)
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
