using BDD_Specflow_Selenium.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDD_Specflow_Selenium.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        [Given(@"User goes to Landing page with url ""(.*)""")]
        public void GivenUserGoesToLandingPageWithUrl(string url)
        {
            BrowserHelper.Navigate(url);
        }

        [Then(@"A product ""(.*)"" should be available Priced at ""(.*)""")]
        public void ThenAProductShouldBeAvailablePricedAt(string p0, string p1)
        {
        }

    }
}
