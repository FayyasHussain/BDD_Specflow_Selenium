using BDD_Specflow_Selenium.Constants;
using BDD_Specflow_Selenium.Interfaces;
using System;
using System.Configuration;

namespace BDD_Specflow_Selenium.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowserType()
        {
            try
            {
                string browser = ConfigurationManager.AppSettings.Get(AppConstants.browser);
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
                // BrowserType browserType = browser != null ? null : null;
            }
            catch  (System.ArgumentException)
            {
                // Add to the logger
            }
            return BrowserType.None;
        }

        public string GetUserName()
        {
            return ConfigurationManager.AppSettings.Get(AppConstants.username);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConstants.password);
        }

        public string GetUrl()
        {
            return ConfigurationManager.AppSettings.Get(AppConstants.url);
        }
    }
}
