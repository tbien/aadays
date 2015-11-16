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

        [Test]
        public void ProperSave() {
            var task4 = new Task4(this.Driver);
            task4.NavigateToPage(GetHost() + "task_4");
            Driver.WaitForElement(By.CssSelector("button.btn.btn-primary.btn-block.js-open-window"), 2).Click();
            var abc = Driver.WindowHandles;
            Driver.SwitchTo().Window(abc[1]);
            Driver.SwitchTo().Frame(0);
            Driver.FindDisplayedElement(By.CssSelector("input[name='name'")).SendKeys("12345678901234567890123456789012345678901234567890");
            Driver.FindDisplayedElement(By.CssSelector("input[name='email']")).SendKeys("Tomasz@vp.pl");
            Driver.FindDisplayedElement(By.CssSelector("input[name='phone']")).SendKeys("693-463-719");
            Driver.FindDisplayedElement(By.CssSelector("button#save-btn")).Click();
            Assert.AreEqual("Wiadomość została wysłana", Driver.FindDisplayedElement(By.CssSelector("h1")).Text);

        }
    }
}
