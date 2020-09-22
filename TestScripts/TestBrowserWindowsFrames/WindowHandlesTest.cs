using System;
using BDD_Specflow_Selenium.ComponentHelper;
using BDD_Specflow_Selenium.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace BDD_Specflow_Selenium.TestScripts
{
    [TestClass]
    public class WindowHandlesTest
    {
        [TestMethod]
        public void TestWindowHandles()
        {
            BrowserHelper.Navigate("https://www.w3schools.com/js/js_popup.asp");
            GenericHelper.FindElement(By.XPath("//*[contains(text(),'Try it Yourself')][1]"), 5000).Click();
            var windowName = ObjectRepository.Driver.WindowHandles;
            ObjectRepository.Driver.SwitchTo().Window(windowName[1]);
            BrowserHelper.GotoWindows(1);
            ObjectRepository.Driver.SwitchTo().Frame(GenericHelper.FindElement(By.XPath("//iframe[@id='iframeResult']"), 2000));
            BrowserHelper.GotoFrame(By.XPath("//iframe[@id='iframeResult']"));
            GenericHelper.FindElement(By.XPath("//button[text()='Try it']"), 5000).Click();

            ObjectRepository.Driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void TestAlert()
        {
            BrowserHelper.Navigate("http://www.w3schools.com/js/js_popup.asp");
            GenericHelper.FindElement(By.XPath("//div[@id='main']/descendant::a[position()=3]"), 5000).Click();
            BrowserHelper.GotoWindows(1);
            IWebElement textarea = ObjectRepository.Driver.FindElement(By.Id("textareaCode"));
            try
            {
                JavaScriptExecutor.ExecuteScript("document.getElementById('textareaCode').setAttribute('style','display: inline;')");
                GenericHelper.FindElement(By.CssSelector("#textareawrapper"), 5000).Clear();

            }
            catch (Exception)
            {

            }
            BrowserHelper.GotoFrame(By.Id("iframeResult"));
            // ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            //var text = JavaScriptPopHelper.GetPopUpText();
            //JavaScriptPopHelper.ClickOkOnPopup();
            //        //IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();
            //        //var text = alert.Text;
            //        //alert.Accept();
            //ObjectRepository.Driver.SwitchTo().DefaultContent();
            //GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
            //        //TextBoxHelper.ClearTextBox(By.Id("textareaCode"));
            //        //TextBoxHelper.TypeInTextBox(By.Id("textareaCode"),text);
            //Logger.Info("Test Alert Complete");
            //GenericHelper.Wait(ExpectedConditions.ElementIsVisible(By.Id("id")), TimeSpan.FromSeconds(60));

        }
    }
}
