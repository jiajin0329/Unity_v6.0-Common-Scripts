#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _04_VirtualJoystick_View_UnitTest_EditMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _04_VirtualJoystick_View_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Variable()
        {
            _04_VirtualJoystick_View_UnitTest.Check_Variable();
        }
    }
}
#endif