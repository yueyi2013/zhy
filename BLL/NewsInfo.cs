using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZHY.Model;
using System.Collections;

using System.IO;
using System.Net;
namespace ZHY.BLL
{
	/// <summary>
	/// NewsInfo
	/// </summary>
	public partial class NewsInfo
	{
		private readonly ZHY.DAL.NewsInfo dal=new ZHY.DAL.NewsInfo();
		public NewsInfo()
		{}

        #region ��Ա����
        /// <summary>
        /// ���÷�ҳ�洢����
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="name"></param>
        /// <param name="CountAll"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, string name, ref int CountAll)
        {
            string strGetFields = " NewsId,NewsTitle,NewsPubDate,NewsAuthor,NewsCategory,NewsIndustry,NewsSource,NewsContents,NewsStatus,NavCreateAt,NavCreateBy,NavUpdateDT,NavUpdateBy ";
            string tablename = " NewsInfo ";
            int pageSize = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("pageSize"));
            int intOrder = Int32.Parse(LTP.Common.ConfigHelper.GetKeyValue("intOrder"));
            string strOrder = " NavUpdateDT";
            string strWhere = " 1=1 ";
            if (!String.IsNullOrEmpty(name))
            {
                strWhere += "NewsTitle like '%" + name + "'";
            }

            return dal.GetList(tablename, strGetFields, PageIndex, pageSize, strWhere, strOrder, intOrder, ref CountAll);
        }

        public void NewsCollect(string inputURL,string userName)
        {
            ArrayList titleList = GetMainPage(inputURL);
            StringBuilder sbTitle = new StringBuilder();
            StringBuilder sbContent = new StringBuilder();
            for (int k = 0; k < titleList.Count - 1; k++)
            {
                ZHY.Model.NewsInfo model = new ZHY.Model.NewsInfo();
                model.NavCreateBy = userName;
                model.NavUpdateBy = userName;
                string content = GetPage(titleList[k].ToString());

                //��ȡ����
                int titleS = content.IndexOf("<h1>") + 4;
                int titleE = content.IndexOf("</h1>");
                string title = content.Substring(titleS, titleE - titleS);
                model.NewsTitle = title;

                //��ȡʱ��
                int dateS = content.IndexOf("<span id=\"endData\">") + 19;
                int dateE = content.IndexOf("</span>");
                string date = content.Substring(dateS, dateE - dateS);
                string[] strDate = date.Split('/');
                model.NewsPubDate = DateTime.Parse(strDate[0] + "-" + strDate[1]+"-"+strDate[2]+" "+strDate[3]);

                //��ȡ��Դ(����ҳ����Դ���ڵڶ���</span>��,����Ҫ�ӵ�һ��</span>�Ժ���ַ��н�ȡ)
                string temp = content.Substring(dateE + 5);
                int sourseS = temp.IndexOf("<span id=\"endSource\">") + 21;
                int sourseE = temp.IndexOf("</span>");
                string sourse = temp.Substring(sourseS, sourseE - sourseS);
                model.NewsSource = sourse;

                //��ȡ����
                int authorS = content.IndexOf("<span id=\"endAuthor\">");
                if (authorS > 0)
                {
                    string tempAuthor = content.Substring(authorS + 21);
                    int authorE = tempAuthor.IndexOf("</span>");
                    string author = tempAuthor.Substring(0, authorE);
                    model.NewsAuthor = author;
                }
                else
                {
                    model.NewsAuthor = "";
                }

                //��ȡ����
                string neirong = "";
                if (content.IndexOf(">[1]<") > 0)
                {
                    neirong += GetContent(content, "duo");
                    for (int i = 2; i < 100; i++)
                    {
                        if (content.IndexOf(">[" + i + "]<") > 0)
                        {
                            string urls = titleList[k].ToString().Replace(".shtml", "-" + i + ".shtml");
                            neirong += GetContent(GetPage(urls), "duo");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                    neirong += GetContent(content, "one");

                model.NewsContents = neirong;

                try
                {

                    Add(model);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }


        public ArrayList GetMainPage(string inputUrl)
        {
            //�õ���ҳ��
            string mainPage = GetPage(inputUrl);

            //�洢����
            ArrayList titleList = new ArrayList();

            //��ȡ��һҳ���б�������
            string temp = "��<a class=line05 href=\"";
            for (int i = 0; i < 100; i++)
            {
                int titleS = mainPage.IndexOf(temp) + 23;
                string str = mainPage.Substring(titleS, 26);

                int urlS = inputUrl.IndexOf("http://info.laser.hc360.com") + 27;
                string urlTemp = inputUrl.Substring(urlS);

                string url = inputUrl.Replace(urlTemp, str);
                titleList.Add(url);
                mainPage = mainPage.Substring(titleS);
                if (titleS < 23)
                    break;
            }
            return titleList;
        }

        public string GetPage(string url)
        {
            string content = "";
            HttpWebResponse webResponse = null;
            StreamReader reader = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("GB2312"));
                //����ҳ������
                content = reader.ReadToEnd();
            }
            catch(Exception ex)
            {

                
            }
            finally {

                reader.Close();
                webResponse.Close();  
            }
            
            return content.Replace("<script", "&lt;script");
        }

        public string GetContent(string page, string type)
        {
            int contentS = page.IndexOf("<div id=\"artical\">") + 18;
            int contentE = 0;
            if (type.Equals("one"))
            {
                contentE = page.IndexOf("</div>", contentS);
            }
            else
            {
                contentE = page.IndexOf("<div style=\"text-align:center;\">", contentS) - 3;
            }

            if (contentE - contentS < 0)
            {
                return "�쳣";
            }
            return page.Substring(contentS, contentE - contentS);
        }

        #endregion

        #region  BasicMethod
        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(decimal NewsId)
		{
			return dal.Exists(NewsId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public decimal Add(ZHY.Model.NewsInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(ZHY.Model.NewsInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(decimal NewsId)
		{
			
			return dal.Delete(NewsId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string NewsIdlist )
		{
			return dal.DeleteList(NewsIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZHY.Model.NewsInfo GetModel(decimal NewsId)
		{
			
			return dal.GetModel(NewsId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public ZHY.Model.NewsInfo GetModelByCache(decimal NewsId)
		{
			
			string CacheKey = "NewsInfoModel-" + NewsId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NewsId);
					if (objModel != null)
					{
						//int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("CacheTime"), 30);
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache"); 
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZHY.Model.NewsInfo)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.NewsInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZHY.Model.NewsInfo> DataTableToList(DataTable dt)
		{
			List<ZHY.Model.NewsInfo> modelList = new List<ZHY.Model.NewsInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZHY.Model.NewsInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

