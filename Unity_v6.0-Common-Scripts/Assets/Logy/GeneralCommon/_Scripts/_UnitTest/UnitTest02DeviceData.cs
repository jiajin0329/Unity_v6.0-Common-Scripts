#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct UnitTest02DeviceData
    {
        private static DeviceData deviceData;

        public static void CheckInitialize()
        {
            deviceData = new();

            deviceData = deviceData.InitializeWithReturn();
        }

        public static void CheckVariable()
        {
            Assert.AreNotEqual(deviceData, new DeviceData());
            Assert.AreNotEqual(deviceData.dpi, 0f);
        }
    }
}
#endif