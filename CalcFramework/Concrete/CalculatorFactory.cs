﻿using System;
using CalcFramework.Abstract;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CalcFramework.Concrete
{
    /// <summary>
    /// Represents calculator factory.
    /// </summary>
    public class CalculatorFactory
    {
        private readonly IWebDriver driver;
        private readonly ICalculator calculator;

        /// <summary>
        /// Initialize fctory with selected calculator.
        /// </summary>
        /// <param name="src">Calculator source.</param>
        public CalculatorFactory(CalcSource src)
        {
            calculator = src == CalcSource.Chrome ?
                new SeleniumCalculator(driver = new ChromeDriver()) : null;
            if(calculator==null)
                throw new NotImplementedException(Driver.FactoryException);

            driver.Navigate().GoToUrl(Driver.url);
            driver.Manage().Timeouts().SetPageLoadTimeout
                (TimeSpan.FromSeconds(Double.Parse(Driver.Timeout)));
        }

        ~CalculatorFactory()
        {
            driver.Quit();
            driver.Dispose();
        }

        /// <summary>
        /// Get calculator instance.
        /// </summary>
        /// <returns>Returns calculator instance.</returns>
        public ICalculator GetInstance() => calculator;
    }
}