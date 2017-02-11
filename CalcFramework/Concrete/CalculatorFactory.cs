using System;
using System.Diagnostics;
using CalcFramework.Abstract;
using OpenQA.Selenium;

namespace CalcFramework.Concrete
{
    /// <summary>
    /// Represents calculator factory.
    /// </summary>
    public sealed class CalculatorFactory : IDisposable
    {
        private Boolean isDisposed;
        private readonly IWebDriver driver;
        private readonly ICalculator calculator;
        private readonly Process calcProcess;

        /// <summary>
        /// Initialize factory with selected calculator.
        /// </summary>
        /// <param name="src">Calculator source.</param>
        public CalculatorFactory(CalcSource src)
        {
            switch (src)
            {
                case CalcSource.Chrome:
                    calculator = new SeleniumCalculator(driver = ChromeCalculatorProvider.GetInstance());
                    break;
                case CalcSource.Windows:
                    calcProcess = Process.Start(Win.ProcessName);
                    calculator = new WindowsCalculator(WindowsCalculatorProvider.GetInstance());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(src), src, null);
            }
        }

        ~CalculatorFactory()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            if (isDisposed) return;

            driver?.Quit();
            calcProcess?.CloseMainWindow();
            calcProcess?.Close();

            isDisposed = true;
        }

        /// <summary>
        /// Get calculator instance.
        /// </summary>
        /// <returns>Returns calculator instance.</returns>
        public ICalculator GetInstance() => calculator;
    }
}