using BDD_Specflow_Selenium.Configuration;
using BDD_Specflow_Selenium.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.Constants
{
    public class ObjectRepository
    {
        public static IWebDriver Driver { get; set; }
        public static IConfig Config { get; set; }
    }
}
