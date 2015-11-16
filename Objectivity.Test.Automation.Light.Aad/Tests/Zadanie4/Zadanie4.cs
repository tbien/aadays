// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JavaScriptAlertsTests.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Objectivity.Test.Automation.Light.Aad.Tests.JavaScriptAlertsTests
{
    using NUnit.Framework;

    using Objectivity.Test.Automation.Light.Aad.Pages;
    using Objectivity.Test.Automation.Light.Common;
    using Objectivity.Test.Automation.Light.Common.Extensions;
    using OpenQA.Selenium;

    /// <summary>
    /// The java script alerts tests.
    /// </summary>
    public class Zadanie4 : TestBase
    {
        /// <summary>
        /// The confirm java script alert test.
        /// </summary>
        [Test]
        public void ConfirmJavaScriptAlertTest()
        {
            var examplePage = new ExamplePage(this.Driver);
            var javaScriptAlertsPage = examplePage.GoToJavaScriptAlerts();
            javaScriptAlertsPage.OpenJsAlert();
            this.Driver.SwitchTo().Alert().Accept();
            this.Driver.SwitchTo().DefaultContent();
            Assert.True(javaScriptAlertsPage.Contains("You successfuly clicked an alert"));
        }

        [Test]
        public void ProperSave() {
            var task4 = new Task4(this.Driver);
            task4.NavigateToPage(GetHost() + "task_4");
            Driver.WaitForElement(By.CssSelector("button.btn.btn-primary.btn-block.js-open-window"), 2).Click();

        }
    }
}
