using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objectivity.Test.Automation.Light.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace Objectivity.Test.Automation.Light.Aad.Pages
{
    public class Task2 : PageBase
    {
        private By selectLocator = By.CssSelector("select");

        [FindsBy(How = How.CssSelector, Using = "span.select2-selection")]
        private IWebElement WybierzProduktList;

        [FindsBy(How = How.CssSelector, Using = "input.select2-search__field")]
        private IWebElement WybierzProduktWSearchInput;

        [FindsBy(How = How.CssSelector, Using = "div.caption")]
        private IList<IWebElement> ProductsList;

        public Task2(IWebDriver driver) : base(driver)
        {
        }

        public void ClickWybierzProdukList()
        {
            WybierzProduktList.Click();
        }
        public bool IsWybierzProductExpanded()
        {
            var expanded = WybierzProduktList.GetAttribute("aria-expanded").Contains("true");
            return expanded;
        }

        public IList<IWebElement> GetProductList()
        {
            var select = new SelectElement(Driver.FindElement(selectLocator));
            var values = select.Options.ToList();
            return values;
        }

        public void SearchWybierzProduktList(string text)
        {
            ClickWybierzProdukList();
            WybierzProduktWSearchInput.SendKeys(text);
            WybierzProduktWSearchInput.SendKeys(Keys.Enter);
        }

        public string GetSelectedWybierzProductList()
        {
            var selected = WybierzProduktList.Text;
            return selected;
        }

        public IList<IWebElement> GetProducts()
        {
            return ProductsList.ToList();
        }
    }
}
