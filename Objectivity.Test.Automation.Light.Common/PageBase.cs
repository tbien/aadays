// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageBase.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Objectivity.Test.Automation.Light.Common
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// The page base.
    /// </summary>
    public class PageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageBase"/> class.
        /// </summary>
        /// <param name="driver">
        /// The driver.
        /// </param>
        public PageBase(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(this.Driver, this);
        }

        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>
        /// The get title.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetTitle()
        {
            return this.Driver.Title;
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Contains(string text)
        {
            var pageSours = this.Driver.PageSource;
            var contains = pageSours.Contains(text);
            return contains;
        }
    }
}
