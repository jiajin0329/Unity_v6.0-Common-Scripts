#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _02_Input_Generic_Model_UnitTest_PlayMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _02_Input_Generic_Model_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Begin()
        {
            _02_Input_Generic_Model_UnitTest.Check_Begin();
        }

        [Test]
        public void _03_Remove_All_inputAction_Listener()
        {
            _02_Input_Generic_Model_UnitTest.Remove_All_inputAction_Listener();
        }
    }
}
#endif