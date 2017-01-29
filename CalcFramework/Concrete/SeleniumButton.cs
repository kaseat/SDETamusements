using System;
using CalcFramework.Abstract;
using OpenQA.Selenium;

namespace CalcFramework.Concrete
{
    public class SeleniumButton : IButton
    {
        private readonly IWebElement wElement;

        public SeleniumButton(IWebElement wElement)
        {
            this.wElement = wElement;
        }

        public String Text => wElement.GetAttribute(Driver.ValueToken);
        public Boolean IsSelected => wElement.Selected;

        public void Click() => wElement.Click();
    }
}