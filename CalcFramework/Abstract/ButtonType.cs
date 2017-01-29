using System;
using System.ComponentModel;

namespace CalcFramework.Abstract
{
    /// <summary>
    /// Represents button type.
    /// </summary>
    public enum Button : Byte
    {
        /// <summary>
        /// Addition.
        /// </summary>
        [Description("+")] Plus,

        /// <summary>
        /// Substraction.
        /// </summary>
        [Description("-")] Minus,

        /// <summary>
        /// Division.
        /// </summary>
        [Description("÷")] Div,

        /// <summary>
        /// Multiplication.
        /// </summary>
        [Description("×")] Mul,

        /// <summary>
        /// Rootsquaring.
        /// </summary>
        [Description("√")] Sqr,

        /// <summary>
        /// Equals button.
        /// </summary>
        [Description("=")] Eq,

        /// <summary>
        /// Percent.
        /// </summary>
        [Description("%")] Pers,

        /// <summary>
        /// Clear.
        /// </summary>
        [Description("C")] Clr,

        /// <summary>
        /// Dot.
        /// </summary>
        [Description(".")] Dot,

        /// <summary>
        /// One.
        /// </summary>
        [Description("1")] One,

        /// <summary>
        /// Two.
        /// </summary>
        [Description("2")] Two,

        /// <summary>
        /// Three.
        /// </summary>
        [Description("3")] Three,

        /// <summary>
        /// Four.
        /// </summary>
        [Description("4")] Four,

        /// <summary>
        /// Five.
        /// </summary>
        [Description("5")] Five,

        /// <summary>
        /// Six.
        /// </summary>
        [Description("6")] Six,

        /// <summary>
        /// Seven.
        /// </summary>
        [Description("7")] Seven,

        /// <summary>
        /// Eight.
        /// </summary>
        [Description("8")] Eight,

        /// <summary>
        /// Nine.
        /// </summary>
        [Description("9")] Nine,

        /// <summary>
        /// Zero.
        /// </summary>
        [Description("0")] Zero
    }
}