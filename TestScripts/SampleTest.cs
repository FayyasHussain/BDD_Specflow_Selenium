using System;
using BDD_Specflow_Selenium.ComponentHelper;
using BDD_Specflow_Selenium.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDD_Specflow_Selenium.TestScripts
{
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void TestMethod2()
        {
            NavigationHelper.Navigate(ObjectRepository.Config.GetUrl());
        }
    }
}
