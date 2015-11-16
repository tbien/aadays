// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JavaScriptAlertsTests.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using Objectivity.Test.Automation.Light.Aad.Pages;
using Objectivity.Test.Automation.Light.Common;
using OpenQA.Selenium;

namespace Objectivity.Test.Automation.Light.Aad.Tests.Zadanie10
{
    /// <summary>
    /// The java script alerts tests.
    /// </summary>
    [Category("Zadanie10")]
    public class Zadanie10 : TestBase
    {
        [SetUp]
        public void OpenTaskPage()
        {
            Driver.Navigate().GoToUrl(GetHost() + "task_10");
        }
        /// <summary>
        /// The confirm java script alert test.
        /// </summary>
        [Test]
        public void HeaderExistsTest()
        {
            var taskPage = new Task2(this.Driver);
            Assert.True(taskPage.Contains("<h3>Lorem ipsum</h3>"));
        }

        [Test]
        public void KoniecNotVisibleTest()
        {
            var taskPage = new Task10(this.Driver);
            Assert.False(taskPage.Contains("<h3>Koniec</h3>"));
        }

        [Test]
        public void ScrollToKoniecTest()
        {
            var taskPage = new Task10(this.Driver);
            for (int i = 0; i < 6; i++)
            {
                taskPage.GetTextContainer().SendKeys(Keys.PageDown);
            }
            Assert.True(taskPage.Contains("Koniec"));
        }
    }
}
