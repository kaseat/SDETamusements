using System;
using System.Linq;
using CalcFramework.Abstract;
using CalcFramework.Helpers;
using OpenQA.Selenium;


namespace CalcFramework.Concrete
{
    public class SeleniumCalculator : ICalculator
    {
        private readonly IWebDriver driver;

        public SeleniumCalculator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IButton GetButton(Button bType)
            => driver.FindElements(By.ClassName(Driver.ButtonToken))
                .Select(x => new SeleniumButton(x))
                .First(button => button.Text == bType.GetDescription());

        public Int32 GetButtonCount()
            => driver.FindElements(By.ClassName(Driver.ButtonToken))
                .Select(x => new SeleniumButton(x)).Count();

        public String GetScreenText()
            => driver.FindElement(By.ClassName(Driver.ScreenToken))
                .GetAttribute(Driver.ValueToken);
    }
}