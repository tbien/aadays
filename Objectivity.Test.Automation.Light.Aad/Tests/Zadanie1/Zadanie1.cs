// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JavaScriptAlertsTests.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading;
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
        public void AmountValidationTest()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_1");
            task1.AddAmount("product1", "101");
           
            Assert.True(task1.IsAlertVisible(), "Alert Message is not visible");
        }

        [Test]
        public void AlertTextValidationTest()
        {
            const string expectedMessage = "Łączna ilość produktów w koszyku nie może przekroczyć 100.";
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_1");
            task1.AddAmount("product1", "101");

            Assert.True(task1.IsAlertVisible(), "Alert Message is not visible");
            Assert.True(task1.GetValidationText().Equals(expectedMessage), "Improper alert message, expected {0}, actual {1}", expectedMessage, task1.GetValidationText());
        }

        [Test]
        public void AddProductToBasket()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_1");
            task1.AddAmount("product1", "1");

            var elementName = task1.GetProductName();

            Assert.True(task1.GetBasketText().Contains(elementName), "improper product in basket " + elementName + " " + task1.GetBasketText());
        }

    }
}
