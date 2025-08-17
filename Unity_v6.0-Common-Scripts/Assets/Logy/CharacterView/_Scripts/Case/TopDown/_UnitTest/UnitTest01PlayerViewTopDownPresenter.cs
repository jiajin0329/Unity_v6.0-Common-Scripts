#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public struct UnitTest01PlayerViewTopDownPresenter
    {
        private static PlayerViewTopDownPresenter _viewPresenter;

        public static async UniTask CheckInitialize()
        {
            BuildObject();

            await Process.CheckInitializeWithUniTask(_viewPresenter);
        }

        private static void BuildObject()
        {
            _viewPresenter = new();

            PlayerViewTopDownPresenter.Data _data = new()
            {
                moveModel = _02_Move_Model_UnitTest.model,
                stateMachine = _02_StateMachine_TopDown_UnitTest.stateMachine,
            };

            _viewPresenter.SetReference(_data);
        }
    }
}
#endif