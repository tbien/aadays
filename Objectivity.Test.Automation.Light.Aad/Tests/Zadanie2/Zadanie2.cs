// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JavaScriptAlertsTests.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using Objectivity.Test.Automation.Light.Aad.Pages;
using Objectivity.Test.Automation.Light.Common;
using OpenQA.Selenium;

namespace Objectivity.Test.Automation.Light.Aad.Tests.Zadanie2
{
    [Category("Zadanie2")]
    public class Zadanie2 : TestBase
    {
        [SetUp]
        public void OpenTaskPage()
        {
            Driver.Navigate().GoToUrl(GetHost() + "task_2");
        }

        [Test]
        public void VerifyCategoriesAfterClickTest()
        {
            var taskPage = new Task2(this.Driver);
            taskPage.ClickWybierzProdukList();
            Assert.True(taskPage.IsWybierzProductExpanded());
        }

        [Test]
        public void VerifyCategoriesListTest()
        {
            var list = new List<string> {"-1", "Sport", "Elektronika", "Firma i usługi"};
            var taskPage = new Task2(this.Driver);
            var categoryList = taskPage.GetProductList();
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[i], categoryList[i].GetAttribute("value"));
            }
        }

        [Test]
        public void DefaultWybierzProduktListValueTest()
        {
            var taskPage = new Task2(this.Driver);
            Assert.AreEqual("Proszę wybrać kategorie", taskPage.GetSelectedWybierzProductList());
        }

        [Test]
        public void FilterElektronikaTest()
        {
            var taskPage = new Task2(this.Driver);
            taskPage.SearchWybierzProduktList("Elektronika");
            var products = taskPage.GetProducts();
            foreach (var product in products)
            {
                Assert.AreEqual("Elektronika", product.FindElement(By.TagName("strong")).Text);
            }
        }

        [Test]
        public void FilterFirmaIUslugiTest()
        {
            var taskPage = new Task2(this.Driver);
            taskPage.SearchWybierzProduktList("uslugi");
            var products = taskPage.GetProducts();
            foreach (var product in products)
            {
                Assert.AreEqual("Firma i usługi", product.FindElement(By.TagName("strong")).Text);
            }
        }
    }
}
