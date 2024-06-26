using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ResuMeta_BDDTests.Shared;
using System.Collections.ObjectModel;
using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace ResuMeta_BDDTests.PageObjects
{
    public class ViewResumePageObject : PageObject
    {
        public ViewResumePageObject(IWebDriver webDriver) : base(webDriver)
        {
            // using a named page (in Common.cs)
            _pageName = "ViewResume";
        }

        public bool resumeCreated = false;

        public IWebElement QuillEditor => _webDriver.FindElement(By.CssSelector("div[class=\"ql-editor\"]"));
        public IWebElement QuillToolBar => _webDriver.FindElement(By.CssSelector("div[class=\"ql-toolbar ql-snow\"]"));
        public IWebElement SaveResumeBtn => _webDriver.FindElement(By.Id("save-resume"));
        public IWebElement ResumeTitle => _webDriver.FindElement(By.Id("resume-title"));
        public IWebElement ExportPdfBtn => _webDriver.FindElement(By.Id("export-pdf"));
        public IWebElement ImproveWithAIBtn => _webDriver.FindElement(By.Id("improve-with-ai"));
        public bool GetEditor()
        {
            if (QuillToolBar.Displayed && QuillEditor.Displayed) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TypeIntoEditor()
        {
            Thread.Sleep(1000);
            QuillEditor.Click();
            QuillEditor.SendKeys("Hello, World!");
            Thread.Sleep(1000);
        }   

        public void SaveResume()
        {
            ResumeTitle.Click();
            ResumeTitle.SendKeys("Test Resume");
            SaveResumeBtn.Click();
            resumeCreated = true;
        }

        public string GetSaveMessage()
        {
            Thread.Sleep(1000);
            var saveStatus = _webDriver.FindElement(By.Id("validation-success"));
            return saveStatus.Text;
        }

        public void ExportPdf()
        {
            ExportPdfBtn.Click();
            Thread.Sleep(3000);
            if (_webDriver.WindowHandles.Count > 1)
            {
                _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);
                _webDriver.Close();
                _webDriver.SwitchTo().Window(_webDriver.WindowHandles[0]);
            }
        }
        public bool ImproveWithAIButton()
        {
            Thread.Sleep(1000);
            if (ImproveWithAIBtn.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ClickImproveWithAI()
        {
            ImproveWithAIBtn.Click();
        }
        public string GetYourImprovedResumeUrl(string resumeId)
        {
            string improveResumeUrl = "/ImproveResume/" + resumeId;

            return improveResumeUrl;
        }

    }
}
