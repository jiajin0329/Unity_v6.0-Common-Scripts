#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    public struct _01_Player_StateMachine_TopDown_Presenter_UnitTest
    {
        private static Player_StateMachine_TopDown_Presenter _stateMachine;

        public static async UniTask Check_Initialize()
        {
            _stateMachine = new();
            _stateMachine.Set_Reference(_02_Move_Model_UnitTest.model);
            
            await Process.Check_Initialize_With_UniTask(_stateMachine);
        }
    }
}
#endif