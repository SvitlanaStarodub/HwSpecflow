using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowHw.Helper;

namespace SpecflowHw.Pages
{
    public class SearchResultBrandPage
    {
        private readonly IWebDriver _driver;

        public SearchResultBrandPage()
        {
            _driver = DriverHelper.Driver;
        }

        public IReadOnlyList<IWebElement> PhoneSeries => _driver.FindElements(By.XPath("//div[@param='series']//a"));

        public IWebElement scrollToSeria =>
            _driver.FindElement(By.XPath("//a[@name='filter_parameters_title'][contains(text(),'Серия')]"));
       // public IWebElement WaitForHeader => _driver.FindElement(By.XPath("//h1[contains(text(),'Apple iPhone')]"));

        //public IWebElement iPhone7 => _driver.FindElement(By.XPath("//a[@name='series_9713']"));
        //public IWebElement iPhone7Plus => _driver.FindElement(By.XPath("//a[@name='series_9720']"));

        public ListOfiPhone7Page NavigateToListOfiPhones(string phone)
        {
            
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", scrollToSeria);
            var item = PhoneSeries.First(el=>el.Text.StartsWith(phone));
            item.Click();
            return new ListOfiPhone7Page();
        }
        
    }
}
