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
    using System.Threading;

    /// <summary>
    /// The java script alerts tests.
    /// </summary>
    public class Zadanie6 : TestBase
    {
        /// <summary>
        /// The confirm java script alert test.
        /// </summary>
        [Test]
        public void EmptyLogin()
        {
            var task6 = new Task6(this.Driver);
            task6.NavigateToPage(GetHost() + "task_6");
            Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Displayed,"You have logged in without login");
            Driver.WaitForElement(By.CssSelector("#LoginForm__username"), 2).SendKeys("tester");
            Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Displayed, "You have logged in without password");
            Driver.WaitForElement(By.CssSelector("#LoginForm__password"), 2).SendKeys("tester");
            Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Click();
            Thread.Sleep(2000);
            Assert.AreEqual(Driver.WaitForElement(By.CssSelector(".alert.alert-danger"), 2).Text, "Nieprawidłowe dane logowania", "No warning about invalid credentials");
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Displayed, "You have logged in with invalid credentials");
        }

        [Test]
        public void YouHaveLoggedIn() {
            var task6 = new Task6(this.Driver);
            task6.NavigateToPage(GetHost() + "task_6");
            Driver.WaitForElement(By.CssSelector("#LoginForm__username"), 2).SendKeys("tester");
            Driver.WaitForElement(By.CssSelector("#LoginForm__password"), 2).SendKeys("123-xyz");
            Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Click();
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("a[href='/task_6/download']"), 2).Displayed, "Downlad file link not displayed");
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("#logout"), 2).Displayed, "logout link not displayed");
            Driver.WaitForElement(By.CssSelector("#logout"), 2).Click();
            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("a[href='/task_6/download']"), 2).Equals(null), "Downlad file link displayed");
            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("#logout"), 2).Equals(null), "logout link displayed");
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("#LoginForm__username"), 2).Displayed, "login input not didplayed");
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("#LoginForm__password"), 2).Displayed, "password input not didplayed");
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Displayed, "save button not displayed");
            Driver.WaitForElement(By.CssSelector("#LoginForm__username"), 2).SendKeys("tester");
            Driver.WaitForElement(By.CssSelector("#LoginForm__password"), 2).SendKeys("123-xyz");
            Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Click();
            Assert.IsTrue(Driver.WaitForElement(By.CssSelector("a[href='/task_6/download']"), 2).Displayed, "Downlad file link not displayed, you have not logged in again");
        }

        [Test]
        public void CLickDownloadLink()
        {
            var task6 = new Task6(this.Driver);
            task6.NavigateToPage(GetHost() + "task_6");
            Driver.WaitForElement(By.CssSelector("#LoginForm__username"), 2).SendKeys("tester");
            Driver.WaitForElement(By.CssSelector("#LoginForm__password"), 2).SendKeys("123-xyz");
            Driver.WaitForElement(By.CssSelector("#LoginForm_save"), 2).Click();
            Driver.WaitForElement(By.CssSelector("a[href='/task_6/download']"), 2).Click();
            
        }
    }
}
