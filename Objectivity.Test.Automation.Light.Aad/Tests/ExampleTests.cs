// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExampleTests.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// <summary>
//   The example tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Objectivity.Test.Automation.Light.Aad.Tests
{
    using NUnit.Framework;

    using Objectivity.Test.Automation.Light.Aad.Pages;
    using Objectivity.Test.Automation.Light.Common;

    /// <summary>
    /// The example tests.
    /// </summary>
    public class ExampleTests : TestBase
    {
        /// <summary>
        /// The open example page test.
        /// </summary>
        [Test]
        public void OpenExamplePageTest()
        {
            var examplePage = new ExamplePage(this.Driver);
            Assert.AreEqual("The Internet", examplePage.GetTitle());
        }

        /// <summary>
        /// The open java script alerts page test.
        /// </summary>
        [Test]
        public void OpenJavaScriptAlertsPageTest()
        {
            var examplePage = new ExamplePage(this.Driver);
            var jsAlertsPage = examplePage.GoToJavaScriptAlerts();

            Assert.True(jsAlertsPage.Contains("<h3>JavaScript Alerts</h3>"));
        }
    }
}
