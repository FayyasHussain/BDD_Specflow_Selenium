using BDD_Specflow_Selenium.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.ComponentHelper
{
    public class NavigationHelper
    {
        public static void Navigate(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }
    }
}
