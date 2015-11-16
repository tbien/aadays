using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
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
        private string productPrice = "//div[@class='row'][1]/div[1]//p[1]";
        private string basketRow = "div.row-in-basket .text-on-button-level";
        private string summaryPrice = "span.summary-price";
        private string removeButton = "button[data-remove-from-basket]";
        private string summaryQuantity = "span.summary-quantity";
        private string basket = "div[data-basket-body]";
        private string img = "//div[@class='row'][1]/div[1]//img/..";
        private string placeToDrop = "div.place-to-drop";

        public Task1(IWebDriver driver) : base(driver)
        {
        }

        public string GetQuantity()
        {
            return GetElementText(By.CssSelector(summaryQuantity));
        }

        public void RemoveProduct()
        {
            Click(By.CssSelector(removeButton));
        }

        public string GetProductPrice()
        {
            var tab = GetElementText(By.XPath(productPrice)).Split(' ');
            return tab[1];
        }

        public string GetSummaryPrice()
        {
            return GetElementText(By.CssSelector(summaryPrice));
        }

        public void AddAmount(string product1, string amount)
        {
            SendKeys(By.XPath(productOneLocator), amount);
            Click(By.XPath(productOneButton));
        }

        public void AddAmountByDd(string amount)
        {
            SendKeys(By.XPath(productOneLocator), amount);
            DragAndDrop(By.XPath(img), By.CssSelector(placeToDrop));
        }

        public bool IsButtonEnabled()
        {
            return IsElementEnabled(By.XPath(productOneButton));
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

        public void DismissAlert()
        {
            ConfirmAlert();
        }

        public void RefreshTaskPage()
        {
            RefreshPage();
        }
    }
}
