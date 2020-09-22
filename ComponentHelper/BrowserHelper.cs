using BDD_Specflow_Selenium.Constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.ComponentHelper
{
    public class BrowserHelper
    {
        public static void Navigate(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }

        public static void GotoWindows(int window)
        {
            var windowHandles = ObjectRepository.Driver.WindowHandles;
            if (windowHandles != null)
            {
                ObjectRepository.Driver.SwitchTo().Window(windowHandles[window]);
            }
            else
            {
                throw new NoSuchWindowException("No Windows found");
            }
        }

        public static void GotoFrame(By by)
        {
            ObjectRepository.Driver.SwitchTo().Frame(GenericHelper.FindElement(by,3000));
        }

        public static void GotoParent()
        {
            var windowHandles = ObjectRepository.Driver.WindowHandles;
            if (windowHandles != null)
            {
                for (int count = windowHandles.Count; count > 1; count--)
                {
                    ObjectRepository.Driver.Close();
                    ObjectRepository.Driver.SwitchTo().Window(windowHandles[count-2]);
                }
            }
            else
            {
                throw new NoSuchWindowException("No Windows found");
            }
        }
    }
}