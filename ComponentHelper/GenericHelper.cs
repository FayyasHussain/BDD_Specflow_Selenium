using BDD_Specflow_Selenium.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.ComponentHelper
{
    public class GenericHelper
    {
        public static void TakeScreenshot(string fileName = "NoNameProvided")
        {
            // ITakesScreenshot screenShotDriver = ObjectRepository.Driver as ITakesScreenshot;
            ITakesScreenshot screenShotDriver = (ITakesScreenshot)ObjectRepository.Driver;

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
            return (elements.Count > 0);
        }

        public static IWebElement GetElement(By Locator)
        {
            return ObjectRepository.Driver.FindElement(Locator);
        }

        public static IWebElement FindElement(By by, int time)
        {
            // Returns a IWebElement if found within 'time', else returns null
            // Achieved through WebDriverExplicit waits.
            // Add polling while instantiating webdriver wait.

            WebDriverWait wait = GetWebdriverwait(time);
            return wait.Until(d => d.FindElement(by));
        }

        private Func<IWebDriver,IWebElement> AnonymousFunction(By by)
        {
            return x =>
            {
              return  ObjectRepository.Driver.FindElement(by);
            };
        }

        public static bool CheckElementExists(By by, int time)
        {
            try
            {
                IWebElement element = FindElement(by, time);
                return (element != null) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsElementVisible(By by, int time)
        {
            WebDriverWait wait = GetWebdriverwait(time);
            return wait.Until(function =>
            {
                try
                {
                    IWebElement element = ObjectRepository.Driver.FindElement(by);
                    return element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        private static WebDriverWait GetWebdriverwait(int time)
        {
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromMilliseconds(time));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException));
            return wait;
        }

        public static bool RetryFindClick(By by, int time)
        {
            // Sometimes you need to click multiple times for the button to work.
            bool elementClicked = false;
            int numberOfTries = 5;
            int attempt = 1;

            while (attempt <= numberOfTries)
            {
                try
                {
                    FindElement(by, time).Click();
                    elementClicked = true;
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    attempt++;
                }
            }

            return elementClicked;
        }
    }
}
