#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct Player_View_TopDown_Presenter_UnitTest
    {
        private static Player_View_TopDown_Presenter _view_presenter;

        public static async UniTask Check_Initialize()
        {
            Build_Object();

            await Process.Check_Initialize_With_UniTask(_view_presenter);
        }

        private static void Build_Object()
        {
            _view_presenter = new();

            Player_View_TopDown_Presenter.Data _data = new()
            {
                input_model = _02_Input_Model_UnitTest.model,
                stateMachine = _02_StateMachine_TopDown_UnitTest.stateMachine,
            };

            _view_presenter.Set_Reference(_data);
        }
    }
}
#endif