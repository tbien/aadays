// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriverFactory.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Objectivity.Test.Automation.Light.Common
{
    using System.Threading;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    /// <summary>
    /// The driver context.
    /// </summary>
    public class DriverFactory
    {
        /// <summary>
        /// The driver thread.
        /// </summary>
        private static ThreadLocal<IWebDriver> driverThread;

        /// <summary>
        /// The start driver.
        /// </summary>
        public static void StartDriver()
        {
            driverThread = new ThreadLocal<IWebDriver>(
                () =>
                {
                    var webDriver = new FirefoxDriver();
                    return webDriver;
                });
        }

        /// <summary>
        /// The get driver.
        /// </summary>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        public static IWebDriver GetDriver()
        {
            return driverThread.Value;
        }

        /// <summary>
        /// The quit driver.
        /// </summary>
        public static void QuitDriver()
        {
            driverThread.Value.Close();
            driverThread.Value.Dispose();
        }
    }
}
