using System;
using System.Linq;
using System.Windows.Automation;
using CalcFramework.Abstract;
using CalcFramework.Helpers;

namespace CalcFramework.Concrete
{
    public class WindowsCalculator : ICalculator
    {
        private readonly AutomationElement calculator;

        public WindowsCalculator(AutomationElement calculator)
        {
            if (calculator == null)
                throw new ArgumentNullException(nameof(calculator));

            this.calculator = calculator;
        }


        public IButton GetButton(Button bType) => new WindowsButton(calculator.FindFirst(TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, bType.GetAutomationId())));


        public Int32 GetButtonCount() => calculator.FindAll(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ClassNameProperty, Win.ButtonClass))
            .Cast<AutomationElement>().Count();

        public String GetScreenText() => calculator.FindFirst(TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, Win.ScreenId)).GetText();
    }
}