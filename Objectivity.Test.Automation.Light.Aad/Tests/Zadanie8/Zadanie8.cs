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

    /// <summary>
    /// The java script alerts tests.
    /// </summary>
    [Category("Zadanie8")]
    public class Zadanie8 : TestBase
    {
        [SetUp]
        public void OpenTaskPage()
        {
            Driver.Navigate().GoToUrl(GetHost() + "task_8");
        }
        /// <summary>
        /// The confirm java script alert test.
        /// </summary>
        [Test]
        public void SubmitEmptyForm()
        {
            var taskPage = new Task8(this.Driver);
            taskPage.Submit();
            Assert.True(taskPage.Contains("Zapłać"));
        }
        [Test]
        public void SubmitFilledForm()
        {
            var taskPage = new Task8(this.Driver);
            taskPage.FillForm("American Express", "Kowalski", "378282246310005", "123", "January", "2016");
            taskPage.Submit();
            Assert.True(taskPage.Contains("Zamówienie opłacone"));
        }
    }
}
