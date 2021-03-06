﻿using System;
using System.ComponentModel;
using CalcFramework.Abstract;

namespace CalcFramework.Helpers
{
    /// <summary>
    /// Represents Enum helpers.
    /// </summary>
    public static class EnumHelpers
    {
        /// <summary>
        /// Convert Enum entry attribute into text.
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="enumerationValue">entry to be converted.</param>
        /// <returns>Returns vaue of Description attribute if any,
        /// otherwise returns value.ToString.</returns>
        public static String GetDescription<T>(this T enumerationValue) where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum) throw new ArgumentException(Driver.EnumException, nameof(enumerationValue));

            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length <= 0) return enumerationValue.ToString();
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Length > 0 ? ((DescriptionAttribute) attrs[0]).Description : enumerationValue.ToString();
        }

        public static String GetAutomationId(this Button enumerationValue)
        {
            String[] mapper =
            {
                "93", "94", "91", "92", "110", "121", "118", "81", "84", "131", "132", "133", "134",
                "135", "136", "137", "138", "139", "130"
            };
            
            return mapper[(Int32)enumerationValue];
        }
    }
}