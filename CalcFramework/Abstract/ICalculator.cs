using System;

namespace CalcFramework.Abstract
{
    /// <summary>
    /// Represents a calculator test class.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Get button depending on its value.
        /// </summary>
        /// <param name="bType">Buton type.</param>
        /// <returns>Returns Button</returns>
        IButton GetButton(Button bType);

        /// <summary>
        /// Get button count on a calculator.
        /// </summary>
        /// <returns></returns>
        Int32 GetButtonCount();

        /// <summary>
        /// Get text on Calculator result window.
        /// </summary>
        /// <returns>Returns text on the result window.</returns>
        String GetScreenText();
    }
}