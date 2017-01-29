using CalcFramework.Abstract;
using CalcFramework.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public abstract class TestBase
    {
        protected static readonly ICalculator Calc = new CalculatorFactory(CalcSource.Chrome).GetInstance();
    }
}