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
        /// 
        /// </summary>
        /// <param name="itemRUL"></param>
        /// <returns></returns>
        public static string extractHtmlBatchContent(string itemRUL) 
        {
            string htmlSource = RSSFeeds.loadRssFeeds(itemRUL, "gb2312");
            if (string.IsNullOrEmpty(htmlSource)) {

                return "";
            }
            string result = extractHtmlsource(htmlSource);
            int pagecount = extractHtmlPageTags(ref result);
            if (pagecount > 0)
            {
                int len = itemRUL.Length;
                string pageUrl = itemRUL.Substring(0, len - 5);
                StringBuilder sbContent = new StringBuilder(result);
                for (int i = 2; i <= pagecount;i++ )
                {
                    htmlSource = RSSFeeds.loadRssFeeds(pageUrl+"-"+i+".html", "gb2312");
                    result = extractHtmlsource(htmlSource);
                    extractHtmlPageTags(ref result);
                    if (result.Equals(sbContent.ToString()))
                    {
                        continue;
                    }
                    sbContent.Append(result);
                }
                return sbContent.ToString();
            }
            else {

                return result;
            }
        }

        /// <summary>
        /// 提取指定标签中的节点个数
        /// </summary>
        /// <param name="htmlSource"></param>
        /// <returns></returns>
        public static int extractHtmlPageTags(ref string htmlSource)
        {
            try
            {
                Parser htmlParser = Parser.CreateParser(htmlSource, "GB2312");
                NodeFilter filter = new NodeClassFilter(typeof(Div));
                NodeList nodeList = htmlParser.Parse(filter);
                INode pageAt = null;
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
                }

                htmlSource = DropHtmlTag(htmlSource,"center");

                return tags;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        /// <summary>
        /// 去掉html内容中的指定的html标签
        /// </summary>
        /// <param name="content">html内容</param>
        /// <param name="tagName">html标签</param>
        /// <returns>去掉标签的内容</returns>
        public static string DropHtmlTag(string content, string tagName)
        {
            //去掉<tagname>和</tagname>
            return DropIgnoreCase(content, "<[/]{0,1}" + tagName + "[^>]*>" + ".*?" + "<[/]{0,1}" + tagName + "[^>]*>");
        }

        /// <summary>
        /// 删除字符串中指定的内容,不区分大小写
        /// </summary>
        /// <param name="src">要修改的字符串</param>
        /// <param name="pattern">要删除的正则表达式模式</param>
        /// <returns>已删除指定内容的字符串</returns>
        public static string DropIgnoreCase(string src, string pattern)
        {
            return ReplaceIgnoreCase(src, pattern, "");
        }

        #region 不区分大小写替换字符串
        /// <summary>
        /// 不区分大小写替换字符串
        /// </summary>
        /// <param name="src">源字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="replacement">替换字符串</param>
        /// <returns>已修改的字符串</returns>
        public static string ReplaceIgnoreCase(string src, string pattern, string replacement)
        {
            return Replace(src, pattern, replacement, RegexOptions.IgnoreCase);
        }
        #endregion

        #region 正则替换字符串
        /// <summary>
        ///  正则替换字符串
        /// </summary>
        /// <param name="src">要修改的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="replacement">替换字符串</param>
        /// <param name="options">匹配模式</param>
        /// <returns>已修改的字符串</returns>
        public static string Replace(string src, string pattern, string replacement, RegexOptions options)
        {
            Regex regex = new Regex(pattern, options | RegexOptions.Compiled);
            return regex.Replace(src, replacement);
        }
        #endregion

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
