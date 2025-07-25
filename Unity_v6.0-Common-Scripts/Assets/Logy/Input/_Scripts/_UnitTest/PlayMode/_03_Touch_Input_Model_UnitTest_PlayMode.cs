#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _03_Touch_Input_Model_UnitTest_PlayMode
    {
        [Test]
        public void _01_Check_Initialize()
        {            
            _03_Touch_Input_Model_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Begin()
        {
            _03_Touch_Input_Model_UnitTest.Check_Begin();
        }

        [Test]
        public void _03_Check_Variable()
        {
            _03_Touch_Input_Model_UnitTest.Check_Variable();
        }
    }
}
#endif