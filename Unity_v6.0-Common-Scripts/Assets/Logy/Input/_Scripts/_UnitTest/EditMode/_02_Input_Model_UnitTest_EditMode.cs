#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _02_Input_Model_UnitTest_EditMode
    {
        [Test]
        public void _01_Check_Initialize()
        {            
            _02_Input_Model_UnitTest.Check_Initialize();
        }

        [Test]
        public void _03_Check_Variable()
        {
            _02_Input_Model_UnitTest.Check_Variable();
        }
    }
}
#endif