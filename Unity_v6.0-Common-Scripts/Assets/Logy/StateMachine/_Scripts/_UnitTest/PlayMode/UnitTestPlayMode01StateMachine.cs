#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestPlayMode01StateMachine
    {
        [Test]
        public void _01_CheckInitialize()
        {
            UnitTest01StateMachine.CheckInitialize();
        }
    }
}
#endif