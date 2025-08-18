#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestPlayMode02StateMachineTopDown
    {
        [Test]
        public void _01_CheckInitialize()
        {
            UnitTest02StateMachineTopDown.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest02StateMachineTopDown.CheckVariable();
        }
    }
}
#endif