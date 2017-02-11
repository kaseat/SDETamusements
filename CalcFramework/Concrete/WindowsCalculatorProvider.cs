using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using CalcFramework.Helpers;

namespace CalcFramework.Concrete
{
    public static class WindowsCalculatorProvider
    {
        public static AutomationElement GetInstance()
        {
            for (var i = 0; i < Const.MaxAttempts; i++)
            {
                Thread.Sleep(Const.SleepTimeout);
                AutomationElement result;
                if ((result = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                        new PropertyCondition(AutomationElement.NameProperty, Win.ComCalcElem))) != null)
                    return result;
            }
            throw new InvalidComObjectException(Win.ComTimeout);
        }
    }
}
