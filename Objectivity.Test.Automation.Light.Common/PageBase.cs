// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageBase.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Remoting.Messaging;
using Objectivity.Test.Automation.Light.Common.Extensions;
using OpenQA.Selenium.Interactions;

namespace Objectivity.Test.Automation.Light.Common
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// The page base.
    /// </summary>
    public class PageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageBase"/> class.
        /// </summary>
        /// <param name="driver">
        /// The driver.
        /// </param>
        public PageBase(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(this.Driver, this);
        }

        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>
        /// The get title.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetTitle()
        {
            return this.Driver.Title;
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Contains(string text)
        {
            var pageSours = this.Driver.PageSource;
            var contains = pageSours.Contains(text);
            return contains;
        }


        public void NavigateToPage(string page)
        {
            Driver.Navigate().GoToUrl(page);
        }

        protected bool IsAlertPresent()
        {
            try
            {
                return Driver.SwitchTo().Alert().Text.Length > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }

        protected string GetAlertText()
        {
            try
            {
                return Driver.SwitchTo().Alert().Text;
            }
            catch
            {
                return "";
            }
        }

        protected void ConfirmAlert()
        {
           Driver.SwitchTo().Alert().Dismiss();
        }

        protected void Click(By by)
        {
            Driver.FindDisplayedElement(by).Click();
        }

        protected void DragAndDrop(By by1, By by2)
        {
            var abc = Driver.FindElement(by2);
            var x = abc.Location.X;
            var y = abc.Location.Y;

            IJavaScriptExecutor  js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].style.visibility = 'visible', arguments[0].style.height = '1px'; arguments[0].style.width = '1px'; arguments[0].style.opacity = 1", abc);

            new Actions(Driver).DragAndDropToOffset(Driver.FindDisplayedElement(by1), x, y).Build().Perform();
            new Actions(Driver).DragAndDrop(Driver.FindDisplayedElement(by1), Driver.FindElement(by2)).Build().Perform();
        }

        public bool IsElementEnabled(By by)
        {
            try
            {
                return Driver.FindDisplayedElement(by, 1).Enabled;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        protected void SendKeys(By by, string text)
        {
            Driver.FindDisplayedElement(by).SendKeys(text);
        }

        protected string GetElementText(By by)
        {
            try
            {
                return Driver.FindDisplayedElement(by, 1).Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        protected void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }
    }
}
