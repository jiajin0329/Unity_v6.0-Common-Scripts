#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _01_Launcher_Input_Generic_TopDown_UnitTest_EditMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _01_Launcher_Input_Generic_TopDown_UnitTest.Check_Initialize_EditMode();
        }

        [Test]
        public void _02_Check_Begin()
        {
            _01_Launcher_Input_Generic_TopDown_UnitTest.Check_Begin_EditMode();
        }

        [Test]
        public void _03_Cancel()
        {
            _01_Launcher_Input_Generic_TopDown_UnitTest.Cancel();
        }
    }
}
#endif