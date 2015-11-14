// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Objectivity.Test.Automation.Light.Common
{
    using NUnit.Framework;

    using OpenQA.Selenium;

    /// <summary>
    /// The test base.
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// The driver context.
        /// </summary>
        private readonly DriverFactory driverFactory = new DriverFactory();

        /// <summary>
        /// Gets the driver context.
        /// </summary>
        protected DriverFactory DriverFactory
        {
            get
            {
                return this.driverFactory;
            }
        }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        protected IWebDriver Driver
        {
            get
            {
                return DriverFactory.GetDriver(); // this.DriverFactory.Driver;
            }
        }

        /// <summary>
        /// Before the test.
        /// </summary>
        [SetUp]
        public void BeforeTest()
        {
            var baseUrl = ConfigurationBase.Protocol + "://" + ConfigurationBase.Host + ConfigurationBase.Url;
            DriverFactory.StartDriver(); // .Start();
            this.Driver.Navigate().GoToUrl(baseUrl);
        }

        /// <summary>
        /// After the test.
        /// </summary>
        [TearDown]
        public void AfterTest()
        {
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                var folder = ConfigurationBase.TestFolder;
                var title = TestContext.CurrentContext.Test.Name;
                ScreenshotHelper.SaveScreenshot(this.Driver, folder, title);
            }

            DriverFactory.QuitDriver();
        }
    }
}
