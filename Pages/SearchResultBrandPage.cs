using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SpecflowHw.Pages
{
    public class SearchResultBrandPage
    {
        private readonly IWebDriver _driver;

        public SearchResultBrandPage(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}
