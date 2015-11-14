// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationBase.cs" company="Objectivity">
//   Copyright (c) Objectivity. All rights reserved.
// </copyright>
// <summary>
//   The base configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Objectivity.Test.Automation.Light.Common
{
    using System;
    using System.Configuration;
    using System.Globalization;

    /// <summary>
    /// The base configuration.
    /// </summary>
    public static class ConfigurationBase
    {
        /// <summary>
        /// Gets the Driver.
        /// </summary>
        public static string TestBrowser
        {
            get { return ConfigurationManager.AppSettings["browser"]; }
        }

        /// <summary>
        /// Gets the application protocol (http or https).
        /// </summary>
        public static string Protocol
        {
            get { return ConfigurationManager.AppSettings["protocol"]; }
        }

        /// <summary>
        /// Gets the application host name.
        /// </summary>
        public static string Host
        {
            get { return ConfigurationManager.AppSettings["host"]; }
        }

        /// <summary>
        /// Gets the url.
        /// </summary>
        public static string Url
        {
            get { return ConfigurationManager.AppSettings["url"]; }
        }

        /// <summary>
        /// Gets the username.
        /// </summary>
        public static string Username
        {
            get { return ConfigurationManager.AppSettings["username"]; }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public static string Password
        {
            get { return ConfigurationManager.AppSettings["password"]; }
        }

        /// <summary>
        /// Gets the java script or ajax waiting time.
        /// </summary>
        public static double MediumTimeout
        {
            get { return Convert.ToDouble(ConfigurationManager.AppSettings["mediumTimeout"], CultureInfo.CurrentCulture); }
        }

        /// <summary>
        /// Gets the page load waiting time.
        /// </summary>
        public static double LongTimeout
        {
            get { return Convert.ToDouble(ConfigurationManager.AppSettings["longTimeout"], CultureInfo.CurrentCulture); }
        }

        /// <summary>
        /// Gets the assertion waiting time.
        /// </summary>
        public static double ShortTimeout
        {
            get { return Convert.ToDouble(ConfigurationManager.AppSettings["shortTimeout"], CultureInfo.CurrentCulture); }
        }

        /// <summary>
        /// Gets the firefox path
        /// </summary>
        public static string FirefoxPath
        {
            get
            {
                return ConfigurationManager.AppSettings["FireFoxPath"];
            }
        }

        /// <summary>
        /// Gets the data driven file.
        /// </summary>
        /// <value>
        /// The data driven file.
        /// </value>
        public static string DataDrivenFile
        {
            get
            {
                return ConfigurationManager.AppSettings["DataDrivenFile"];
            }
        }

        /// <summary>
        /// Enable full desktop screen shot. False by default.
        /// </summary>
        public static bool FullDesktopScreenShotEnabled
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["FullDesktopScreenShotEnabled"]))
                {
                    return false;
                }

                if (ConfigurationManager.AppSettings["FullDesktopScreenShotEnabled"].ToLower(CultureInfo.CurrentCulture).Equals("true"))
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Enable full desktop screen shot. True by default.
        /// </summary>
        public static bool SeleniumScreenShotEnabled
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SeleniumScreenShotEnabled"]))
                {
                    return true;
                }

                if (ConfigurationManager.AppSettings["SeleniumScreenShotEnabled"].ToLower(CultureInfo.CurrentCulture).Equals("true"))
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the test folder.
        /// </summary>
        /// <value>
        /// The test folder.
        /// </value>
        public static string TestFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["TestFolder"];
            }
        }

        /// <summary>
        /// Gets the test folder.
        /// </summary>
        /// <value>
        /// The test folder.
        /// </value>
        public static string ScreenShotFolder
        {
            get
            {
                return string.IsNullOrEmpty(ConfigurationManager.AppSettings["ScreenShotFolder"]) ? string.Empty : ConfigurationManager.AppSettings["ScreenShotFolder"];
            }
        }

        /// <summary>
        /// Gets the download folder.
        /// </summary>
        /// <value>
        /// The download folder.
        /// </value>
        public static string DownloadFolder
        {
            get
            {
                return string.IsNullOrEmpty(ConfigurationManager.AppSettings["DownloadFolder"]) ? string.Empty : ConfigurationManager.AppSettings["DownloadFolder"];
            }
        }
    }
}
