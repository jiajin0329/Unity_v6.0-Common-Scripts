#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _02_Device_Data_UnitTest
    {
        private static Device_Data device_data;

        public static void Check_Initialize()
        {
            device_data = new();

            Process.Check_Initialize(device_data);
        }

        public static void Check_Variable()
        {
            Assert.AreNotEqual(device_data, new Device_Data());
            Assert.AreNotEqual(device_data.dpi, 0f);
        }
    }
}
#endif