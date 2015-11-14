// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JavaScriptAlertsPage.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Objectivity.Test.Automation.Light.Aad.Pages
{
    using Objectivity.Test.Automation.Light.Common;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// The java script alerts page.
    /// </summary>
    public class JavaScriptAlertsPage : PageBase
    {
        /// <summary>
        /// The js alert button.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "button[onclick='jsAlert()']")]
        private IWebElement jsAlertButton;

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptAlertsPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The driver.
        /// </param>
        public JavaScriptAlertsPage(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        /// The open js alert.
        /// </summary>
        public void OpenJsAlert()
        {
            this.jsAlertButton.Click();
        }
    }
}
