using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Objectivity.Test.Automation.Light.Common.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement WaitForElement(this IWebDriver webDriver, By locator, double timeoutInSeconds)
        {
            IWebElement element;
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
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
                        catch (Exception e)
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
    }
}
