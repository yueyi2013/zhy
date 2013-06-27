using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections;

namespace ZHY.Common
{
    public class FileOperation
    {
        /// <summary>
        /// 保存邮件地址
        /// </summary>
        /// <param name="value"></param>
        public static void SaveFile(string value,string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fs);
                try
                {
                    sw.Write(value);
                }
                catch
                {
                    
                }
                finally
                {
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    fs.Close();
                }
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public static string GetFileContent(string filePath)
        {
            using (StreamReader objReader = new StreamReader(filePath,System.Text.Encoding.Default))
            {
                try
                {
                    return objReader.ReadToEnd();
                }
                catch
                {
                    return "";
                }
                finally
                {
                    objReader.Close();
                }
            }
        }

        public static ArrayList GetSqlFile(string varFileName, string dbname)
        {
            ArrayList alSql = new ArrayList();
            if (!File.Exists(varFileName))
            {
                return alSql;
            }
            using (StreamReader rs = new StreamReader(varFileName, System.Text.Encoding.Default))//注意编码
            {
                string commandText = "";
                string varLine = "";
                try { 
                    while (rs.Peek() > -1)
                    {
                        varLine = rs.ReadLine();
                        if (varLine == "")
                        {
                            continue;
                        }
                        if (varLine != "GO" && varLine != "go")
                        {
                            commandText += varLine;
                            commandText = commandText.Replace("@database_name=N'dbhr'", string.Format("@database_name=N'{0}'", dbname));
                            commandText += "\r\n";
                        }
                        else
                        {
                            alSql.Add(commandText);
                            commandText = "";
                        }
                    }
                }catch
                {
                    return alSql;

                }finally{
                    rs.Close();
                }                
            }
            
            return alSql;
        }
    }
}
