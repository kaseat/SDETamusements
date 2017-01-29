using System;

namespace CalcFramework.Abstract
{
    /// <summary>
    /// Represents calculator button.
    /// </summary>
    public interface IButton
    {
        /// <summary>
        /// Button text.
        /// </summary>
        String Text { get; }

        /// <summary>
        /// Is the button selected.
        /// </summary>
        Boolean IsSelected { get; }

        /// <summary>
        /// Click the button.
        /// </summary>
        void Click();
    }
}