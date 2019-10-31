using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SpecflowHw.Pages
{
    public class LandingPage
    {
        private readonly IWebDriver _driver;

        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SearchField => _driver.FindElement(By.XPath("//input[@name='search']"));
        public IWebElement SearchButton => _driver.FindElement(By.XPath("//button[contains(text(),'Найти')]"));
        public LandingPage Navigation(IWebDriver driver, string page)
        {
            driver.Url = page;
            return new LandingPage(driver);
        }

        public SearchResultBrandPage SearchPhone(string brand)
        {
            SearchField.SendKeys(brand);
            SearchButton.Click();

            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.MinValue);
            var expectedNewTitle = "Apple iPhone";
            var actualTitle = _driver.Title;
            Assert.IsTrue(actualTitle.Contains(expectedNewTitle));
            return new SearchResultBrandPage(_driver);
        }
    }
}
