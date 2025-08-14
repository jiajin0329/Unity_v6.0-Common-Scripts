#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _01_Controller_InputAction_UnitTest_PlayMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _01_Controller_InputAction_UnitTest.Check_Initialize();
        }

        [Test]
        public void _03_Check_Variable()
        {
            _01_Controller_InputAction_UnitTest.Check_Variable();
        }
        
        [Test]
        public void _04_Remove_All_inputAction_Listener()
        {
            _01_Controller_InputAction_UnitTest.Remove_All_inputAction_Listener();
        }
    }
}
#endif