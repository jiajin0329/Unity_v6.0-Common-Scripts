#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode03Updater
    {
        [Test]
        public void _01_CheckInitialize()
        {
            UnitTest03Updater.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest03Updater.CheckVariable();
        }
    }
}
#endif