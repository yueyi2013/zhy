using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolUtils
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
           
            InitializeComponent();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            
        }


        private void btnReg_Click(object sender, EventArgs e)
        {
            autoTask();
        }

        private void autoReg() 
        {
            this.wbHTML.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbHTML_Reg_DocumentCompleted);
            this.wbHTML.ScriptErrorsSuppressed = true;
            wbHTML.Navigate("http://www.syihy.com/", false);            
        }


        private void autoTask() 
        {
            this.wbHTML.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbHTML_DocumentCompleted);
            this.wbHTML.ScriptErrorsSuppressed = true;
            wbHTML.Navigate("http://www.admimsy.com/", false);

        }


        private void wbHTML_Reg_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) 
        {
            string path = e.Url.Host;
            if (!string.IsNullOrEmpty(path) && path.IndexOf("syihy.com") > 0 && !firstStep)
            {
                HtmlElement admimsy = wbHTML.Document.GetElementById("admimsy");
                admimsy.InvokeMember("click");
                firstStep = true;
            }

            if (!string.IsNullOrEmpty(path) && path.IndexOf("admimsy.com") > 0)
            {
                if(firstStep && !secondStep)
                {
                    HtmlElementCollection htc = wbHTML.Document.GetElementsByTagName("a");
                    foreach (HtmlElement he in htc)
                    {
                        string view = he.GetAttribute("href");
                        if (he.GetAttribute("href").LastIndexOf("CreateAccount.cfm") > 0)
                        {
                            he.InvokeMember("click");
                            secondStep = true;
                            return;
                        }
                    }
                }

                if (secondStep && !thirdStep)
                {
                    HtmlElement userName = wbHTML.Document.GetElementById("UserName");
                    userName.SetAttribute("value", "james00404");
                    HtmlElement password = wbHTML.Document.GetElementById("password");
                    password.SetAttribute("value", "james1qazxsw2");
                    HtmlElement emailAddress = wbHTML.Document.GetElementById("EmailAddress");
                    emailAddress.SetAttribute("value", "james002@gmail.com");
                    HtmlElement gender = wbHTML.Document.GetElementById("Gender");
                    gender.SetAttribute("value", "Female");                    
                    HtmlElement theMonth = wbHTML.Document.GetElementById("TheMonth");
                    theMonth.SetAttribute("value", "2");
                    HtmlElement theDay = wbHTML.Document.GetElementById("TheDay");
                    theDay.SetAttribute("value", "7");
                    HtmlElement theYear = wbHTML.Document.GetElementById("TheYear");
                    theYear.SetAttribute("value", "1982");
                    HtmlElement numberAbove = wbHTML.Document.GetElementById("NumberAbove");                    
                    HtmlElement numberBelow = wbHTML.Document.GetElementById("NumberBelow");
                    numberBelow.SetAttribute("value", numberAbove.GetAttribute("value"));
                    HtmlElement b1 = wbHTML.Document.GetElementById("B1");
                    b1.InvokeMember("click");
                    thirdStep = true;
                }

            }

        }

        private bool firstStep = false;
        private bool secondStep = false;
        private bool thirdStep = false;
        private bool fouthStep = false;
        private bool fifthStep = false;

        private void wbHTML_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string path = e.Url.AbsolutePath;
            if (!firstStep)
            {
                try
                {
                    HtmlElement userName = wbHTML.Document.GetElementById("UserName");
                    if (userName == null)
                        return;
                    HtmlElement password = wbHTML.Document.GetElementById("Password");
                    HtmlElement loginSubmit = wbHTML.Document.GetElementById("loginSubmit");
                    userName.SetAttribute("value", "james00404");
                    password.SetAttribute("value", "james1qazxsw2");
                    loginSubmit.InvokeMember("click");
                    firstStep = true;
                    return;
                }
                catch { 
                
                }
            }
            
            
            if (firstStep && !secondStep)
            {
              HtmlElementCollection htc = wbHTML.Document.GetElementsByTagName("a");
              foreach(HtmlElement he in htc)
              {
                  string view = he.GetAttribute("href");
                  if (he.GetAttribute("href").LastIndexOf("ViewAds.cfm")>0)
                  {
                      he.InvokeMember("click");
                      secondStep = true;
                      return;
                  }
              }
            }

            if (secondStep&&!thirdStep)
            {
                HtmlElementCollection htc = wbHTML.Document.GetElementsByTagName("a");
                foreach (HtmlElement he in htc)
                {
                    string view = he.GetAttribute("href");
                    if (he.GetAttribute("href").LastIndexOf("ADViewer.cfm?A=") > 0)
                    {
                        he.InvokeMember("click");
                        thirdStep = true;
                        return;
                    }
                }
            }
            if (!string.IsNullOrEmpty(path)&&
                path.IndexOf("TopViewAd")>0 && 
                thirdStep && !fouthStep)
            {
                wbHTML.Document.Window.Frames["topFrame"].Document.InvokeScript("onfinish");
                fouthStep = true;
            }
            
            if(!string.IsNullOrEmpty(path)&&
                path.IndexOf("ADViewer") > 0 &&
                fouthStep && !fifthStep)
            {
                firstStep = true;
                secondStep = true;
                thirdStep = false;
                fouthStep = false;
                fifthStep = false;
                wbHTML.Navigate("http://www.admimsy.com/ViewAds.cfm");
            }
        }

    }
}