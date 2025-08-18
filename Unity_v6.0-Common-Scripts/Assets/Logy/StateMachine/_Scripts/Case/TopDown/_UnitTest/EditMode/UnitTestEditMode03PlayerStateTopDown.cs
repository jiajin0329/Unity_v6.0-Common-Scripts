#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode03PlayerStateTopDown
    {
        [Test]
        public void _01_CheckInitialize()
        {
            UnitTest03PlayerStateTopDown.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest03PlayerStateTopDown.CheckVariable();
        }
    }
}
#endif