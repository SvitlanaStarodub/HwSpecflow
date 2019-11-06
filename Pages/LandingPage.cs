using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowHw.Helper;

namespace SpecflowHw.Pages
{
    public class LandingPage
    {
        private readonly IWebDriver _driver;

        public LandingPage()
        {
            _driver = DriverHelper.Driver;
        }

        public IWebElement SearchField => _driver.FindElement(By.XPath("//input[@name='search']"));
        public IWebElement SearchButton => _driver.FindElement(By.XPath("//button[contains(text(),'Найти')]"));
        public IWebElement WaitForButton => _driver.FindElement(By.XPath("//button[@aria-label='Отменить поиск']"));
        public IWebElement WaitForHeader => _driver.FindElement(By.XPath("//h1[contains(text(),'Apple iPhone')]"));

        public LandingPage Navigation(string page)
        {
            _driver.Url = page;
            return new LandingPage();
        }

        public SearchResultBrandPage SearchPhone(string brand)
        {
            SearchField.SendKeys(brand);
            var wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            wait1.Until(drv=> WaitForButton.Enabled);
            SearchButton.Click();
            var wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            wait2.Until(drv => WaitForHeader.Displayed);
            return new SearchResultBrandPage();


        }
    }
}
