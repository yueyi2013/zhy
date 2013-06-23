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

       
    }
}
