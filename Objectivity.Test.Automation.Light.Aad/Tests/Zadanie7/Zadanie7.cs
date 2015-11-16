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
    public class Zadanie7 : TestBase
    {
        /// <summary>
        /// The confirm java script alert test.
        /// </summary>
        [Test]
        public void AmountValidationTest()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "101");

            Assert.True(task1.IsAlertVisible(), "Alert Message is not visible");
            task1.DismissAlert();
        }

        [Test]
        public void AlertTextValidationTest()
        {
            const string expectedMessage = "Łączna ilość produktów w koszyku nie może przekroczyć 100.";
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "101");

            Assert.True(task1.IsAlertVisible(), "Alert Message is not visible");
            Assert.True(task1.GetValidationText().Equals(expectedMessage), "Improper alert message, expected {0}, actual {1}", expectedMessage, task1.GetValidationText());
            task1.DismissAlert();
        }

        [Test]
        public void CheckIfProperProductIsAdded()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "1");

            var elementName = task1.GetProductName();
            var productPrice = task1.GetProductPrice();

            Assert.True(task1.GetBasketText().Contains(elementName), "improper product in basket " + elementName + " " + task1.GetBasketText());
        }

        [Test]
        public void CheckIfProperPrice()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "1");

            var elementName = task1.GetProductName();
            var productPrice = task1.GetProductPrice();

            var price = task1.GetBasketText().Split('(');
            price = price[1].Split(')');
            Assert.AreEqual(productPrice, price[0], "price in basket is improper, should be {0}", productPrice);
        }

        [Test]
        public void CheckIfSummaryPriceIsProperlyCalculated()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "100");

            var elementName = task1.GetProductName();
            var productPrice = task1.GetProductPrice();
            var psummaryQuantity = task1.GetQuantity();
            double abc = double.Parse(productPrice) * 100;

            Assert.AreEqual(abc.ToString("F"), task1.GetSummaryPrice().Split(' ')[0], "summary price in basket is improper, should be {0}", productPrice);
            Assert.AreEqual("100", psummaryQuantity);
        }

        [Test]
        public void CheckBasketAfterPageRefresh()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "100");

            var elementName = task1.GetProductName();
            task1.RefreshTaskPage();

            Assert.True(task1.GetBasketText().Contains(elementName), "lack of product in basket");
        }

        [Test]
        public void RemoveProduct()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "1");

            var elementName = task1.GetProductName();
            task1.RemoveProduct();

            Assert.False(task1.GetBasketText().Contains(elementName), "product was not removed");
        }

        [Test]
        public void CheckIfAddButtonIsDisabled()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "1");

            var elementName = task1.GetProductName();
            task1.RemoveProduct();

            Assert.False(task1.IsButtonEnabled(), "add buton is not disabled");
        }

        [Test]
        public void RemoveProduct2()
        {
            var task1 = new Task1(this.Driver);
            task1.NavigateToPage(GetHost() + "task_7");
            task1.AddAmount("product1", "1");

            var elementName = task1.GetProductName();
            task1.RemoveProduct();
            task1.AddAmount("product1", "1");

            Assert.True(task1.GetBasketText().Contains(elementName), "product was not removed");
            var productPrice = task1.GetProductPrice();

            Assert.AreEqual(productPrice, task1.GetSummaryPrice().Split(' ')[0], "summary price in basket is improper, should be {0}", productPrice);
        }

    }
}
