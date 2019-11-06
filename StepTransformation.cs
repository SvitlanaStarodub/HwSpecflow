using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowHw
{
    [Binding]
    public class StepTransformation
    {
        [StepArgumentTransformation]
        public List<string> ToListOfPhones (string phone)
        {
            return phone.Split(",").ToList();
        }
    }
}
