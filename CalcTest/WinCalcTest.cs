using System.Globalization;
using CalcFramework.Abstract;
using CalcFramework.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public class WinCalcTest
    {
        private static readonly CalculatorFactory Factory = new CalculatorFactory(CalcSource.Windows);
        private static readonly ICalculator Calc = Factory.GetInstance();

        [TestInitialize]
        public void Initialize() => Calc.GetButton(Button.Clr).Click();

        [TestMethod]
        public void CheckIfThereAreTwentyEightButtons()
            => Assert.AreEqual(28, Calc.GetButtonCount());

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

            Assert.AreEqual((-3).ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfThreeMultiplySevenEqualsTwentyOne()
        {
            Calc.GetButton(Button.Three).Click();
            Calc.GetButton(Button.Mul).Click();
            Calc.GetButton(Button.Seven).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual(21.ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfNineDevideBySixEqualsOneDotFive()
        {
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Six).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual(1.5.ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
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

            Assert.AreEqual(2.ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfSquareRootOfNineEqualsThree()
        {
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Sqr).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual(3.ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckIfClearKeyIsWorking()
        {
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Clr).Click();

            Assert.AreEqual(0.ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckTheDivisionOfANumberByZero()
        {
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual(Asserts.ZeroDiv, Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckTheDivisionOfZeroByAnyNumber()
        {
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Nine).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual(0.ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
        }

        [TestMethod]
        public void CheckTheDivisionOfZeroByZero()
        {
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Zero).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual(Asserts.UndefRes, Calc.GetScreenText());
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

            Assert.AreEqual((-2.5).ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
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

            Assert.AreEqual((-48).ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
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

            Assert.AreEqual(8.ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
        }

        [TestMethod]
        public void VerifyThatOnPressingTwoOperatorsOneAfterTheOtherTheLatestOneWillOverrideThePreviousOperator()
        {
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Div).Click();
            Calc.GetButton(Button.Plus).Click();
            Calc.GetButton(Button.Two).Click();
            Calc.GetButton(Button.Eq).Click();

            Assert.AreEqual(4.ToString(CultureInfo.CurrentCulture), Calc.GetScreenText());
        }
    }
}