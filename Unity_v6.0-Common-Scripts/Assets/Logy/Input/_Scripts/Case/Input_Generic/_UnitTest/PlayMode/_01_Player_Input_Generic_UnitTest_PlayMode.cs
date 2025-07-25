#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _01_Player_Input_Generic_UnitTest_PlayMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _01_Player_Input_Generic_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Begin()
        {
            _01_Player_Input_Generic_UnitTest.Check_Begin();
        }

        [Test]
        public void _03_Check_Get_Variable_Listener()
        {
            _01_Player_Input_Generic_UnitTest.Check_Get_Variable_Listener();
        }

        [Test]
        public void _04_Remove_All_inputAction_Listener()
        {
            _01_Player_Input_Generic_UnitTest.Remove_All_inputAction_Listener();
        }
    }
}
#endif