using BDD_Specflow_Selenium.Constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.ComponentHelper
{
    public class JavascriptPopupHelper
    {
        public static bool IsAlertPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetAlertText()
        {
            if (IsAlertPresent())
            {
                return ObjectRepository.Driver.SwitchTo().Alert().Text;
            }
            return String.Empty;
        }

        public static void AcceptAlert()
        {
            if (IsAlertPresent())
            {
                ObjectRepository.Driver.SwitchTo().Alert().Accept();
            }
        }

        public static void DismissAlert()
        {
            if (IsAlertPresent())
            {
                ObjectRepository.Driver.SwitchTo().Alert().Dismiss();
            }
        }

        public static void AlertMessage(string message)
        {
            if (IsAlertPresent())
            {
                ObjectRepository.Driver.SwitchTo().Alert().SendKeys(message);
            }
        }
    }
}
