// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScreenshotHelper.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Objectivity.Test.Automation.Light.Common
{
    using System;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using OpenQA.Selenium;

    /// <summary>
    /// The screenshot helper.
    /// </summary>
    public static class ScreenshotHelper
    {
        /// <summary>
        /// The save screenshot.
        /// </summary>
        /// <param name="driver">
        /// The driver.
        /// </param>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public static void SaveScreenshot(IWebDriver driver, string folder, string title)
        {
            var screenshotDriver = (ITakesScreenshot)driver;
            var screenshot = screenshotDriver.GetScreenshot();
            var fileName = string.Format(CultureInfo.CurrentCulture, "{0}_{1}.png", title, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss-fff"));
            var correctFileName = Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(CultureInfo.CurrentCulture), string.Empty));
            var path = Path.Combine(Environment.CurrentDirectory, folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, correctFileName);

            screenshot.SaveAsFile(filePath, ImageFormat.Png);

            Console.Error.WriteLine("Screenshot saved to {0}.", filePath);
        }
    }
}
