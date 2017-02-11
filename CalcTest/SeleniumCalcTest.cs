using CalcFramework.Abstract;
using CalcFramework.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public class SeleniumCalcTest
    {
        private static readonly CalculatorFactory Factory = new CalculatorFactory(CalcSource.Chrome);
        private static readonly ICalculator Calc = Factory.GetInstance();

        [TestMethod]
        public void CheckIfThereAreNineteenButtons()
            => Assert.AreEqual(19, Calc.GetButtonCount());

        [TestMethod]
        public void CheckIfOnePlusFourEqualsFive()
        {
            Calc.GetButton(Button.One).Click();
            Calc.GetButton(Button.Plus).Click();
            Calc.GetButton(Button.Four).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("5", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfTwoMinusFiveEqualsMinusThree()
        {
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Minus).Click();
            Calc.GetButton(Button.Five).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("-3", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfThreeMultiplySevenEqualsTwentyOne()
        {
            Calc.GetButton(Button.Three).Click();
            Calc.GetButton(Button.Mul).Click();
            Calc.GetButton(Button.Seven).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("21", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfNineDevideBySixEqualsOneDotFive()
        {
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Six).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("1.5", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfTenMinusEightyPercentEqualsTwo()
        {
            Calc.GetButton(Button.One).Click();
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Minus).Click();
            Calc.GetButton(Button.Eight).Click();
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Pers).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("2", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfSquareRootOfNineEqualsThree()
        {
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Sqr).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("3", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfClearKeyIsWorking()
        {
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Clr).Click();

            Assert.AreEqual("0", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckTheDivisionOfANumberByZero()
        {
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("Infinity", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckTheDivisionOfZeroByAnyNumber()
        {
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("0", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckTheDivisionOfZeroByZero()
        {
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("NaN", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckTheDivisionOfANegativeNumberByNumber()
        {
            Calc.GetButton(Button.Five).Click();
            Calc.GetButton(Button.Minus).Click();
            Calc.GetButton(Button.One).Click();
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Eq).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("-2.5", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckTheMultiplicationOfOneNegativeAndOnePositiveNumber()
        {
            Calc.GetButton(Button.Three).Click();
            Calc.GetButton(Button.Minus).Click();
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Eq).Click();
            Calc.GetButton(Button.Mul).Click();
            Calc.GetButton(Button.Eight).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("-48", Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfBodmasIsNotImplemented()
        {
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Plus).Click();
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Mul).Click();
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("8", Calc.GetScreenText());
        }

        [TestMethod]
        public void VerifyThatOnPressingTwoOperatorsOneAfterTheOtherTheLatestOneWillNotOverrideThePreviousOperator()
        {
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Plus).Click();
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual("1", Calc.GetScreenText());
        }
    }
}
