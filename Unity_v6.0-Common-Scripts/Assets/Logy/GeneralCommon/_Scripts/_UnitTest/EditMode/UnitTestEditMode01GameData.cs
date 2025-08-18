#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode01GameData
    {
        [Test]
        public void _01_CheckInitialize()
        {
            UnitTest01GameData.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest01GameData.CheckVariable();
        }
    }
}
#endif