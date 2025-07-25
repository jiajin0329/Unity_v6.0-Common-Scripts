#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _02_State_UnitTest_PlayMode
    {
        [Test]
        public void _01_Check_Initialize()
        {
            _02_State_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Variable()
        {
            _02_State_UnitTest.Check_Variable();
        }
    }
}
#endif