using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ScenarioContext _context;

        public SearchForiPhonesSteps(ScenarioContext context)
        {
            _context = context;
        }  
        
        [Given(@"I open '(.*)'")]
        public void GivenIOpen(string siteName)
        {
            var landingPage = new LandingPage();
            landingPage.Navigation(siteName);

        }

        [Given(@"I search for '(.*)'")]
        public void GivenISearchFor(string searchInput)
        {
            var landingPage = new LandingPage();
            landingPage.SearchPhone(searchInput);
        }

        [Given(@"I search for '(.*)' characteristics")]
        public void GivenISearchForCharacteristics(List<string> phones)
        {
            //_context.Add("my_keys", phones);
            var searchResultPage = new SearchResultBrandPage();
            var listOfiPhone7Page = new ListOfiPhone7Page();

            var container = new Dictionary<string, List<string>>();
            foreach (var phone in phones)
            {
                searchResultPage.NavigateToListOfiPhones(phone);
                listOfiPhone7Page.SelectFirstElement();
                listOfiPhone7Page.NavigateToCharacteristic();
                var phoneDescription = listOfiPhone7Page.NoteCharacteristics();
                container.Add(phone, phoneDescription);
               listOfiPhone7Page.NavigateToApplePhonePage();
            }
            _context.Add("container", container);
        }

        [Then(@"I save similar phone's characteristics")]
        public void ThenISaveSimilarPhoneSCharacteristics()
        {
            var container = _context.Get<Dictionary<string, List<string>>>("container");
            var phoneA = container.First();
            var phoneB = container.Last();
            var similarCharacteristics = phoneA.Value.Intersect(phoneB.Value).ToList();
           _context.Add("similar characteristics", similarCharacteristics);
        }

        [Then(@"The similar characteristics are available in a file")]
        public void ThenTheSimilarCharacteristicsAreAvailableInAFile()
        {
            var result = _context.Get<List<string>>("similar characteristics");
            FileHelper.SavePhoneDetailsToFile(result);
        }







    }
}
