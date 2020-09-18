using System;
using BDD_Specflow_Selenium.ComponentHelper;
using BDD_Specflow_Selenium.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace BDD_Specflow_Selenium.TestScripts
{
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void TestMethod2()
        {
            NavigationHelper.Navigate(ObjectRepository.Config.GetUrl());
            //GenericHelper.TakeScreenshot("Screengrab.Jpeg");
            // GenericHelper.TakeScreenshot();
            GenericHelper.FindElement(By.XPath("//input[@placeholder='Search']"), 5000).SendKeys("Shirt");
            GenericHelper.FindElement(By.XPath("//button[@name='submit_search']"), 5000).Click();
            GenericHelper.FindElement(By.XPath("//ul[@class='product_list grid row']/li[1]"), 5000).Click();
            GenericHelper.FindElement(By.XPath("//ul[@class='product_list grid row']/li[1]"), 5000).Click();

        }
    }
}
