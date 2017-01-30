using System.ComponentModel;

namespace FrameworkTests.Helpers
{
    public enum SampleEnum
    {
        [Description(Param.WeightAttr)] Weight,
        [ToolboxItem(Param.LengthAttr)] Height,
        Temperature
    }
}