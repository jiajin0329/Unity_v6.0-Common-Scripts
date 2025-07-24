#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _01_Launcher_Input_Generic_TopDown_UnitTest_PlayMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _01_Launcher_Input_Generic_TopDown_UnitTest.Check_Initialize_PlayMode();
        }

        [Test]
        public async Task _02_Check_Begin()
        {
            await _01_Launcher_Input_Generic_TopDown_UnitTest.Check_Begin_PlayMode();
        }
    }
}
#endif