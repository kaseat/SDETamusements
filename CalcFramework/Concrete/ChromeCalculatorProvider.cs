using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CalcFramework.Concrete
{
    public static class ChromeCalculatorProvider
    {
        public static IWebDriver GetInstance()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl(Driver.url);
            driver.Manage().Timeouts().SetPageLoadTimeout
                (TimeSpan.FromSeconds(Double.Parse(Driver.Timeout)));

            return driver;
        }
    }
}