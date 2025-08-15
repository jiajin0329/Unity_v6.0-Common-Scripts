#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _03_Controller_InputAction_Generic_UnitTest_EditMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _03_Controller_InputAction_Generic_UnitTest.Check_Initialize();
        }

        [Test]
        public void _03_Check_Variable()
        {
            _03_Controller_InputAction_Generic_UnitTest.Check_Variable();
        }
        
        [Test]
        public void _04_Remove_All_inputAction_Listener()
        {
            _03_Controller_InputAction_Generic_UnitTest.Remove_All_inputAction_Listener();
        }
    }
}
#endif