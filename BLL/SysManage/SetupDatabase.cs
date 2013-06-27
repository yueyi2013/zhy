using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZHY.BLL
{
    public class SetupDatabase
    {
        private readonly ZHY.DAL.SetupDatabase dal = new ZHY.DAL.SetupDatabase();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlFilePath"></param>
        public bool CreateDBTables(string sqlFilePath,string dbName)
        {
            return dal.CreateDBTables(sqlFilePath, dbName);
        }
    }
}
