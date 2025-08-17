#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class _03_StateMachine_Variable_Viewer_UnitTest_EditMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _03_StateMachine_Variable_Viewer_UnitTest.Check_Initialize();
        }

        [Test]
        public void _02_Check_Variable()
        {
            _03_StateMachine_Variable_Viewer_UnitTest.Check_Variable();
        }
    }
}
#endif