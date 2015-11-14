// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExamplePage.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// <summary>
//   The example page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Objectivity.Test.Automation.Light.Aad.Pages
{
    using Objectivity.Test.Automation.Light.Common;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// The example page.
    /// </summary>
    public class ExamplePage : PageBase
    {
        /// <summary>
        /// The java script alert link.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "a[href='/javascript_alerts']")]
        private IWebElement javaScriptAlertsLink;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamplePage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The driver.
        /// </param>
        public ExamplePage(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        /// The go to java script alerts.
        /// </summary>
        public JavaScriptAlertsPage GoToJavaScriptAlerts()
        {
            this.javaScriptAlertsLink.Click();
            return new JavaScriptAlertsPage(this.Driver);
        }
    }
}
