using System;
using System.Windows.Automation;

namespace CalcFramework.Helpers
{
    public static class WinHelpers
    {
        public static String GetText(this AutomationElement element)
        {
            Object patternObj;
            if (element.TryGetCurrentPattern(ValuePattern.Pattern, out patternObj))
                return ((ValuePattern) patternObj).Current.Value.TrimEnd(' ');

            return element.TryGetCurrentPattern(TextPattern.Pattern, out patternObj)
                ? ((TextPattern)patternObj).DocumentRange.GetText(-1).TrimEnd('\r')
                : element.Current.Name;
        }

        public static void Execute(this AutomationElement element)=>
            ((InvokePattern)element.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
    }
}