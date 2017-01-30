using System;
using CalcFramework.Helpers;
using FrameworkTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkTests.Tests
{
    [TestClass]
    public class EnumHelpersTests
    {
        [TestMethod]
        public void CheckIfEnumHelperReturnsCorrectAttributeValue()
            => Assert.AreEqual(Param.WeightAttr, SampleEnum.Weight.GetDescription());

        [TestMethod]
        public void CheckIfEnumHelperReturnsToStringValueIfThereIsNoAttributeAppliedToAnEnty()
            => Assert.AreEqual(SampleEnum.Temperature.ToString(), SampleEnum.Temperature.GetDescription());

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfEnumHelperThrowsExceptionWhenEnumTypeMismatch()
            => Assert.AreEqual(SampleEnum.Temperature.ToString(), SampleStruct.SampleField.GetDescription());

        [TestMethod]
        public void CheckIfEnumHelperNotRecogniseOtherTypesOfAttributesRatherThanDescriptionAttribute()
            => Assert.AreEqual(SampleEnum.Height.ToString(), SampleEnum.Height.GetDescription());
    }
}