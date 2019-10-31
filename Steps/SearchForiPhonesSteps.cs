using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SpecflowHw.Helper;
using SpecflowHw.Pages;
using TechTalk.SpecFlow;

namespace SpecflowHw.Steps
{
    [Binding]
    public class SearchForiPhonesSteps
    {
        private readonly IWebDriver _driver;

        public SearchForiPhonesSteps(IWebDriver driver)
        {
            _driver = driver;
        }     
        [Given(@"I open '(.*)'")]
        public void GivenIOpen(string siteName)
        {
            var landingPage = new LandingPage(_driver);
            landingPage.Navigation(_driver, siteName);

        }

        [Given(@"I search for '(.*)'")]
        public void GivenISearchFor(string searchInput)
        {
            var landingPage = new LandingPage(_driver);
            landingPage.SearchPhone(searchInput);


            var searchResultPage = new SearchResultBrandPage(_driver);
            
        }

    }
}
