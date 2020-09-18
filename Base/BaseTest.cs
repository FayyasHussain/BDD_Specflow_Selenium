using BDD_Specflow_Selenium.Configuration;
using BDD_Specflow_Selenium.Constants;
using BDD_Specflow_Selenium.CustomException;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace BDD_Specflow_Selenium.Base
{
    [TestClass]
    public class BaseTest
    {

        [AssemblyInitialize]
        public static void SuiteInitialize(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();

            switch (ObjectRepository.Config.GetBrowserType())
            {
                case BrowserType.Chrome:
                    {
                        ObjectRepository.Driver = GetChromeDriver();
                        break;
                    };
                case BrowserType.Edge:
                    {
                        ObjectRepository.Driver = GetEdgeDriver();
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        ObjectRepository.Driver = GetFirefoxDriver();
                        break;
                    }
                case BrowserType.Safari:
                    {
                        ObjectRepository.Driver = GetSafariDriver();
                        break;
                    }
                case BrowserType.IE:
                    {
                        ObjectRepository.Driver = GetIEDriver();
                        break;
                    }
                default:
                    {
                        throw new NoSuitableDriverFoundException("Driver not found : " + ObjectRepository.Config.GetBrowserType());
                    }
            }
        }

        private static IWebDriver GetIEDriver()
        {
            return new InternetExplorerDriver(GetIEOptions());
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            return options;
        }

        private static IWebDriver GetSafariDriver()
        {
            return new SafariDriver();
        }

        private static IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver(GetFirefoxOptions());
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();
            FirefoxOptions options = new FirefoxOptions();
            // options.Profile = manager.GetProfile("default-release");
            return options;
        }

        private static IWebDriver GetEdgeDriver()
        {
            return new EdgeDriver();
        }

        private static IWebDriver GetChromeDriver()
        {
            return new ChromeDriver(GetChromeOptions());
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddExtension(@"E:\Fayyas\Projects\Learning\C# Selenium\BDD_Specflow_Selenium\Extensions\extension_1_21_0_0.crx");
            return options;
        }

        [AssemblyCleanup]
        public static void SuiteCleanup()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
