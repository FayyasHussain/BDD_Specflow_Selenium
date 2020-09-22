using BDD_Specflow_Selenium.Constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.ComponentHelper
{
    public class JavaScriptExecutor
    {
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)ObjectRepository.Driver;
            return executor.ExecuteScript(script);
        }
    }
}
