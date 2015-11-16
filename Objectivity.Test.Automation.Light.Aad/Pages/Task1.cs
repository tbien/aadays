using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objectivity.Test.Automation.Light.Common;
using Objectivity.Test.Automation.Light.Common.Extensions;
using OpenQA.Selenium;

namespace Objectivity.Test.Automation.Light.Aad.Pages
{
    public class Task1 : PageBase
    {

        private string productOneLocator = "";

        public Task1(IWebDriver driver) : base(driver)
        {
        }

        public void AddAmount(string product1, int amount)
        {
            Driver.FindDisplayedElement(By.XPath(productOneLocator)).SendKeys(amount);
        }
    }
}
