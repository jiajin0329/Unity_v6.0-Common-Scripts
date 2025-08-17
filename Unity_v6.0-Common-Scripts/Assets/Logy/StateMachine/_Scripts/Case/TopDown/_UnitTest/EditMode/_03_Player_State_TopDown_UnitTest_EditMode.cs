#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class _03_Player_State_TopDown_UnitTest_EditMode
    {
        [Test]
        public void _01_Check_Initialize()
        {
            _03_Player_State_TopDown_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Variable()
        {
            _03_Player_State_TopDown_UnitTest.Check_Variable();
        }
    }
}
#endif