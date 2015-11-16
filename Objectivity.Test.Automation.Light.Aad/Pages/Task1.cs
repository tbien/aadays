using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Objectivity.Test.Automation.Light.Common;
using Objectivity.Test.Automation.Light.Common.Extensions;
using OpenQA.Selenium;

namespace Objectivity.Test.Automation.Light.Aad.Pages
{
    public class Task1 : PageBase
    {

        private string productOneLocator = "//div[@class='row'][1]/div[1]//input";
        private string productOneButton = "//div[@class='row'][1]/div[1]//button";
        private string productName = "//div[@class='row'][1]/div[1]//h4";
        private string basketRow = "div.row-in-basket .text-on-button-level";

        public Task1(IWebDriver driver) : base(driver)
        {
        }

        public void AddAmount(string product1, string amount)
        {
            SendKeys(By.XPath(productOneLocator), amount);
            Click(By.XPath(productOneButton));
        }

        public bool IsAlertVisible()
        {
            return IsAlertPresent();
        }

        public string GetValidationText()
        {
            return GetAlertText();
        }

        public string GetBasketText()
        {
            return GetElementText(By.CssSelector(basketRow));
        }

        public string GetProductName()
        {
            return GetElementText(By.XPath(productName));
        }
    }
}
