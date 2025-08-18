#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode02DeviceData
    {
        [Test]
        public void _01_CheckInitialize()
        {
            UnitTest02DeviceData.CheckInitialize();
        }

        [Test]
        public void _01_CheckVariable()
        {
            UnitTest02DeviceData.CheckVariable();
        }
    }
}
#endif