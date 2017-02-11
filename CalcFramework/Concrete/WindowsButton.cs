using System;
using System.Windows.Automation;
using CalcFramework.Abstract;
using CalcFramework.Helpers;

namespace CalcFramework.Concrete
{
    public class WindowsButton : IButton
    {
        private readonly AutomationElement button;

        public WindowsButton(AutomationElement button)
        {
            if (button == null)
                throw new ArgumentNullException(nameof(button));

            this.button = button;
        }

        public String Text => button.Current.Name;
        public void Click() => button.Execute();
    }
}