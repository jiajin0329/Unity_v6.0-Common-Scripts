#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestPlayMode02State
    {
        [Test]
        public void _01_CheckInitialize()
        {
            UnitTest02State.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest02State.CheckVariable();
        }
    }
}
#endif