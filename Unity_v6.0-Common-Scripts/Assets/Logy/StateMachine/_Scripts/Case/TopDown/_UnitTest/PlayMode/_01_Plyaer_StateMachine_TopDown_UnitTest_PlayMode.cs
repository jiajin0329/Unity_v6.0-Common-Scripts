#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _01_Plyaer_StateMachine_TopDown_UnitTest_PlayMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _01_Plyaer_StateMachine_TopDown_UnitTest.Check_Initialize();
        }
    }
}
#endif