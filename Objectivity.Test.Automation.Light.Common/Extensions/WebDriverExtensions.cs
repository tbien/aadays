using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Objectivity.Test.Automation.Light.Common.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement WaitForElement(this IWebDriver webDriver, By locator, double timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return element;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }


        public static bool IsElementPresent(this IWebDriver webDriver, By by, double timeoutInSeconds)
        {
            try
            {
                return new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds))
                    .Until<bool>(d =>
                    {
                        try
                        {
                            return d.FindElement(by).Displayed;
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    });
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IWebElement FindDisplayedElement(this IWebDriver webDriver, By by)
        {
            return FindDisplayedElement(webDriver, by, 10);
        }


    public static IWebElement FindDisplayedElement(this IWebDriver webDriver, By by, double time)
        {
            try
            {
                {
                    return new WebDriverWait(webDriver, TimeSpan.FromSeconds(time))
                        .Until<IWebElement>(d =>
                        {
                            try
                            {
                                return d.FindElement(@by).Displayed ? d.FindElement(@by) : null;
                            }
                            catch (Exception)
                            {
                                return null;
                            }
                        });
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Element was not found. Timeou after: {0}", time);
                return null;
            }
        }
    }
}
