using BDD_Specflow_Selenium.Configuration;

namespace BDD_Specflow_Selenium.Interfaces
{
    public interface IConfig
    {
        BrowserType GetBrowserType();
        string GetUserName();
        string GetPassword();
        string GetUrl();
    }
}
