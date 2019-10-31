using System;
using System.Collections.Generic;
using System.Text;
using BoDi;
using OpenQA.Selenium;
using SpecflowHw.Helper;
using TechTalk.SpecFlow;

namespace SpecflowHw
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer container;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        //[BeforeScenario]
        //public void RegisterChromeDriver()
        //{
            
        //}

        [BeforeScenario]
        public void SetBrowser()
        {
            var driver = Driver.CreateDriver;
            container.RegisterInstanceAs(driver);
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void CloseBrowser(IWebDriver driver)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
