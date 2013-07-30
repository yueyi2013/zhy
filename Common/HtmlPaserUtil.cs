using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Winista;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
namespace ZHY.Common
{
    public class HtmlPaserUtil
    {

        /// <summary>
        /// 提取html指定标签中的内容
        /// </summary>
        /// <param name="htmlSource"></param>
        /// <returns></returns>
        public static string extractHtmlsource(string htmlSource)
        {
            try
            {
                Parser htmlParser = Parser.CreateParser(htmlSource, "GB2312");
                NodeFilter filter = new NodeClassFilter(typeof(Div));
                NodeList nodeList = htmlParser.Parse(filter);
                for (int i = 0; i < nodeList.Size(); i++)
                {
                    
                    Div div = (Div)nodeList.ElementAt(i);
                    string id = div.GetAttribute("id");
                    string cls = div.GetAttribute("class");
                    if (!string.IsNullOrEmpty(id) && id.Equals("p_content"))
                    {
                        return div.StringText;
                    }

                    if (!string.IsNullOrEmpty(cls) && cls.Equals("c3"))
                    {
                        return div.StringText;
                    }
                }                
            }
            catch(Exception ex) {

                Console.WriteLine(ex.Message);
            }
            return "";
        }

        /// <summary>
        /// 提取指定标签中的节点个数
        /// </summary>
        /// <param name="htmlSource"></param>
        /// <returns></returns>
        public static int extractHtmlTags(ref string htmlSource)
        {
            try
            {
                Parser htmlParser = Parser.CreateParser(htmlSource, "GB2312");
                NodeFilter filter = new NodeClassFilter(typeof(Div));
                NodeList nodeList = htmlParser.Parse(filter);
                INode pageAt = null;
                INode buttonAt = null;
                int tags = 0;
                for (int i = 0; i < nodeList.Size(); i++)
                {

                    Div div = (Div)nodeList.ElementAt(i);
                    string cls = div.GetAttribute("class");
                    
                    if (!string.IsNullOrEmpty(cls) && cls.Equals("zdfy clearfix"))
                    {
                        pageAt = nodeList[i];
                        tags = div.ChildCount;
                        htmlSource = htmlSource.Replace(nodeList[i].ToHtml(), "");
                    }

                    if (nodeList[i].GetText().Equals("center"))
                    {
                        buttonAt = nodeList[i];
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return 0;
        }


        /**/
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        ///   <param   name="NoHTML">包括HTML的源码   </param>
        ///   <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        #region
        ///移除HTML标签
        /**/
        ///   <summary>
        ///   移除HTML标签
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string ParseTags(string HTMLStr)
        {
            return Regex.Replace(HTMLStr, "<[^>]*>", "");
        }

        #endregion

        #region 移除字符串空格
        public static string RemoveStrSpace(string str)
        {
            return Regex.Replace(str, @"\s", "");
        }
        #endregion

        #region
        ///   取出文本中的图片地址
        /**/
        ///   <summary>
        ///   取出文本中的图片地址
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
              RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

        #endregion

    }
}
