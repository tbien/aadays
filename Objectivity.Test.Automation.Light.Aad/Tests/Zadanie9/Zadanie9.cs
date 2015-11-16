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
    using OpenQA.Selenium;
    using Objectivity.Test.Automation.Light.Common.Extensions;
    using OpenQA.Selenium.Interactions;

    /// <summary>
    /// The java script alerts tests.
    /// </summary>
    public class Zadanie9 : TestBase
    {
        /// <summary>
        /// The confirm java script alert test.
        /// </summary>
        [Test]
        public void ExpandColapse()
        {
            var task9 = new Task9(this.Driver);
            task9.NavigateToPage(GetHost() + "task_9");
            Driver.WaitForElement(By.CssSelector("#j1_1 i.jstree-ocl"),2).Click();

            Assert.IsTrue(Driver.IsElementPresent(By.CssSelector("#j1_2"), 2), "Row not visible");
            Assert.IsTrue(Driver.IsElementPresent(By.CssSelector("#j1_4"), 2), "Row not visible");
            Driver.WaitForElement(By.CssSelector("#j1_2 i.jstree-ocl"), 2).Click();

            Assert.IsTrue(Driver.IsElementPresent(By.CssSelector("#j1_3"), 2));
            Driver.WaitForElement(By.CssSelector("#j1_1 i.jstree-ocl"), 2).Click();

            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("#j1_3"), 2), "Row visible");
            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("#j1_2"), 2), "Row visible");
            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("#j1_4"), 2), "Row visible");
            Driver.WaitForElement(By.CssSelector("#j1_1 i.jstree-ocl"), 2).Click();

            Assert.IsTrue(Driver.IsElementPresent(By.CssSelector("#j1_3"), 2), "Row not visible");
            Assert.IsTrue(Driver.IsElementPresent(By.CssSelector("#j1_2"), 2), "Row not visible");
            Assert.IsTrue(Driver.IsElementPresent(By.CssSelector("#j1_4"), 2), "Row not visible");
            Driver.WaitForElement(By.CssSelector("#j1_2 i.jstree-ocl"), 2).Click();

            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("#j1_3"), 2), "Row visible");
            Assert.IsTrue(Driver.IsElementPresent(By.CssSelector("#j1_2"), 2), "Row not visible");
            Assert.IsTrue(Driver.IsElementPresent(By.CssSelector("#j1_4"), 2), "Row not visible");
            Driver.WaitForElement(By.CssSelector("#j1_1 i.jstree-ocl"), 2).Click();

            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("#j1_3"), 2), "Row visible");
            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("#j1_2"), 2), "Row not visible");
            Assert.IsFalse(Driver.IsElementPresent(By.CssSelector("#j1_4"), 2), "Row not visible");
        }

        [Test]
        public void ChangeName() {
            var task9 = new Task9(this.Driver);
            task9.NavigateToPage(GetHost() + "task_9");
            Driver.WaitForElement(By.CssSelector("#j1_1 i.jstree-ocl"), 2).Click();
            Driver.WaitForElement(By.CssSelector("#j1_2 i.jstree-ocl"), 2).Click();
            var j11anchor = Driver.WaitForElement(By.CssSelector("j1_1_anchor"), 2);
            Actions action = new Actions(Driver);
            action.ContextClick(j11anchor).Perform();
            Driver.WaitForElement(By.CssSelector(".vakata-context.jstree-contextmenu.jstree-default-contextmenu"), 2).Click();
        }
    }
}
