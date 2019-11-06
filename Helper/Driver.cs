using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecflowHw.Helper
{
    public static class DriverHelper
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    ChromeOptions chromeOptions = new ChromeOptions();
                    _driver = new ChromeDriver(Path.Combine(Environment.CurrentDirectory, ".."), chromeOptions);
                }
                return _driver;
            }
            set => _driver = value;
        }
    }
}
