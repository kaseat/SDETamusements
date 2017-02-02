using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CalcFramework.Abstract;
using CalcFramework.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rhino.Mocks;

namespace FrameworkTests.Tests
{
    [TestClass]
    public class SeleniumCalculatorTests
    {
        [TestMethod]
        public void SeleniumCalculatorCheckIfSeleniumMethodClickIsCalled()
        {
            var methodCalled = false;
            var dummyElement = MockRepository.GenerateStub<IWebElement>();
            dummyElement.Expect(x => x.GetAttribute(Arg<String>.Is.Anything)).Return("0").Repeat.Any();
            dummyElement.Expect(x => x.Click()).WhenCalled(x => { methodCalled = true; });

            var dummyDriver = MockRepository.GenerateStub<IWebDriver>();
            var calc = new SeleniumCalculator(dummyDriver);

            dummyDriver.Expect(x => x.FindElement(Arg<By>.Is.Anything)).Return(dummyElement);
            dummyDriver.Expect(x => x.FindElements(Arg<By>.Is.Anything))
                .Return(new ReadOnlyCollection<IWebElement>(new List<IWebElement> {dummyElement}));

            calc.GetButton(Button.Zero).Click();
            Assert.IsTrue(methodCalled);
        }
    }
}