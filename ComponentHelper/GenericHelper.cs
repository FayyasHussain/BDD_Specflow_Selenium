using BDD_Specflow_Selenium.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.ComponentHelper
{
    public class GenericHelper
    {
       public static void TakeScreenshot(string fileName = "NoNameProvided")
        {
            ITakesScreenshot screenShotDriver = ObjectRepository.Driver as ITakesScreenshot;
            Screenshot screenshot = screenShotDriver.GetScreenshot();
            if (fileName.Equals("NoNameProvided"))
            {
                fileName = "Screen" + DateTime.Now.ToString("dd'-'MM'-'yyyy'-'HH'-'mm'-'ss") + ".Jpeg";
            }
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
        }

        public static bool IsElementPresent(By by)
        {
            ReadOnlyCollection<IWebElement> elements = ObjectRepository.Driver.FindElements(by);
            return (elements.Count > 0) ? true : false;
        }

        public static IWebElement GetElement(By Locator)
        {
            return ObjectRepository.Driver.FindElement(Locator);
        }

        public static IWebElement FindElement(By by, int time)
        {
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromMilliseconds(time));
            wait.IgnoreExceptionTypes(typeof(NotFoundException),typeof(TimeoutException),typeof(NoSuchElementException));
            return wait.Until(d => d.FindElement(by));
        }
    }
}
