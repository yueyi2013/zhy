using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// 
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
                    if (!string.IsNullOrEmpty(id) && id.Equals("p_content"))
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

    }
}
