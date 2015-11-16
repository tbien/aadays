using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objectivity.Test.Automation.Light.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Objectivity.Test.Automation.Light.Aad.Pages
{
    public class Task10 : PageBase
    {
        [FindsBy(How = How.CssSelector, Using = "div.container")]
        private IWebElement TextContainer;

        public Task10(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement GetTextContainer()
        {
            return TextContainer;
        }
    }
}
