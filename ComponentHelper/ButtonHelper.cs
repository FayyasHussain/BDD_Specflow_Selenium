using BDD_Specflow_Selenium.Constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.ComponentHelper
{
    public class ButtonHelper
    {
        public void Click(By by)
        {
            ObjectRepository.Driver.FindElement(by).Click();
        }
    }
}
