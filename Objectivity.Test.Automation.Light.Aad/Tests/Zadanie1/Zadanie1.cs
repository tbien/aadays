﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JavaScriptAlertsTests.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using Objectivity.Test.Automation.Light.Aad.Pages;
using Objectivity.Test.Automation.Light.Common;

namespace Objectivity.Test.Automation.Light.Aad.Tests.Zadanie1
{
    /// <summary>
    /// The java script alerts tests.
    /// </summary>
    public class Zadanie1 : TestBase
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
    }
}
