#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _04_Player_State_TopDown_UnitTest_EditMode
    {
        [Test]
        public void _01_Check_Initialize()
        {
            _04_Player_State_TopDown_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Variable()
        {
            _04_Player_State_TopDown_UnitTest.Check_Variable();
        }
    }
}
#endif