using System;
using CalcFramework.Concrete;

namespace CalcFramework.Abstract
{
    public interface ICalculatorFactory : IDisposable
    {
        ICalculator GetCalculator(CalcSource src);
    }
}