#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _05_Input_Generic_Variable_Viewer_UnitTest_PlayMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _05_Input_Generic_Variable_Viewer_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Variable()
        {
            _05_Input_Generic_Variable_Viewer_UnitTest.Check_Variable();
        }
        
    }
}
#endif