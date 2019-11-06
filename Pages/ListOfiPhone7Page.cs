using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using SpecflowHw.Helper;

namespace SpecflowHw.Pages
{
    public class ListOfiPhone7Page
    {
        private readonly IWebDriver _driver;

        public ListOfiPhone7Page()
        {
            _driver = DriverHelper.Driver;
        }

        public IReadOnlyCollection<IWebElement> ListOfiPhone7 =>
            _driver.FindElements(By.XPath("//div[@name='goods_list']/div//div[@class='g-i-tile-i-title clearfix']/a"));

        public IWebElement Characteristics =>
            _driver.FindElement(By.XPath("//a[@routerlinkactive='active'][contains(text(), 'Характеристики')]"));

        public IReadOnlyCollection<IWebElement> IPhone7Details =>
            _driver.FindElements(By.XPath("//div[@class='feature-all']//tr"));

        public IWebElement ScrollToFirstItem => _driver.FindElement(By.XPath("//h1[@itemprop='name']"));


        public void SelectFirstElement()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", ScrollToFirstItem);
            ListOfiPhone7.First().Click();
        }

        public void NavigateToCharacteristic()
        {
            Characteristics.Click();
        }

        public List<string> NoteCharacteristics()
        {
            return IPhone7Details.Select(d => d.Text).ToList();
        }

        public void NavigateToApplePhonePage()
        {
            _driver.Url = "https://rozetka.com.ua/mobile-phones/c80003/preset=smartfon;producer=apple/";
        }

        
    }
}
