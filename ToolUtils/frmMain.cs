using System;
using System.Collections.Generic;
using System.ComponentModel;
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
           // ZHY.BLL.VirtualPersonInfo bll = new ZHY.BLL.VirtualPersonInfo();
           // bll.ExtractPsnInfoFromSite();
        }

        private void autoRegPsn() 
        {
            this.wbHTML.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbHTML_Psn_DocumentCompleted);
            this.wbHTML.ScriptErrorsSuppressed = true;
            wbHTML.Navigate("http://cn.usinfo.me/", false);
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

       // ZHY.BLL.VirtualPersonInfo bll = new ZHY.BLL.VirtualPersonInfo();
        private void wbHTML_Psn_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string path = e.Url.AbsolutePath;
            if (path.IndexOf("t.html") > 0)
            {
                ZHY.Model.VirtualPersonInfo model = new ZHY.Model.VirtualPersonInfo();
                HtmlElement full_name = wbHTML.Document.GetElementById("full_name");
                model.VPFullName = full_name.GetAttribute("value");

                HtmlElement first_name = wbHTML.Document.GetElementById("first_name");
                model.VPFirstName = first_name.GetAttribute("value");

                HtmlElement last_name = wbHTML.Document.GetElementById("last_name");
                model.VPLastName = last_name.GetAttribute("value");

                HtmlElement middle_initial = wbHTML.Document.GetElementById("middle_initial");
                model.VPMiddleName = middle_initial.GetAttribute("value");

                HtmlElement gender = wbHTML.Document.GetElementById("gender");
                model.VPSex = gender.GetAttribute("value");

                HtmlElement birthday = wbHTML.Document.GetElementById("birthday");
                model.VPBirthday = DateTime.Parse(birthday.GetAttribute("value"));

                HtmlElement age = wbHTML.Document.GetElementById("age");
                model.VPAge = int.Parse(age.GetAttribute("value"));

                HtmlElement college = wbHTML.Document.GetElementById("college");
                model.VPCollege = college.GetAttribute("value");

                HtmlElement occupation = wbHTML.Document.GetElementById("occupation");
                model.VPOccupation = occupation.GetAttribute("value");

                HtmlElement ssn = wbHTML.Document.GetElementById("ssn");
                model.VPSsn = ssn.GetAttribute("value");

                HtmlElement email = wbHTML.Document.GetElementById("email");
                model.VPMail = email.GetAttribute("value");

                HtmlElement nick_name = wbHTML.Document.GetElementById("nick_name");
                model.VPNickName = nick_name.GetAttribute("value");

                HtmlElement password = wbHTML.Document.GetElementById("password");
                model.VPPassword = password.GetAttribute("value");

                HtmlElement height = wbHTML.Document.GetElementById("height");
                //model.VPHeight = height.GetAttribute("value");

                HtmlElement blood_type = wbHTML.Document.GetElementById("blood_type");
                model.VPBloodType = blood_type.GetAttribute("value");

                HtmlElement weight = wbHTML.Document.GetElementById("weight");
                //model.VPWeight = weight.GetAttribute("value");

                HtmlElement state = wbHTML.Document.GetElementById("state");
                model.VPState = state.GetAttribute("value");

                HtmlElement city = wbHTML.Document.GetElementById("city");
                model.VPCity = city.GetAttribute("value");

                HtmlElement address = wbHTML.Document.GetElementById("address");
                model.VPStreet = address.GetAttribute("value");

                HtmlElement zip = wbHTML.Document.GetElementById("zip");
                model.VPZip = int.Parse(zip.GetAttribute("value"));

                HtmlElement phone = wbHTML.Document.GetElementById("phone");
                model.VPPhone = phone.GetAttribute("value");

                HtmlElement cc_visa_number = wbHTML.Document.GetElementById("cc_visa_number");
                model.VPVisa = decimal.Parse(cc_visa_number.GetAttribute("value").Replace(" ", ""));

                HtmlElement cc_visa_expiry_date = wbHTML.Document.GetElementById("cc_visa_expiry_date");
                model.VPFullName = cc_visa_expiry_date.GetAttribute("value");

                HtmlElement cc_visa_cvv2 = wbHTML.Document.GetElementById("cc_visa_cvv2");
                model.VPCVV2 = int.Parse(cc_visa_cvv2.GetAttribute("value"));

                HtmlElement bank_name = wbHTML.Document.GetElementById("bank_name");
                model.VPBank = bank_name.GetAttribute("value");

                HtmlElement routing_number = wbHTML.Document.GetElementById("routing_number");
                model.VPRoutingNumber = decimal.Parse(routing_number.GetAttribute("value"));

                HtmlElement bank_account_number = wbHTML.Document.GetElementById("bank_account_number");
                model.VPBankAcct = decimal.Parse(bank_account_number.GetAttribute("value"));

                HtmlElement cc_mastercard_number = wbHTML.Document.GetElementById("cc_mastercard_number");
                model.VPMasterCard = decimal.Parse(cc_mastercard_number.GetAttribute("value").Replace(" ", ""));

                HtmlElement cc_mastercard_expiry_date = wbHTML.Document.GetElementById("cc_mastercard_expiry_date");
                model.VPMExpirDate = DateTime.Parse(cc_mastercard_expiry_date.GetAttribute("value"));

                HtmlElement cc_mastercard_cvc2 = wbHTML.Document.GetElementById("cc_mastercard_cvc2");
                model.VPMCVC2 = int.Parse(cc_mastercard_cvc2.GetAttribute("value"));

                HtmlElement website = wbHTML.Document.GetElementById("website");
                model.VPSite = website.GetAttribute("value");
                //bll.Add(model);
            }
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