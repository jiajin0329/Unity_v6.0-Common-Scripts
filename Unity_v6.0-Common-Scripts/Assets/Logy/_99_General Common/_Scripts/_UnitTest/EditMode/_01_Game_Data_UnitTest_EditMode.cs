#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _01_Game_Data_UnitTest_EditMode
    {
        [Test]
        public void _01_Check_Initialize()
        {
            _01_Game_Data_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Variable()
        {
            _01_Game_Data_UnitTest.Check_Variable();
        }
    }
}
#endif