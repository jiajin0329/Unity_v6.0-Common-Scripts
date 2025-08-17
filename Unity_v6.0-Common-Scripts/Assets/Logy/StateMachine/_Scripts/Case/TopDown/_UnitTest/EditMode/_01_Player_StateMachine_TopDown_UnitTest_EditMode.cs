#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class _01_Player_StateMachine_TopDown_Presenter_UnitTest_EditMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _01_Player_StateMachine_TopDown_Presenter_UnitTest.Check_Initialize();
        }
    }
}
#endif