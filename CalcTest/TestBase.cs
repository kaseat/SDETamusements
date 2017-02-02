using CalcFramework.Abstract;
using CalcFramework.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public abstract class TestBase
    {
        private static CalculatorFactory _cFact;
        protected static ICalculator Calc;

        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            _cFact = new CalculatorFactory(CalcSource.Chrome);
            Calc= _cFact.GetInstance();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            _cFact.Dispose();
        }
    }
}